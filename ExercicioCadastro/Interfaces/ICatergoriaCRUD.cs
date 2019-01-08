using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro.Interfaces
{
    interface ICatergoriaCRUD
    {
        List<Categoria> ObterTodos();

        Categoria ObterPeloId(int id);

        int Inserir(Categoria categoria);

        void Alterar(Categoria categoria);

        void Apagar(int id);

    }
}
