using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComercioSistema.Entidades;
using ComercioSistema.Controladores;
using MySql.Data.MySqlClient;
using System.Data;
using ComercioSistema.Persistencia;

namespace AcessoBancoDados.Controladores
{
    public class ControladorCadastroClassificacaoProduto : ControladorCadastro
    {
        protected override string criarComandoSelecao()
        {
            return "SELECT * FROM CLASSIFICACAOPRODUTO WHERE id = @id";
        }

        protected override string criarComandoInclusao()
        {
            return "INSERT INTO CLASSIFICACAOPRODUTO VALUES(@id, @nome, @descricao)";
        }

        protected override string criarComandoAtualizacao()
        {
            return " UPDATE CLASSIFICACAOPRODUTO " +
                   " SET nome = @nome, " +
                   "     descricao = @descricao" +
                   " WHERE id = @id";
        }

        protected override string criarComandoExclusao()
        {
            return "DELETE FROM CLASSIFICACAOPRODUTO WHERE id = @id";
        }

        protected override void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(ClassificacaoProduto.ATRIBUTO_ID_CLASSIFICACAOPRODUTO, MySqlDbType.Int32);
            comando.Parameters.Add(ClassificacaoProduto.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(ClassificacaoProduto.ATRIBUTO_DESCRICAO, MySqlDbType.Text);
        }


        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(ClassificacaoProduto.ATRIBUTO_ID_CLASSIFICACAOPRODUTO, MySqlDbType.Int32);
        }

        public DataTable SelecionarTodosClassificaoProdutos()
        {
            string comandoSQL = "SELECT * FROM classificacaoproduto";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable SelecionarClassificacaoProdutosPorNome(string nome)
        {
            string comandoSQL = "SELECT * FROM classificacaoProduto WHERE nome LIKE @nome";
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