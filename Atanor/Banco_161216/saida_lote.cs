using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class saida_lote
    {
        List<dynamic> _valoressaida_lote = new List<dynamic>();
        List<string> _colunasaida_lote = new List<string>();
        List<dynamic> _condicoessaida_lote = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunasaida_lote.Count; a++)
         {
             if (col == _colunasaida_lote[a])
                  {
                       return;
                  }
     }
_colunasaida_lote.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoessaida_lote.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idretorno="idretorno";
        public const string nota="nota";
        public const string quantidade="quantidade";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoressaida_lote.Add(value); }
        }

        static int Oidretorno;
        int idretorno;
        public int Idretorno
        {
            get { return idretorno; }
            set { idretorno = value; Add("idretorno"); _valoressaida_lote.Add(value); }
        }

        static string Onota;
        string nota;
        public string Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoressaida_lote.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoressaida_lote.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoressaida_lote.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("saida_lote", TipoDeOperacao.Tipo.InsertMultiplo, _colunasaida_lote,_valoressaida_lote, _condicoessaida_lote);   
        }
        public int Alterar()
        {
if (_condicoessaida_lote.Count > 0)
{
return ExecuteNonSql.Executar("saida_lote", TipoDeOperacao.Tipo.Update, _colunasaida_lote,_valoressaida_lote, _condicoessaida_lote);
}
else
{
List<string> Nomesaida_lote = new List<string>();
List<dynamic> Valorsaida_lote = new List<dynamic>();
_valoressaida_lote.Clear();
if(Id!=null){ Nomesaida_lote.Add("id");
 Valorsaida_lote.Add(Oid);
 _valoressaida_lote.Add(Id);
}if(Idretorno!=null){ Nomesaida_lote.Add("idretorno");
 Valorsaida_lote.Add(Oidretorno);
 _valoressaida_lote.Add(Idretorno);
}if(Nota!=null){ Nomesaida_lote.Add("nota");
 Valorsaida_lote.Add(Onota);
 _valoressaida_lote.Add(Nota);
}if(Quantidade!=null){ Nomesaida_lote.Add("quantidade");
 Valorsaida_lote.Add(Oquantidade);
 _valoressaida_lote.Add(Quantidade);
}if(Obs!=null){ Nomesaida_lote.Add("obs");
 Valorsaida_lote.Add(Oobs);
 _valoressaida_lote.Add(Obs);
}List<dynamic> Condicaosaida_lote = new List<dynamic>();
Condicaosaida_lote.Add(Nomesaida_lote);
Condicaosaida_lote.Add(Valorsaida_lote);
return ExecuteNonSql.Executar("saida_lote", TipoDeOperacao.Tipo.UpdateCondicional, _colunasaida_lote, _valoressaida_lote, Condicaosaida_lote);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("saida_lote", TipoDeOperacao.Tipo.Delete, _colunasaida_lote,_valoressaida_lote, _condicoessaida_lote);
        }
        static public List<saida_lote> Obter()
        {
            List<saida_lote> lista = new List<saida_lote>();
            DataTable tabela = Select.SelectSQL("select * from saida_lote");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                saida_lote novo = new saida_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idretorno = (int)tabela.Rows[a]["idretorno"]; Oidretorno = (int)tabela.Rows[a]["idretorno"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<saida_lote> Obter(string where)
        {
            List<saida_lote> lista = new List<saida_lote>();
            DataTable tabela = Select.SelectSQL("select * from saida_lote where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                saida_lote novo = new saida_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idretorno = (int)tabela.Rows[a]["idretorno"]; Oidretorno = (int)tabela.Rows[a]["idretorno"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<saida_lote> ObterComFiltroAvancado(string sql)
        {
            List<saida_lote> lista = new List<saida_lote>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                saida_lote novo = new saida_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idretorno = (int)tabela.Rows[a]["idretorno"]; Oidretorno = (int)tabela.Rows[a]["idretorno"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from saida_lote").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from saida_lote where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from saida_lote ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from saida_lote where " + where + "");
}


# endregion
    }
}
