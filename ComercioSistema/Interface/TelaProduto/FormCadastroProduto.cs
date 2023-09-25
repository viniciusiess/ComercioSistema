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
using ComercioSistema.Entidades;
using MySqlX.XDevAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ComercioSistema.Interface.TelaProduto
{
    public partial class FormCadastroProduto : Form
    {
        private ListaProduto listaProduto;
        public FormCadastroProduto(ListaProduto listaProduto)
        {
            InitializeComponent();
            PreencherListaClassificacoes();
            PreencherListaFornecedor();
            this.listaProduto = listaProduto;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto
            {
                nome = txtNome.Text,
                preco = float.TryParse(txtPreco.Text, out float preco) ? preco : 0.0f,
                estoque = int.TryParse(txtEstoque.Text, out int estoque) ? estoque : 0,
                unidade = txtUnidade.Text,
            };

            if (comboBoxClassificacao.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBoxClassificacao.SelectedItem;
                produto.classificacao_id = Convert.ToInt32(selectedRow["id"]);
            }

            if (comboBoxFornecedor.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)comboBoxFornecedor.SelectedItem;
                produto.fornecedor_id = Convert.ToInt32(selectedRow["id"]);
            }

            ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();

            try
            {
                controladorProduto.incluir(produto);
                LimparCampos();
                MessageBox.Show("Produto Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaProduto.AtualizarTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
            txtUnidade.Clear();
        }
    }
}
