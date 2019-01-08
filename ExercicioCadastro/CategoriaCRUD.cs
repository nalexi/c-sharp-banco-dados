using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    public class CategoriaCRUD : Interfaces.ICatergoriaCRUD
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nlasa\source\repos\ExercicioCadastro\ExercicioCadastro\Estrutura.mdf;Integrated Security=True";
        //private readonly string connectionString =   @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\NLASA\SOURCE\REPOS\EXERCICIOCADASTRO\EXERCICIOCADASTRO\ESTRUTURA.MDF";
        public void Alterar(Categoria categoria)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE categorias SET
                                    nome = @NOME,
                                    WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", categoria.Nome);
            comando.Parameters.AddWithValue("@ID", categoria.Id);
            comando.ExecuteNonQuery();
            conexao.Close();

        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE categorias SET registro_ativo WHERE id=@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public int Inserir(Categoria categoria)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO categorias
                                    (nome, registro_ativo)
                                    OUTPUT INSERTED.ID
                                    VALUES (@NOME, 1)";
            comando.Parameters.AddWithValue("@NOME", categoria.Nome);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());

            conexao.Close();
            return id;
        }

        public Categoria ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM categorias WHERE registro_ativo =1";

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            if (table.Rows.Count == 1)
            {
                Categoria categoria = new Categoria();
                DataRow row = table.Rows[0];
                categoria.Id = Convert.ToInt32(row["id"].ToString());
                categoria.Nome = row["nome"].ToString();
                return categoria;    
            }
            return null;
        }

        public List<Categoria> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM categorias WHERE registro_ativo = 1";
            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Categoria> categorias = new List<Categoria>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Categoria categoria = new Categoria();
                categoria.Id = Convert.ToInt32(table.Rows[0]["id"].ToString());
                categoria.Nome = table.Rows[0]["nome"].ToString();

            }
            return categorias;
                

        }
    }
}
