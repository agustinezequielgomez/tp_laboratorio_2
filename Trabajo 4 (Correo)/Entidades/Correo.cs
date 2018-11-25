using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> _mockPaquetes;
        private List<Paquete> _paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece una <see cref="List{T}"/> de tipo <see cref="Paquete"/>.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this._paquetes;
            }
            set
            {
                this._paquetes = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Correo"/>.
        /// </summary>
        public Correo()
        {
            this._mockPaquetes = new List<Thread>();
            this.Paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de un elemento de tipo <see cref="IMostrar{T}"/>. En este caso sera una <see cref="List{T}"/> de tipo <see cref="Paquete"/>.
        /// </summary>
        /// <param name="elementos"><see cref="List{T}"/> de tipo <see cref="Paquete"/> de la cual se mostraran los datos.</param>
        /// <returns>Retorna un <see cref="string"/> con todos los datos de <see cref="List{T}"/>.</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetes = (List<Paquete>)((Correo)elementos).Paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in paquetes)
            {
                sb.AppendLine(String.Format("{0} ({1})", paquete.ToString(), paquete.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Cierra todos los <see cref="Thread"/> que se generaron al agregar Paquetes al <see cref="Correo"/>.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this._mockPaquetes)
            {
                hilo.Abort();
            }
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un <see cref="Paquete"/> al <see cref="Correo"/> siempre y cuando este no haya sido agregado con anterioridad.
        /// </summary>
        /// <param name="c"><see cref="Correo"/> al que se agregara el <see cref="Paquete"/>.</param>
        /// <param name="p"><see cref="Paquete"/> que se agregara al <see cref="Correo"/>.</param>
        /// <returns>Retorna un <see cref="Correo"/> con el <see cref="Paquete"/> agregado. Si el Paquete ya estaba agregado, se lanza una <see cref="TrackingIdRepetidoException"/>.</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException(String.Format("\nEl Tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c._mockPaquetes.Add(hilo);
            hilo.Start();
            return c;
        }
        #endregion
    }
}
