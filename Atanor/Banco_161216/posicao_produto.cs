using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class posicao_produto
    {
        List<dynamic> _valoresposicao_produto = new List<dynamic>();
        List<string> _colunaposicao_produto = new List<string>();
        List<dynamic> _condicoesposicao_produto = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaposicao_produto.Count; a++)
         {
             if (col == _colunaposicao_produto[a])
                  {
                       return;
                  }
     }
_colunaposicao_produto.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesposicao_produto.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string id_posicao="id_posicao";
        public const string id_produto="id_produto";
        public const string lote="lote";
        public const string quantidade="quantidade";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresposicao_produto.Add(value); }
        }

        static int Oid_posicao;
        int id_posicao;
        public int Id_posicao
        {
            get { return id_posicao; }
            set { id_posicao = value; Add("id_posicao"); _valoresposicao_produto.Add(value); }
        }

        static int Oid_produto;
        int id_produto;
        public int Id_produto
        {
            get { return id_produto; }
            set { id_produto = value; Add("id_produto"); _valoresposicao_produto.Add(value); }
        }

        static string Olote;
        string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; Add("lote"); _valoresposicao_produto.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresposicao_produto.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("posicao_produto", TipoDeOperacao.Tipo.InsertMultiplo, _colunaposicao_produto,_valoresposicao_produto, _condicoesposicao_produto);   
        }
        public int Alterar()
        {
if (_condicoesposicao_produto.Count > 0)
{
return ExecuteNonSql.Executar("posicao_produto", TipoDeOperacao.Tipo.Update, _colunaposicao_produto,_valoresposicao_produto, _condicoesposicao_produto);
}
else
{
List<string> Nomeposicao_produto = new List<string>();
List<dynamic> Valorposicao_produto = new List<dynamic>();
_valoresposicao_produto.Clear();
if(Id!=null){ Nomeposicao_produto.Add("id");
 Valorposicao_produto.Add(Oid);
 _valoresposicao_produto.Add(Id);
}if(Id_posicao!=null){ Nomeposicao_produto.Add("id_posicao");
 Valorposicao_produto.Add(Oid_posicao);
 _valoresposicao_produto.Add(Id_posicao);
}if(Id_produto!=null){ Nomeposicao_produto.Add("id_produto");
 Valorposicao_produto.Add(Oid_produto);
 _valoresposicao_produto.Add(Id_produto);
}if(Lote!=null){ Nomeposicao_produto.Add("lote");
 Valorposicao_produto.Add(Olote);
 _valoresposicao_produto.Add(Lote);
}if(Quantidade!=null){ Nomeposicao_produto.Add("quantidade");
 Valorposicao_produto.Add(Oquantidade);
 _valoresposicao_produto.Add(Quantidade);
}List<dynamic> Condicaoposicao_produto = new List<dynamic>();
Condicaoposicao_produto.Add(Nomeposicao_produto);
Condicaoposicao_produto.Add(Valorposicao_produto);
return ExecuteNonSql.Executar("posicao_produto", TipoDeOperacao.Tipo.UpdateCondicional, _colunaposicao_produto, _valoresposicao_produto, Condicaoposicao_produto);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("posicao_produto", TipoDeOperacao.Tipo.Delete, _colunaposicao_produto,_valoresposicao_produto, _condicoesposicao_produto);
        }
        static public List<posicao_produto> Obter()
        {
            List<posicao_produto> lista = new List<posicao_produto>();
            DataTable tabela = Select.SelectSQL("select * from posicao_produto");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_produto novo = new posicao_produto();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_posicao = (int)tabela.Rows[a]["id_posicao"]; Oid_posicao = (int)tabela.Rows[a]["id_posicao"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_produto> Obter(string where)
        {
            List<posicao_produto> lista = new List<posicao_produto>();
            DataTable tabela = Select.SelectSQL("select * from posicao_produto where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_produto novo = new posicao_produto();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_posicao = (int)tabela.Rows[a]["id_posicao"]; Oid_posicao = (int)tabela.Rows[a]["id_posicao"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_produto> ObterComFiltroAvancado(string sql)
        {
            List<posicao_produto> lista = new List<posicao_produto>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_produto novo = new posicao_produto();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_posicao = (int)tabela.Rows[a]["id_posicao"]; Oid_posicao = (int)tabela.Rows[a]["id_posicao"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from posicao_produto").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from posicao_produto where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from posicao_produto ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from posicao_produto where " + where + "");
}


# endregion
    }
}
