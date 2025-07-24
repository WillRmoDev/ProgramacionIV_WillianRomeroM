using ProgramacionIV.ServiceReferenceUniversidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramacionIV.Views
{
    public partial class Materias : System.Web.UI.Page
    {
        string respuestaMetodo = string.Empty;
        List<Materia> materias = new List<Materia>();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
            {
                respuestaMetodo = vWCFClient.ProbarConexion();
                //mensajeDesdeServicio.InnerText = respuestaMetodo;
                if (respuestaMetodo == "200")
                {
                    materias = vWCFClient.ObtenerTodasLasMaterias();
                    gvMaterias.DataSource = materias;
                    gvMaterias.DataBind();

                }

                txtId.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtCodigo.Text = string.Empty;
                txtCreditos.Text = string.Empty;
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
                string codigo = txtCodigo.Text.Trim();
                string creditos = txtCreditos.Text.Trim();

                // Validaciones básicas (puedes hacer más detalladas si gustas)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(creditos))
                {
                    // Aquí podrías mostrar un mensaje en una etiqueta (lblMensaje.Text = "Complete los campos obligatorios")
                    return;
                }

                // Simular guardado (por ejemplo, en base de datos)
                using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
                {
                    Materia materia = new Materia()
                    {
                        MateriaID = !string.IsNullOrEmpty(id) ? int.Parse(id) : 0,
                        Nombre = nombre,
                        Codigo = codigo,
                        Creditos = Convert.ToInt32(creditos)
                    };

                    if (materia.MateriaID == 0)
                    {
                        var respuestaMetodo = vWCFClient.InsertarMateria(materia);
                    }
                    else
                    {
                        var respuestaMetodo = vWCFClient.ActualizarMateria(materia);

                    }

                    materias = vWCFClient.ObtenerTodasLasMaterias();
                    gvMaterias.DataSource = materias;
                    gvMaterias.DataBind();
                }

                // Mostrar mensaje de éxito o no
                Response.Write("<script>alert('Persona guardada correctamente');</script>");

            }

        }

        protected void gvMateria_acciones(object sender, GridViewCommandEventArgs e)
        {
            // Obtiene el índice de la fila seleccionada
            int index = Convert.ToInt32(e.CommandArgument);
            int materiaID = Convert.ToInt32(gvMaterias.DataKeys[index].Value);

            if (e.CommandName == "Seleccionar")
            {
                Response.Write($"Seleccionado materia con ID: {materiaID}");
            }
            else if (e.CommandName == "Eliminar")
            {
                // Llamar al servicio para eliminar el materia
                using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
                {
                    string resultado = vWCFClient.BorrarMateria(materiaID);
                    respuestaMetodo = resultado;
                    if (resultado.Contains("correctamente"))
                    {
                        materias = vWCFClient.ObtenerTodasLasMaterias();
                        gvMaterias.DataSource = materias;
                        gvMaterias.DataBind();
                    }
                    else
                    {
                        // Mostrar mensaje de error
                        Response.Write("Error al eliminar el materia.");
                    }
                }
            }
        }
    }
}