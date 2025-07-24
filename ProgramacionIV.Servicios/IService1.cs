using ProgramacionIV.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProgramacionIV.Servicios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string GuardarProfesor(Profesor profesor);

        [OperationContract]
        string ProbarConexion();

        [OperationContract]
        string InsertarEstudiante(Estudiante estudiante);

        [OperationContract]
        List<Estudiante> ObtenerEstudiantes();

        [OperationContract]
        string BorrarEstudiante(int estudianteID);

        [OperationContract]
        string ActualizarEstudiante(Estudiante estudiante);

        [OperationContract]
        Estudiante ObtenerEstudiantePorID(int estudianteID);

        [OperationContract]
        string InsertarMateria(Materia materia);

        [OperationContract]
        List<Materia> ObtenerTodasLasMaterias();

        [OperationContract]
        string BorrarMateria(int materiaID);

        [OperationContract]
        string ActualizarMateria(Materia materia);

        [OperationContract]
        Materia ObtenerMateriaPorID(int materiaID);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
