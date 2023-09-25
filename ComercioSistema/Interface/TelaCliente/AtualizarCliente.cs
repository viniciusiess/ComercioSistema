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
    public partial class AtualizarCliente : Form
    {
        private Cliente cliente;
        private ListaCliente listaCliente;

        public AtualizarCliente(Cliente cliente, ListaCliente listaCliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.listaCliente = listaCliente;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = cliente.nome;
            txtCpfCnpj.Text = cliente.cpfCnpj;
            txtTelefone.Text = cliente.telefone;
            txtEmail.Text = cliente.email;
            txtLogradouro.Text = cliente.logradouro;
            txtNumero.Text = cliente.numero;
            txtComplemento.Text = cliente.complemento;
            txtBairro.Text = cliente.bairro;
            txtCidade.Text = cliente.cidade;
            txtUf.Text = cliente.uf;
            txtCep.Text = cliente.cep;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.nome = txtNome.Text;
                cliente.cpfCnpj = txtCpfCnpj.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;
                cliente.logradouro = txtLogradouro.Text;
                cliente.numero = txtNumero.Text;
                cliente.complemento = txtComplemento.Text;
                cliente.bairro = txtBairro.Text;
                cliente.cidade = txtCidade.Text;
                cliente.uf = txtUf.Text;
                cliente.cep = txtCep.Text;

                ControladorCadastroCliente controladorCliente = new ControladorCadastroCliente();
                controladorCliente.atualizar(cliente);

                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaCliente.AtualizarTabela();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar cliente: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
