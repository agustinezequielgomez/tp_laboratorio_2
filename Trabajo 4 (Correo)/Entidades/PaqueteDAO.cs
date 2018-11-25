using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Atributos
        private static SqlCommand _comando;
        private static SqlConnection _conexion;
        #endregion
                
        #region Constructor
        /// <summary>
        /// Inicializa los atributos estaticos de la clase <see cref="PaqueteDAO"/>.
        /// </summary>
        static PaqueteDAO()
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.conexion);
            PaqueteDAO._comando = new SqlCommand();

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda un <see cref="Paquete"/> en la base de datos. 
        /// </summary>
        /// <param name="p"><see cref="Paquete"/> a guardar en la base de datos.</param>
        /// <returns>Retorna <see cref="true"/> si el <see cref="Paquete"/> logro guardarse con exito, si ocurrio un error lanza la excepcion correspondiente.</returns>
        public static bool Insertar(Paquete p)
        {
            PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO._comando.CommandText = String.Format("INSERT INTO Paquetes values('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Agustin Gomez");
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;
            try
            {
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                PaqueteDAO._conexion.Close();
            }
            catch(Exception e)
            {
                throw e;
            }
            return true;
        }
        #endregion
    }
}
