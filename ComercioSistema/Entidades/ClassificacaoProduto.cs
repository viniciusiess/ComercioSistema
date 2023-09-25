using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ComercioSistema.Entidades
{
    public class ClassificacaoProduto : Entidade
    {
        public const string ATRIBUTO_ID_CLASSIFICACAOPRODUTO = "id";
        public const string ATRIBUTO_NOME = "nome";
        public const string ATRIBUTO_DESCRICAO = "descricao";

        public int idClassificacaoProduto { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }

        public override void transferirDados(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CLASSIFICACAOPRODUTO].Value = idClassificacaoProduto;
            comando.Parameters[ATRIBUTO_NOME].Value = nome;
            comando.Parameters[ATRIBUTO_DESCRICAO].Value = descricao;
        }

        public override void transferirDadosIdentificador(MySqlCommand comando)
        {
            comando.Parameters[ATRIBUTO_ID_CLASSIFICACAOPRODUTO].Value = idClassificacaoProduto;
        }

        public override void lerDados(MySqlDataReader leitorDados)
        {
            idClassificacaoProduto = int.Parse(leitorDados[ATRIBUTO_ID_CLASSIFICACAOPRODUTO].ToString());
            nome = leitorDados[ATRIBUTO_NOME].ToString();
            descricao = leitorDados[ATRIBUTO_DESCRICAO].ToString();
        }
    }
}
