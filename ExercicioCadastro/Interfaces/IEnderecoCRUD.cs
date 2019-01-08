using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro.Interfaces
{
    internal interface IEnderecoCRUD 
    {
        List<Endereco> ObterTodos();

        Endereco ObterPeloId(int id);

        int Inserir(Endereco endereco);

        void Alterar(Endereco endereco);

        void Apagar(int id);
    }
}
