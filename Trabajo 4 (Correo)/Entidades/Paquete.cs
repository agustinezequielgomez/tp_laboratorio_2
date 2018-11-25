using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        private string _direccionEntrega;
        private EEstado _estado;
        private string _trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece la Direccion de entrega de un <see cref="Paquete"/>.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this._direccionEntrega;
            }
            set
            {
                this._direccionEntrega = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el Estado de un <see cref="Paquete"/>.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el Tracking ID de un <see cref="Paquete"/>.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this._trackingID;
            }
            set
            {
                this._trackingID = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Paquete"/>.
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del Paquete.</param>
        /// <param name="trackingID">Tracking ID del Paquete.</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de un elemento de tipo <see cref="IMostrar{Paquete}"/>.
        /// </summary>
        /// <param name="elemento">Elemento del cual se van a mostrar sus datos.</param>
        /// <returns>Retorna un <see cref="string"/> con los datos del Elemento.</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paquete = (Paquete)elemento;
            return String.Format("{0} para {1}",paquete.TrackingID,paquete.DireccionEntrega);
        }

        /// <summary>
        /// Muestra la informacion de un <see cref="Paquete"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con la informacion del <see cref="Paquete"/>.</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Hace que un <see cref="Paquete"/> cambie de estado.
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            } while (this.Estado != EEstado.Entregado);
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch(Exception e)
            {
                this.InformarException(e);
            }
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comrpeuba si dos objetos de tipo <see cref="Paquete"/> son iguales.
        /// </summary>
        /// <param name="p1">Primer objeto a comparar.</param>
        /// <param name="p2">Segundo objeto a comparar.</param>
        /// <returns>Retorna <see cref="true"/> si los dos objetos son iguales, <see cref="false"/> si no lo son.</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        /// <summary>
        /// Comprueba si dos objetos de tipo <see cref="Paquete"/> son distintos.
        /// </summary>
        /// <param name="p1">Primer objeto a comparar.</param>
        /// <param name="p2">Segundo objeto a comparar.</param>
        /// <returns>Retorna <see cref="true"/> si son distintos, <see cref="false"/> si no lo son.</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento encargado de informar el estado de un <see cref="Paquete"/>.
        /// </summary>
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Evento encargado de informar si se produjo alguna Excepcion en el manejo de un <see cref="Paquete"/>.
        /// </summary>
        public event DelegadoException InformarException;
        #endregion

        #region Delegados
        /// <summary>
        /// Delegado encargado de manejar metodos que informaran cambios de estado en el <see cref="Paquete"/>.
        /// </summary>
        /// <param name="sender">Objeto que produce el cambio de estado.</param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);

        /// <summary>
        /// Delegado encargado de manejar metodos que informaran de excepciones ocurridas en el manejo de un <see cref="Paquete"/>.
        /// </summary>
        /// <param name="e">Excepcion ocurrida.</param>
        public delegate void DelegadoException(Exception e);
        #endregion

        #region Enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion
    }
}
