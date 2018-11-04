using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace UnitTestTP3
{

    [TestClass]
    public class UnitTestTP3
    {

        /// <summary>
        /// Test Unitario que comrpueba que al agregar dos objetos de tipo <see cref="Alumno"/> a una <see cref="Universidad"/>, se lance la excepcion <see cref="AlumnoRepetidoException"/>.
        /// </summary>
        [TestMethod]
        public void AlumnoRepetidoExceptionTest()
        {
            //Se instancian dos alumnos con mismo numero de DNI
            Alumno alumno = new Alumno(1500, "Roberto", "Martinez", "458000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno segundoAlumno = new Alumno(45800, "Martin", "Echeverria", "458000", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            //Se instancia una Universidad en la que se agregaran los alumnos
            Universidad universidad = new Universidad();
            try
            {
                //Se agregan los alumnos.
                universidad += alumno;
                universidad += segundoAlumno;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Test Unitario que comprueba que al instanciar un <see cref="Alumno"/> con formato invalido de DNI, se lance la excepcion <see cref="DniInvalidoException"/>
        /// </summary>
        [TestMethod]
        public void DniInvalidoExceptionTest()
        {
            //Dni con letra
            try
            {
                Alumno alumno = new Alumno(20, "Jose", "Gonzalez", "1230002d", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            //Dni con puntos
            try
            {
                Alumno alumno = new Alumno(10, "Pedro", "Rodriguez", "12.000.150", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Test Unitario que comprueba que al instanciar un <see cref="Alumno"/> con un DNI fuera de rango para su nacionalidad, se lance <see cref="NacionalidadInvalidaException"/>.
        /// </summary>
        [TestMethod]
        public void NacionalidadInvalidaExceptionTest()
        {
            //Nacionalidad Argentina
            //DNI > 90000000
            try
            {
                Alumno alumno = new Alumno(50, "Mariano", "Gomez", "95150367", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Deudor);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //DNI < 1
            try
            {
                Alumno alumno = new Alumno(323, "Alberto", "Bardini", "0", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //Nacionalidad Extranjera
            //DNI < 89999999
            try
            {
                Alumno alumno = new Alumno(458, "Pedro", "Gonzalez", "12536188", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            //DNI > 99999999
            //Test no implementado ya que cualquier DNI > 99.999.999 será tomado como DniInvalidoException ya que los DNI no pueden tener mas de 8 caracteres.
            /*try
            {
                Alumno alumno = new Alumno(1548, "Jose", "Gonzalez", "100000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }*/
        }

        /// <summary>
        /// Test Unitario que valida un Valor Numerico
        /// </summary>
        [TestMethod]
        public void ValorNumericoTest()
        {
            Profesor profesor = new Profesor(1500, "Selene", "Vargas", "487532", Persona.ENacionalidad.Argentino);
            Alumno alumno = new Alumno(132897, "Victoria", "Galli", "95002365", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsInstanceOfType(profesor.DNI, typeof(int));
            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }

        /// <summary>
        /// Test Unitario que comprueba que no haya atributos <see cref="null"/> en las instancias de la clase <see cref="Alumno"/>. 
        /// </summary>
        [TestMethod]
        public void ValoresNulosTestAlumno()
        {
            //Test de Alumno con sus distintos constructores
            //No se comprueba con los constructores por default ya que estos estan creados exclusivamente por la serializacion.

            Alumno alumno = new Alumno(1500, "Jose", "Alberto", "45877", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.IsNotNull(alumno);
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.DNI);
            Assert.IsNotNull(alumno.Nacionalidad);
            Assert.IsNotNull(alumno.Nombre);


            Alumno segundoAlumno = new Alumno(4800, "Camila", "Gonzalez", "94777489", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Assert.IsNotNull(segundoAlumno);
            Assert.IsNotNull(segundoAlumno.Apellido);
            Assert.IsNotNull(segundoAlumno.DNI);
            Assert.IsNotNull(segundoAlumno.Nacionalidad);
            Assert.IsNotNull(segundoAlumno.Nombre);
        }

        /// <summary>
        /// Test Unitario que comprueba que no haya atributos <see cref="null"/> en las instancias de la clase <see cref="Profesor"/>. 
        /// </summary>
        [TestMethod]
        public void ValoresNulosTestProfesor()
        {
            //Test de Profesor con sus distintos constructores
            //No se comprueba con los constructores por default ya que estos estan creados exclusivamente por la serializacion.


            Profesor profesor = new Profesor(4785, "Carolina", "Siedlar", "1500365", Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(profesor);
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.DNI);
            Assert.IsNotNull(profesor.Nacionalidad);
            Assert.IsNotNull(profesor.Nombre);
        }

        /// <summary>
        /// Test Unitario que comprueba que no haya atributos <see cref="null"/> en las instancias de la clase <see cref="Jornada"/>. 
        /// </summary>
        [TestMethod]
        public void ValoresNulosTestJornada()
        {
            //Test de Jornada con sus distintos constructores
            Profesor profesor = new Profesor();
            Jornada jornada = new Jornada(Universidad.EClases.Laboratorio, profesor);
            Assert.IsNotNull(jornada);
            Assert.IsNotNull(jornada.Alumnos);
            Assert.IsNotNull(jornada.Clase);
            Assert.IsNotNull(jornada.Instructor);
        }

        /// <summary>
        /// Test Unitario que comprueba que no haya atributos <see cref="null"/> en las instancias de la clase <see cref="Universidad"/>. 
        /// </summary>
        [TestMethod]
        public void ValoresNulosTestUniversidad()
        {
            //Test de Universidad con sus distintos constructores
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad);
            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
