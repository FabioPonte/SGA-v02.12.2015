using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class grupo_itens
    {
        List<dynamic> _valoresgrupo_itens = new List<dynamic>();
        List<string> _colunagrupo_itens = new List<string>();
        List<dynamic> _condicoesgrupo_itens = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunagrupo_itens.Count; a++)
         {
             if (col == _colunagrupo_itens[a])
                  {
                       return;
                  }
     }
_colunagrupo_itens.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesgrupo_itens.Add(value); }
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
            set { id = value; Add("id"); _valoresgrupo_itens.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresgrupo_itens.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("grupo_itens", TipoDeOperacao.Tipo.InsertMultiplo, _colunagrupo_itens,_valoresgrupo_itens, _condicoesgrupo_itens);   
        }
        public int Alterar()
        {
if (_condicoesgrupo_itens.Count > 0)
{
return ExecuteNonSql.Executar("grupo_itens", TipoDeOperacao.Tipo.Update, _colunagrupo_itens,_valoresgrupo_itens, _condicoesgrupo_itens);
}
else
{
List<string> Nomegrupo_itens = new List<string>();
List<dynamic> Valorgrupo_itens = new List<dynamic>();
_valoresgrupo_itens.Clear();
if(Id!=null){ Nomegrupo_itens.Add("id");
 Valorgrupo_itens.Add(Oid);
 _valoresgrupo_itens.Add(Id);
}if(Nome!=null){ Nomegrupo_itens.Add("nome");
 Valorgrupo_itens.Add(Onome);
 _valoresgrupo_itens.Add(Nome);
}List<dynamic> Condicaogrupo_itens = new List<dynamic>();
Condicaogrupo_itens.Add(Nomegrupo_itens);
Condicaogrupo_itens.Add(Valorgrupo_itens);
return ExecuteNonSql.Executar("grupo_itens", TipoDeOperacao.Tipo.UpdateCondicional, _colunagrupo_itens, _valoresgrupo_itens, Condicaogrupo_itens);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("grupo_itens", TipoDeOperacao.Tipo.Delete, _colunagrupo_itens,_valoresgrupo_itens, _condicoesgrupo_itens);
        }
        static public List<grupo_itens> Obter()
        {
            List<grupo_itens> lista = new List<grupo_itens>();
            DataTable tabela = Select.SelectSQL("select * from grupo_itens");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                grupo_itens novo = new grupo_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<grupo_itens> Obter(string where)
        {
            List<grupo_itens> lista = new List<grupo_itens>();
            DataTable tabela = Select.SelectSQL("select * from grupo_itens where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                grupo_itens novo = new grupo_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<grupo_itens> ObterComFiltroAvancado(string sql)
        {
            List<grupo_itens> lista = new List<grupo_itens>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                grupo_itens novo = new grupo_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from grupo_itens").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from grupo_itens where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from grupo_itens ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from grupo_itens where " + where + "");
}


# endregion
    }
}
