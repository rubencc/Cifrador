using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Algoritmos
{
    public class AlgoritmoAES : Algoritmo
    {
        private readonly RijndaelManaged AES;

        public AlgoritmoAES(MemoryStream ms)
            : base(ms)
        {
            AES = new RijndaelManaged();
        }

        public override byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] saltBytes = new byte[] { 49, 50, 51, 52, 53, 54, 55, 56 };
            return this.Cifrar(bytesToBeEncrypted, passwordBytes, saltBytes);
        }

        public override byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes)
        {

            byte[] encryptedBytes = null;


            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

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


            return encryptedBytes;
        }

        protected override void Dispose(bool disposing)
        {
            this.AES.Dispose();
            base.Dispose(disposing);
        }

        public override byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] saltBytes = new byte[] { 49, 50, 51, 52, 53, 54, 55, 56 };
            return this.Descifrar(bytesToBeDecrypted, passwordBytes, saltBytes);
        }

        public override byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes, byte[] saltBytes)
        {
            byte[] encryptedBytes = null;


            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CBC;

            using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                cs.Close();
            }
            encryptedBytes = ms.ToArray();


            return encryptedBytes;
        }
    }
}
