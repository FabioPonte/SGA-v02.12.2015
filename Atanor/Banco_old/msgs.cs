using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class msgs
    {
        List<dynamic> _valoresmsgs = new List<dynamic>();
        List<string> _colunamsgs = new List<string>();
        List<dynamic> _condicoesmsgs = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunamsgs.Count; a++)
         {
             if (col == _colunamsgs[a])
                  {
                       return;
                  }
     }
_colunamsgs.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesmsgs.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string poschamado_id="poschamado_id";
        public const string msg="msg";
        public const string html="html";
        public const string conteudo="conteudo";
        public const string url="url";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresmsgs.Add(value); }
        }

        static int Oposchamado_id;
        int poschamado_id;
        public int Poschamado_id
        {
            get { return poschamado_id; }
            set { poschamado_id = value; Add("poschamado_id"); _valoresmsgs.Add(value); }
        }

        static dynamic Omsg;
        dynamic msg;
        public dynamic Msg
        {
            get { return msg; }
            set { msg = value; Add("msg"); _valoresmsgs.Add(value); }
        }

        static Boolean Ohtml;
        Boolean html;
        public Boolean Html
        {
            get { return html; }
            set { html = value; Add("html"); _valoresmsgs.Add(value); }
        }

        static string Oconteudo;
        string conteudo;
        public string Conteudo
        {
            get { return conteudo; }
            set { conteudo = value; Add("conteudo"); _valoresmsgs.Add(value); }
        }

        static string Ourl;
        string url;
        public string Url
        {
            get { return url; }
            set { url = value; Add("url"); _valoresmsgs.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("msgs", TipoDeOperacao.Tipo.InsertMultiplo, _colunamsgs,_valoresmsgs, _condicoesmsgs);   
        }
        public int Alterar()
        {
if (_condicoesmsgs.Count > 0)
{
return ExecuteNonSql.Executar("msgs", TipoDeOperacao.Tipo.Update, _colunamsgs,_valoresmsgs, _condicoesmsgs);
}
else
{
List<string> Nomemsgs = new List<string>();
List<dynamic> Valormsgs = new List<dynamic>();
_valoresmsgs.Clear();
if(Id!=null){ Nomemsgs.Add("id");
 Valormsgs.Add(Oid);
 _valoresmsgs.Add(Id);
}if(Poschamado_id!=null){ Nomemsgs.Add("poschamado_id");
 Valormsgs.Add(Oposchamado_id);
 _valoresmsgs.Add(Poschamado_id);
}if(Msg!=null){ Nomemsgs.Add("msg");
 Valormsgs.Add(Omsg);
 _valoresmsgs.Add(Msg);
}if(Html!=null){ Nomemsgs.Add("html");
 Valormsgs.Add(Ohtml);
 _valoresmsgs.Add(Html);
}if(Conteudo!=null){ Nomemsgs.Add("conteudo");
 Valormsgs.Add(Oconteudo);
 _valoresmsgs.Add(Conteudo);
}if(Url!=null){ Nomemsgs.Add("url");
 Valormsgs.Add(Ourl);
 _valoresmsgs.Add(Url);
}List<dynamic> Condicaomsgs = new List<dynamic>();
Condicaomsgs.Add(Nomemsgs);
Condicaomsgs.Add(Valormsgs);
return ExecuteNonSql.Executar("msgs", TipoDeOperacao.Tipo.UpdateCondicional, _colunamsgs, _valoresmsgs, Condicaomsgs);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("msgs", TipoDeOperacao.Tipo.Delete, _colunamsgs,_valoresmsgs, _condicoesmsgs);
        }
        static public List<msgs> Obter()
        {
            List<msgs> lista = new List<msgs>();
            DataTable tabela = Select.SelectSQL("select * from msgs");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                msgs novo = new msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Html = Convert.ToBoolean(tabela.Rows[a]["html"]);  Ohtml= Convert.ToBoolean(tabela.Rows[a]["html"]); } catch { }
            try {   novo.Conteudo = (string)tabela.Rows[a]["conteudo"]; Oconteudo = (string)tabela.Rows[a]["conteudo"]; } catch { }
            try {   novo.Url = (string)tabela.Rows[a]["url"]; Ourl = (string)tabela.Rows[a]["url"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<msgs> Obter(string where)
        {
            List<msgs> lista = new List<msgs>();
            DataTable tabela = Select.SelectSQL("select * from msgs where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                msgs novo = new msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Html = Convert.ToBoolean(tabela.Rows[a]["html"]);  Ohtml= Convert.ToBoolean(tabela.Rows[a]["html"]); } catch { }
            try {   novo.Conteudo = (string)tabela.Rows[a]["conteudo"]; Oconteudo = (string)tabela.Rows[a]["conteudo"]; } catch { }
            try {   novo.Url = (string)tabela.Rows[a]["url"]; Ourl = (string)tabela.Rows[a]["url"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<msgs> ObterComFiltroAvancado(string sql)
        {
            List<msgs> lista = new List<msgs>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                msgs novo = new msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Html = Convert.ToBoolean(tabela.Rows[a]["html"]);  Ohtml= Convert.ToBoolean(tabela.Rows[a]["html"]); } catch { }
            try {   novo.Conteudo = (string)tabela.Rows[a]["conteudo"]; Oconteudo = (string)tabela.Rows[a]["conteudo"]; } catch { }
            try {   novo.Url = (string)tabela.Rows[a]["url"]; Ourl = (string)tabela.Rows[a]["url"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from msgs").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from msgs where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from msgs ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from msgs where " + where + "");
}


# endregion
    }
}
