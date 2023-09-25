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

namespace ComercioSistema.Interface.TelaFornecedor
{
    public partial class ListaFornecedor : Form
    {
        public ListaFornecedor()
        {
            InitializeComponent();
            Load += (s, e) => CarregarDadosFornecedores();
        }

        private void CarregarDadosFornecedores()
        {
            try
            {
                ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                DataTable dataTable = controladorFornecedor.SelecionarTodosFornecedores();

                if (dataTable != null)
                {
                    dataGridViewFornecedor.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum fornecedor encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Método CarregarFornecedor() foi chamado.");
        }

        private void dataGridViewFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarDadosFornecedores();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewFornecedor.SelectedRows[0];
                int idFornecedor = Convert.ToInt32(selectedRow.Cells["id"].Value);
                Fornecedor fornecedorSelecionado = ObterFornecedorId(idFornecedor);
                MessageBox.Show("Cliente: " + idFornecedor);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Fornecedor ObterFornecedorId(int idFornecedor)
        {
            ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.idFornecedor = idFornecedor;
            controladorFornecedor.selecionar(fornecedor);
            return fornecedor;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir fornecedor?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridViewFornecedor.SelectedRows[0];
                    int idFornecedor = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                    Fornecedor fornecedorExcluir = new Fornecedor();
                    fornecedorExcluir.idFornecedor = idFornecedor;

                    try
                    {
                        controladorFornecedor.excluir(fornecedorExcluir);
                        CarregarDadosFornecedores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir fornecedor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para excluir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFornecedor.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewFornecedor.SelectedRows[0];
                int idFornecedor = Convert.ToInt32(selectedRow.Cells["id"].Value);

                ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                Fornecedor fornecedorSelecionado = new Fornecedor();
                fornecedorSelecionado.idFornecedor = idFornecedor;
                controladorFornecedor.selecionar(fornecedorSelecionado);

                AtualizarFornecedor formAtualizarFornecedor = new AtualizarFornecedor(fornecedorSelecionado, this);
                formAtualizarFornecedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void AtualizarTabela()
        {
            try
            {
                ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                DataTable dataTable = controladorFornecedor.SelecionarTodosFornecedores();

                if (dataTable != null)
                {
                    dataGridViewFornecedor.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum fornecedor encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar fornecedores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtroNome = txtPesquisar.Text.Trim();

            try
            {
                ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                DataTable dataTable;

                if (string.IsNullOrEmpty(filtroNome))
                {
                    // Se o campo de filtro estiver vazio, carregue todos os clientes.
                    dataTable = controladorFornecedor.SelecionarTodosFornecedores();
                }
                else
                {
                    // Caso contrário, aplique o filtro pelo nome.
                    dataTable = controladorFornecedor.SelecionarFornecedoresPorNome(filtroNome);
                }

                if (dataTable != null)
                {
                    dataGridViewFornecedor.DataSource = dataTable;
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
            FormCadastroFornecedor formCadastroFornecedor = new FormCadastroFornecedor(this);
            formCadastroFornecedor.ShowDialog();
        }
    }
}
