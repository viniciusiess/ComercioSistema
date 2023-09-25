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
using ComercioSistema.Interface;
using ComercioSistema.Interface.TelaClassificacaoProduto;
using ComercioSistema.Interface.TelaFornecedor;
using ComercioSistema.Interface.TelaProduto;
using ComercioSistema.Persistencia;

namespace ComercioSistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Conectar automaticamente ao iniciar o aplicativo
            BancoDados.obterInstancia().conectar();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Desconectar ao fechar o aplicativo
            BancoDados.obterInstancia().desconectar();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ListaCliente listaCliente = new ListaCliente();
            listaCliente.ShowDialog();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            ListaFornecedor listaFornecedor = new ListaFornecedor();
            listaFornecedor.ShowDialog();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            ListaProduto listaProduto = new ListaProduto();
            listaProduto.ShowDialog();
        }

        private void btnClassificacao_Click(object sender, EventArgs e)
        {
            ListaClassificacaoProduto listaClassificacaoProduto = new ListaClassificacaoProduto();
            listaClassificacaoProduto.ShowDialog();
        }
    }
}
