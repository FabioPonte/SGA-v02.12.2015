using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class retorno_lote
    {
        List<dynamic> _valoresretorno_lote = new List<dynamic>();
        List<string> _colunaretorno_lote = new List<string>();
        List<dynamic> _condicoesretorno_lote = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaretorno_lote.Count; a++)
         {
             if (col == _colunaretorno_lote[a])
                  {
                       return;
                  }
     }
_colunaretorno_lote.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesretorno_lote.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idacerto_lote="idacerto_lote";
        public const string data_baixa="data_baixa";
        public const string docsap="docsap";
        public const string quantidade="quantidade";
        public const string codigo="codigo";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresretorno_lote.Add(value); }
        }

        static int Oidacerto_lote;
        int idacerto_lote;
        public int Idacerto_lote
        {
            get { return idacerto_lote; }
            set { idacerto_lote = value; Add("idacerto_lote"); _valoresretorno_lote.Add(value); }
        }

        static DateTime Odata_baixa;
        DateTime data_baixa;
        public DateTime Data_baixa
        {
            get { return data_baixa; }
            set { data_baixa = value; Add("data_baixa"); _valoresretorno_lote.Add(value); }
        }

        static string Odocsap;
        string docsap;
        public string Docsap
        {
            get { return docsap; }
            set { docsap = value; Add("docsap"); _valoresretorno_lote.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresretorno_lote.Add(value); }
        }

        static int Ocodigo;
        int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresretorno_lote.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("retorno_lote", TipoDeOperacao.Tipo.InsertMultiplo, _colunaretorno_lote,_valoresretorno_lote, _condicoesretorno_lote);   
        }
        public int Alterar()
        {
if (_condicoesretorno_lote.Count > 0)
{
return ExecuteNonSql.Executar("retorno_lote", TipoDeOperacao.Tipo.Update, _colunaretorno_lote,_valoresretorno_lote, _condicoesretorno_lote);
}
else
{
List<string> Nomeretorno_lote = new List<string>();
List<dynamic> Valorretorno_lote = new List<dynamic>();
_valoresretorno_lote.Clear();
if(Id!=null){ Nomeretorno_lote.Add("id");
 Valorretorno_lote.Add(Oid);
 _valoresretorno_lote.Add(Id);
}if(Idacerto_lote!=null){ Nomeretorno_lote.Add("idacerto_lote");
 Valorretorno_lote.Add(Oidacerto_lote);
 _valoresretorno_lote.Add(Idacerto_lote);
}if(Data_baixa!=null){ Nomeretorno_lote.Add("data_baixa");
 Valorretorno_lote.Add(Odata_baixa);
 _valoresretorno_lote.Add(Data_baixa);
}if(Docsap!=null){ Nomeretorno_lote.Add("docsap");
 Valorretorno_lote.Add(Odocsap);
 _valoresretorno_lote.Add(Docsap);
}if(Quantidade!=null){ Nomeretorno_lote.Add("quantidade");
 Valorretorno_lote.Add(Oquantidade);
 _valoresretorno_lote.Add(Quantidade);
}if(Codigo!=null){ Nomeretorno_lote.Add("codigo");
 Valorretorno_lote.Add(Ocodigo);
 _valoresretorno_lote.Add(Codigo);
}List<dynamic> Condicaoretorno_lote = new List<dynamic>();
Condicaoretorno_lote.Add(Nomeretorno_lote);
Condicaoretorno_lote.Add(Valorretorno_lote);
return ExecuteNonSql.Executar("retorno_lote", TipoDeOperacao.Tipo.UpdateCondicional, _colunaretorno_lote, _valoresretorno_lote, Condicaoretorno_lote);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("retorno_lote", TipoDeOperacao.Tipo.Delete, _colunaretorno_lote,_valoresretorno_lote, _condicoesretorno_lote);
        }
        static public List<retorno_lote> Obter()
        {
            List<retorno_lote> lista = new List<retorno_lote>();
            DataTable tabela = Select.SelectSQL("select * from retorno_lote");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                retorno_lote novo = new retorno_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; Oidacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; } catch { }
            try {   novo.Data_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; Odata_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; } catch { }
            try {   novo.Docsap = (string)tabela.Rows[a]["docsap"]; Odocsap = (string)tabela.Rows[a]["docsap"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Codigo = (int)tabela.Rows[a]["codigo"]; Ocodigo = (int)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<retorno_lote> Obter(string where)
        {
            List<retorno_lote> lista = new List<retorno_lote>();
            DataTable tabela = Select.SelectSQL("select * from retorno_lote where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                retorno_lote novo = new retorno_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; Oidacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; } catch { }
            try {   novo.Data_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; Odata_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; } catch { }
            try {   novo.Docsap = (string)tabela.Rows[a]["docsap"]; Odocsap = (string)tabela.Rows[a]["docsap"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Codigo = (int)tabela.Rows[a]["codigo"]; Ocodigo = (int)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<retorno_lote> ObterComFiltroAvancado(string sql)
        {
            List<retorno_lote> lista = new List<retorno_lote>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                retorno_lote novo = new retorno_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; Oidacerto_lote = (int)tabela.Rows[a]["idacerto_lote"]; } catch { }
            try {   novo.Data_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; Odata_baixa = (DateTime)tabela.Rows[a]["data_baixa"]; } catch { }
            try {   novo.Docsap = (string)tabela.Rows[a]["docsap"]; Odocsap = (string)tabela.Rows[a]["docsap"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Codigo = (int)tabela.Rows[a]["codigo"]; Ocodigo = (int)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from retorno_lote").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from retorno_lote where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from retorno_lote ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from retorno_lote where " + where + "");
}


# endregion
    }
}
