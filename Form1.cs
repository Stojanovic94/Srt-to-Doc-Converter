using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Srt_to_Doc_Converter
{
    public partial class Form1 : Form
    {
        private string _currentSourcePath;
        private bool _busy;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStatus("Ready");
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }
        }

        private SrtConversionOptions CurrentOptions()
        {
            return new SrtConversionOptions
            {
                SeparateCues = chkSeparateCues.Checked,
                StripFormattingTags = true
            };
        }

        private void SetStatus(string message)
        {
            statusLabel.Text = message;
        }

        private static bool IsSrtFile(string path)
        {
            return string.Equals(Path.GetExtension(path), ".srt", StringComparison.OrdinalIgnoreCase);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            LoadSingleFile(openFileDialog.FileName);
        }

        private void LoadSingleFile(string path)
        {
            try
            {
                previewBox.Text = SubtitleFileReader.ReadAllText(path);
                _currentSourcePath = path;
                SetStatus($"Loaded {Path.GetFileName(path)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not open the file.\n\n{ex.Message}", "Open failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(previewBox.Text))
            {
                MessageBox.Show(this, "Open an SRT file or paste subtitle text first.", "Nothing to convert",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            previewBox.Text = SrtConverter.ToPlainText(previewBox.Text, CurrentOptions());
            SetStatus("Converted subtitle text");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(previewBox.Text))
            {
                MessageBox.Show(this, "Convert subtitle text before saving.", "Nothing to save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(_currentSourcePath))
            {
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(_currentSourcePath) + ".docx";
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(_currentSourcePath);
            }

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            try
            {
                DocxWriter.Write(saveFileDialog.FileName, previewBox.Text);
                SetStatus($"Saved {Path.GetFileName(saveFileDialog.FileName)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not save the document.\n\n{ex.Message}", "Save failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            previewBox.Clear();
            _currentSourcePath = null;
            SetStatus("Ready");
        }

        private void PreviewBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = HasSrtDrop(e) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void PreviewBox_DragDrop(object sender, DragEventArgs e)
        {
            var files = GetDroppedSrtFiles(e);
            if (files.Count == 0)
            {
                return;
            }

            LoadSingleFile(files[0]);
            if (files.Count > 1)
            {
                AddFiles(files);
                tabs.SelectedTab = tabBulk;
                SetStatus($"Loaded {Path.GetFileName(files[0])}. Additional files were added to bulk conversion.");
            }
        }

        private void BtnAddFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            AddFiles(openFileDialog.FileNames);
        }

        private void BtnAddFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.srt", SearchOption.AllDirectories);
            if (files.Length == 0)
            {
                MessageBox.Show(this, "No .srt files were found in that folder.", "No files",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddFiles(files);
            if (string.IsNullOrWhiteSpace(txtOutputFolder.Text))
            {
                txtOutputFolder.Text = Path.Combine(folderBrowserDialog.SelectedPath, "Converted");
            }
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listFiles.SelectedItems.Cast<ListViewItem>().ToList())
            {
                item.Remove();
            }

            SetStatus($"{listFiles.Items.Count} file(s) in queue");
        }

        private void BtnClearQueue_Click(object sender, EventArgs e)
        {
            listFiles.Items.Clear();
            progressBar.Value = 0;
            SetStatus("Queue cleared");
        }

        private void BtnBrowseOutput_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Choose where converted Word files should be saved",
                UseDescriptionForTitle = true
            };

            if (!string.IsNullOrWhiteSpace(txtOutputFolder.Text) && Directory.Exists(txtOutputFolder.Text))
            {
                dialog.SelectedPath = txtOutputFolder.Text;
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = dialog.SelectedPath;
            }
        }

        private void TabBulk_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = HasSrtDrop(e) || HasFolderDrop(e) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void TabBulk_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] dropped) || dropped.Length == 0)
            {
                return;
            }

            var files = new List<string>();
            foreach (var path in dropped)
            {
                if (Directory.Exists(path))
                {
                    files.AddRange(Directory.GetFiles(path, "*.srt", SearchOption.AllDirectories));
                }
                else if (IsSrtFile(path))
                {
                    files.Add(path);
                }
            }

            AddFiles(files);
        }

        private void AddFiles(IEnumerable<string> paths)
        {
            var existing = new HashSet<string>(
                listFiles.Items.Cast<ListViewItem>().Select(item => (string)item.Tag),
                StringComparer.OrdinalIgnoreCase);

            var added = 0;
            foreach (var path in paths.Where(IsSrtFile).Distinct(StringComparer.OrdinalIgnoreCase))
            {
                if (!existing.Add(path))
                {
                    continue;
                }

                var item = new ListViewItem(path)
                {
                    Tag = path,
                    SubItems = { "Queued" }
                };
                listFiles.Items.Add(item);
                added++;
            }

            if (added > 0 && string.IsNullOrWhiteSpace(txtOutputFolder.Text))
            {
                var first = (string)listFiles.Items[0].Tag;
                txtOutputFolder.Text = Path.Combine(Path.GetDirectoryName(first) ?? string.Empty, "Converted");
            }

            SetStatus($"{listFiles.Items.Count} file(s) in queue");
        }

        private async void BtnConvertAll_Click(object sender, EventArgs e)
        {
            if (_busy)
            {
                return;
            }

            if (listFiles.Items.Count == 0)
            {
                MessageBox.Show(this, "Add one or more SRT files first.", "Queue is empty",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var outputFolder = txtOutputFolder.Text.Trim();
            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show(this, "Choose an output folder.", "Output folder required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Directory.CreateDirectory(outputFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Could not create the output folder.\n\n{ex.Message}", "Output folder",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _busy = true;
            SetBusy(true);

            var options = CurrentOptions();
            var succeeded = 0;
            var failed = 0;
            progressBar.Maximum = listFiles.Items.Count;
            progressBar.Value = 0;

            try
            {
                for (var i = 0; i < listFiles.Items.Count; i++)
                {
                    var item = listFiles.Items[i];
                    var sourcePath = (string)item.Tag;
                    item.SubItems[1].Text = "Converting…";
                    item.ForeColor = Color.FromArgb(37, 99, 235);
                    SetStatus($"Converting {i + 1} of {listFiles.Items.Count}: {Path.GetFileName(sourcePath)}");

                    try
                    {
                        await Task.Run(() => ConvertFile(sourcePath, outputFolder, options));
                        item.SubItems[1].Text = "Done";
                        item.ForeColor = Color.FromArgb(22, 163, 74);
                        succeeded++;
                    }
                    catch (Exception ex)
                    {
                        item.SubItems[1].Text = "Failed";
                        item.ToolTipText = ex.Message;
                        item.ForeColor = Color.FromArgb(185, 28, 28);
                        failed++;
                    }

                    progressBar.Value = i + 1;
                }

                SetStatus($"Finished: {succeeded} converted, {failed} failed");

                if (chkOpenFolder.Checked && succeeded > 0)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = outputFolder,
                        UseShellExecute = true
                    });
                }

                if (failed > 0)
                {
                    MessageBox.Show(this,
                        $"{succeeded} file(s) converted.\n{failed} file(s) failed. Hover a failed row for details.",
                        "Bulk conversion complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            finally
            {
                _busy = false;
                SetBusy(false);
            }
        }

        private static void ConvertFile(string sourcePath, string outputFolder, SrtConversionOptions options)
        {
            var content = SubtitleFileReader.ReadAllText(sourcePath);
            var converted = SrtConverter.ToPlainText(content, options);
            var outputPath = DocxWriter.UniquePath(DocxWriter.GetOutputPath(sourcePath, outputFolder));
            DocxWriter.Write(outputPath, converted);
        }

        private void SetBusy(bool busy)
        {
            btnOpen.Enabled = !busy;
            btnConvert.Enabled = !busy;
            btnSave.Enabled = !busy;
            btnClear.Enabled = !busy;
            btnAddFiles.Enabled = !busy;
            btnAddFolder.Enabled = !busy;
            btnRemoveSelected.Enabled = !busy;
            btnClearQueue.Enabled = !busy;
            btnBrowseOutput.Enabled = !busy;
            btnConvertAll.Enabled = !busy;
            txtOutputFolder.Enabled = !busy;
            chkSeparateCues.Enabled = !busy;
            UseWaitCursor = busy;
        }

        private static bool HasSrtDrop(DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return false;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            return files != null && files.Any(path => IsSrtFile(path) || Directory.Exists(path));
        }

        private static bool HasFolderDrop(DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return false;
            }

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            return files != null && files.Any(Directory.Exists);
        }

        private static List<string> GetDroppedSrtFiles(DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] files))
            {
                return new List<string>();
            }

            return files.Where(IsSrtFile).ToList();
        }
    }
}
