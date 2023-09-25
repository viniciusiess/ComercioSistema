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

namespace ComercioSistema.Interface
{
    public partial class ListaCliente : Form
    {
        public ListaCliente()
        {
            InitializeComponent();
            Load += (s, e) => CarregarDadosClientes();

        }


        private void CarregarDadosClientes()
        {
            try
            {
                ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                DataTable dataTable = controladorCliente.SelecionarTodosCliente();

                if(dataTable != null )
                {
                    dataGridViewClientes.DataSource = dataTable;
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
            MessageBox.Show("Método CarregarDadosCliente() foi chamado.");
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarDadosClientes();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if(dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClientes.SelectedRows[0];
                int idCliente = Convert.ToInt32(selectedRow.Cells["id"].Value);
                Cliente clienteSelecionado = ObterClienteId(idCliente);
                MessageBox.Show("Cliente: " + idCliente);
            }
            else
            {
                MessageBox.Show("Selecione uma linha para atualizar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Cliente ObterClienteId(int idCliente)
        {
            ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
            Cliente cliente = new Cliente();
            cliente.idCliente = idCliente;
            controladorCliente.selecionar(cliente);
            return cliente;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dataGridViewClientes.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir cliente?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(resultado == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridViewClientes.SelectedRows[0];
                    int idCliente = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                    Cliente clienteExcluir = new Cliente();
                    clienteExcluir.idCliente = idCliente;

                    try
                    {
                        controladorCliente.excluir(clienteExcluir);
                        CarregarDadosClientes();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Erro ao excluir cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para excluir.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if(dataGridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClientes.SelectedRows[0];
                int idCliente = Convert.ToInt32(selectedRow.Cells["id"].Value);

                ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                Cliente clienteSelecionado = new Cliente();
                clienteSelecionado.idCliente = idCliente;
                controladorCliente.selecionar(clienteSelecionado);

                AtualizarCliente formAtualizarCliente = new AtualizarCliente(clienteSelecionado, this);
                formAtualizarCliente.ShowDialog();
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
                ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                DataTable dataTable = controladorCliente.SelecionarTodosCliente();


                if (dataTable != null)
                {
                    dataGridViewClientes.DataSource = dataTable;
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

        private void ListaCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string filtroNome = txtPesquisar.Text.Trim();

            try
            {
                ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                DataTable dataTable;

                if (string.IsNullOrEmpty(filtroNome))
                {
                    // Se o campo de filtro estiver vazio, carregue todos os clientes.
                    dataTable = controladorCliente.SelecionarTodosCliente();
                }
                else
                {
                    // Caso contrário, aplique o filtro pelo nome.
                    dataTable = controladorCliente.SelecionarClientesPorNome(filtroNome);
                }

                if (dataTable != null)
                {
                    dataGridViewClientes.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            FormCadastroCliente formCadastroCliente = new FormCadastroCliente(this);
            formCadastroCliente.ShowDialog();
        }
    }
}
