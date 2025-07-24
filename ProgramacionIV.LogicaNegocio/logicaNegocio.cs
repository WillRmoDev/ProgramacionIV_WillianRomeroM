using ProgramacionIV.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionIV.LogicaNegocio
{
    public class logicaNegocio
    {
        coneccion acceso = new coneccion();
        public logicaNegocio()
        {           
           
        }
        public string ProbarConexion()
        {
            return acceso.ProbarConexion();
        }
    }
}
