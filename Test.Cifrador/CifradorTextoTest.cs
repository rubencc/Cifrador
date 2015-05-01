using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cifrador.Cifradores;
using Cifrador.Algoritmos;
using System.IO;

namespace Test.Cifrador
{
    [TestClass]
    public class CifradorTextoTest
    {
        private CifradorDeTexto cifrador;
        private MemoryStream ms;
        private ICifrado aes;


        [TestInitialize]
        public void Setup()
        {
            this.ms = new MemoryStream();
            this.aes = new AlgoritmoAES(ms);          
        }

        [TestCleanup]
        public void Finalize()
        {
            this.aes.Dispose();
            this.ms.Dispose();
            this.cifrador.Dispose();
        }

        [TestMethod]
        public void Cifrar_text_12345_password_secreto()
        {
            string input = "12345";
            string password = "secreto";

            this.cifrador = new CifradorDeTexto(aes);

            string output = this.cifrador.CifrarTexto(input, password);

            Assert.AreEqual("F/ZcHbFDN2xMU/bhJ2CabA==", output, "El texto cifrado no coincide");
        }


    }
}
