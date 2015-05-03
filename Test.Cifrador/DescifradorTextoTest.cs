using Cifrador.Algoritmos;
using Cifrador.Descifradores;
using Cifrador.Validadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Cifrador
{
    [TestClass]
    public class DescifradorTextoTest
    {
        private DescifradorDeTexto descifrador;
        private MemoryStream ms;
        private Algoritmo aes;

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
            this.descifrador.Dispose();
        }

        [TestMethod]
        public void Descifrar_text_12345_password_secreto()
        {
            string input = "K+HjyM/T7G82uAofHeWTDg==";
            string password = "secreto";

            Mock<ISaltValidator> saltValidator = new Mock<ISaltValidator>();

            this.descifrador = new DescifradorDeTexto(aes, saltValidator.Object);

            string output = this.descifrador.DescifrarTexto(input, password);

            Assert.AreEqual("12345", output, "El texto descifrado no coincide");
        }
    }
}
