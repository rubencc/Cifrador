using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Algoritmos
{
    public interface IDescifrar : IDisposable
    {
        byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes);
        byte[] Descifrar(byte[] bytesToBeDecrypted, byte[] passwordBytes, byte[] saltBytes);
    }
}
