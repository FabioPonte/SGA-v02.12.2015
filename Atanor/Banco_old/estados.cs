using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class estados
    {
        List<dynamic> _valoresestados = new List<dynamic>();
        List<string> _colunaestados = new List<string>();
        List<dynamic> _condicoesestados = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaestados.Count; a++)
         {
             if (col == _colunaestados[a])
                  {
                       return;
                  }
     }
_colunaestados.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesestados.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string uf="uf";
        public const string nome="nome";
        public const string local="local";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresestados.Add(value); }
        }

        static string Ouf;
        string uf;
        public string Uf
        {
            get { return uf; }
            set { uf = value; Add("uf"); _valoresestados.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresestados.Add(value); }
        }

        static string Olocal;
        string local;
        public string Local
        {
            get { return local; }
            set { local = value; Add("local"); _valoresestados.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("estados", TipoDeOperacao.Tipo.InsertMultiplo, _colunaestados,_valoresestados, _condicoesestados);   
        }
        public int Alterar()
        {
if (_condicoesestados.Count > 0)
{
return ExecuteNonSql.Executar("estados", TipoDeOperacao.Tipo.Update, _colunaestados,_valoresestados, _condicoesestados);
}
else
{
List<string> Nomeestados = new List<string>();
List<dynamic> Valorestados = new List<dynamic>();
_valoresestados.Clear();
if(Id!=null){ Nomeestados.Add("id");
 Valorestados.Add(Oid);
 _valoresestados.Add(Id);
}if(Uf!=null){ Nomeestados.Add("uf");
 Valorestados.Add(Ouf);
 _valoresestados.Add(Uf);
}if(Nome!=null){ Nomeestados.Add("nome");
 Valorestados.Add(Onome);
 _valoresestados.Add(Nome);
}if(Local!=null){ Nomeestados.Add("local");
 Valorestados.Add(Olocal);
 _valoresestados.Add(Local);
}List<dynamic> Condicaoestados = new List<dynamic>();
Condicaoestados.Add(Nomeestados);
Condicaoestados.Add(Valorestados);
return ExecuteNonSql.Executar("estados", TipoDeOperacao.Tipo.UpdateCondicional, _colunaestados, _valoresestados, Condicaoestados);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("estados", TipoDeOperacao.Tipo.Delete, _colunaestados,_valoresestados, _condicoesestados);
        }
        static public List<estados> Obter()
        {
            List<estados> lista = new List<estados>();
            DataTable tabela = Select.SelectSQL("select * from estados");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estados novo = new estados();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estados> Obter(string where)
        {
            List<estados> lista = new List<estados>();
            DataTable tabela = Select.SelectSQL("select * from estados where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estados novo = new estados();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estados> ObterComFiltroAvancado(string sql)
        {
            List<estados> lista = new List<estados>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estados novo = new estados();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from estados").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from estados where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from estados ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from estados where " + where + "");
}


# endregion
    }
}
