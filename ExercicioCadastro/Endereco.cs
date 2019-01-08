using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    public class Endereco
    {
        public int Id;
        public string Estado;
        public string Cidade;
        public string Bairro;
        public string Cep;
        public short Numero;
        public string Complemento;
        public bool RegistroAtivo;

        public override string ToString()
        {
            return Id + " - " + Estado + " - " + Cidade + " - " + Bairro + " - " + Cep + " - " + Numero + " - " + Complemento;
        }

    }
}
