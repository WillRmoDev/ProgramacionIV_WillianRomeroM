using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramacionIV
{
    public partial class _Default : Page
    {
        string respuestaMetodo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
            {
                respuestaMetodo = vWCFClient.ProbarConexion();
                //mensajeDesdeServicio.InnerText = respuestaMetodo;
            }
            if (respuestaMetodo=="200")
            {
                // Obtener datos del formulario
                string nombre = txtNombre.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string sexo = rbMasculino.Checked ? "Masculino" : (rbFemenino.Checked ? "Femenino" : "");
                string nacionalidad = ddlNacionalidad.SelectedValue;
                int edad = 0;
                int.TryParse(txtEdad.Text, out edad);
                string correo = txtCorreo.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                // Validaciones básicas (puedes hacer más detalladas si gustas)
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(sexo))
                {
                    // Aquí podrías mostrar un mensaje en una etiqueta (lblMensaje.Text = "Complete los campos obligatorios")
                    return;
                }

                // Simular guardado (por ejemplo, en base de datos)
                using (ServiceReferenceUniversidad.Service1Client vWCFClient = new ServiceReferenceUniversidad.Service1Client())
                {
                    ServiceReferenceUniversidad.Profesor profesor = new ServiceReferenceUniversidad.Profesor();
                    profesor.Nombre = nombre;
                    var respuestaMetodo = vWCFClient.GuardarProfesor(profesor);
                }

                // Mostrar mensaje de éxito o redirigir
                Response.Write("<script>alert('Persona guardada correctamente');</script>");
            }
            
        }
    }
}