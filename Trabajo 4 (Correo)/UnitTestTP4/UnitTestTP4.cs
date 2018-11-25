using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestTP4
{
    [TestClass]
    public class UnitTestTP4
    {
        /// <summary>
        /// Test Unitario que comprueba que la Lista de Paquetes de la clase correo se instancie al crear un objeto de este tipo.
        /// </summary>
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            //Se instancia un nuevo objeto de la clase Correo.
            Correo correoTest = new Correo();

            //Se verifica que la lista del objeto Correo este instanciada.
            Assert.IsNotNull(correoTest.Paquetes);
        }

        /// <summary>
        /// Test Unitario que comprueba que no se agreguen dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void TrackingIDRepetido()
        {
            //Instancio dos objetos de tipo Paquete
            Paquete primerPaquete = new Paquete("Primera direccion", "111-222-3333");
            Paquete segundoPaquete = new Paquete("Segundo direccion", "111-222-3333");

            //Instancio un objeto correo donde se agregaran los dos Paquetes.
            Correo correoTest = new Correo();

            //Agrego los dos Paquetes al correo
            correoTest += primerPaquete;
            try
            {
                correoTest += segundoPaquete;
                Assert.Fail("Deberia arrojarse excepcion de Paquete repetido");
            }
            catch(Exception e)
            {
                //Verifico que se produzca la excepcion apropiada al añadir un Paquete repetido.
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
                
                //Verifico que solo se haya añadido una instancia de tipo Paquete
                Assert.IsTrue(correoTest.Paquetes.Count == 1);
            }
        }
    }
}
