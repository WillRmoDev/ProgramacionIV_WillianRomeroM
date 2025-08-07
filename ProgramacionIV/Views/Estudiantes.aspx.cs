using ProgramacionIV.ServiceReferenceUniversidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramacionIV.Views
{
    public partial class Estudiantes : Page
    {
        string respuestaMetodo = string.Empty;
        List<Estudiante> estudiantes = new List<Estudiante>(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
            {
                respuestaMetodo = vWCFClient.ProbarConexion();
                //mensajeDesdeServicio.InnerText = respuestaMetodo;
                if (respuestaMetodo == "200")
                {
                    estudiantes = vWCFClient.ObtenerEstudiantes();
                    gvEstudiantes.DataSource = estudiantes;
                    gvEstudiantes.DataBind();

                }

                txtId.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtApellidos.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtFechaNacimiento.Text = string.Empty;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
            {
                respuestaMetodo = vWCFClient.ProbarConexion();
                //mensajeDesdeServicio.InnerText = respuestaMetodo;
            }
            if (respuestaMetodo == "200")
            {
                // Obtener datos del formulario
                string id = txtId.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);// error al convertir a fecha

                // Validaciones básicas (puedes hacer más detalladas si gustas)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(txtFechaNacimiento.Text))
                {
                    // Aquí podrías mostrar un mensaje en una etiqueta (lblMensaje.Text = "Complete los campos obligatorios")
                    return;
                }

                // Simular guardado (por ejemplo, en base de datos)
                using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
                {
                    Estudiante estudiante = new Estudiante()
                    {
                        EstudianteID = !string.IsNullOrEmpty(id) ? int.Parse(id): 0,
                        Nombre = nombre,
                        Apellido = apellidos,
                        Correo = correo,
                        FechaNacimiento = fechaNacimiento
                    };

                    // Esto inserta un nuevo registro
                    if (estudiante.EstudianteID == 0)
                    {
                        var respuestaMetodo = vWCFClient.InsertarEstudiante(estudiante);
                    } else
                    {
                        // Actualiza un registro
                        var respuestaMetodo = vWCFClient.ActualizarEstudiante(estudiante);

                    }

                    estudiantes = vWCFClient.ObtenerEstudiantes();
                    gvEstudiantes.DataSource = estudiantes;
                    gvEstudiantes.DataBind();
                }

                // Mostrar mensaje de éxito o no
                Response.Write("<script>alert('Persona guardada correctamente');</script>");

            }

        }

        protected void gvEstudiantes_acciones(object sender, GridViewCommandEventArgs e)
        {
            // Obtiene el índice de la fila seleccionada
            int index = Convert.ToInt32(e.CommandArgument);
            int estudianteID = Convert.ToInt32(gvEstudiantes.DataKeys[index].Value);

            // seleccionar para actualizar en el form
            if (e.CommandName == "Seleccionar")
            {
                Response.Write($"Seleccionado estudiante con ID: {estudianteID}");
            }
            else if (e.CommandName == "Eliminar")
            {
                // Llamar al servicio para eliminar el estudiante
                using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
                {
                    string resultado = vWCFClient.BorrarEstudiante(estudianteID);
                    respuestaMetodo = resultado;
                    if (resultado.Contains("correctamente"))
                    {
                        estudiantes = vWCFClient.ObtenerEstudiantes();
                        gvEstudiantes.DataSource = estudiantes;
                        gvEstudiantes.DataBind();
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        Response.Write("Error al eliminar el estudiante.");
                    }
                }
            }
        }
    }
}