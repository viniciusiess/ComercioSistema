using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioSistema.Entidades;
using ComercioSistema.Persistencia;
using MySql.Data.MySqlClient;

using ComercioSistema.Persistencia;
using ComercioSistema.Entidades;
using ComercioSistema.Controladores;
using MySql.Data.MySqlClient;
using System.Data;

namespace ComercioSistema.Controladores
{
    public class ControladorVenda : ControladorCadastro
    {

        protected override string criarComandoSelecao()
        {
            return "SELECT * FROM VENDA WHERE id = @id";
        }

        protected override string criarComandoInclusao()
        {
            return "INSERT INTO VENDA (quantidade, valor_unitario, data_hora_venda, total, tipo_pagamento, parcelado, parcelamento_vezes, cliente_id, produto_id) " +
                   "VALUES (@quantidade, @valor_unitario, @data_hora_venda, @total, @tipo_pagamento, @parcelado, @parcelamento_vezes, @cliente_id, @produto_id)";
        }

        protected override string criarComandoAtualizacao()
        {
            return "UPDATE VENDA SET quantidade = @quantidade, valor_unitario = @valor_unitario WHERE id = @id";

        }

        protected override string criarComandoExclusao()
        {
            return "DELETE FROM VENDA WHERE id = @id";
        }

        protected override void criarParametros(MySqlCommand comando)
        {
            comando.Parameters.Add(Venda.ATRIBUTO_ID_VENDA, MySqlDbType.Int32);
            comando.Parameters.Add(Venda.ATRIBUTO_QUANTIDADE, MySqlDbType.Int32);
            comando.Parameters.Add(Venda.ATRIBUTO_VALOR_UNITARIO, MySqlDbType.Decimal);
            comando.Parameters.Add(Venda.ATRIBUTO_DATA_HORA_VENDA, MySqlDbType.Datetime);
            comando.Parameters.Add(Venda.ATRIBUTO_TOTAL, MySqlDbType.Decimal);
            comando.Parameters.Add(Venda.ATRIBUTO_TIPO_PAGAMENTO, MySqlDbType.String);
            comando.Parameters.Add(Venda.ATRIBUTO_PARCELADO, MySqlDbType.String);
            comando.Parameters.Add(Venda.ATRIBUTO_PARCELAMENTO_VEZES, MySqlDbType.Int32);

        }


        protected override void criarParametrosChavePrimaria(MySqlCommand comando)
        {
            comando.Parameters.Add(Venda.ATRIBUTO_ID_VENDA, MySqlDbType.Int32);
        }

        public DataTable SelecionarTodosVendas()
        {
            string comandoSQL = "SELECT * FROM venda";
            MySqlConnection conexao = BancoDados.obterInstancia().obterConexao();

            using (MySqlCommand comando = new MySqlCommand(comandoSQL, conexao))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

       
    }
}