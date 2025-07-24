using System.Collections.Generic;

namespace ProgramacionIV.Entidades
{
 

    
    public  class Curso
    {
       
        public Curso()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int CursoID { get; set; }

        public int MateriaID { get; set; }

        public int ProfesorID { get; set; }

        public int Anio { get; set; }

        public byte Semestre { get; set; }

        public virtual Materia Materia { get; set; }

        public virtual Profesor Profesor { get; set; }
       
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
