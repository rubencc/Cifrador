﻿using Cifrador.Algoritmos;
using Cifrador.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Cifradores
{
    public class CifradorDeTexto : ICifrarTexto, IDisposable
    {
        private readonly ISaltValidator saltValidator;
        private readonly ICifrar algoritmoCifrador;
        private bool disposed;

        public CifradorDeTexto(ICifrar algoritmo, ISaltValidator saltValidator)
        {
            this.saltValidator = saltValidator;
            this.algoritmoCifrador = algoritmo;
        }

        public string CifrarTexto(string input, string password)
        {
            byte[] byteArrayInput = this.GetBytes(input);
            byte[] byteArrayPassword = this.GetBytes(password);

            byte[] byteArrayOutput = this.algoritmoCifrador.Cifrar(byteArrayInput, byteArrayPassword);

            string output = this.GetString(byteArrayOutput);

            return output;
        }

        public string CifrarTexto(string input, string password, string salt)
        {
            if (!this.saltValidator.Validate(salt))
            {
                throw new ArgumentException();
            }

            byte[] byteArrayInput = this.GetBytes(input);
            byte[] byteArrayPassword = this.GetBytes(password);
            byte[] byteArraySalt = this.GetBytes(salt);

            byte[] byteArrayOutput = this.algoritmoCifrador.Cifrar(byteArrayInput, byteArrayPassword, byteArraySalt);

            string output = this.GetString(byteArrayOutput);

            return output;
        }

        private byte[] GetBytes(string str)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(str);
            return bytesToBeEncrypted;
        }

        private string GetString(byte[] bytes)
        {
            string output = Convert.ToBase64String(bytes);
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
