using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class fabricantes
    {
        List<dynamic> _valoresfabricantes = new List<dynamic>();
        List<string> _colunafabricantes = new List<string>();
        List<dynamic> _condicoesfabricantes = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunafabricantes.Count; a++)
         {
             if (col == _colunafabricantes[a])
                  {
                       return;
                  }
     }
_colunafabricantes.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesfabricantes.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string site="site";
        public const string email="email";
        public const string tel1="tel1";
        public const string tel2="tel2";
        public const string tel3="tel3";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresfabricantes.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresfabricantes.Add(value); }
        }

        static string Osite;
        string site;
        public string Site
        {
            get { return site; }
            set { site = value; Add("site"); _valoresfabricantes.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresfabricantes.Add(value); }
        }

        static string Otel1;
        string tel1;
        public string Tel1
        {
            get { return tel1; }
            set { tel1 = value; Add("tel1"); _valoresfabricantes.Add(value); }
        }

        static string Otel2;
        string tel2;
        public string Tel2
        {
            get { return tel2; }
            set { tel2 = value; Add("tel2"); _valoresfabricantes.Add(value); }
        }

        static string Otel3;
        string tel3;
        public string Tel3
        {
            get { return tel3; }
            set { tel3 = value; Add("tel3"); _valoresfabricantes.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("fabricantes", TipoDeOperacao.Tipo.InsertMultiplo, _colunafabricantes,_valoresfabricantes, _condicoesfabricantes);   
        }
        public int Alterar()
        {
if (_condicoesfabricantes.Count > 0)
{
return ExecuteNonSql.Executar("fabricantes", TipoDeOperacao.Tipo.Update, _colunafabricantes,_valoresfabricantes, _condicoesfabricantes);
}
else
{
List<string> Nomefabricantes = new List<string>();
List<dynamic> Valorfabricantes = new List<dynamic>();
_valoresfabricantes.Clear();
if(Id!=null){ Nomefabricantes.Add("id");
 Valorfabricantes.Add(Oid);
 _valoresfabricantes.Add(Id);
}if(Nome!=null){ Nomefabricantes.Add("nome");
 Valorfabricantes.Add(Onome);
 _valoresfabricantes.Add(Nome);
}if(Site!=null){ Nomefabricantes.Add("site");
 Valorfabricantes.Add(Osite);
 _valoresfabricantes.Add(Site);
}if(Email!=null){ Nomefabricantes.Add("email");
 Valorfabricantes.Add(Oemail);
 _valoresfabricantes.Add(Email);
}if(Tel1!=null){ Nomefabricantes.Add("tel1");
 Valorfabricantes.Add(Otel1);
 _valoresfabricantes.Add(Tel1);
}if(Tel2!=null){ Nomefabricantes.Add("tel2");
 Valorfabricantes.Add(Otel2);
 _valoresfabricantes.Add(Tel2);
}if(Tel3!=null){ Nomefabricantes.Add("tel3");
 Valorfabricantes.Add(Otel3);
 _valoresfabricantes.Add(Tel3);
}List<dynamic> Condicaofabricantes = new List<dynamic>();
Condicaofabricantes.Add(Nomefabricantes);
Condicaofabricantes.Add(Valorfabricantes);
return ExecuteNonSql.Executar("fabricantes", TipoDeOperacao.Tipo.UpdateCondicional, _colunafabricantes, _valoresfabricantes, Condicaofabricantes);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("fabricantes", TipoDeOperacao.Tipo.Delete, _colunafabricantes,_valoresfabricantes, _condicoesfabricantes);
        }
        static public List<fabricantes> Obter()
        {
            List<fabricantes> lista = new List<fabricantes>();
            DataTable tabela = Select.SelectSQL("select * from fabricantes");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                fabricantes novo = new fabricantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Site = (string)tabela.Rows[a]["site"]; Osite = (string)tabela.Rows[a]["site"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Tel1 = (string)tabela.Rows[a]["tel1"]; Otel1 = (string)tabela.Rows[a]["tel1"]; } catch { }
            try {   novo.Tel2 = (string)tabela.Rows[a]["tel2"]; Otel2 = (string)tabela.Rows[a]["tel2"]; } catch { }
            try {   novo.Tel3 = (string)tabela.Rows[a]["tel3"]; Otel3 = (string)tabela.Rows[a]["tel3"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<fabricantes> Obter(string where)
        {
            List<fabricantes> lista = new List<fabricantes>();
            DataTable tabela = Select.SelectSQL("select * from fabricantes where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                fabricantes novo = new fabricantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Site = (string)tabela.Rows[a]["site"]; Osite = (string)tabela.Rows[a]["site"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Tel1 = (string)tabela.Rows[a]["tel1"]; Otel1 = (string)tabela.Rows[a]["tel1"]; } catch { }
            try {   novo.Tel2 = (string)tabela.Rows[a]["tel2"]; Otel2 = (string)tabela.Rows[a]["tel2"]; } catch { }
            try {   novo.Tel3 = (string)tabela.Rows[a]["tel3"]; Otel3 = (string)tabela.Rows[a]["tel3"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<fabricantes> ObterComFiltroAvancado(string sql)
        {
            List<fabricantes> lista = new List<fabricantes>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                fabricantes novo = new fabricantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Site = (string)tabela.Rows[a]["site"]; Osite = (string)tabela.Rows[a]["site"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Tel1 = (string)tabela.Rows[a]["tel1"]; Otel1 = (string)tabela.Rows[a]["tel1"]; } catch { }
            try {   novo.Tel2 = (string)tabela.Rows[a]["tel2"]; Otel2 = (string)tabela.Rows[a]["tel2"]; } catch { }
            try {   novo.Tel3 = (string)tabela.Rows[a]["tel3"]; Otel3 = (string)tabela.Rows[a]["tel3"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from fabricantes").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from fabricantes where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from fabricantes ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from fabricantes where " + where + "");
}


# endregion
    }
}
