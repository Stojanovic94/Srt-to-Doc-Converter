using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Srt_to_Doc_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Omogućavanje Drag & Drop funkcionalnosti za RichTextBox
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(RichTextBox_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(RichTextBox_DragDrop);
        }

        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Path.GetExtension(files[0]).ToLower() == ".srt") // Proverava da li je fajl SRT
                {
                    e.Effect = DragDropEffects.Copy; // Omogućava prevlačenje
                }
                else
                {
                    e.Effect = DragDropEffects.None; // Blokira nedozvoljene fajlove
                }
            }
        }

        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string srtFilePath = files[0]; // Uzima putanju prvog prevučenog fajla

            // Učitava sadržaj SRT fajla i prikazuje ga u RichTextBox-u
            richTextBox1.Text = File.ReadAllText(srtFilePath);
        }

        // Otvori open dijalog i trazi txt fajlove
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "srt";
            openFileDialog1.Filter = "Subtitle text (*.srt)|*.srt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        // Kreiranje Save File dijaloga
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Word (*.doc)|*.doc|All files (*.*)|*.*";
            saveDlg.DefaultExt = "doc";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType stream_type = (saveDlg.FilterIndex == 2)
                    ? RichTextBoxStreamType.PlainText
                    : RichTextBoxStreamType.RichText;

                richTextBox1.SaveFile(saveDlg.FileName, stream_type);
            }
        }

        private string RemoveNumberedLines(string srtContent)
        {
            StringBuilder result = new StringBuilder();
            using (StringReader reader = new StringReader(srtContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!int.TryParse(line, out _)) // Proverava da li je linija broj
                    {
                        result.AppendLine(line);
                    }
                }
            }
            return result.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        // Convert
        private void button1_Click_1(object sender, EventArgs e)
        {
            string srtContent = richTextBox1.Text;
            string updatedText = RemoveNumberedLines(srtContent);
            updatedText = RemoveTimelines(updatedText);
            updatedText = CompactText(updatedText);
            richTextBox1.Text = updatedText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Može ostati prazno
        }

        private string RemoveTimelines(string srtContent)
        {
            StringBuilder result = new StringBuilder();
            using (StringReader reader = new StringReader(srtContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains("-->")) // Proverava da li linija sadrži vremensku oznaku
                    {
                        result.AppendLine(line);
                    }
                }
            }
            return result.ToString();
        }

        private string CompactText(string input)
        {
            StringBuilder result = new StringBuilder();
            bool previousCharWasWhitespace = false;

            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!previousCharWasWhitespace)
                    {
                        result.Append(' '); // Dodaje samo jedan razmak
                        previousCharWasWhitespace = true;
                    }
                }
                else
                {
                    result.Append(c);
                    previousCharWasWhitespace = false;
                }
            }

            return result.ToString().Trim();
        }
    }
}