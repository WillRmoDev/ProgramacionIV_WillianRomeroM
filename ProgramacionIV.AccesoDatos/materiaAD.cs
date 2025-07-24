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
    public class materiaAD
    {
        public string InsertarMateria(Materia materia)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Materia_Insertar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", materia.Nombre);
                comando.Parameters.AddWithValue("@Codigo", materia.Codigo);
                comando.Parameters.AddWithValue("@Creditos", materia.Creditos);


                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idMateria = (int)comando.Parameters["@IdMateria"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Insertado correctamente con ID: {idMateria}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al insertar la materia: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  Actualizar
        public string ActualizarMateria(Materia materia)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Materia_Actualizar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdMateria", materia.MateriaID);
                comando.Parameters.AddWithValue("@Nombre", materia.Nombre);
                comando.Parameters.AddWithValue("@Codigo", materia.Codigo);
                comando.Parameters.AddWithValue("@Creditos", materia.Creditos);


                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idMateria = (int)comando.Parameters["@IdMateria"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Actualizado correctamente con ID: {idMateria}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al actualizar la materia: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  Borrar
        public string BorrarMateria(int materiaID)
        {
            string respuesta;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Materia_Eliminar", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@IdMateria", materiaID);

                comando.Parameters.Add("@IdMateria", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@CodError", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
                comando.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 1000).Direction = ParameterDirection.Output;

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();

                    int idMateria = (int)comando.Parameters["@IdMateria"].Value;
                    string codError = comando.Parameters["@CodError"].Value.ToString();
                    string mensaje = comando.Parameters["@Mensaje"].Value.ToString();

                    if (codError != "00")
                    {
                        respuesta = $"Error [{codError}]: {mensaje}";
                    }
                    else
                    {
                        respuesta = $"Borrado correctamente con ID: {idMateria}";
                    }
                }
                catch (Exception ex)
                {
                    respuesta = $"Excepción al borrar la materia: {ex.Message}";
                }
            }

            return respuesta;
        }

        //  getID
        public Materia ObtenerMateriaPorID(int materiaID)
        {
            Materia materia = null;
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Materia_ObtenerPorID", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@EstudianteID", materiaID);

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            materia = new Materia
                            {
                                MateriaID = Convert.ToInt32(reader["MateriaID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                Creditos = Convert.ToInt32(reader["Creditos"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el materia por ID: " + ex.Message);
                }
            }

            return materia;
        }

        //  get
        public List<Materia> ObtenerTodasLasMaterias()
        {
            List<Materia> materias = new List<Materia>();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand("pa_Materia_ObtenerTodos", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;

                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Materia materia = new Materia
                            {
                                MateriaID = Convert.ToInt32(reader["MateriaID"]),
                                Nombre = reader["Nombre"].ToString(),
                                Codigo = reader["Codigo"].ToString(),
                                Creditos = Convert.ToInt32(reader["Creditos"])
                            };
                            materias.Add(materia);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo opcional de errores, podrías loguearlo o lanzar excepción
                    throw new Exception("Error al obtener los materias: " + ex.Message);
                }
            }

            return materias;
        }

    }
}
