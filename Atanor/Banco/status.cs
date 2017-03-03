using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class status
    {
        List<dynamic> _valoresstatus = new List<dynamic>();
        List<string> _colunastatus = new List<string>();
        List<dynamic> _condicoesstatus = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunastatus.Count; a++)
         {
             if (col == _colunastatus[a])
                  {
                       return;
                  }
     }
_colunastatus.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesstatus.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string estado="estado";
        public const string obs="obs";
        public const string cor="cor";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresstatus.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresstatus.Add(value); }
        }

        static Boolean Oestado;
        Boolean estado;
        public Boolean Estado
        {
            get { return estado; }
            set { estado = value; Add("estado"); _valoresstatus.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresstatus.Add(value); }
        }

        static string Ocor;
        string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; Add("cor"); _valoresstatus.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("status", TipoDeOperacao.Tipo.InsertMultiplo, _colunastatus,_valoresstatus, _condicoesstatus);   
        }
        public int Alterar()
        {
if (_condicoesstatus.Count > 0)
{
return ExecuteNonSql.Executar("status", TipoDeOperacao.Tipo.Update, _colunastatus,_valoresstatus, _condicoesstatus);
}
else
{
List<string> Nomestatus = new List<string>();
List<dynamic> Valorstatus = new List<dynamic>();
_valoresstatus.Clear();
if(Id!=null){ Nomestatus.Add("id");
 Valorstatus.Add(Oid);
 _valoresstatus.Add(Id);
}if(Nome!=null){ Nomestatus.Add("nome");
 Valorstatus.Add(Onome);
 _valoresstatus.Add(Nome);
}if(Estado!=null){ Nomestatus.Add("estado");
 Valorstatus.Add(Oestado);
 _valoresstatus.Add(Estado);
}if(Obs!=null){ Nomestatus.Add("obs");
 Valorstatus.Add(Oobs);
 _valoresstatus.Add(Obs);
}if(Cor!=null){ Nomestatus.Add("cor");
 Valorstatus.Add(Ocor);
 _valoresstatus.Add(Cor);
}List<dynamic> Condicaostatus = new List<dynamic>();
Condicaostatus.Add(Nomestatus);
Condicaostatus.Add(Valorstatus);
return ExecuteNonSql.Executar("status", TipoDeOperacao.Tipo.UpdateCondicional, _colunastatus, _valoresstatus, Condicaostatus);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("status", TipoDeOperacao.Tipo.Delete, _colunastatus,_valoresstatus, _condicoesstatus);
        }
        static public List<status> Obter()
        {
            List<status> lista = new List<status>();
            DataTable tabela = Select.SelectSQL("select * from status");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                status novo = new status();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Estado = Convert.ToBoolean(tabela.Rows[a]["estado"]);  Oestado= Convert.ToBoolean(tabela.Rows[a]["estado"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<status> Obter(string where)
        {
            List<status> lista = new List<status>();
            DataTable tabela = Select.SelectSQL("select * from status where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                status novo = new status();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Estado = Convert.ToBoolean(tabela.Rows[a]["estado"]);  Oestado= Convert.ToBoolean(tabela.Rows[a]["estado"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<status> ObterComFiltroAvancado(string sql)
        {
            List<status> lista = new List<status>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                status novo = new status();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Estado = Convert.ToBoolean(tabela.Rows[a]["estado"]);  Oestado= Convert.ToBoolean(tabela.Rows[a]["estado"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from status").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from status where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from status ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from status where " + where + "");
}


# endregion
    }
}
