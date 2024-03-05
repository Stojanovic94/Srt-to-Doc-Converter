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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Otvori open dijalog i trazi txt fajlove
               openFileDialog1.DefaultExt = "srt";
               openFileDialog1.Filter =
               "Subtitle text (*.srt)|*.srt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Richtext 01_01: Create the Save File dialog Instance
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            //Richtext 01_02: Set the Filters for the save dialog.
            saveDlg.Filter = "Microsoft Word (*.doc)|*.doc|All files (*.*)|*.*"; //Don't include space when when typing *.ext. Because space is treated as extension
            saveDlg.DefaultExt = "*.doc";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            //Richtext 01_03: Show the save file dialog
            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;

            //Richtext 01_04: Set the correct stream type (Rich text or Plain text?)
            RichTextBoxStreamType stream_type;
            if (saveDlg.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;

            //Richtext 01_05: Now its time to save the content
            richTextBox1.SaveFile(filename, stream_type);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string srtContent = richTextBox1.Text;
            string updatedText = RemoveNumberedLines(srtContent);
           
            updatedText = RemoveTimelines(updatedText);

            updatedText = CompactText(updatedText);
            richTextBox1.Text = updatedText;
        }

        private string RemoveNumberedLines(string srtContent)
        {
            StringBuilder result = new StringBuilder();
            using (StringReader reader = new StringReader(srtContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int lineNumber;
                    if (!int.TryParse(line, out lineNumber))
                    {
                        result.AppendLine(line);
                    }
                }
            }
            return result.ToString();
        }
 
        private string RemoveTimelines(string srtContent)
        {
            StringBuilder result = new StringBuilder();
            using (StringReader reader = new StringReader(srtContent))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains("-->"))
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
                        result.Append(' '); // Add a single space
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