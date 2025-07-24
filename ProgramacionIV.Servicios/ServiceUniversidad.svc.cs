using ProgramacionIV.Entidades;
using ProgramacionIV.LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProgramacionIV.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceUniversidad" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceUniversidad.svc or ServiceUniversidad.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUniversidad : IService1
    {
        logicaNegocio negocio = new logicaNegocio();
        estudianteLN estudianteLN = new estudianteLN();
        materiaLN materiaLN = new materiaLN();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GuardarProfesor(Profesor profesor)
        {
            return "OK";
        }       

        public string ProbarConexion()
        {
            return negocio.ProbarConexion();
        }

        public string InsertarEstudiante(Estudiante estudiante)
        {

            return estudianteLN.InsertarEstudiante(estudiante);

        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return estudianteLN.ObtenerEstudiantes();
        }

        public string BorrarEstudiante(int estudianteID)
        {
            return estudianteLN.BorrarEstudiante(estudianteID);
        }

        public string ActualizarEstudiante(Estudiante estudiante)
        {
            return estudianteLN.ActualizarEstudiante(estudiante);
        }

        public Estudiante ObtenerEstudiantePorID(int estudianteID)
        {
            return estudianteLN.ObtenerEstudiantePorID(estudianteID);
        }

        public string InsertarMateria(Materia materia)
        {

            return materiaLN.InsertarMateria(materia);

        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            return materiaLN.ObtenerTodasLasMaterias();
        }

        public string BorrarMateria(int materiaID)
        {
            return materiaLN.BorrarMateria(materiaID);
        }

        public string ActualizarMateria(Materia materia)
        {
            return materiaLN.ActualizarMateria(materia);
        }

        public Materia ObtenerMateriaPorID(int materiaID)
        {
            return materiaLN.ObtenerMateriaPorID(materiaID);
        }

    }
}
