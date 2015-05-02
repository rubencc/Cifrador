using Cifrador.Algoritmos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Cifradores
{
    public abstract class CifradorBase : IDisposable
    {
        protected readonly ICifrado algoritmoCifrador;
        private bool disposed;

        public CifradorBase(ICifrado algoritmoCifrador)
        {
            this.algoritmoCifrador = algoritmoCifrador;
            this.disposed = false;
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
                this.algoritmoCifrador.Dispose();
            }
            disposed = true;
        }

        protected byte[] GetBytes(string str)
        {
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(str);
            return bytesToBeEncrypted;
        }

        protected string GetString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
