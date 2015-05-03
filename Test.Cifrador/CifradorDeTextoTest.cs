using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cifrador.Cifradores;
using Cifrador.Algoritmos;
using System.IO;
using Moq;
using Cifrador.Validadores;

namespace Test.Cifrador
{
    [TestClass]
    public class CifradorDeTextoTest
    {
        private CifradorDeTexto cifrador;
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
            this.cifrador.Dispose();
        }

        [TestMethod]
        public void Cifrar_text_12345_password_secreto()
        {
            string input = "12345";
            string password = "secreto";

            Mock<ISaltValidator> saltValidator = new Mock<ISaltValidator>();

            this.cifrador = new CifradorDeTexto(aes, saltValidator.Object);

            string output = this.cifrador.CifrarTexto(input, password);

            Assert.AreEqual("K+HjyM/T7G82uAofHeWTDg==", output, "El texto cifrado no coincide");
        }

        [TestMethod]
        public void Cifrar_text_12345_password_secreto_salt()
        {
            string input = "12345";
            string password = "secreto";
            string salt = "12345678";

            Mock<ISaltValidator> saltValidatorMock = new Mock<ISaltValidator>();
            saltValidatorMock.Setup(method => method.Validate(It.IsAny<string>())).Returns(true);

            this.cifrador = new CifradorDeTexto(aes, saltValidatorMock.Object);

            string output = this.cifrador.CifrarTexto(input, password, salt);

            Assert.AreEqual("K+HjyM/T7G82uAofHeWTDg==", output, "El texto cifrado no coincide");
        }
    }
}
