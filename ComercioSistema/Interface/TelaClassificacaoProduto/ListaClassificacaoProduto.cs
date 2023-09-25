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


namespace ComercioSistema.Interface.TelaClassificacaoProduto
{
    public partial class ListaClassificacaoProduto : Form
    {
        public ListaClassificacaoProduto()
        {
            InitializeComponent();
            Load += (s, e) => CarregarDadosClassificacaoProdutos();
        }

        private void CarregarDadosClassificacaoProdutos()
        {
            try
            {
                ControladorCadastroClassificacaoProduto controladorClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                DataTable dataTable = controladorClassificacaoProduto.SelecionarTodosClassificaoProdutos();

                if (dataTable != null)
                {
                    dataGridViewClassificacaoProduto.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhuma classificação de produto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar classificação dos produtos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Método CarregarDadosClassificacaoProdutos() foi chamado.");
        }

        private void dataGridViewClassificacaoProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarDadosClassificacaoProdutos();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassificacaoProduto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClassificacaoProduto.SelectedRows[0];
                int idClassificacaoProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);
                ClassificacaoProduto classificacaoProdutoSelecionado = ObterClassificacaoProdutoId(idClassificacaoProduto);
                MessageBox.Show("Classificação Produto: " + idClassificacaoProduto);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private ClassificacaoProduto ObterClassificacaoProdutoId(int idClassificacaoProduto)
        {
            ControladorCadastroClassificacaoProduto controladorCadastroClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
            ClassificacaoProduto classificacaoProduto = new ClassificacaoProduto();
            classificacaoProduto.idClassificacaoProduto = idClassificacaoProduto;
            controladorCadastroClassificacaoProduto.selecionar(classificacaoProduto);
            return classificacaoProduto;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassificacaoProduto.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir classificação do produto?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridViewClassificacaoProduto.SelectedRows[0];
                    int idClassificacaoProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    ControladorCadastroClassificacaoProduto controladorCadastroClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                    ClassificacaoProduto classificacaoProdutoExcluir = new ClassificacaoProduto();
                    classificacaoProdutoExcluir.idClassificacaoProduto = idClassificacaoProduto;

                    try
                    {
                        controladorCadastroClassificacaoProduto.excluir(classificacaoProdutoExcluir);
                        CarregarDadosClassificacaoProdutos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir classificação do produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um classificação para excluir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassificacaoProduto.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClassificacaoProduto.SelectedRows[0];
                int idClassificacaoProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);

                ControladorCadastroClassificacaoProduto controladorCadastroClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                ClassificacaoProduto classificacaoProdutoSelecionado = new ClassificacaoProduto();
                classificacaoProdutoSelecionado.idClassificacaoProduto = idClassificacaoProduto;
                controladorCadastroClassificacaoProduto.selecionar(classificacaoProdutoSelecionado);

                AtualizarClassificacaoProduto formAtualizarClassificacaoProduto = new AtualizarClassificacaoProduto(classificacaoProdutoSelecionado, this);
                formAtualizarClassificacaoProduto.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AtualizarTabela()
        {
            try
            {
                ControladorCadastroClassificacaoProduto controladorCadastroClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                DataTable dataTable = controladorCadastroClassificacaoProduto.SelecionarTodosClassificaoProdutos();

                if (dataTable != null)
                {
                    dataGridViewClassificacaoProduto.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhuma classificãção de produto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar classificações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtroNome = txtPesquisar.Text.Trim();

            try
            {
                ControladorCadastroClassificacaoProduto controladorClassificacaoProduto = new ControladorCadastroClassificacaoProduto();
                DataTable dataTable;

                if (string.IsNullOrEmpty(filtroNome))
                {
                    // Se o campo de filtro estiver vazio, carregue todos os clientes.
                    dataTable = controladorClassificacaoProduto.SelecionarTodosClassificaoProdutos();
                }
                else
                {
                    // Caso contrário, aplique o filtro pelo nome.
                    dataTable = controladorClassificacaoProduto.SelecionarClassificacaoProdutosPorNome(filtroNome);
                }

                if (dataTable != null)
                {
                    dataGridViewClassificacaoProduto.DataSource = dataTable;
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
            FormCadastroClassificacaoProduto formCadastroClassificacaoProduto = new FormCadastroClassificacaoProduto(this);
            formCadastroClassificacaoProduto.ShowDialog();
        }
    }
}
