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
    public class ControladorCadastroProduto : ControladorCadastro
    {

        protected override string criarComandoSelecao()
        {
            return "SELECT * FROM PRODUTO WHERE id = @id";
        }

        protected override string criarComandoInclusao()
        {
            return "INSERT INTO PRODUTO (nome, preco, estoque, unidade, classificacao_id, fornecedor_id) " +
                   "VALUES (@nome, @preco, @estoque, @unidade, @classificacao_id, @fornecedor_id)";
        }

        protected override string criarComandoAtualizacao()
        {
            return " UPDATE PRODUTO " +
                   " SET nome = @nome, " +
                   "     estoque = @estoque, " +
                   "     preco = @preco, " +
                   "     unidade = @unidade, " +
                   " WHERE id = @id";
        }

        protected override string criarComandoExclusao()
        {
            return "DELETE FROM PRODUTO WHERE id = @id";
        }

        protected override void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Produto.ATRIBUTO_ID_PRODUTO, MySqlDbType.Int32);
            comando.Parameters.Add(Produto.ATRIBUTO_NOME, MySqlDbType.String);
            comando.Parameters.Add(Produto.ATRIBUTO_ESTOQUE, MySqlDbType.Int32);
            comando.Parameters.Add(Produto.ATRIBUTO_UNIDADE, MySqlDbType.String);
            comando.Parameters.Add(Produto.ATRIBUTO_PRECO, MySqlDbType.Float);
        }


        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Produto.ATRIBUTO_ID_PRODUTO, MySqlDbType.Int32);
        }

        public DataTable SelecionarTodosProdutos()
        {
            string comandoSQL = "SELECT * FROM produto";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable SelecionarTodosProdutosComNomes()
        {
            string comandoSQL = "SELECT P.id, P.nome, C.nome AS nome_classificacao, F.nome AS nome_fornecedor FROM produto P " +
                                "INNER JOIN classificacaoproduto C ON P.classificacao_id = C.id " +
                                "INNER JOIN fornecedor F ON P.fornecedor_id = F.id";

            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable SelecionarProdutosPorNome(string nome)
        {
            string comandoSQL = "SELECT * FROM produto WHERE nome LIKE @nome";
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