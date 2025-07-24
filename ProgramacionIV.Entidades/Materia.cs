using System.Collections.Generic;

namespace ProgramacionIV.Entidades
{
     
    public  class Materia
    {
       
        public Materia()
        {
            Cursoes = new HashSet<Curso>();
        }

        public int MateriaID { get; set; }

       
        public string Nombre { get; set; }

       
        public string Codigo { get; set; }

        public int Creditos { get; set; }
      
        public virtual ICollection<Curso> Cursoes { get; set; }
    }
}
