using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;


namespace WinFormsApp9
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

            //KORAK 1
            var text = "";//Holds the text of current line being looped.
            var startindex = 0;//The position where selection starts.
            var endindex = 2000;//The length of selection.

            for (int i = 0; i < richTextBox1.Lines.Length; i++)//Loops through each line of text in RichTextBox
            {
                text = richTextBox1.Lines[i];//Stores current line of text.
                if (text.Contains("-->") == true)//Checks if the line contains MOVE STORAGE.
                    
                    {
                    startindex = richTextBox1.GetFirstCharIndexFromLine(i);//If match is found the index of first char of that line is stored in startindex.
                    endindex = text.Length;//Gets the length of line till semicolon and stores it in endindex.
                    richTextBox1.Select(startindex, endindex);//Selects the text.
                    richTextBox1.Text = richTextBox1.Text.Replace(richTextBox1.SelectedText, string.Empty);//Replaces the text with empty string.
                }
            }


            //Korak 2
            richTextBox1.Text = richTextBox1.Text.Remove(0, richTextBox1.Lines[0].Length);
            //Brise prazna mesta na richtextbox
            richTextBox1.Lines = richTextBox1.Lines.Where(line => line.Trim() != string.Empty).ToArray();

            //KORAK 3
            string[] lines = richTextBox1.Text.Split('\n');
            StringBuilder updatedText = new StringBuilder();

            for (int i = 0; i < lines.Length; i++)
            {
                if (i % 2 == 0) // Check if it's an even-numbered line
                {
                    updatedText.AppendLine(lines[i]);
                }
            }

            richTextBox1.Text = updatedText.ToString();

            //Korak 4 preuredi text
            string mergedText = string.Join(" ", richTextBox1.Lines);
            richTextBox1.Text = mergedText;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
