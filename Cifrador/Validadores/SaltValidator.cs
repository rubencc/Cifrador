using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Validadores
{
    public class SaltValidator : ISaltValidator
    {
        public bool Validate(string salt)
        {
            return this.Validate(this.GetBytes(salt));
        }

        public bool Validate(byte[] salt)
        {
            return salt.Length > 7;
        }

        protected byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
