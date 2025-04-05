using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Project2
{
    public partial class Form1 : Form
    {
        private FontDialog fd = new FontDialog();
        public Form1()
        {
            InitializeComponent();
            richTextBox1.Font = new Font("Courier New", 14);
            wordWrapToolStripMenuItem.Checked = true;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Text = "Untitled - Text Editor";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Documents (*.txt)|*.txt";
            ofd.Title = "Open a File...";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new StreamReader(ofd.FileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }

            Text = ofd.FileName + " - Text Editor";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Documents (*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;

            richTextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fd.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.Font = fd.Font;
            }
        }
    }
}