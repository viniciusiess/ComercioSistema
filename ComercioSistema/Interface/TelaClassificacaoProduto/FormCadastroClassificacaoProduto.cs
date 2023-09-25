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

namespace ComercioSistema.Interface.TelaClassificacaoProduto
{
    
    public partial class FormCadastroClassificacaoProduto : Form
    {
        private ListaClassificacaoProduto listaClassificacaoProduto;
        public FormCadastroClassificacaoProduto(ListaClassificacaoProduto listaClassificacaoProduto)
        {
            InitializeComponent();
            this.listaClassificacaoProduto = listaClassificacaoProduto;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ClassificacaoProduto classificacaoProduto = new ClassificacaoProduto
            {
                nome = txtNome.Text,
                descricao = txtDescricao.Text,
            };

            ControladorCadastroClassificacaoProduto controladorCadastroClassificacaoProduto = new ControladorCadastroClassificacaoProduto();

            try
            {
                controladorCadastroClassificacaoProduto.incluir(classificacaoProduto);
                LimparCampos();
                MessageBox.Show("Classificação do Produto Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listaClassificacaoProduto.AtualizarTabela();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o classificação do produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
        }
    }
}
