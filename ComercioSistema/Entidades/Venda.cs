using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ComercioSistema.Entidades
{
    public class Venda : Entidade
    {
        public const string ATRIBUTO_ID_VENDA = "id";
        public const string ATRIBUTO_DATA_HORA_VENDA = "data_hora_venda";
        public const string ATRIBUTO_CLIENTE_ID = "cliente_id";
        public const string ATRIBUTO_PRODUTO_ID = "produto_id";
        public const string ATRIBUTO_QUANTIDADE = "quantidade";
        public const string ATRIBUTO_VALOR_UNITARIO = "valor_unitario";
        public const string ATRIBUTO_TOTAL = "total";
        public const string ATRIBUTO_TIPO_PAGAMENTO = "tipo_pagamento";
        public const string ATRIBUTO_PARCELADO = "parcelado";
        public const string ATRIBUTO_PARCELAMENTO_VEZES = "parcelamento_vezes";

        public int idVenda { get; set; }
        public DateTime dataHoraVenda { get; set; }
        public int cliente_id { get; set; }
        public int produto_id { get; set; }
        public int quantidade { get; set; }
        public decimal valorUnitario { get; set; }
        public decimal total{ get; set; }
        public string tipoPagamento { get; set; }
        public string parcelado { get; set; }
        public int parcelamentoVezes { get; set; }

        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@data_hora_venda", dataHoraVenda);
            comando.Parameters.AddWithValue("@cliente_id", cliente_id);
            comando.Parameters.AddWithValue("@produto_id", produto_id);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@valor_unitario", valorUnitario);
            comando.Parameters.AddWithValue("@total", total);
            comando.Parameters.AddWithValue("@tipo_pagamento", tipoPagamento);
            comando.Parameters.AddWithValue("@parcelado", parcelado);
            comando.Parameters.AddWithValue("@parcelamento_vezes", parcelamentoVezes);
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_VENDA].Value = idVenda;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idVenda = int.Parse(leitorDados[ATRIBUTO_ID_VENDA].ToString());
            dataHoraVenda = DateTime.Parse(leitorDados[ATRIBUTO_DATA_HORA_VENDA].ToString());
            total = decimal.Parse(leitorDados[ATRIBUTO_TOTAL].ToString());
            cliente_id = int.Parse(leitorDados[ATRIBUTO_CLIENTE_ID].ToString());
            produto_id = int.Parse(leitorDados[ATRIBUTO_PRODUTO_ID].ToString()); 
            quantidade = int.Parse(leitorDados[ATRIBUTO_QUANTIDADE].ToString()); 
            valorUnitario = decimal.Parse(leitorDados[ATRIBUTO_VALOR_UNITARIO].ToString());
            tipoPagamento = leitorDados[ATRIBUTO_TIPO_PAGAMENTO].ToString(); 
            parcelado = leitorDados[ATRIBUTO_PARCELADO].ToString(); 
            parcelamentoVezes = int.Parse(leitorDados[ATRIBUTO_PARCELAMENTO_VEZES].ToString());
        } 
    }
}
