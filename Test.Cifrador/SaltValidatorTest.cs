using Cifrador.Validadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Cifrador
{
    [TestClass]
    public class SaltValidatorTest
    {
        private SaltValidator validator;

        [TestInitialize]
        public void Setup()
        {
            this.validator = new SaltValidator();
        }

        [TestCleanup]
        public void Finalize()
        {
            this.validator = null;
        }

        [TestMethod]
        public void Validar_Salt_de_menos_de_8_elementos()
        {
            string salt = "1234567";

            bool result = this.validator.Validate(salt);

            Assert.IsFalse(result, "El resultado es true. Deberia ser false");
        }

        [TestMethod]
        public void Validar_Salt_de_8_elementos()
        {
            string salt = "12345678";

            bool result = this.validator.Validate(salt);

            Assert.IsTrue(result, "El resultado es false. Deberia ser true");
        }

        [TestMethod]
        public void Validar_Salt_de_mas_de_8_elementos()
        {
            string salt = "123456789";

            bool result = this.validator.Validate(salt);

            Assert.IsTrue(result, "El resultado es false. Deberia ser true");
        }
    }
}
