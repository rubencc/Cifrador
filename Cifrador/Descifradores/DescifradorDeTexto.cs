using Cifrador.Algoritmos;
using Cifrador.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Descifradores
{
    public class DescifradorDeTexto : IDescifrarTexto, IDisposable
    {
        private readonly ISaltValidator saltValidator;
        private readonly IDescifrar algoritmoDescifrador;
        private bool disposed;

        public DescifradorDeTexto(IDescifrar algoritmo, ISaltValidator saltValidator)
        {
            this.algoritmoDescifrador = algoritmo;
            this.saltValidator = saltValidator;
        }

        public string DescifrarTexto(string input, string password)
        {
            byte[] byteArrayInput = this.GetBytesFromText(input);
            byte[] byteArrayPassword = this.GetBytes(password);

            byte[] byteArrayOutput = this.algoritmoDescifrador.Descifrar(byteArrayInput, byteArrayPassword);

            string output = this.GetString(byteArrayOutput);

            return output;
        }

        public string DescifrarTexto(string input, string password, string salt)
        {
            if (!this.saltValidator.Validate(salt))
            {
                throw new ArgumentException();
            }

            byte[] byteArrayInput = this.GetBytesFromText(input);
            byte[] byteArrayPassword = this.GetBytes(password);
            byte[] byteArraySalt = this.GetBytes(salt);

            byte[] byteArrayOutput = this.algoritmoDescifrador.Descifrar(byteArrayInput, byteArrayPassword, byteArraySalt);

            string output = this.GetString(byteArrayOutput);

            return output;
        }

        private byte[] GetBytesFromText(string str)
        {
            byte[] bytesToBeEncrypted = Convert.FromBase64String(str);
            return bytesToBeEncrypted;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(str);
            return bytesToBeEncrypted;
        }

        private string GetString(byte[] bytes)
        {
            string output = Encoding.UTF8.GetString(bytes);
            return output;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }
            disposed = true;
        }
    }
}
