using System;
using System.Windows.Forms;
using System.IO;

namespace Encrypter
{
    public partial class Main : Form
    {
        //path to input file
        string input;
        //path to output file
        string output;
        //extension of the input file
        string ext;
        //Worker class instance. This class contains encryption and decryption methods
        Worker worker;
        public Main()
        {
            InitializeComponent();
            worker = new Worker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordBox.Text))
            {
                MessageBox.Show("Please provide a password");
                return;
            } 
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please provide an input file");
                return;
            }
            if (string.IsNullOrEmpty(output))
            {
                MessageBox.Show("Please provide an output file");
                return;
            }   
            if (encrypt.Checked)
            {
                if (worker.FileEncrypt(input, output, passwordBox.Text))
                    MessageBox.Show("Encryption succesful");
                else
                    MessageBox.Show("Encryption failed");
            }
            else if (decrypt.Checked)
            {
                if (worker.FileDecrypt(input, output, passwordBox.Text))
                    MessageBox.Show("Decryption succesful");
                else
                    MessageBox.Show("Decryotion failed");
            }

            else
                return;

            clearValues();
        }

        private void pick_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
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
            catch
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "(*" + ext + ")|*" + ext;
                sv.FilterIndex = 0;
                sv.RestoreDirectory = true;
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    output = sv.FileName;
                    outputBox.Text = output;
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please try again");
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
            {
                MessageBox.Show("Please provide a password");
                return;
            }
            if (String.IsNullOrEmpty(inputString.Text))
            {
                MessageBox.Show("Please provide an input text");
                return;
            }
                
            if (encryptString.Checked)  
                outputString.Text = worker.StringEncrypt(inputString.Text, passwordStringBox.Text);
            else if(decryptString.Checked)
                outputString.Text = worker.StringDecrypt(inputString.Text, passwordStringBox.Text);
            else
                return;

            clearValues();
        }
    }
}
