using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos
        private Correo correo;
        #endregion

        #region Constructor
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Actualiza el contenido de los <see cref="ListBox"/> del Formulario.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            foreach (Paquete paquete in this.correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paquete);
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += this.paq_InformaEstado;
            paquete.InformarException += this.paq_InformaException;
            try
            {
                this.correo += paquete;
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException exception)
            {
                MessageBox.Show(exception.Message,"Paquete repetido",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        private void paq_InformaException(Exception e)
        {
            MessageBox.Show(e.Message, "Error al enviar el paquete a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra los datos de una clase que implementa la interfaz <see cref="IMostrar{T}"/> en un <see cref="RichTextBox"/> y escribe esos datos en un archivo de texto.
        /// </summary>
        /// <param name="elemento">Elemento del cual se van a mostrar los datos.</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(Object.Equals(elemento,null)))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                (elemento.MostrarDatos(elemento)).Guardar("salida.txt");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        #endregion
    }
}
