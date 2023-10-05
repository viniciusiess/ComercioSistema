using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComercioSistema.Persistencia;
using ComercioSistema.Entidades;
using ComercioSistema.Controladores;
using MySql.Data.MySqlClient;
using System.Data;

namespace AcessoBancoDados.Controladores
{
    public class ControladorCadastroCliente : ControladorCadastro
    {

        protected override string criarComandoSelecao()
        {
            return "SELECT * FROM CLIENTE WHERE id = @id";
        }

        protected override string criarComandoInclusao() {
            return "INSERT INTO CLIENTE VALUES(@id, @cpf_cnpj, @nome, @telefone, @email, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep)";
        }

        protected override string criarComandoAtualizacao()
        {
            return " UPDATE CLIENTE " +
                   " SET cpf_cnpj = @cpf_cnpj, " +
                   "     nome = @nome, " +
                   "     telefone = @telefone, " +
                   "     email = @email, " +
                   "     logradouro = @logradouro, " +
                   "     numero = @numero, " +
                   "     complemento = @complemento, " +
                   "     bairro = @bairro, " +
                   "     cidade = @cidade, " +
                   "     uf = @uf, " +
                   "     cep = @cep" +
                   " WHERE id = @id";
        }

        protected override string criarComandoExclusao()
        {
            return "DELETE FROM CLIENTE WHERE id = @id";
        }

        protected override void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Cliente.ATRIBUTO_ID_CLIENTE, MySqlDbType.Int32);
            comando.Parameters.Add(Cliente.ATRIBUTO_CPF_CNPJ, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_TELEFONE, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_EMAIL, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_LOGRADOURO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_NUMERO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_COMPLEMENTO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_BAIRRO, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_CIDADE, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_UF, MySqlDbType.String);
            comando.Parameters.Add(Cliente.ATRIBUTO_CEP, MySqlDbType.String);
        }


        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Cliente.ATRIBUTO_ID_CLIENTE, MySqlDbType.Int32);
        }

        public DataTable SelecionarTodosCliente()
        {
            string comandoSQL = "SELECT * FROM cliente";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using(MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable SelecionarClientesPorNome(string nome)
        {
            string comandoSQL = "SELECT * FROM cliente WHERE nome LIKE @nome";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using(MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                comando.Parameters.AddWithValue("@nome", $"%{nome}%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public string ObterNomeClientePorId(int clienteId)
        {
            string comandoSQL = "SELECT nome FROM cliente WHERE id = @id";

            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                comando.Parameters.AddWithValue("@id", clienteId);

                try
                {
                    conexao.Open();
                    var result = comando.ExecuteScalar();

                    // Verifica se o resultado não é nulo e converte para string
                    return result != null ? result.ToString() : string.Empty;
                }
                catch (Exception ex)
                {
                    // Lidar com exceções conforme necessário
                    Console.WriteLine("Erro ao obter o nome do cliente por ID: " + ex.Message);
                    return string.Empty;
                }
            }
        }
    }
}
