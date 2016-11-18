using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class setor
    {
        List<dynamic> _valoressetor = new List<dynamic>();
        List<string> _colunasetor = new List<string>();
        List<dynamic> _condicoessetor = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunasetor.Count; a++)
         {
             if (col == _colunasetor[a])
                  {
                       return;
                  }
     }
_colunasetor.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoessetor.Add(value); }
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
            set { id = value; Add("id"); _valoressetor.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoressetor.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("setor", TipoDeOperacao.Tipo.InsertMultiplo, _colunasetor,_valoressetor, _condicoessetor);   
        }
        public int Alterar()
        {
if (_condicoessetor.Count > 0)
{
return ExecuteNonSql.Executar("setor", TipoDeOperacao.Tipo.Update, _colunasetor,_valoressetor, _condicoessetor);
}
else
{
List<string> Nomesetor = new List<string>();
List<dynamic> Valorsetor = new List<dynamic>();
_valoressetor.Clear();
if(Id!=null){ Nomesetor.Add("id");
 Valorsetor.Add(Oid);
 _valoressetor.Add(Id);
}if(Nome!=null){ Nomesetor.Add("nome");
 Valorsetor.Add(Onome);
 _valoressetor.Add(Nome);
}List<dynamic> Condicaosetor = new List<dynamic>();
Condicaosetor.Add(Nomesetor);
Condicaosetor.Add(Valorsetor);
return ExecuteNonSql.Executar("setor", TipoDeOperacao.Tipo.UpdateCondicional, _colunasetor, _valoressetor, Condicaosetor);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("setor", TipoDeOperacao.Tipo.Delete, _colunasetor,_valoressetor, _condicoessetor);
        }
        static public List<setor> Obter()
        {
            List<setor> lista = new List<setor>();
            DataTable tabela = Select.SelectSQL("select * from setor");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                setor novo = new setor();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<setor> Obter(string where)
        {
            List<setor> lista = new List<setor>();
            DataTable tabela = Select.SelectSQL("select * from setor where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                setor novo = new setor();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<setor> ObterComFiltroAvancado(string sql)
        {
            List<setor> lista = new List<setor>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                setor novo = new setor();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from setor").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from setor where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from setor ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from setor where " + where + "");
}


# endregion
    }
}
