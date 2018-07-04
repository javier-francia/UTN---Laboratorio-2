using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PaquetesCorreoInstanciados()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void PaquetesMismoID()
        {
            Paquete p1 = new Paquete("abc", "123");
            Paquete p2 = new Paquete("def", "123");
            Correo c = new Correo();
            c += p1;
            c += p2;
        }
    }
}
