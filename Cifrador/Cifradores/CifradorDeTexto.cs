using Cifrador.Algoritmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Cifradores
{
    public class CifradorDeTexto : CifradorBase , ICifradorDeTexto
    {

        public CifradorDeTexto(ICifrado cifrador)
            : base(cifrador)
        {

        }

        public string CifrarTexto(string input, string password)
        {
            byte[] byteArrayInput = this.GetBytes(input);
            byte[] byteArrayPassword = this.GetBytes(password);

            byte[] byteArrayoutput =  this.cifrador.Cifrar(byteArrayInput, byteArrayPassword);

            string output = GetString(byteArrayoutput);

            return output;
        }

        public string CifrarTexto(string input, string password, string[] salt)
        {
            throw new NotImplementedException();
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(str);
            return bytesToBeEncrypted;
        }

        private  string GetString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
