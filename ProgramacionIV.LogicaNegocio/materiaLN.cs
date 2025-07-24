using ProgramacionIV.AccesoDatos;
using ProgramacionIV.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionIV.LogicaNegocio
{
    public class materiaLN
    {
        materiaAD acceso = new materiaAD();
        public materiaLN()
        {           
           
        }

        public string InsertarMateria(Materia materia)
        {
           return acceso.InsertarMateria(materia);
        }

        public string ActualizarMateria(Materia materia)
        {
            return acceso.ActualizarMateria(materia);
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            return acceso.ObtenerTodasLasMaterias();
        }

        public string BorrarMateria(int materiaID)
        {
            return acceso.BorrarMateria(materiaID);
        }

        public Materia ObtenerMateriaPorID(int materiaID)
        {
            return acceso.ObtenerMateriaPorID(materiaID);
        }
    }
}
