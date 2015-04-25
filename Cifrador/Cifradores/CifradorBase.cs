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
        protected readonly ICifrado cifrador;
        private bool disposed;

        public CifradorBase(ICifrado cifrador)
        {
            this.cifrador = cifrador;
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
                this.cifrador.Dispose();
            }
            disposed = true;
        }
    }
}
