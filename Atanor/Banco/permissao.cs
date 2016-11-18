using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class permissao
    {
        List<dynamic> _valorespermissao = new List<dynamic>();
        List<string> _colunapermissao = new List<string>();
        List<dynamic> _condicoespermissao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunapermissao.Count; a++)
         {
             if (col == _colunapermissao[a])
                  {
                       return;
                  }
     }
_colunapermissao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoespermissao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string modulo="modulo";
        public const string programa="programa";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorespermissao.Add(value); }
        }

        static string Omodulo;
        string modulo;
        public string Modulo
        {
            get { return modulo; }
            set { modulo = value; Add("modulo"); _valorespermissao.Add(value); }
        }

        static string Oprograma;
        string programa;
        public string Programa
        {
            get { return programa; }
            set { programa = value; Add("programa"); _valorespermissao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("permissao", TipoDeOperacao.Tipo.InsertMultiplo, _colunapermissao,_valorespermissao, _condicoespermissao);   
        }
        public int Alterar()
        {
if (_condicoespermissao.Count > 0)
{
return ExecuteNonSql.Executar("permissao", TipoDeOperacao.Tipo.Update, _colunapermissao,_valorespermissao, _condicoespermissao);
}
else
{
List<string> Nomepermissao = new List<string>();
List<dynamic> Valorpermissao = new List<dynamic>();
_valorespermissao.Clear();
if(Id!=null){ Nomepermissao.Add("id");
 Valorpermissao.Add(Oid);
 _valorespermissao.Add(Id);
}if(Modulo!=null){ Nomepermissao.Add("modulo");
 Valorpermissao.Add(Omodulo);
 _valorespermissao.Add(Modulo);
}if(Programa!=null){ Nomepermissao.Add("programa");
 Valorpermissao.Add(Oprograma);
 _valorespermissao.Add(Programa);
}List<dynamic> Condicaopermissao = new List<dynamic>();
Condicaopermissao.Add(Nomepermissao);
Condicaopermissao.Add(Valorpermissao);
return ExecuteNonSql.Executar("permissao", TipoDeOperacao.Tipo.UpdateCondicional, _colunapermissao, _valorespermissao, Condicaopermissao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("permissao", TipoDeOperacao.Tipo.Delete, _colunapermissao,_valorespermissao, _condicoespermissao);
        }
        static public List<permissao> Obter()
        {
            List<permissao> lista = new List<permissao>();
            DataTable tabela = Select.SelectSQL("select * from permissao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao novo = new permissao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Modulo = (string)tabela.Rows[a]["modulo"]; Omodulo = (string)tabela.Rows[a]["modulo"]; } catch { }
            try {   novo.Programa = (string)tabela.Rows[a]["programa"]; Oprograma = (string)tabela.Rows[a]["programa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<permissao> Obter(string where)
        {
            List<permissao> lista = new List<permissao>();
            DataTable tabela = Select.SelectSQL("select * from permissao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao novo = new permissao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Modulo = (string)tabela.Rows[a]["modulo"]; Omodulo = (string)tabela.Rows[a]["modulo"]; } catch { }
            try {   novo.Programa = (string)tabela.Rows[a]["programa"]; Oprograma = (string)tabela.Rows[a]["programa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<permissao> ObterComFiltroAvancado(string sql)
        {
            List<permissao> lista = new List<permissao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao novo = new permissao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Modulo = (string)tabela.Rows[a]["modulo"]; Omodulo = (string)tabela.Rows[a]["modulo"]; } catch { }
            try {   novo.Programa = (string)tabela.Rows[a]["programa"]; Oprograma = (string)tabela.Rows[a]["programa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from permissao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from permissao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from permissao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from permissao where " + where + "");
}


# endregion
    }
}
