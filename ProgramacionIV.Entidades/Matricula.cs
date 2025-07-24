using System;

namespace ProgramacionIV.Entidades
{
     
    public class Matricula
    {
        public int MatriculaID { get; set; }

        public int EstudianteID { get; set; }

        public int CursoID { get; set; }

        public DateTime FechaMatricula { get; set; }

        public decimal? NotaFinal { get; set; }

        public int? RegistradoPorProfesorID { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
