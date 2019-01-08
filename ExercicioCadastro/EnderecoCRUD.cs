using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{

    public class EnderecoCRUD : Interfaces.IEnderecoCRUD
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nlasa\source\repos\ExercicioCadastro\ExercicioCadastro\Estrutura.mdf;Integrated Security=True";

        public void Alterar(Endereco endereco)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE enderecos SET
                                    estado =@ESTADO,
                                    cidade = @CIDADE,
                                    bairro =@BAIRRO,
                                    cep = @CEP,
                                    numero = @NUMERO,
                                    complemento = @COMPLEMENTO
                                    WHERE id= @ID";
            comando.Parameters.AddWithValue("@ESTADO", endereco.Estado);
            comando.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", endereco.Bairro);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            comando.Parameters.AddWithValue("@ID", endereco.Id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Apagar(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE enderecos SET registro_ativo = 0 WHERE id =@ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public int Inserir(Endereco endereco)
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = connectionString;
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO enderecos
                                  (cidade, estado, bairro, cep, numero, complemento, registro_ativo)
                                  OUTPUT INSERTED.ID
                                  VALUES (@CIDADE, @BAIRRO, @CEP, @NUMERO, @COMPLEMENTO, 1)";
            comando.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", endereco.Bairro);
            comando.Parameters.AddWithValue("@ESTADO", endereco.Estado);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);

            int id = Convert.ToInt32(comando.ExecuteScalar().ToString());
            conexao.Close();
            return id;

        }

        public Endereco ObterPeloId(int id)
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM enderecos WHERE id = @ID and registro_ativo =1";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());
            if (table.Rows.Count == 1)
            {
                Endereco endereco = new Endereco();
                DataRow row = table.Rows[0];
                endereco.Id = Convert.ToInt32(row["id"].ToString());
                endereco.Cidade = row["cidade"].ToString();
                endereco.Bairro = row["bairro"].ToString();
                endereco.Cep = row["cep"].ToString();
                endereco.Numero = Convert.ToInt16(row["numero"]);
                endereco.Complemento = row["complemento"].ToString();
                return endereco;    
            }
            return null;
        }

        public List<Endereco> ObterTodos()
        {
            SqlConnection conexao = new SqlConnection(connectionString);
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"SELECT * FROM enderecos WHERE registro_ativo = 1";

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());

            List<Endereco> enderecos = new List<Endereco>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Endereco endereco = new Endereco();
                DataRow row = table.Rows[i];
                endereco.Id = Convert.ToInt32(row["id"].ToString());
                endereco.Cidade = row["cidade"].ToString();
                endereco.Bairro = row["bairro"].ToString();
                endereco.Cep = row["cep"].ToString();
                endereco.Numero = Convert.ToInt16(row["numero"].ToString());
                endereco.Complemento = row["complemento"].ToString();
                enderecos.Add(endereco);

            }
            return enderecos;
        }
    }
}
