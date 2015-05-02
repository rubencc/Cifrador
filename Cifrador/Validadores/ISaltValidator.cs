using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Validadores
{
    public interface ISaltValidator
    {
        bool Validate(String salt);
        bool Validate(byte[] salt);
    }
}
