using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    public class PessoaCRUD : Interfaces.IPessoaCRUD
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nlasa\source\repos\ExercicioCadastro\ExercicioCadastro\Estrutura.mdf;Integrated Security=True;Connect Timeout=30";
        public void Alterar(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE pessoas SET
                                    nome =@NOME,
                                    cpf = @CPF,
                                    rg =@RG,
                                    data_nascimento = @DATA_NASCIMENTO,
                                    sexo = @SEXO,
                                    idade = @IDADE
                                    WHERE id= @ID";
            comando.Parameters.AddWithValue("@NOME", pessoa.Nome);
            comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            comando.Parameters.AddWithValue("@RG", pessoa.Rg);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", pessoa.DataNascimento);
            comando.Parameters.AddWithValue("@SEXO", pessoa.Sexo);
            comando.Parameters.AddWithValue("@IDADE", pessoa.Idade);
            comando.Parameters.AddWithValue("@ID", pessoa.Id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE pessoas SET registro_ativo = 0 WHERE id =@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public int Inserir(Pessoa pessoa)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = connectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO pessoas
                                  (nome, cpf, rg, data_nascimento, sexo, idade, registro_ativo)
                                  OUTPUT INSERTED.ID
                                  VALUES (@NOME, @CPF, @RG, @DATA_NASCIMENTO, @SEXO, @IDADE, 1)";
            comando.Parameters.AddWithValue("@NOME", pessoa.Nome);
            comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            comando.Parameters.AddWithValue("@RG", pessoa.Rg);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", pessoa.DataNascimento);
            comando.Parameters.AddWithValue("@SEXO", pessoa.Sexo);
            comando.Parameters.AddWithValue("@IDADE", pessoa.Idade);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            conexao.Close();
            return id;
        }
        public Pessoa ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM pessoas WHERE id = @ID and registro_ativo =1";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                Pessoa pessoa = new Pessoa();
                DataRow row = table.Rows[0];
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Cpf = row["cpf"].ToString();
                pessoa.Rg = row["rg"].ToString();
                pessoa.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
                pessoa.Sexo = Convert.ToChar(row["sexo"].ToString());
                pessoa.Idade = Convert.ToInt16(row["idade"].ToString());
                return pessoa;
            }
            return null;
        }

        public List<Pessoa> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM pessoas WHERE registro_ativo = 1";

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Pessoa pessoa = new Pessoa();
                DataRow row = table.Rows[i];
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Cpf = row["cpf"].ToString();
                pessoa.Rg = row["rg"].ToString();
                pessoa.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
                pessoa.Sexo = Convert.ToChar(row["sexo"].ToString());
                pessoa.Idade = Convert.ToInt16(row["idade"].ToString());
                pessoas.Add(pessoa);
            }

           /* foreach (DataRow row in table.Rows)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Id = Convert.ToInt32(row["id"].ToString());
                pessoa.Nome = row["nome"].ToString();
                pessoa.Cpf = row["cpf"].ToString();
                pessoa.Rg = row["rg"].ToString();
                pessoa.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
                pessoa.Sexo = Convert.ToChar(row["sexo"].ToString());
                pessoa.Idade = Convert.ToInt16(row["idade"].ToString());
                pessoas.Add(pessoa);

            }
            */
            return pessoas;
        }
    }
}
