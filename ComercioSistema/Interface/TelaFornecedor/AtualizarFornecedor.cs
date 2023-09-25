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
using MySqlX.XDevAPI;

namespace ComercioSistema.Interface.TelaFornecedor
{
    public partial class AtualizarFornecedor : Form
    {
        private Fornecedor fornecedor;
        private ListaFornecedor listaFornecedor;

        public AtualizarFornecedor(Fornecedor fornecedor, ListaFornecedor listaFornecedor)
        {
            InitializeComponent();
            this.fornecedor = fornecedor;
            this.listaFornecedor = listaFornecedor;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            txtNome.Text = fornecedor.nome;
            txtCpfCnpj.Text = fornecedor.cpfCnpj;
            txtTelefone.Text = fornecedor.telefone;
            txtEmail.Text = fornecedor.email;
            txtLogradouro.Text = fornecedor.logradouro;
            txtNumero.Text = fornecedor.numero;
            txtComplemento.Text = fornecedor.complemento;
            txtBairro.Text = fornecedor.bairro;
            txtCidade.Text = fornecedor.cidade;
            txtUf.Text = fornecedor.uf;
            txtCep.Text = fornecedor.cep;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                fornecedor.nome = txtNome.Text;
                fornecedor.cpfCnpj = txtCpfCnpj.Text;
                fornecedor.telefone = txtTelefone.Text;
                fornecedor.email = txtEmail.Text;
                fornecedor.logradouro = txtLogradouro.Text;
                fornecedor.numero = txtNumero.Text;
                fornecedor.complemento = txtComplemento.Text;
                fornecedor.bairro = txtBairro.Text;
                fornecedor.cidade = txtCidade.Text;
                fornecedor.uf = txtUf.Text;
                fornecedor.cep = txtCep.Text;

                ControladorCadastroFornecedor controladorFornecedor = new ControladorCadastroFornecedor();
                controladorFornecedor.atualizar(fornecedor);

                MessageBox.Show("Fornecedor atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaFornecedor.AtualizarTabela();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar fornecedor: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
