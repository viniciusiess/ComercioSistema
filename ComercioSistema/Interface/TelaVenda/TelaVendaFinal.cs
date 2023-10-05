using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComercioSistema.Controladores;

namespace ComercioSistema.Interface.TelaVenda
{
    public partial class TelaVendaFinal : Form
    {
        public TelaVendaFinal()
        {
            InitializeComponent();
            Load += (s, e) => CarregarDadosVenda();
        }

        private void CarregarDadosVenda()
        {
            try
            {
                ControladorVenda controladorVenda = new ControladorVenda();
                DataTable dataTable = controladorVenda.SelecionarTodosVendas();

                if(dataTable != null )
                {
                    dataGridView.DataSource = dataTable;
                    DateTime horaVenda = Convert.ToDateTime(dataTable.Rows[0]["data_hora_venda"]);
                    decimal total = Convert.ToInt32(dataTable.Rows[0]["total"]);

                    // Assuming labelHora is the name of your label control
                    labelHora.Text = "Hora da Venda: " + horaVenda.ToString("HH:mm:ss");
                    labelTotal.Text = "Total: " + total.ToString();
                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelHora_Click(object sender, EventArgs e)
        {

        }

        private void labelNomeCliente_Click(object sender, EventArgs e)
        {

        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
