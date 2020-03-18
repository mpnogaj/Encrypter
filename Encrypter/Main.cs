using System;
using System.Windows.Forms;
using System.IO;

namespace Encrypter
{
    public partial class Main : Form
    {
        //path to input file
        string _input;
        //path to output file
        string _output;
        //extension of the input file
        string _ext;
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                MessageBox.Show(@"Please provide a password");
                return;
            } 
            if (string.IsNullOrEmpty(_input))
            {
                MessageBox.Show(@"Please provide an input file");
                return;
            }
            if (string.IsNullOrEmpty(_output))
            {
                MessageBox.Show(@"Please provide an output file");
                return;
            }   
            if (encrypt.Checked)
            {
                if (Worker.FileEncrypt(_input, _output, passwordBox.Text))
                    MessageBox.Show(@"Encryption succesful");
                else
                    MessageBox.Show(@"Encryption failed");
            }
            else if (decrypt.Checked)
            {
                if (Worker.FileDecrypt(_input, _output, passwordBox.Text))
                    MessageBox.Show(@"Decryption succesful");
                else
                    MessageBox.Show(@"Decryotion failed");
            }

            else
                return;

            ClearValues();
        }

        private void Pick_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog
                {
                    Filter = @"All files (*.*)|*.*", FilterIndex = 0, RestoreDirectory = true
                };
                if (op.ShowDialog() == DialogResult.OK)
                {
                    _input = op.FileName;
                    inputBox.Text = _input;
                    _ext = Path.GetExtension(op.FileName);
                }
            }
            catch
            {
                MessageBox.Show(@"Something went wrong. Please try again");
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog
                {
                    Filter = @"(*" + _ext + @")|*" + _ext, FilterIndex = 0, RestoreDirectory = true
                };
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    _output = sv.FileName;
                    outputBox.Text = _output;
                }
            }
            catch
            {
                MessageBox.Show(@"Something went wrong. Please try again");
            }
        }

        private void ClearValues()
        {
            _input = null;
            _output = null;
            passwordBox.Text = "";
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void DoString_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordStringBox.Text))
            {
                MessageBox.Show(@"Please provide a password");
                return;
            }
            if (String.IsNullOrEmpty(inputString.Text))
            {
                MessageBox.Show(@"Please provide an input text");
                return;
            }
                
            if (encryptString.Checked)  
                outputString.Text = Worker.StringEncrypt(inputString.Text, passwordStringBox.Text);
            else if(decryptString.Checked)
                outputString.Text = Worker.StringDecrypt(inputString.Text, passwordStringBox.Text);
            else
                return;

            ClearValues();
        }
    }
}
