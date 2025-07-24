using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System;

namespace ProgramacionIV.AccesoDatos
{
    public class coneccion
    {
        private readonly string connectionString;

        public coneccion()
        {
            // Asegúrate de tener este string en tu Web.config o App.config
            connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
        }
        public string ProbarConexion()
        {
            string mensaje = string.Empty;
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    mensaje = "200";
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                mensaje = "500";
                return mensaje;
            }
        }
        // Para procedimientos almacenados
        public DataTable EjecutarProcedimiento(string nombreSP, SqlParameter[] parametros = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    return resultado;
                }
            }
        }
    }
}
