using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotePad
{
    public partial class MainNotepadFrm : Form
    {

        string path;
        public MainNotepadFrm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            MainRichTextBox.Clear();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String fn = openFileDialog1.FileName;
            System.IO.StreamReader sr = new System.IO.StreamReader(fn);
            MainRichTextBox.Text = sr.ReadToEnd();
            sr.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            String fn = saveFileDialog1.FileName;
            System.IO.StreamWriter sw = new System.IO.StreamWriter (fn);
            sw.Write(MainRichTextBox.Text);
            sw.Flush();
            sw.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //this.close();
            Application.Exit();
        }


        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All Rights are reserved by the author.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
        }

        private void MainRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainRichTextBox.Text.Length > 0)
            {
                undoToolStripMenuItem.Enabled = true;
                CutToolStripMenuItem.Enabled = true;
                CopyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                

            }
            else
            {
                selectAllToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
                CutToolStripMenuItem.Enabled = false;
                CopyToolStripMenuItem.Enabled = false;

                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled =false;
                underlineToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
            }
        }


        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Italic);
        }





        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectedText = "";
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Underline);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Regular);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Strikeout);
        }

        private void textColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            MainRichTextBox.ForeColor = colorDialog1.Color;

        }

        private void fontDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            MainRichTextBox.Font = fontDialog1.Font;

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void NEW_Click(object sender, EventArgs e)
        {
            path = string.Empty;
            MainRichTextBox.Clear();
        }

        private void OPEN_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = openFileDialog1.FileName;
                if (File.Exists(fn))
                {
                    using (StreamReader sr = new StreamReader(fn))
                    {
                        MainRichTextBox.Text = sr.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("Selected file not found.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string fn = saveFileDialog1.FileName;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fn);
            sw.Write(MainRichTextBox.Text);
            sw.Flush();
            sw.Close();
        }

        private void PRINT_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void UNDO_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void REDO_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
        }

        private void BOLD_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Bold);
        }

        private void ITALIC_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Italic);
        }

        private void UNDERLINE_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Underline);
        }

        private void STRIKETHROUGH_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Strikeout);
        }

        private void NORMAL_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Regular);
        }

        private void TextCOLOR_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            MainRichTextBox.ForeColor = colorDialog1.Color;
        }

        private void FontDialog_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            MainRichTextBox.Font = fontDialog1.Font;

        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void allingmentToolStripMenuItem_Click1(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void LEFT_Click1(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void CENTER_Click1(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void RIGHT_Click1(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
            MainRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.Timer.Text = dateTime.ToString();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            
        }

        private void MainNotepadFrm_Load(object sender, EventArgs e)
        {

        }

        private void MainRichTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
