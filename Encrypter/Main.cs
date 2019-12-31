using System;
using System.Windows.Forms;
using System.IO;

namespace Encrypter
{
    public partial class Main : Form
    {
        string input;
        string output;
        string ext;
        Worker worker;
        public Main()
        {
            InitializeComponent();
            worker = new Worker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
                return;
            if (string.IsNullOrEmpty(input))
                return;
            if (string.IsNullOrEmpty(output))
                return;
            if (encrypt.Checked)
            {
                if (worker.FileEncrypt(input, output, passwordBox.Text))
                {
                    MessageBox.Show("Encryption succesful");
                }
                else
                {
                    MessageBox.Show("Encryption failed");
                }
            }
            else if (decrypt.Checked)
            {
                if (worker.FileDecrypt(input, output, passwordBox.Text))
                {
                    MessageBox.Show("Decryption succesful");
                }
                else
                {
                    MessageBox.Show("Decryotion failed");
                }
            }
            else
            {
                return;
            }
            clearValues();
        }

        private void pick_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = "c:\\";
            op.Filter = "All files (*.*)|*.*";
            op.FilterIndex = 0;
            op.RestoreDirectory = true;
            if (op.ShowDialog() == DialogResult.OK)
            {
                input = op.FileName;
                inputBox.Text = input;
                ext = Path.GetExtension(op.FileName);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.InitialDirectory = "c:\\";
            sv.Filter = "(*" + ext + ")|*" + ext;
            sv.FilterIndex = 0;
            sv.RestoreDirectory = true;
            if(sv.ShowDialog() == DialogResult.OK)
            {
                output = sv.FileName;
                outputBox.Text = output;
            }
        }

        private void clearValues()
        {
            input = null;
            output = null;
            passwordBox.Text = "";
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void doString_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordStringBox.Text))
                return;
            if (String.IsNullOrEmpty(inputString.Text))
                return;
            if (encryptString.Checked)
            {
                outputString.Text = worker.StringEncrypt(inputString.Text, passwordStringBox.Text);
                
            }
            else if(decryptString.Checked)
            {
                outputString.Text = worker.StringDecrypt(inputString.Text, passwordStringBox.Text);
            }
            else
            {
                return;
            }
            clearValues();
        }
    }
}
