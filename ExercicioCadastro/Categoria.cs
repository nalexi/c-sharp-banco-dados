using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    public class Categoria
    {
        public int Id;
        public string Nome;
        public bool RegistroAtivo;

        public override string ToString()
        {
            return Id + " - " + Nome;
        }
    }   
}
