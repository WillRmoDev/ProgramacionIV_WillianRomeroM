using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramacionIV.Entidades;
using System.Configuration;
using System.Data.SqlClient;

namespace ProgramacionIV.AccesoDatos
{
    public class estudianteAD
    {
        public string InsertarEstudiante(Estudiante estudiante)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Estudiante_Insertar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                comando.Parameters.AddWithValue("@Correo", estudiante.Correo);
               

                comando.Parameters.Add("@IdEstudiante", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idEstudiante = (int)comando.Parameters["@IdEstudiante"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Insertado correctamente con ID: {idEstudiante}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al insertar estudiante: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  Actualizar
        public string ActualizarEstudiante(Estudiante estudiante)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Estudiante_Actualizar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@EstudianteID", estudiante.EstudianteID);
                comando.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                comando.Parameters.AddWithValue("@Apellido", estudiante.Apellido);
                comando.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                comando.Parameters.AddWithValue("@Correo", estudiante.Correo);


                comando.Parameters.Add("@IdEstudiante", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idEstudiante = (int)comando.Parameters["@IdEstudiante"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Actualizado correctamente con ID: {idEstudiante}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al actualizar estudiante: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  Borrar
        public string BorrarEstudiante(int estudianteID)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Estudiante_Eliminar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@EstudianteID", estudianteID);

                comando.Parameters.Add("@IdEstudiante", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idEstudiante = (int)comando.Parameters["@IdEstudiante"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Borrado correctamente con ID: {idEstudiante}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al borrar estudiante: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  getID
        public Estudiante ObtenerEstudiantePorID(int estudianteID)
        {
            Estudiante estudiante = null;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Estudiante_ObtenerPorID", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@EstudianteID", estudianteID);

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estudiante = new Estudiante
                            {
                                EstudianteID = Convert.ToInt32(reader["EstudianteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                Correo = reader["Correo"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el estudiante por ID: " + ex.Message);
                }
            }

            return estudiante;
        }

        //  get
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Estudiante_ObtenerTodos", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Estudiante estudiante = new Estudiante
                            {
                                EstudianteID = Convert.ToInt32(reader["EstudianteID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                                Correo = reader["Correo"].ToString()
                            };
                            estudiantes.Add(estudiante);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo opcional de errores, podrías loguearlo o lanzar excepción
                    throw new Exception("Error al obtener los estudiantes: " + ex.Message);
                }
            }

            return estudiantes;
        }

    }
}
