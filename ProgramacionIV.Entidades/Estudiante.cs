using System;
using System.Collections.Generic;

namespace ProgramacionIV.Entidades
{
       
    public class Estudiante    {
      
        public Estudiante()
        {
            Matriculas = new HashSet<Matricula>();
        }

        public int EstudianteID { get; set; }

      
        public string Nombre { get; set; }

        
        public string Apellido { get; set; }

       
        public DateTime? FechaNacimiento { get; set; }

       
        public string Correo { get; set; }
     
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
