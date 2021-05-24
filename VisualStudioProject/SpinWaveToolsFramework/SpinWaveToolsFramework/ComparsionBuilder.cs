using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SpinWaveToolsFramework
{
    public partial class ComparsionBuilder : Form
    {
        public ComparsionBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = textDirectory.Text;
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                textDirectory.Text = dialog.FileName.Replace(Path.GetFileName(dialog.FileName), "");
                if (textPattern.Text == "") textPattern.Text = "\\w*" + Path.GetExtension(dialog.FileName);
                if (textOutput.Text == "") textOutput.Text = textDirectory.Text + "ComparsionFile.txt";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> filesList = new List<string>();
            DirSearch(textDirectory.Text, filesList);

            if (textPattern.Text != "")
            {
                Regex reg = new Regex(textPattern.Text);
                for (var i = 0; i < filesList.Count; i++)
                {
                    if (!reg.IsMatch(filesList[i]))
                    {
                        filesList.RemoveAt(i);
                        i--;
                    }
                }
            }

            var files = filesList.ToArray();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(files);
        }

        void DirSearch(string sDir, List<string> list)
        {
            foreach (string d in Directory.GetDirectories(sDir))
            {
                foreach (string f in Directory.GetFiles(d))
                {
                    list.Add(f);
                }
                DirSearch(d, list);
            }
            foreach (string f in Directory.GetFiles(sDir))
            {
                list.Add(f);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int row = -1;
            int.TryParse(textColumn.Text, out row);
            if (row == -1)
            {
                MessageBox.Show("Row must be a positive integer!");
                return;
            }
            int offset = -1;
            int.TryParse(textOffset.Text, out offset);
            if (offset == -1)
            {
                MessageBox.Show("Offset must be a positive integer!");
                return;
            }
            button3.Enabled = false;
            await Task.Run(() =>
            {
                string[] files = new string[listBox1.Items.Count];
                for(var i = 0; i < listBox1.Items.Count; i++)
                {
                    files[i] = (string)listBox1.Items[i];
                }
                MathWorker.Merge(files, row, textOutput.Text, offset);
            });
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.InitialDirectory = textOutput.Text;
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                textOutput.Text = dialog.FileName;
            }
        }
    }
}
