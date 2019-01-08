using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    public class Pessoa
    {
        public int Id;
        public string Nome;
        public string Cpf;
        public string Rg;
        public DateTime DataNascimento;
        public char Sexo;
        public short Idade;
        public bool RegistroAtivo;

        public override string ToString()
        {
            return Id + " " + Nome + " " + Cpf + " " + Rg + " " + DataNascimento + " " + Sexo + " " + Idade + " " + RegistroAtivo;
        }
    }
}
