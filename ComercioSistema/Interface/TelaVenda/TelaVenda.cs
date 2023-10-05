using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcessoBancoDados.Controladores;
using ComercioSistema.Controladores;
using ComercioSistema.Entidades;
using ComercioSistema.Interface.TelaProduto;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ComercioSistema.Interface.TelaVenda
{
    public partial class TelaVenda : Form
    {
        public TelaVenda()
        {
            InitializeComponent();
            PreencherListaClientes();
            PreencherListaProdutos();
        }

        private void PreencherListaClientes()
        {
            ControladorCadastroCliente controladorCadastroCliente = new ControladorCadastroCliente();
            DataTable clientes = controladorCadastroCliente.SelecionarTodosCliente();

            comboBoxClientes.DisplayMember = "nome";
            comboBoxClientes.ValueMember = "id";
            comboBoxClientes.DataSource = clientes;
        }

        private void PreencherListaProdutos()
        {
            ControladorCadastroProduto controladorCadastroProduto = new ControladorCadastroProduto();
            DataTable produtos = controladorCadastroProduto.SelecionarTodosProdutos();

            comboBoxProdutos.DisplayMember = "nome";
            comboBoxProdutos.ValueMember = "id";
            comboBoxProdutos.DataSource = produtos;
        }

        private void TelaVenda_Load(object sender, EventArgs e)
        {
            comboBoxFormaPagamento.Items.Add("Dinheiro");
            comboBoxFormaPagamento.Items.Add("PIX");
            comboBoxFormaPagamento.Items.Add("Débito");
            comboBoxFormaPagamento.Items.Add("Crédito");

            comboBoxFormaPagamento.SelectedIndex = 0;
        }

        
        private void LimparCampos()
        {
            textBoxQuantidade.Clear();
            textBoxValorUnitario.Clear();
            textBoxVezes.Clear();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {

                Venda venda = new Venda
                {
                    quantidade = int.TryParse(textBoxQuantidade.Text, out int quantidade) ? quantidade : 0,
                    valorUnitario = decimal.TryParse(textBoxValorUnitario.Text, out decimal valorUnitario) ? valorUnitario : 0,
                    parcelamentoVezes = int.TryParse(textBoxVezes.Text, out int parcelamentoVezes) ? parcelamentoVezes : 0,
                    total = valorUnitario * quantidade,
                    dataHoraVenda = DateTime.Now,
                    parcelado = textBoxParcelado.Text,
                    tipoPagamento = comboBoxFormaPagamento.SelectedItem.ToString()
                };

                if (comboBoxClientes.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)comboBoxClientes.SelectedItem;
                    venda.cliente_id = Convert.ToInt32(selectedRow["id"]);
                }

                if (comboBoxProdutos.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)comboBoxProdutos.SelectedItem;
                    venda.produto_id = Convert.ToInt32(selectedRow["id"]);
                }

                ControladorVenda controladorVenda = new ControladorVenda();


                try
                {
                    controladorVenda.incluir(venda);
                    LimparCampos();
                    MessageBox.Show("Produto Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTelaVendaFinal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar o produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.StackTrace);
                }
            }

        private void MostrarTelaVendaFinal()
        {
            TelaVendaFinal telaVendaFinal = new TelaVendaFinal();
            telaVendaFinal.ShowDialog();
        }
    }

   
}

