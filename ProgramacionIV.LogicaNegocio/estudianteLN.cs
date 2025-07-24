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
    public class estudianteLN
    {
        estudianteAD acceso = new estudianteAD();
        public estudianteLN()
        {           
           
        }

        public string InsertarEstudiante(Estudiante estudiante)
        {
           return acceso.InsertarEstudiante(estudiante);
        }

        public string ActualizarEstudiante(Estudiante estudiante)
        {
            return acceso.ActualizarEstudiante(estudiante);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return acceso.ObtenerTodosLosEstudiantes();
        }

        public string BorrarEstudiante(int estudianteID)
        {
            return acceso.BorrarEstudiante(estudianteID);
        }

        public Estudiante ObtenerEstudiantePorID(int estudianteID)
        {
            return acceso.ObtenerEstudiantePorID(estudianteID);
        }
    }
}
