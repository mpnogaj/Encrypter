using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Encrypter
{
    class Worker
    {
        //salt to generate encryption key
        private byte[] salt;

        //function to generate random salt
        private static byte[] GenerateRandomSalt()
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

        public bool FileEncrypt(string inputFile,string outputFile, string password)
        {
            //flag to check if encryption was succesful
            bool succesful = true;
            //generate random salt
            salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(outputFile, FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);

            //set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            //generate key for encryption
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

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

        public bool FileDecrypt(string inputFile, string outputFile, string password)
        {
            //flag to check if encryption was succesful
            bool succesful = true;
            //get password bytes and save them to byte array
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password);
            //salt placeholder
            salt = new byte[32];

            //read salt from the begining of the input file
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            //set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            //set key
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);


            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

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

        public string StringEncrypt(string plainText, string password)
        {
            //input text bytes
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            //generate random salt
            salt = GenerateRandomSalt();

            //prepare aes 
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CFB;
            //set keys
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 2000);
            var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
            var aesIV = pbkdf2.GetBytes(aes.BlockSize / 8);
            aes.Key = aesKey;
            aes.IV = aesIV;
            //write salt at the beginning of memory stream
            MemoryStream ms = new MemoryStream();
            ms.Write(salt, 0, salt.Length);
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                //encrypt and write encrypted bytes to memory stream
                cs.Write(plainBytes, 0, plainBytes.Length);
            };
            //return encrypted text  
            return Convert.ToBase64String(ms.ToArray());

        }
        public string StringDecrypt(string cryptoText, string password)
        {
            //alt and input text bytes
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            //read salt from the begining of cryptoBytes array
            byte[] saltBytes = cryptoBytes.Take(32).ToArray();
            //read the rest of cryptoBytes
            byte[] textBytes = cryptoBytes.Skip(32).Take(cryptoBytes.Length - 32).ToArray();

            salt = saltBytes;

            //prepare aes 
            Aes aes = Aes.Create();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CFB;
            //set keys
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 2000);
            var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
            var aesIV = pbkdf2.GetBytes(aes.BlockSize / 8);
            aes.Key = aesKey;
            aes.IV = aesIV;
            //Memory stream for decrypted bytes
            MemoryStream ms = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(textBytes, 0, textBytes.Length);
            };
            //Return decrypted text
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}
