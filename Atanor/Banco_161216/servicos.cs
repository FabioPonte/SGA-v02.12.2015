using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class servicos
    {
        List<dynamic> _valoresservicos = new List<dynamic>();
        List<string> _colunaservicos = new List<string>();
        List<dynamic> _condicoesservicos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaservicos.Count; a++)
         {
             if (col == _colunaservicos[a])
                  {
                       return;
                  }
     }
_colunaservicos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesservicos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string nome="nome";

         }
# endregion
#region Colunas


        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresservicos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("servicos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaservicos,_valoresservicos, _condicoesservicos);   
        }
        public int Alterar()
        {
if (_condicoesservicos.Count > 0)
{
return ExecuteNonSql.Executar("servicos", TipoDeOperacao.Tipo.Update, _colunaservicos,_valoresservicos, _condicoesservicos);
}
else
{
List<string> Nomeservicos = new List<string>();
List<dynamic> Valorservicos = new List<dynamic>();
_valoresservicos.Clear();
if(Nome!=null){ Nomeservicos.Add("nome");
 Valorservicos.Add(Onome);
 _valoresservicos.Add(Nome);
}List<dynamic> Condicaoservicos = new List<dynamic>();
Condicaoservicos.Add(Nomeservicos);
Condicaoservicos.Add(Valorservicos);
return ExecuteNonSql.Executar("servicos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaservicos, _valoresservicos, Condicaoservicos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("servicos", TipoDeOperacao.Tipo.Delete, _colunaservicos,_valoresservicos, _condicoesservicos);
        }
        static public List<servicos> Obter()
        {
            List<servicos> lista = new List<servicos>();
            DataTable tabela = Select.SelectSQL("select * from servicos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                servicos novo = new servicos();
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<servicos> Obter(string where)
        {
            List<servicos> lista = new List<servicos>();
            DataTable tabela = Select.SelectSQL("select * from servicos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                servicos novo = new servicos();
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<servicos> ObterComFiltroAvancado(string sql)
        {
            List<servicos> lista = new List<servicos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                servicos novo = new servicos();
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from servicos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from servicos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from servicos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from servicos where " + where + "");
}


# endregion
    }
}
