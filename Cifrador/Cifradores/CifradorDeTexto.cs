using Cifrador.Algoritmos;
using Cifrador.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador.Cifradores
{
    public class CifradorDeTexto : CifradorBase , ICifradorDeTexto
    {
        ISaltValidator saltValidator;

        public CifradorDeTexto(ICifrado cifrador, ISaltValidator saltValidator)
            : base(cifrador)
        {
            this.saltValidator = saltValidator;
        }

        public string CifrarTexto(string input, string password)
        {
            byte[] byteArrayInput = this.GetBytes(input);
            byte[] byteArrayPassword = this.GetBytes(password);

            byte[] byteArrayoutput =  this.algoritmoCifrador.Cifrar(byteArrayInput, byteArrayPassword);

            string output = this.GetString(byteArrayoutput);

            return output;
        }

        public string CifrarTexto(string input, string password, string salt)
        {
            if(!this.saltValidator.Validate(salt))
            {
                throw new ArgumentException();
            }

            byte[] byteArrayInput = this.GetBytes(input);
            byte[] byteArrayPassword = this.GetBytes(password);
            byte[] byteArraySalt = this.GetBytes(salt);

            byte[] byteArrayoutput = this.algoritmoCifrador.Cifrar(byteArrayInput, byteArrayPassword, byteArraySalt);

            string output = this.GetString(byteArrayoutput);

            return output;
        }


    }
}
