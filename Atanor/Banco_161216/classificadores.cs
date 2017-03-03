using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class classificadores
    {
        List<dynamic> _valoresclassificadores = new List<dynamic>();
        List<string> _colunaclassificadores = new List<string>();
        List<dynamic> _condicoesclassificadores = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaclassificadores.Count; a++)
         {
             if (col == _colunaclassificadores[a])
                  {
                       return;
                  }
     }
_colunaclassificadores.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesclassificadores.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string obs="obs";
        public const string obrigatorio="obrigatorio";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresclassificadores.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresclassificadores.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresclassificadores.Add(value); }
        }

        static Boolean Oobrigatorio;
        Boolean obrigatorio;
        public Boolean Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; Add("obrigatorio"); _valoresclassificadores.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("classificadores", TipoDeOperacao.Tipo.InsertMultiplo, _colunaclassificadores,_valoresclassificadores, _condicoesclassificadores);   
        }
        public int Alterar()
        {
if (_condicoesclassificadores.Count > 0)
{
return ExecuteNonSql.Executar("classificadores", TipoDeOperacao.Tipo.Update, _colunaclassificadores,_valoresclassificadores, _condicoesclassificadores);
}
else
{
List<string> Nomeclassificadores = new List<string>();
List<dynamic> Valorclassificadores = new List<dynamic>();
_valoresclassificadores.Clear();
if(Id!=null){ Nomeclassificadores.Add("id");
 Valorclassificadores.Add(Oid);
 _valoresclassificadores.Add(Id);
}if(Nome!=null){ Nomeclassificadores.Add("nome");
 Valorclassificadores.Add(Onome);
 _valoresclassificadores.Add(Nome);
}if(Obs!=null){ Nomeclassificadores.Add("obs");
 Valorclassificadores.Add(Oobs);
 _valoresclassificadores.Add(Obs);
}if(Obrigatorio!=null){ Nomeclassificadores.Add("obrigatorio");
 Valorclassificadores.Add(Oobrigatorio);
 _valoresclassificadores.Add(Obrigatorio);
}List<dynamic> Condicaoclassificadores = new List<dynamic>();
Condicaoclassificadores.Add(Nomeclassificadores);
Condicaoclassificadores.Add(Valorclassificadores);
return ExecuteNonSql.Executar("classificadores", TipoDeOperacao.Tipo.UpdateCondicional, _colunaclassificadores, _valoresclassificadores, Condicaoclassificadores);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("classificadores", TipoDeOperacao.Tipo.Delete, _colunaclassificadores,_valoresclassificadores, _condicoesclassificadores);
        }
        static public List<classificadores> Obter()
        {
            List<classificadores> lista = new List<classificadores>();
            DataTable tabela = Select.SelectSQL("select * from classificadores");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                classificadores novo = new classificadores();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Obrigatorio = Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]);  Oobrigatorio= Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<classificadores> Obter(string where)
        {
            List<classificadores> lista = new List<classificadores>();
            DataTable tabela = Select.SelectSQL("select * from classificadores where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                classificadores novo = new classificadores();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Obrigatorio = Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]);  Oobrigatorio= Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<classificadores> ObterComFiltroAvancado(string sql)
        {
            List<classificadores> lista = new List<classificadores>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                classificadores novo = new classificadores();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Obrigatorio = Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]);  Oobrigatorio= Convert.ToBoolean(tabela.Rows[a]["obrigatorio"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from classificadores").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from classificadores where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from classificadores ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from classificadores where " + where + "");
}


# endregion
    }
}
