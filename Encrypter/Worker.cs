using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Encrypter
{
    class Worker
    {
        private byte[] salt;
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        public bool FileEncrypt(string inputFile,string outputFile, string password)
        {
            bool succesful = true;
            //generate random salt
            salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(outputFile, FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;
            //High iteration counts.
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
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
            bool succesful = true;
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);
            salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

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
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            salt = GenerateRandomSalt();
            var aes = Aes.Create();
            //generating keys ,IV
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 2000);
            var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
            var aesIV = pbkdf2.GetBytes(aes.BlockSize / 8);
            aes.Key = aesKey;
            aes.Mode = CipherMode.CFB;
            aes.IV = aesIV;
            var ms = new MemoryStream();
            ms.Write(salt, 0, salt.Length);
            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            };
            return Convert.ToBase64String(ms.ToArray());

        }
        public string StringDecrypt(string cryptoText, string password)
        {
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            byte[] saltBytes = cryptoBytes.Take(32).ToArray();
            byte[] textBytes = cryptoBytes.Skip(32).Take(cryptoBytes.Length - 32).ToArray();
            salt = saltBytes;
            var aes = Aes.Create();
            //generating keys ,IV
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CFB;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 2000);
            var aesKey = pbkdf2.GetBytes(aes.KeySize / 8);
            var aesIV = pbkdf2.GetBytes(aes.BlockSize / 8);
            aes.Key = aesKey;
            aes.IV = aesIV;
            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(textBytes, 0, textBytes.Length);
            };
            return Encoding.Unicode.GetString(ms.ToArray());
        }
    }
}
