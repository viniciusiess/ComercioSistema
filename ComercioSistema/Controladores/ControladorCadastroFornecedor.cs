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
    public class ControladorCadastroFornecedor : ControladorCadastro
    {

        protected override string criarComandoSelecao()
        {
            return "SELECT * FROM FORNECEDOR WHERE id = @id";
        }

        protected override string criarComandoInclusao() {
            return "INSERT INTO FORNECEDOR VALUES(@id, @cpf_cnpj, @nome, @telefone, @email, @logradouro, @numero, @complemento, @bairro, @cidade, @uf, @cep)";
        }

        protected override string criarComandoAtualizacao()
        {
            return " UPDATE FORNECEDOR " +
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
            return "DELETE FROM FORNECEDOR WHERE id = @id";
        }

        protected override void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Fornecedor.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_CPF_CNPJ, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_TELEFONE, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_EMAIL, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_LOGRADOURO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_NUMERO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_COMPLEMENTO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_BAIRRO, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_CIDADE, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_UF, MySqlDbType.String);
            comando.Parameters.Add(Fornecedor.ATRIBUTO_CEP, MySqlDbType.String);
        }


        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Fornecedor.ATRIBUTO_ID_FORNECEDOR, MySqlDbType.Int32);
        }

        public DataTable SelecionarTodosFornecedores()
        {
            string comandoSQL = "SELECT * FROM fornecedor";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using(MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable SelecionarFornecedoresPorNome(string nome)
        {
            string comandoSQL = "SELECT * FROM fornecedor WHERE nome LIKE @nome";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                comando.Parameters.AddWithValue("@nome", $"%{nome}%");
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
