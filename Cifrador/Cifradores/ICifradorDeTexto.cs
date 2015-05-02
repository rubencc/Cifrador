using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Cifradores
{
    public interface ICifradorDeTexto : IDisposable
    {
        string CifrarTexto(string input, string password);
        string CifrarTexto(string input, string password, string salt);
    }
}
