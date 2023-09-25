using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcessoBancoDados.Controladores;
using ComercioSistema.Controladores;
using ComercioSistema.Entidades;
using ComercioSistema.Interface.TelaFornecedor;
using ComercioSistema.Persistencia;
using MySqlX.XDevAPI;

namespace ComercioSistema.Interface.TelaClassificacaoProduto
{
    public partial class AtualizarClassificacaoProduto : Form
    {
        private ClassificacaoProduto classificacaoProduto;
        private ListaClassificacaoProduto listaClassificacaoProduto;
        public AtualizarClassificacaoProduto(ClassificacaoProduto classificacaoProduto, ListaClassificacaoProduto listaClassificacaoProduto)
        {
            InitializeComponent();
            this.classificacaoProduto = classificacaoProduto;
            this.listaClassificacaoProduto = listaClassificacaoProduto;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = classificacaoProduto.nome;
            txtDescricao.Text = classificacaoProduto.descricao;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                classificacaoProduto.nome = txtNome.Text;
                classificacaoProduto.descricao = txtDescricao.Text;

                ControladorCadastroClassificacaoProduto controladorClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                controladorClassificacaoProduto.atualizar(classificacaoProduto);

                MessageBox.Show("Classificação do Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaClassificacaoProduto.AtualizarTabela();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar classificação do produto: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
