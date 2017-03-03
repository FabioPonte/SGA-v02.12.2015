using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class emails_copia
    {
        List<dynamic> _valoresemails_copia = new List<dynamic>();
        List<string> _colunaemails_copia = new List<string>();
        List<dynamic> _condicoesemails_copia = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemails_copia.Count; a++)
         {
             if (col == _colunaemails_copia[a])
                  {
                       return;
                  }
     }
_colunaemails_copia.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemails_copia.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string email="email";
        public const string emails_id="emails_id";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemails_copia.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresemails_copia.Add(value); }
        }

        static int Oemails_id;
        int emails_id;
        public int Emails_id
        {
            get { return emails_id; }
            set { emails_id = value; Add("emails_id"); _valoresemails_copia.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("emails_copia", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemails_copia,_valoresemails_copia, _condicoesemails_copia);   
        }
        public int Alterar()
        {
if (_condicoesemails_copia.Count > 0)
{
return ExecuteNonSql.Executar("emails_copia", TipoDeOperacao.Tipo.Update, _colunaemails_copia,_valoresemails_copia, _condicoesemails_copia);
}
else
{
List<string> Nomeemails_copia = new List<string>();
List<dynamic> Valoremails_copia = new List<dynamic>();
_valoresemails_copia.Clear();
if(Id!=null){ Nomeemails_copia.Add("id");
 Valoremails_copia.Add(Oid);
 _valoresemails_copia.Add(Id);
}if(Email!=null){ Nomeemails_copia.Add("email");
 Valoremails_copia.Add(Oemail);
 _valoresemails_copia.Add(Email);
}if(Emails_id!=null){ Nomeemails_copia.Add("emails_id");
 Valoremails_copia.Add(Oemails_id);
 _valoresemails_copia.Add(Emails_id);
}List<dynamic> Condicaoemails_copia = new List<dynamic>();
Condicaoemails_copia.Add(Nomeemails_copia);
Condicaoemails_copia.Add(Valoremails_copia);
return ExecuteNonSql.Executar("emails_copia", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemails_copia, _valoresemails_copia, Condicaoemails_copia);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("emails_copia", TipoDeOperacao.Tipo.Delete, _colunaemails_copia,_valoresemails_copia, _condicoesemails_copia);
        }
        static public List<emails_copia> Obter()
        {
            List<emails_copia> lista = new List<emails_copia>();
            DataTable tabela = Select.SelectSQL("select * from emails_copia");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_copia novo = new emails_copia();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_copia> Obter(string where)
        {
            List<emails_copia> lista = new List<emails_copia>();
            DataTable tabela = Select.SelectSQL("select * from emails_copia where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_copia novo = new emails_copia();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_copia> ObterComFiltroAvancado(string sql)
        {
            List<emails_copia> lista = new List<emails_copia>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_copia novo = new emails_copia();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from emails_copia").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from emails_copia where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from emails_copia ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from emails_copia where " + where + "");
}


# endregion
    }
}
