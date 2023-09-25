using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ComercioSistema.Entidades
{
    public class Produto : Entidade
    {
        public const string ATRIBUTO_ID_PRODUTO = "id";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_PRECO = "preco";
        public const string ATRIBUTO_ESTOQUE = "estoque";
        public const string ATRIBUTO_UNIDADE = "unidade";
        public const string ATRIBUTO_CLASSIFICACAO_ID = "classificacao_id";
        public const string ATRIBUTO_FORNECEDOR_ID = "fornecedor_id";


        public int idProduto { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }
        public int estoque { get; set; }
        public string unidade { get; set; }
        public int classificacao_id { get; set; }
        public int fornecedor_id { get; set; }

        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@preco", preco);
            comando.Parameters.AddWithValue("@estoque", estoque);
            comando.Parameters.AddWithValue("@unidade", unidade);
            comando.Parameters.AddWithValue("@classificacao_id", classificacao_id);
            comando.Parameters.AddWithValue("@fornecedor_id", fornecedor_id);
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_PRODUTO].Value = idProduto;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idProduto = int.Parse(leitorDados[ATRIBUTO_ID_PRODUTO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            preco = float.Parse(leitorDados[ATRIBUTO_PRECO].ToString());
            estoque = int.Parse(leitorDados[ATRIBUTO_ESTOQUE].ToString());
            unidade = leitorDados[ATRIBUTO_UNIDADE].ToString();
            classificacao_id = int.Parse(leitorDados[ATRIBUTO_CLASSIFICACAO_ID].ToString());
            fornecedor_id = int.Parse(leitorDados[ATRIBUTO_FORNECEDOR_ID].ToString());
        }
    }
}