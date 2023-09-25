using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcessoBancoDados.Controladores;
using ComercioSistema.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ComercioSistema.Interface
{
    public partial class FormCadastroCliente : Form
    {

        private ListaCliente listaCliente;

        public FormCadastroCliente(ListaCliente listaCliente)
        {
            InitializeComponent();
            this.listaCliente = listaCliente;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente {
                nome = txtNome.Text,
                cpfCnpj = txtCpfCnpj.Text,
                telefone = txtTelefone.Text,
                email = txtEmail.Text,
                logradouro = txtLogradouro.Text,
                numero = txtNumero.Text,
                complemento = txtComplemento.Text,
                bairro = txtBairro.Text,
                cidade = txtCidade.Text,
                uf = txtUf.Text,
                cep = txtCep.Text,
            };

            ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();

            try
            {
                controladorCliente.incluir(cliente);
                LimparCampos();
                MessageBox.Show("Cliente Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaCliente.AtualizarTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCpfCnpj.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtCep.Clear();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogradouro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCpfCnpj_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
