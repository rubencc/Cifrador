using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Algoritmos
{
    public class AlgoritmoAES : AlgoritmoBase
    {

        public AlgoritmoAES(MemoryStream ms)
            : base(ms)
        {

        }

        public override byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            return this.Cifrar(bytesToBeEncrypted, passwordBytes, saltBytes);
        }

        public override byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            
            byte[] encryptedBytes = null;

            using (RijndaelManaged AES = new RijndaelManaged())
            {
                AES.KeySize = 256;
                AES.BlockSize = 128;

                var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                AES.Key = key.GetBytes(AES.KeySize / 8);
                AES.IV = key.GetBytes(AES.BlockSize / 8);

                AES.Mode = CipherMode.CBC;

                using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                    cs.Close();
                }
                encryptedBytes = ms.ToArray();
            }


            return encryptedBytes;
        }
    }
}
