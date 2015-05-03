using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Descifradores
{
    public interface IDescifrarTexto
    {
        string DescifrarTexto(string input, string password);
        string DescifrarTexto(string input, string password, string salt);
    }
}
