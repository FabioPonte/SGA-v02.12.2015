using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class itens_entrada_saida
    {
        List<dynamic> _valoresitens_entrada_saida = new List<dynamic>();
        List<string> _colunaitens_entrada_saida = new List<string>();
        List<dynamic> _condicoesitens_entrada_saida = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaitens_entrada_saida.Count; a++)
         {
             if (col == _colunaitens_entrada_saida[a])
                  {
                       return;
                  }
     }
_colunaitens_entrada_saida.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesitens_entrada_saida.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string iditens="iditens";
        public const string identradasaida="identradasaida";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresitens_entrada_saida.Add(value); }
        }

        static int Oiditens;
        int iditens;
        public int Iditens
        {
            get { return iditens; }
            set { iditens = value; Add("iditens"); _valoresitens_entrada_saida.Add(value); }
        }

        static int Oidentradasaida;
        int identradasaida;
        public int Identradasaida
        {
            get { return identradasaida; }
            set { identradasaida = value; Add("identradasaida"); _valoresitens_entrada_saida.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresitens_entrada_saida.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("itens_entrada_saida", TipoDeOperacao.Tipo.InsertMultiplo, _colunaitens_entrada_saida,_valoresitens_entrada_saida, _condicoesitens_entrada_saida);   
        }
        public int Alterar()
        {
if (_condicoesitens_entrada_saida.Count > 0)
{
return ExecuteNonSql.Executar("itens_entrada_saida", TipoDeOperacao.Tipo.Update, _colunaitens_entrada_saida,_valoresitens_entrada_saida, _condicoesitens_entrada_saida);
}
else
{
List<string> Nomeitens_entrada_saida = new List<string>();
List<dynamic> Valoritens_entrada_saida = new List<dynamic>();
_valoresitens_entrada_saida.Clear();
if(Id!=null){ Nomeitens_entrada_saida.Add("id");
 Valoritens_entrada_saida.Add(Oid);
 _valoresitens_entrada_saida.Add(Id);
}if(Iditens!=null){ Nomeitens_entrada_saida.Add("iditens");
 Valoritens_entrada_saida.Add(Oiditens);
 _valoresitens_entrada_saida.Add(Iditens);
}if(Identradasaida!=null){ Nomeitens_entrada_saida.Add("identradasaida");
 Valoritens_entrada_saida.Add(Oidentradasaida);
 _valoresitens_entrada_saida.Add(Identradasaida);
}if(Obs!=null){ Nomeitens_entrada_saida.Add("obs");
 Valoritens_entrada_saida.Add(Oobs);
 _valoresitens_entrada_saida.Add(Obs);
}List<dynamic> Condicaoitens_entrada_saida = new List<dynamic>();
Condicaoitens_entrada_saida.Add(Nomeitens_entrada_saida);
Condicaoitens_entrada_saida.Add(Valoritens_entrada_saida);
return ExecuteNonSql.Executar("itens_entrada_saida", TipoDeOperacao.Tipo.UpdateCondicional, _colunaitens_entrada_saida, _valoresitens_entrada_saida, Condicaoitens_entrada_saida);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("itens_entrada_saida", TipoDeOperacao.Tipo.Delete, _colunaitens_entrada_saida,_valoresitens_entrada_saida, _condicoesitens_entrada_saida);
        }
        static public List<itens_entrada_saida> Obter()
        {
            List<itens_entrada_saida> lista = new List<itens_entrada_saida>();
            DataTable tabela = Select.SelectSQL("select * from itens_entrada_saida");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_entrada_saida novo = new itens_entrada_saida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Identradasaida = (int)tabela.Rows[a]["identradasaida"]; Oidentradasaida = (int)tabela.Rows[a]["identradasaida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens_entrada_saida> Obter(string where)
        {
            List<itens_entrada_saida> lista = new List<itens_entrada_saida>();
            DataTable tabela = Select.SelectSQL("select * from itens_entrada_saida where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_entrada_saida novo = new itens_entrada_saida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Identradasaida = (int)tabela.Rows[a]["identradasaida"]; Oidentradasaida = (int)tabela.Rows[a]["identradasaida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens_entrada_saida> ObterComFiltroAvancado(string sql)
        {
            List<itens_entrada_saida> lista = new List<itens_entrada_saida>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_entrada_saida novo = new itens_entrada_saida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Identradasaida = (int)tabela.Rows[a]["identradasaida"]; Oidentradasaida = (int)tabela.Rows[a]["identradasaida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from itens_entrada_saida").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from itens_entrada_saida where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from itens_entrada_saida ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from itens_entrada_saida where " + where + "");
}


# endregion
    }
}
