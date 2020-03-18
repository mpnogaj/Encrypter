using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Encrypter
{
    class Worker
    {
        //salt to generate encryption key
        private static byte[] _salt;

        //function to generate random salt
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    //fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }
            return data;
        }

        public static bool FileEncrypt(string inputFile,string outputFile, string password)
        {
            //flag to check if encryption was succesful
            bool succesful = true;
            //generate random salt
            _salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(outputFile, FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);

            //set Rijndael symmetric encryption algorithm
            RijndaelManaged aes = new RijndaelManaged
            {
                KeySize = 256, BlockSize = 128, Padding = PaddingMode.PKCS7, Mode = CipherMode.CFB
            };

            //generate key for encryption
            var key = new Rfc2898DeriveBytes(passwordBytes, _salt, 50000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);

            //write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(_salt, 0, _salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;

            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }
                fsIn.Close();
            }
            catch
            {
                succesful = false;
            }
            finally
            {
                cs.Close();
                fsCrypt.Close(); 
            }
            return succesful;
        }

        public static bool FileDecrypt(string inputFile, string outputFile, string password)
        {
            //flag to check if encryption was succesful
            bool succesful = true;
            //get password bytes and save them to byte array
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            //salt placeholder
            _salt = new byte[32];

            //read salt from the begining of the input file
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(_salt, 0, _salt.Length);

            //set Rijndael symmetric encryption algorithm
            RijndaelManaged aes = new RijndaelManaged
            {
                KeySize = 256, BlockSize = 128, Padding = PaddingMode.PKCS7, Mode = CipherMode.CFB
            };

            //set key
            var key = new Rfc2898DeriveBytes(passwordBytes, _salt, 50000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);


            CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
                cs.Close();
            }
            catch
            {
                succesful = false;
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
            return succesful;
        }

        public static string StringEncrypt(string plainText, string password)
        {
            //input text bytes
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            //generate random salt
            _salt = GenerateRandomSalt();

            //prepare aes 
            Aes aes = Aes.Create();
            if (aes != null)
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;
                aes.Mode = CipherMode.CFB;
                //set keys
                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, _salt, 2000);
                var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
                var aesIv = pbkdf2.GetBytes(aes.BlockSize / 8);
                aes.Key = aesKey;
                aes.IV = aesIv;
                //write salt at the beginning of memory stream
                MemoryStream ms = new MemoryStream();
                ms.Write(_salt, 0, _salt.Length);
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    //encrypt and write encrypted bytes to memory stream
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }

                //return encrypted text  
                return Convert.ToBase64String(ms.ToArray());
            }
            else
            {
                MessageBox.Show(@"Something went wrong. Please try again");
                return null;
            }
        }
        public static string StringDecrypt(string cryptoText, string password)
        {
            //alt and input text bytes
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            //read salt from the begining of cryptoBytes array
            byte[] saltBytes = cryptoBytes.Take(32).ToArray();
            //read the rest of cryptoBytes
            byte[] textBytes = cryptoBytes.Skip(32).Take(cryptoBytes.Length - 32).ToArray();

            _salt = saltBytes;

            //prepare aes 
            Aes aes = Aes.Create();
            if (aes != null)
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.Zeros;
                aes.Mode = CipherMode.CFB;
                //set keys
                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, _salt, 2000);
                var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
                var aesIv = pbkdf2.GetBytes(aes.BlockSize / 8);
                aes.Key = aesKey;
                aes.IV = aesIv;
                //Memory stream for decrypted bytes
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(textBytes, 0, textBytes.Length);
                }

                //Return decrypted text
                return Encoding.Unicode.GetString(ms.ToArray());
            }
            else
            {
                MessageBox.Show(@"Something went wrong. Please try again");
                return null;
            }
        }
    }
}
