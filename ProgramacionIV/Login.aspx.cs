using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Threading;
using System.Security.Principal;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramacionIV
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = txtUsuario.Text.Trim();
            var password = txtPassword.Text;

            try
            {
                if (TryValidateUser(usuario, password, out string[] roles))
                {
                    // Creamos ticket con roles en UserData
                    var ticket = new FormsAuthenticationTicket(
                        1, usuario, DateTime.Now, DateTime.Now.AddMinutes(120),
                        false, string.Join(",", roles));
                    var enc = FormsAuthentication.Encrypt(ticket);
                    var cookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName, enc);
                    Response.Cookies.Add(cookie);

                    // Redirige a URL original o default
                    var returnUrl = Request.QueryString["ReturnUrl"];
                    Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "~/Views/Estudiantes.aspx" : returnUrl, false);
                }
                else
                {
                    lblError.Text = "Usuario o contraseña inválidos.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
        }

        private bool TryValidateUser(string usuario, string password, out string[] roles)
        {
            roles = new string[0];
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(@"
SELECT TOP 1 Id, PasswordHash, PasswordSalt, Activo
FROM dbo.Usuarios WHERE Usuario=@u", cn))
            {
                cmd.Parameters.AddWithValue("@u", usuario);
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read()) return false;
                    if (!(bool)rd["Activo"]) return false;

                    var userId = (int)rd["Id"];
                    var dbHash = (byte[])rd["PasswordHash"];
                    var dbSalt = (byte[])rd["PasswordSalt"];

                    var calc = HashPassword(password, dbSalt);
                    var ok = CryptographicEquals(dbHash, calc);
                    if (!ok) return false;

                    roles = GetRolesByUserId(cn, userId);
                    return true;
                }
            }
        }

        private string[] GetRolesByUserId(SqlConnection cn, int userId)
        {
            using (var cmd = new SqlCommand(@"
SELECT r.Nombre
FROM dbo.UsuarioRoles ur
JOIN dbo.Roles r ON r.Id = ur.RolId
WHERE ur.UsuarioId=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using (var rd = cmd.ExecuteReader())
                {
                    var list = new System.Collections.Generic.List<string>();
                    while (rd.Read()) list.Add((string)rd["Nombre"]);
                    return list.ToArray();
                }
            }
        }

        // Helpers de seguridad
        public static byte[] HashPassword(string password, byte[] salt)
        {
            //using (var sha = SHA256.Create())
            //{
            //    var passBytes = System.Text.Encoding.UTF8.GetBytes(password);
            //    var input = new byte[salt.Length + passBytes.Length];
            //    Buffer.BlockCopy(salt, 0, input, 0, salt.Length);
            //    Buffer.BlockCopy(passBytes, 0, input, salt.Length, passBytes.Length);
            //    return sha.ComputeHash(input);
            //}
        }

        public static bool CryptographicEquals(byte[] a, byte[] b)
        {
            if (a == null || b == null || a.Length != b.Length) return false;
            int diff = 0; for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}