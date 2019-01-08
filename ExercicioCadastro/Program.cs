using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCadastro
{
    class Program
    {
        static void Main(string[] args)
         {
            EnderecoCRUD endereco = new EnderecoCRUD();
            PessoaCRUD pessoa = new PessoaCRUD();
          /*

            Pessoa people = pessoa.ObterPeloId(4);
            if (people == null)
            {
                Console.WriteLine("non ecxiste");
            }
            else
            {
                Console.WriteLine(people.ToString());
            }*/

            Pessoa fisica = new Pessoa();
            {
                fisica.Nome = "djeison";
                fisica.Cpf = "000.000.255-14";
                fisica.Rg = "*45/464.55";
                fisica.DataNascimento = DateTime.Now;
                fisica.Sexo = 'f';
                fisica.Idade = 23;
                fisica.RegistroAtivo = true;
            }
            int id = pessoa.Inserir(fisica);
            //pessoa.Apagar(3);
            /*
            Pessoa fisica = new Pessoa();
            {
                fisica.Nome = "djeison";
                fisica.Cpf = "000.000.255-14";
                fisica.Rg = "*45/464.55";
                fisica.DataNascimento = DateTime.Now;
                fisica.Sexo = 'f';
                fisica.Idade = 23;
                fisica.RegistroAtivo = true;
            }
            pessoa.Inserir(fisica);

            int id = pessoa.Inserir(fisica);
            fisica.Id = id;
            fisica.Sexo = 'm';
            pessoa.Alterar(fisica);
            */

            /*
             Endereco gaspar = new Endereco();
              {
                  gaspar.Cidade = "gasxpa";
                  gaspar.Bairro = "nova";
                  gaspar.Cep = "6554";
                  gaspar.Estado = "PR";
                  gaspar.Numero = 354;
                  gaspar.RegistroAtivo = true;
                  gaspar.Complemento = "casa";
              }
              endereco.Inserir(gaspar);
              */


            /* int id = endereco.Inserir(blumenau);
             blumenau.Id = id;
             blumenau.Bairro = "velha";
             endereco.Alterar(blumenau);*/


            /*Endereco ende = endereco.ObterPeloId(1);
            if (ende == null)
            {
                Console.WriteLine("Endereço nao encontrado");
            }
            else
            {
                Console.WriteLine(ende.ToString());
            }*/

            /* CategoriaCRUD categoria = new CategoriaCRUD();
             Categoria compra = new Categoria();
             compra.Nome = "acho";
             categoria.Inserir(compra);*/

            /*
            EnderecoCRUD blumenau = new EnderecoCRUD();
            {
            blumenau.Cidade = "Blumenau";
            }
            endereco.Inserir(blumenau);*/



        }
    }
}
