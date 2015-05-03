using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Algoritmos
{
    public abstract class Algoritmo : ICifrar, IDescifrar
    {
        protected readonly MemoryStream ms;
        private bool disposed;

        public Algoritmo(MemoryStream ms)
        {
            this.disposed = false;
            this.ms = ms;
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

        public abstract byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes);

        public abstract byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes);

        public abstract byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes);

        public abstract byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes, byte[] saltBytes);
    }
}
