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
using ComercioSistema.Persistencia;

namespace ComercioSistema.Interface.TelaProduto
{
    public partial class ListaProduto : Form
    {
        public ListaProduto()
        {
            InitializeComponent();
            Load += (s, e) => CarregarDadosProdutos();
        }

        private void CarregarDadosProdutos()
        {
            try
            {
                ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
                DataTable dataTable = controladorProduto.SelecionarTodosProdutosComNomes();

                if (dataTable != null)
                {
                    dataGridViewProduto.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Método CarregarProduto() foi chamado.");
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewProduto.SelectedRows[0];
                int idProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);
                Produto produtoSelecionado = ObterProdutoId(idProduto);
                MessageBox.Show("Produto: " + idProduto);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Produto ObterProdutoId(int idProduto)
        {
            ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
            Produto produto = new Produto();
            produto.idProduto = idProduto;
            controladorProduto.selecionar(produto);
            return produto;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduto.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridViewProduto.SelectedRows[0];
                    int idProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
                    Produto produtoExcluir = new Produto();
                    produtoExcluir.idProduto = idProduto;

                    try
                    {
                        controladorProduto.excluir(produtoExcluir);
                        CarregarDadosProdutos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewProduto.SelectedRows[0];
                int idProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);

                ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
                Produto produtoSelecionado = new Produto();
                produtoSelecionado.idProduto = idProduto;
                controladorProduto.selecionar(produtoSelecionado);

                AtualizarProduto formAtualizarProduto = new AtualizarProduto(produtoSelecionado, this);
                formAtualizarProduto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um produto para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AtualizarTabela()
        {
            try
            {
                ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
                DataTable dataTable = controladorProduto.SelecionarTodosProdutos();

                if (dataTable != null)
                {
                    dataGridViewProduto.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtroNome = txtPesquisar.Text.Trim();

            try
            {
                ControladorCadastroProduto controladorProduto = new ControladorCadastroProduto();
                DataTable dataTable;

                if (string.IsNullOrEmpty(filtroNome))
                {
                    // Se o campo de filtro estiver vazio, carregue todos os clientes.
                    dataTable = controladorProduto.SelecionarTodosProdutos();
                }
                else
                {
                    // Caso contrário, aplique o filtro pelo nome.
                    dataTable = controladorProduto.SelecionarProdutosPorNome(filtroNome);
                }

                if (dataTable != null)
                {
                    dataGridViewProduto.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormCadastroProduto formCadastroProduto = new FormCadastroProduto(this);
            formCadastroProduto.ShowDialog();
        }
    }
}
