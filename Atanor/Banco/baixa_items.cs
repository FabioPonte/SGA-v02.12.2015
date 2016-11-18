using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class baixa_items
    {
        List<dynamic> _valoresbaixa_items = new List<dynamic>();
        List<string> _colunabaixa_items = new List<string>();
        List<dynamic> _condicoesbaixa_items = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunabaixa_items.Count; a++)
         {
             if (col == _colunabaixa_items[a])
                  {
                       return;
                  }
     }
_colunabaixa_items.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesbaixa_items.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string iditens="iditens";
        public const string idrequisitantes="idrequisitantes";
        public const string quantidade="quantidade";
        public const string os="os";
        public const string data="data";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresbaixa_items.Add(value); }
        }

        static int Oiditens;
        int iditens;
        public int Iditens
        {
            get { return iditens; }
            set { iditens = value; Add("iditens"); _valoresbaixa_items.Add(value); }
        }

        static int Oidrequisitantes;
        int idrequisitantes;
        public int Idrequisitantes
        {
            get { return idrequisitantes; }
            set { idrequisitantes = value; Add("idrequisitantes"); _valoresbaixa_items.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresbaixa_items.Add(value); }
        }

        static string Oos;
        string os;
        public string Os
        {
            get { return os; }
            set { os = value; Add("os"); _valoresbaixa_items.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresbaixa_items.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("baixa_items", TipoDeOperacao.Tipo.InsertMultiplo, _colunabaixa_items,_valoresbaixa_items, _condicoesbaixa_items);   
        }
        public int Alterar()
        {
if (_condicoesbaixa_items.Count > 0)
{
return ExecuteNonSql.Executar("baixa_items", TipoDeOperacao.Tipo.Update, _colunabaixa_items,_valoresbaixa_items, _condicoesbaixa_items);
}
else
{
List<string> Nomebaixa_items = new List<string>();
List<dynamic> Valorbaixa_items = new List<dynamic>();
_valoresbaixa_items.Clear();
if(Id!=null){ Nomebaixa_items.Add("id");
 Valorbaixa_items.Add(Oid);
 _valoresbaixa_items.Add(Id);
}if(Iditens!=null){ Nomebaixa_items.Add("iditens");
 Valorbaixa_items.Add(Oiditens);
 _valoresbaixa_items.Add(Iditens);
}if(Idrequisitantes!=null){ Nomebaixa_items.Add("idrequisitantes");
 Valorbaixa_items.Add(Oidrequisitantes);
 _valoresbaixa_items.Add(Idrequisitantes);
}if(Quantidade!=null){ Nomebaixa_items.Add("quantidade");
 Valorbaixa_items.Add(Oquantidade);
 _valoresbaixa_items.Add(Quantidade);
}if(Os!=null){ Nomebaixa_items.Add("os");
 Valorbaixa_items.Add(Oos);
 _valoresbaixa_items.Add(Os);
}if(Data!=null){ Nomebaixa_items.Add("data");
 Valorbaixa_items.Add(Odata);
 _valoresbaixa_items.Add(Data);
}List<dynamic> Condicaobaixa_items = new List<dynamic>();
Condicaobaixa_items.Add(Nomebaixa_items);
Condicaobaixa_items.Add(Valorbaixa_items);
return ExecuteNonSql.Executar("baixa_items", TipoDeOperacao.Tipo.UpdateCondicional, _colunabaixa_items, _valoresbaixa_items, Condicaobaixa_items);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("baixa_items", TipoDeOperacao.Tipo.Delete, _colunabaixa_items,_valoresbaixa_items, _condicoesbaixa_items);
        }
        static public List<baixa_items> Obter()
        {
            List<baixa_items> lista = new List<baixa_items>();
            DataTable tabela = Select.SelectSQL("select * from baixa_items");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                baixa_items novo = new baixa_items();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Idrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; Oidrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Os = (string)tabela.Rows[a]["os"]; Oos = (string)tabela.Rows[a]["os"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<baixa_items> Obter(string where)
        {
            List<baixa_items> lista = new List<baixa_items>();
            DataTable tabela = Select.SelectSQL("select * from baixa_items where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                baixa_items novo = new baixa_items();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Idrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; Oidrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Os = (string)tabela.Rows[a]["os"]; Oos = (string)tabela.Rows[a]["os"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<baixa_items> ObterComFiltroAvancado(string sql)
        {
            List<baixa_items> lista = new List<baixa_items>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                baixa_items novo = new baixa_items();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Idrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; Oidrequisitantes = (int)tabela.Rows[a]["idrequisitantes"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Os = (string)tabela.Rows[a]["os"]; Oos = (string)tabela.Rows[a]["os"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from baixa_items").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from baixa_items where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from baixa_items ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from baixa_items where " + where + "");
}


# endregion
    }
}
