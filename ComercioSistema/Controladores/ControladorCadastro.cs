using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using ComercioSistema.Controladores;
using ComercioSistema.Persistencia;
using ComercioSistema.Entidades;
using System.Windows.Forms;

namespace ComercioSistema.Controladores
{
    public abstract class ControladorCadastro
    {   
        private MySqlCommand comandoInclusao;
        private MySqlCommand comandoAtualizacao;
        private MySqlCommand comandoExclusao;
        private MySqlCommand comandoSelecao;

        protected abstract string criarComandoSelecao();
 
        protected abstract string criarComandoInclusao();
        protected abstract string criarComandoAtualizacao();
        protected abstract string criarComandoExclusao();

        protected abstract void criarParametros(MySqlCommand comando);
        protected abstract void criarParametrosChavePrimaria(MySqlCommand comandoExclusao);

        protected virtual void criarParametrosInclusao(MySqlCommand comandoExclusao)
        {
            criarParametros(comandoInclusao);
        }

        protected virtual void criarParametrosAtualizacao(MySqlCommand comandoAtualizacao)
        {
            criarParametros(comandoAtualizacao);
        }

        public ControladorCadastro()
        {
            comandoInclusao = new MySqlCommand(criarComandoInclusao(), BancoDados.obterInstancia().obterConexao()); ;
            comandoAtualizacao = new MySqlCommand(criarComandoAtualizacao(), BancoDados.obterInstancia().obterConexao());
            comandoExclusao = new MySqlCommand(criarComandoExclusao(), BancoDados.obterInstancia().obterConexao());
            comandoSelecao = new MySqlCommand(criarComandoSelecao(), BancoDados.obterInstancia().obterConexao());
            criarParametrosInclusao(comandoInclusao);
            criarParametrosAtualizacao(comandoAtualizacao);
            criarParametrosChavePrimaria(comandoExclusao);
            criarParametrosChavePrimaria(comandoSelecao);
        }

        public void selecionar(Entidade entidade)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDadosIdentificador(comandoSelecao);
                MySqlDataReader leitorDados = comandoSelecao.ExecuteReader();
                while (leitorDados.Read())
                {
                    entidade.lerDados(leitorDados);
                }
                leitorDados.Close();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                BancoDados.obterInstancia().cancelarTransacao();
                MessageBox.Show($"Erro ao selecionar: {ex.Message}", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void incluir(Entidade entidade)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDados(comandoInclusao);
                comandoInclusao.ExecuteNonQuery();
                BancoDados.obterInstancia().confirmarTransacao();
            }
            catch (Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }

        public void atualizar(Entidade entidade)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDados(comandoAtualizacao);
                comandoAtualizacao.ExecuteNonQuery();
                BancoDados.obterInstancia().confirmarTransacao();
            } catch (Exception ex)
            {
                BancoDados.obterInstancia() .cancelarTransacao();
                throw new Exception("Erro ao atualizar cliente: " + ex.Message, ex);
            }
        }

        public void excluir(Entidade entidade)
        {
            BancoDados.obterInstancia().iniciarTransacao();
            try
            {
                entidade.transferirDadosIdentificador(comandoExclusao);
                comandoExclusao.ExecuteNonQuery();
                BancoDados.obterInstancia().confirmarTransacao();
            }catch(Exception ex)
            {
                BancoDados.obterInstancia().cancelarTransacao();
                throw new Exception(ex.Message);
            }
        }
    }
}
