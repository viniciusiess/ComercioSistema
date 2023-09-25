using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ComercioSistema.Persistencia
{
    internal class BancoDados
    {
        private int porta = 3307;
        private string servidor = "localhost";
        private string nomeBancoDados = "comercio_db";
        private MySqlConnection conexao;
        private MySqlTransaction transacao;
        private static BancoDados instancia = null;

        private string criarStringConexao(string usuario, string senha)
        {
            return "server = " + servidor +
                   ";port = " + porta.ToString() +
                   ";user id = " + usuario +
                   ";database = " + nomeBancoDados +
                   ";password = " + senha;
        }

        public void conectar(string usuario, string senha)
        {
            try
            {
                if (conexao == null || conexao.State == System.Data.ConnectionState.Closed)
                {
                    conexao = new MySqlConnection(criarStringConexao(usuario, senha));
                    conexao.Open();
                    MessageBox.Show("Conexão realizada com sucesso");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void conectar()
        {
            conectar("root", "usbw");
        }

        public void desconectar()
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();
            }
        }

        public static BancoDados obterInstancia()
        {
            if (instancia == null)
            {
                instancia = new BancoDados();
            }
            return instancia;
        }

        public MySqlConnection obterConexao()
        {
            return conexao;
        }

        public void iniciarTransacao()
        {
            transacao = conexao.BeginTransaction();
        }

        public void confirmarTransacao()
        {
            if(transacao != null)
            {
                transacao.Commit();
                transacao.Dispose();
            }
        }

        public void cancelarTransacao()
        {
            try
            {
                if (transacao != null)
                {
                    transacao.Rollback();
                    transacao.Dispose();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao cancelar a transação: {ex.Message}", "Erro de Transação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro desconhecido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
