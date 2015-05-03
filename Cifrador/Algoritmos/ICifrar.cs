using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Algoritmos
{
    public interface ICifrar : IDisposable
    {
        byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes);
        byte[] Cifrar(byte[] bytesToBeEncrypted, byte[] passwordBytes, byte[] saltBytes);
    }
}
