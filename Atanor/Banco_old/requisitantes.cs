using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class requisitantes
    {
        List<dynamic> _valoresrequisitantes = new List<dynamic>();
        List<string> _colunarequisitantes = new List<string>();
        List<dynamic> _condicoesrequisitantes = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunarequisitantes.Count; a++)
         {
             if (col == _colunarequisitantes[a])
                  {
                       return;
                  }
     }
_colunarequisitantes.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesrequisitantes.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string cc="cc";
        public const string codigo="codigo";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresrequisitantes.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresrequisitantes.Add(value); }
        }

        static string Occ;
        string cc;
        public string Cc
        {
            get { return cc; }
            set { cc = value; Add("cc"); _valoresrequisitantes.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresrequisitantes.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("requisitantes", TipoDeOperacao.Tipo.InsertMultiplo, _colunarequisitantes,_valoresrequisitantes, _condicoesrequisitantes);   
        }
        public int Alterar()
        {
if (_condicoesrequisitantes.Count > 0)
{
return ExecuteNonSql.Executar("requisitantes", TipoDeOperacao.Tipo.Update, _colunarequisitantes,_valoresrequisitantes, _condicoesrequisitantes);
}
else
{
List<string> Nomerequisitantes = new List<string>();
List<dynamic> Valorrequisitantes = new List<dynamic>();
_valoresrequisitantes.Clear();
if(Id!=null){ Nomerequisitantes.Add("id");
 Valorrequisitantes.Add(Oid);
 _valoresrequisitantes.Add(Id);
}if(Nome!=null){ Nomerequisitantes.Add("nome");
 Valorrequisitantes.Add(Onome);
 _valoresrequisitantes.Add(Nome);
}if(Cc!=null){ Nomerequisitantes.Add("cc");
 Valorrequisitantes.Add(Occ);
 _valoresrequisitantes.Add(Cc);
}if(Codigo!=null){ Nomerequisitantes.Add("codigo");
 Valorrequisitantes.Add(Ocodigo);
 _valoresrequisitantes.Add(Codigo);
}List<dynamic> Condicaorequisitantes = new List<dynamic>();
Condicaorequisitantes.Add(Nomerequisitantes);
Condicaorequisitantes.Add(Valorrequisitantes);
return ExecuteNonSql.Executar("requisitantes", TipoDeOperacao.Tipo.UpdateCondicional, _colunarequisitantes, _valoresrequisitantes, Condicaorequisitantes);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("requisitantes", TipoDeOperacao.Tipo.Delete, _colunarequisitantes,_valoresrequisitantes, _condicoesrequisitantes);
        }
        static public List<requisitantes> Obter()
        {
            List<requisitantes> lista = new List<requisitantes>();
            DataTable tabela = Select.SelectSQL("select * from requisitantes");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                requisitantes novo = new requisitantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cc = (string)tabela.Rows[a]["cc"]; Occ = (string)tabela.Rows[a]["cc"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<requisitantes> Obter(string where)
        {
            List<requisitantes> lista = new List<requisitantes>();
            DataTable tabela = Select.SelectSQL("select * from requisitantes where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                requisitantes novo = new requisitantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cc = (string)tabela.Rows[a]["cc"]; Occ = (string)tabela.Rows[a]["cc"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<requisitantes> ObterComFiltroAvancado(string sql)
        {
            List<requisitantes> lista = new List<requisitantes>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                requisitantes novo = new requisitantes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cc = (string)tabela.Rows[a]["cc"]; Occ = (string)tabela.Rows[a]["cc"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from requisitantes").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from requisitantes where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from requisitantes ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from requisitantes where " + where + "");
}


# endregion
    }
}
