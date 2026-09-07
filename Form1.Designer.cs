namespace Srt_to_Doc_Converter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelHeader = new System.Windows.Forms.Panel();
            btnAbout = new System.Windows.Forms.Button();
            lblSubtitle = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            panelOptions = new System.Windows.Forms.Panel();
            chkOpenFolder = new System.Windows.Forms.CheckBox();
            chkSeparateCues = new System.Windows.Forms.CheckBox();
            tabs = new System.Windows.Forms.TabControl();
            tabSingle = new System.Windows.Forms.TabPage();
            previewBox = new System.Windows.Forms.RichTextBox();
            panelSingleButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnOpen = new System.Windows.Forms.Button();
            btnConvert = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            lblSingleHint = new System.Windows.Forms.Label();
            tabBulk = new System.Windows.Forms.TabPage();
            listFiles = new System.Windows.Forms.ListView();
            columnFile = new System.Windows.Forms.ColumnHeader();
            columnStatus = new System.Windows.Forms.ColumnHeader();
            panelOutput = new System.Windows.Forms.Panel();
            btnBrowseOutput = new System.Windows.Forms.Button();
            txtOutputFolder = new System.Windows.Forms.TextBox();
            lblOutput = new System.Windows.Forms.Label();
            panelBulkButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnAddFiles = new System.Windows.Forms.Button();
            btnAddFolder = new System.Windows.Forms.Button();
            btnRemoveSelected = new System.Windows.Forms.Button();
            btnClearQueue = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            btnConvertAll = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            panelHeader.SuspendLayout();
            panelOptions.SuspendLayout();
            tabs.SuspendLayout();
            tabSingle.SuspendLayout();
            panelSingleButtons.SuspendLayout();
            tabBulk.SuspendLayout();
            panelOutput.SuspendLayout();
            panelBulkButtons.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(27, 54, 93);
            panelHeader.Controls.Add(btnAbout);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new System.Windows.Forms.Padding(23, 19, 23, 19);
            panelHeader.Size = new System.Drawing.Size(983, 104);
            panelHeader.TabIndex = 0;
            // 
            // btnAbout
            // 
            btnAbout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAbout.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAbout.FlatAppearance.BorderSize = 0;
            btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAbout.ForeColor = System.Drawing.Color.White;
            btnAbout.Location = new System.Drawing.Point(869, 29);
            btnAbout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new System.Drawing.Size(91, 43);
            btnAbout.TabIndex = 2;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = false;
            btnAbout.Click += BtnAbout_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            lblSubtitle.Location = new System.Drawing.Point(25, 61);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(396, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Convert subtitle files into clean, readable Word documents";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(23, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(288, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SRT to DOC Converter";
            // 
            // panelOptions
            // 
            panelOptions.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            panelOptions.Controls.Add(chkOpenFolder);
            panelOptions.Controls.Add(chkSeparateCues);
            panelOptions.Dock = System.Windows.Forms.DockStyle.Top;
            panelOptions.Location = new System.Drawing.Point(0, 104);
            panelOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelOptions.Name = "panelOptions";
            panelOptions.Padding = new System.Windows.Forms.Padding(18, 11, 18, 11);
            panelOptions.Size = new System.Drawing.Size(983, 53);
            panelOptions.TabIndex = 1;
            // 
            // chkOpenFolder
            // 
            chkOpenFolder.AutoSize = true;
            chkOpenFolder.Checked = true;
            chkOpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            chkOpenFolder.Location = new System.Drawing.Point(343, 13);
            chkOpenFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkOpenFolder.Name = "chkOpenFolder";
            chkOpenFolder.Size = new System.Drawing.Size(279, 24);
            chkOpenFolder.TabIndex = 1;
            chkOpenFolder.Text = "Open output folder after bulk convert";
            chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // chkSeparateCues
            // 
            chkSeparateCues.AutoSize = true;
            chkSeparateCues.Location = new System.Drawing.Point(23, 13);
            chkSeparateCues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkSeparateCues.Name = "chkSeparateCues";
            chkSeparateCues.Size = new System.Drawing.Size(320, 24);
            chkSeparateCues.TabIndex = 0;
            chkSeparateCues.Text = "Separate each subtitle as its own paragraph";
            chkSeparateCues.UseVisualStyleBackColor = true;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabSingle);
            tabs.Controls.Add(tabBulk);
            tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            tabs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            tabs.Location = new System.Drawing.Point(0, 157);
            tabs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabs.Name = "tabs";
            tabs.Padding = new System.Drawing.Point(12, 6);
            tabs.SelectedIndex = 0;
            tabs.Size = new System.Drawing.Size(983, 526);
            tabs.TabIndex = 2;
            // 
            // tabSingle
            // 
            tabSingle.BackColor = System.Drawing.Color.White;
            tabSingle.Controls.Add(previewBox);
            tabSingle.Controls.Add(panelSingleButtons);
            tabSingle.Controls.Add(lblSingleHint);
            tabSingle.Location = new System.Drawing.Point(4, 36);
            tabSingle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabSingle.Name = "tabSingle";
            tabSingle.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            tabSingle.Size = new System.Drawing.Size(975, 486);
            tabSingle.TabIndex = 0;
            tabSingle.Text = "Single file";
            // 
            // previewBox
            // 
            previewBox.AcceptsTab = true;
            previewBox.AllowDrop = true;
            previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            previewBox.DetectUrls = false;
            previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            previewBox.Font = new System.Drawing.Font("Consolas", 10F);
            previewBox.Location = new System.Drawing.Point(14, 45);
            previewBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            previewBox.Name = "previewBox";
            previewBox.Size = new System.Drawing.Size(947, 359);
            previewBox.TabIndex = 1;
            previewBox.Text = "";
            previewBox.DragDrop += PreviewBox_DragDrop;
            previewBox.DragEnter += PreviewBox_DragEnter;
            // 
            // panelSingleButtons
            // 
            panelSingleButtons.AutoSize = true;
            panelSingleButtons.Controls.Add(btnOpen);
            panelSingleButtons.Controls.Add(btnConvert);
            panelSingleButtons.Controls.Add(btnSave);
            panelSingleButtons.Controls.Add(btnClear);
            panelSingleButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelSingleButtons.Location = new System.Drawing.Point(14, 404);
            panelSingleButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelSingleButtons.Name = "panelSingleButtons";
            panelSingleButtons.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            panelSingleButtons.Size = new System.Drawing.Size(947, 66);
            panelSingleButtons.TabIndex = 2;
            // 
            // btnOpen
            // 
            btnOpen.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnOpen.FlatAppearance.BorderSize = 0;
            btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOpen.ForeColor = System.Drawing.Color.White;
            btnOpen.Location = new System.Drawing.Point(3, 17);
            btnOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new System.Drawing.Size(137, 45);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open SRT...";
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += BtnOpen_Click;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConvert.ForeColor = System.Drawing.Color.White;
            btnConvert.Location = new System.Drawing.Point(146, 17);
            btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(137, 45);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += BtnConvert_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(30, 64, 175);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(289, 17);
            btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(160, 45);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save as Word...";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnClear.Location = new System.Drawing.Point(455, 17);
            btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(114, 45);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // lblSingleHint
            // 
            lblSingleHint.Dock = System.Windows.Forms.DockStyle.Top;
            lblSingleHint.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblSingleHint.Location = new System.Drawing.Point(14, 16);
            lblSingleHint.Name = "lblSingleHint";
            lblSingleHint.Size = new System.Drawing.Size(947, 29);
            lblSingleHint.TabIndex = 0;
            lblSingleHint.Text = "Open or drop an .srt file, convert it, then save as a Word document.";
            // 
            // tabBulk
            // 
            tabBulk.AllowDrop = true;
            tabBulk.BackColor = System.Drawing.Color.White;
            tabBulk.Controls.Add(listFiles);
            tabBulk.Controls.Add(panelOutput);
            tabBulk.Controls.Add(panelBulkButtons);
            tabBulk.Controls.Add(progressBar);
            tabBulk.Controls.Add(btnConvertAll);
            tabBulk.Location = new System.Drawing.Point(4, 36);
            tabBulk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tabBulk.Name = "tabBulk";
            tabBulk.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
            tabBulk.Size = new System.Drawing.Size(975, 486);
            tabBulk.TabIndex = 1;
            tabBulk.Text = "Bulk conversion";
            tabBulk.DragDrop += TabBulk_DragDrop;
            tabBulk.DragEnter += TabBulk_DragEnter;
            // 
            // listFiles
            // 
            listFiles.AllowDrop = true;
            listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnFile, columnStatus });
            listFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            listFiles.FullRowSelect = true;
            listFiles.GridLines = true;
            listFiles.Location = new System.Drawing.Point(14, 69);
            listFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            listFiles.Name = "listFiles";
            listFiles.ShowItemToolTips = true;
            listFiles.Size = new System.Drawing.Size(947, 281);
            listFiles.TabIndex = 1;
            listFiles.UseCompatibleStateImageBehavior = false;
            listFiles.View = System.Windows.Forms.View.Details;
            listFiles.DragDrop += TabBulk_DragDrop;
            listFiles.DragEnter += TabBulk_DragEnter;
            // 
            // columnFile
            // 
            columnFile.Text = "File";
            columnFile.Width = 620;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.Width = 180;
            // 
            // panelOutput
            // 
            panelOutput.Controls.Add(btnBrowseOutput);
            panelOutput.Controls.Add(txtOutputFolder);
            panelOutput.Controls.Add(lblOutput);
            panelOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelOutput.Location = new System.Drawing.Point(14, 350);
            panelOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new System.Drawing.Size(947, 48);
            panelOutput.TabIndex = 2;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnBrowseOutput.Location = new System.Drawing.Point(824, 5);
            btnBrowseOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new System.Drawing.Size(114, 37);
            btnBrowseOutput.TabIndex = 2;
            btnBrowseOutput.Text = "Browse...";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += BtnBrowseOutput_Click;
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtOutputFolder.Location = new System.Drawing.Point(119, 8);
            txtOutputFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new System.Drawing.Size(698, 29);
            txtOutputFolder.TabIndex = 1;
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new System.Drawing.Point(0, 12);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new System.Drawing.Size(107, 21);
            lblOutput.TabIndex = 0;
            lblOutput.Text = "Output folder:";
            // 
            // panelBulkButtons
            // 
            panelBulkButtons.AutoSize = true;
            panelBulkButtons.Controls.Add(btnAddFiles);
            panelBulkButtons.Controls.Add(btnAddFolder);
            panelBulkButtons.Controls.Add(btnRemoveSelected);
            panelBulkButtons.Controls.Add(btnClearQueue);
            panelBulkButtons.Dock = System.Windows.Forms.DockStyle.Top;
            panelBulkButtons.Location = new System.Drawing.Point(14, 16);
            panelBulkButtons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelBulkButtons.Name = "panelBulkButtons";
            panelBulkButtons.Size = new System.Drawing.Size(947, 53);
            panelBulkButtons.TabIndex = 0;
            // 
            // btnAddFiles
            // 
            btnAddFiles.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAddFiles.FlatAppearance.BorderSize = 0;
            btnAddFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddFiles.ForeColor = System.Drawing.Color.White;
            btnAddFiles.Location = new System.Drawing.Point(3, 4);
            btnAddFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddFiles.Name = "btnAddFiles";
            btnAddFiles.Size = new System.Drawing.Size(137, 45);
            btnAddFiles.TabIndex = 0;
            btnAddFiles.Text = "Add files...";
            btnAddFiles.UseVisualStyleBackColor = false;
            btnAddFiles.Click += BtnAddFiles_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnAddFolder.FlatAppearance.BorderSize = 0;
            btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddFolder.ForeColor = System.Drawing.Color.White;
            btnAddFolder.Location = new System.Drawing.Point(146, 4);
            btnAddFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new System.Drawing.Size(137, 45);
            btnAddFolder.TabIndex = 1;
            btnAddFolder.Text = "Add folder...";
            btnAddFolder.UseVisualStyleBackColor = false;
            btnAddFolder.Click += BtnAddFolder_Click;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnRemoveSelected.Location = new System.Drawing.Point(289, 4);
            btnRemoveSelected.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new System.Drawing.Size(149, 45);
            btnRemoveSelected.TabIndex = 2;
            btnRemoveSelected.Text = "Remove selected";
            btnRemoveSelected.Click += BtnRemoveSelected_Click;
            // 
            // btnClearQueue
            // 
            btnClearQueue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnClearQueue.Location = new System.Drawing.Point(444, 4);
            btnClearQueue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClearQueue.Name = "btnClearQueue";
            btnClearQueue.Size = new System.Drawing.Size(114, 45);
            btnClearQueue.TabIndex = 3;
            btnClearQueue.Text = "Clear list";
            btnClearQueue.Click += BtnClearQueue_Click;
            // 
            // progressBar
            // 
            progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            progressBar.Location = new System.Drawing.Point(14, 398);
            progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(947, 21);
            progressBar.TabIndex = 3;
            // 
            // btnConvertAll
            // 
            btnConvertAll.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            btnConvertAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnConvertAll.FlatAppearance.BorderSize = 0;
            btnConvertAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConvertAll.ForeColor = System.Drawing.Color.White;
            btnConvertAll.Location = new System.Drawing.Point(14, 419);
            btnConvertAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnConvertAll.Name = "btnConvertAll";
            btnConvertAll.Size = new System.Drawing.Size(947, 51);
            btnConvertAll.TabIndex = 4;
            btnConvertAll.Text = "Convert all to Word";
            btnConvertAll.UseVisualStyleBackColor = false;
            btnConvertAll.Click += BtnConvertAll_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 683);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(983, 26);
            statusStrip.TabIndex = 3;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(50, 20);
            statusLabel.Text = "Ready";
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Subtitle files (*.srt)|*.srt|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select subtitle files";
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.Filter = "Word document (*.docx)|*.docx";
            saveFileDialog.Title = "Save Word document";
            // 
            // folderBrowserDialog
            // 
            folderBrowserDialog.Description = "Select a folder that contains SRT files";
            folderBrowserDialog.UseDescriptionForTitle = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(983, 709);
            Controls.Add(tabs);
            Controls.Add(panelOptions);
            Controls.Add(panelHeader);
            Controls.Add(statusStrip);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(890, 680);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SRT to DOC Converter";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelOptions.ResumeLayout(false);
            panelOptions.PerformLayout();
            tabs.ResumeLayout(false);
            tabSingle.ResumeLayout(false);
            tabSingle.PerformLayout();
            panelSingleButtons.ResumeLayout(false);
            tabBulk.ResumeLayout(false);
            tabBulk.PerformLayout();
            panelOutput.ResumeLayout(false);
            panelOutput.PerformLayout();
            panelBulkButtons.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.CheckBox chkSeparateCues;
        private System.Windows.Forms.CheckBox chkOpenFolder;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabSingle;
        private System.Windows.Forms.TabPage tabBulk;
        private System.Windows.Forms.Label lblSingleHint;
        private System.Windows.Forms.RichTextBox previewBox;
        private System.Windows.Forms.FlowLayoutPanel panelSingleButtons;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.FlowLayoutPanel panelBulkButtons;
        private System.Windows.Forms.Button btnAddFiles;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnConvertAll;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnAbout;
    }
}
