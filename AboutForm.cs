using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Srt_to_Doc_Converter
{
    public sealed class AboutForm : Form
    {
        private const string GitHubUrl = "https://github.com/Stojanovic94/Srt-to-Doc-Converter";

        public AboutForm()
        {
            Text = "About";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(460, 360);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);
            AutoScaleMode = AutoScaleMode.Font;

            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 78,
                BackColor = Color.FromArgb(27, 54, 93)
            };
            header.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 12),
                Text = "SRT to DOC Converter"
            });
            header.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(203, 213, 225),
                Location = new Point(22, 46),
                Text = "Version 1.0.0  |  MIT License"
            });

            var description = new Label
            {
                Location = new Point(22, 96),
                Size = new Size(416, 88),
                Text = "This app turns movie, series, and YouTube subtitle files (.srt) into clean, readable Word documents (.docx).\nIndexes, timestamps, and formatting tags are removed automatically.\n\nOpen a single file, or convert a whole folder at once.\n"
            };

            var developer = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Location = new Point(22, 196),
                Text = "Developer"
            };

            var developerName = new Label
            {
                AutoSize = true,
                Location = new Point(22, 216),
                Text = "Nikola Stojanović  (Stojanovic94)"
            };

            var githubCaption = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                Location = new Point(22, 248),
                Text = "GitHub"
            };

            var githubLink = new LinkLabel
            {
                AutoSize = true,
                Location = new Point(22, 268),
                Text = GitHubUrl,
                LinkColor = Color.FromArgb(37, 99, 235)
            };
            githubLink.LinkClicked += (_, _) =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = GitHubUrl,
                    UseShellExecute = true
                });
            };

            var btnClose = new Button
            {
                Text = "Close",
                DialogResult = DialogResult.OK,
                Size = new Size(100, 32),
                Location = new Point(338, 312),
                FlatStyle = FlatStyle.System
            };
            AcceptButton = btnClose;
            CancelButton = btnClose;

            Controls.Add(btnClose);
            Controls.Add(githubLink);
            Controls.Add(githubCaption);
            Controls.Add(developerName);
            Controls.Add(developer);
            Controls.Add(description);
            Controls.Add(header);
        }
    }
}
