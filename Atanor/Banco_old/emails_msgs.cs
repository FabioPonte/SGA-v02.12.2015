using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class emails_msgs
    {
        List<dynamic> _valoresemails_msgs = new List<dynamic>();
        List<string> _colunaemails_msgs = new List<string>();
        List<dynamic> _condicoesemails_msgs = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemails_msgs.Count; a++)
         {
             if (col == _colunaemails_msgs[a])
                  {
                       return;
                  }
     }
_colunaemails_msgs.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemails_msgs.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string msg="msg";
        public const string emails_id="emails_id";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemails_msgs.Add(value); }
        }

        static dynamic Omsg;
        dynamic msg;
        public dynamic Msg
        {
            get { return msg; }
            set { msg = value; Add("msg"); _valoresemails_msgs.Add(value); }
        }

        static int Oemails_id;
        int emails_id;
        public int Emails_id
        {
            get { return emails_id; }
            set { emails_id = value; Add("emails_id"); _valoresemails_msgs.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("emails_msgs", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemails_msgs,_valoresemails_msgs, _condicoesemails_msgs);   
        }
        public int Alterar()
        {
if (_condicoesemails_msgs.Count > 0)
{
return ExecuteNonSql.Executar("emails_msgs", TipoDeOperacao.Tipo.Update, _colunaemails_msgs,_valoresemails_msgs, _condicoesemails_msgs);
}
else
{
List<string> Nomeemails_msgs = new List<string>();
List<dynamic> Valoremails_msgs = new List<dynamic>();
_valoresemails_msgs.Clear();
if(Id!=null){ Nomeemails_msgs.Add("id");
 Valoremails_msgs.Add(Oid);
 _valoresemails_msgs.Add(Id);
}if(Msg!=null){ Nomeemails_msgs.Add("msg");
 Valoremails_msgs.Add(Omsg);
 _valoresemails_msgs.Add(Msg);
}if(Emails_id!=null){ Nomeemails_msgs.Add("emails_id");
 Valoremails_msgs.Add(Oemails_id);
 _valoresemails_msgs.Add(Emails_id);
}List<dynamic> Condicaoemails_msgs = new List<dynamic>();
Condicaoemails_msgs.Add(Nomeemails_msgs);
Condicaoemails_msgs.Add(Valoremails_msgs);
return ExecuteNonSql.Executar("emails_msgs", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemails_msgs, _valoresemails_msgs, Condicaoemails_msgs);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("emails_msgs", TipoDeOperacao.Tipo.Delete, _colunaemails_msgs,_valoresemails_msgs, _condicoesemails_msgs);
        }
        static public List<emails_msgs> Obter()
        {
            List<emails_msgs> lista = new List<emails_msgs>();
            DataTable tabela = Select.SelectSQL("select * from emails_msgs");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_msgs novo = new emails_msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_msgs> Obter(string where)
        {
            List<emails_msgs> lista = new List<emails_msgs>();
            DataTable tabela = Select.SelectSQL("select * from emails_msgs where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_msgs novo = new emails_msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_msgs> ObterComFiltroAvancado(string sql)
        {
            List<emails_msgs> lista = new List<emails_msgs>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_msgs novo = new emails_msgs();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Msg = tabela.Rows[a]["msg"];  Omsg= tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from emails_msgs").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from emails_msgs where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from emails_msgs ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from emails_msgs where " + where + "");
}


# endregion
    }
}
