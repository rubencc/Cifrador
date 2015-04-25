using Cifrador.Algoritmos;
using Cifrador.Cifradores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifrador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce el texto a cifrar");

            string input = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el password");

            string password = Console.ReadLine();

            string output = CifrarTexto(input, password);

            Console.WriteLine("\nTexto cifrado:\n {0}", output);

            Console.ReadKey();
        }

        public static string CifrarTexto(string input, string password)
        {
            using (MemoryStream ms = new MemoryStream())
            using (ICifrado aes = new AlgoritmoAES(ms))
            using (ICifradorDeTexto cifrador = new CifradorDeTexto(aes))
            {
                return cifrador.CifrarTexto(input, password);
            }
        }
    }
}
