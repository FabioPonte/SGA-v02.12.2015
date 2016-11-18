using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class prioridades
    {
        List<dynamic> _valoresprioridades = new List<dynamic>();
        List<string> _colunaprioridades = new List<string>();
        List<dynamic> _condicoesprioridades = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaprioridades.Count; a++)
         {
             if (col == _colunaprioridades[a])
                  {
                       return;
                  }
     }
_colunaprioridades.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesprioridades.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresprioridades.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresprioridades.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("prioridades", TipoDeOperacao.Tipo.InsertMultiplo, _colunaprioridades,_valoresprioridades, _condicoesprioridades);   
        }
        public int Alterar()
        {
if (_condicoesprioridades.Count > 0)
{
return ExecuteNonSql.Executar("prioridades", TipoDeOperacao.Tipo.Update, _colunaprioridades,_valoresprioridades, _condicoesprioridades);
}
else
{
List<string> Nomeprioridades = new List<string>();
List<dynamic> Valorprioridades = new List<dynamic>();
_valoresprioridades.Clear();
if(Id!=null){ Nomeprioridades.Add("id");
 Valorprioridades.Add(Oid);
 _valoresprioridades.Add(Id);
}if(Nome!=null){ Nomeprioridades.Add("nome");
 Valorprioridades.Add(Onome);
 _valoresprioridades.Add(Nome);
}List<dynamic> Condicaoprioridades = new List<dynamic>();
Condicaoprioridades.Add(Nomeprioridades);
Condicaoprioridades.Add(Valorprioridades);
return ExecuteNonSql.Executar("prioridades", TipoDeOperacao.Tipo.UpdateCondicional, _colunaprioridades, _valoresprioridades, Condicaoprioridades);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("prioridades", TipoDeOperacao.Tipo.Delete, _colunaprioridades,_valoresprioridades, _condicoesprioridades);
        }
        static public List<prioridades> Obter()
        {
            List<prioridades> lista = new List<prioridades>();
            DataTable tabela = Select.SelectSQL("select * from prioridades");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                prioridades novo = new prioridades();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<prioridades> Obter(string where)
        {
            List<prioridades> lista = new List<prioridades>();
            DataTable tabela = Select.SelectSQL("select * from prioridades where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                prioridades novo = new prioridades();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<prioridades> ObterComFiltroAvancado(string sql)
        {
            List<prioridades> lista = new List<prioridades>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                prioridades novo = new prioridades();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from prioridades").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from prioridades where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from prioridades ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from prioridades where " + where + "");
}


# endregion
    }
}
