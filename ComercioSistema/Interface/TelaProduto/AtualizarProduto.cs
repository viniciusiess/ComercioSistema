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

namespace ComercioSistema.Interface.TelaProduto
{
    public partial class AtualizarProduto : Form
    {
        private Produto produto;
        private ListaProduto listaProduto;
        public AtualizarProduto(Produto produto, ListaProduto listaProduto)
        {
            InitializeComponent();
            this.produto = produto;
            this.listaProduto = listaProduto;
            PreencherListaClassificacoes();
            PreencherListaFornecedor();
            PreencherCampos();
        }


        private void PreencherListaClassificacoes()
        {
            ControladorCadastroClassificacaoProduto controladorClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
            DataTable classificacoes = controladorClassificacaoProduto.SelecionarTodosClassificaoProdutos();

            comboBoxClassificacao.DisplayMember = "nome";
            comboBoxClassificacao.ValueMember = "id";
            comboBoxClassificacao.DataSource = classificacoes;

        }

        private void PreencherListaFornecedor()
        {
            ControladorCadastroFornecedor controladorCadastroFornecedor = new ControladorCadastroFornecedor();
            DataTable fornecedores = controladorCadastroFornecedor.SelecionarTodosFornecedores();

            comboBoxFornecedor.DisplayMember = "nome";
            comboBoxFornecedor.ValueMember = "id";
            comboBoxFornecedor.DataSource = fornecedores;
        }

        private void PreencherCampos()
        {
            txtNome.Text = produto.nome;
            txtPreco.Text = produto.preco.ToString();
            txtEstoque.Text = produto.estoque.ToString();
            txtUnidade.Text = produto.unidade;
            comboBoxClassificacao.SelectedValue = produto.classificacao_id;
            comboBoxFornecedor.SelectedValue = produto.fornecedor_id;
        }


        private void AtualizarProduto_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                int classificacao_id;
                int fornecedor_id;

                if (int.TryParse(comboBoxClassificacao.SelectedValue.ToString(), out classificacao_id) &&
                    int.TryParse(comboBoxFornecedor.SelectedValue.ToString(), out fornecedor_id))
                {
                    Produto novoProduto = new Produto
                    {
                        idProduto = produto.idProduto, // Mantém o mesmo ID do produto existente
                        nome = txtNome.Text,
                        preco = float.TryParse(txtPreco.Text, out float preco) ? preco : 0.0f,
                        estoque = int.TryParse(txtEstoque.Text, out int estoque) ? estoque : 0,
                        unidade = txtUnidade.Text,
                        classificacao_id = classificacao_id,
                        fornecedor_id = fornecedor_id
                    };

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Selecione valores válidos para classificação e fornecedor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
