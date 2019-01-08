using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro.Interfaces
{
    interface IPessoaCRUD
    {
        List<Pessoa> ObterTodos();

        Pessoa ObterPeloId(int id);

        int Inserir(Pessoa pessoa);

        void Alterar(Pessoa pessoa);

        void Apagar(int id);
    }
}
