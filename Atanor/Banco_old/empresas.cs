using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class empresas
    {
        List<dynamic> _valoresempresas = new List<dynamic>();
        List<string> _colunaempresas = new List<string>();
        List<dynamic> _condicoesempresas = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaempresas.Count; a++)
         {
             if (col == _colunaempresas[a])
                  {
                       return;
                  }
     }
_colunaempresas.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesempresas.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string cnpj="cnpj";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresempresas.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresempresas.Add(value); }
        }

        static string Ocnpj;
        string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; Add("cnpj"); _valoresempresas.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.InsertMultiplo, _colunaempresas,_valoresempresas, _condicoesempresas);   
        }
        public int Alterar()
        {
if (_condicoesempresas.Count > 0)
{
return ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.Update, _colunaempresas,_valoresempresas, _condicoesempresas);
}
else
{
List<string> Nomeempresas = new List<string>();
List<dynamic> Valorempresas = new List<dynamic>();
_valoresempresas.Clear();
if(Id!=null){ Nomeempresas.Add("id");
 Valorempresas.Add(Oid);
 _valoresempresas.Add(Id);
}if(Nome!=null){ Nomeempresas.Add("nome");
 Valorempresas.Add(Onome);
 _valoresempresas.Add(Nome);
}if(Cnpj!=null){ Nomeempresas.Add("cnpj");
 Valorempresas.Add(Ocnpj);
 _valoresempresas.Add(Cnpj);
}List<dynamic> Condicaoempresas = new List<dynamic>();
Condicaoempresas.Add(Nomeempresas);
Condicaoempresas.Add(Valorempresas);
return ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.UpdateCondicional, _colunaempresas, _valoresempresas, Condicaoempresas);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("empresas", TipoDeOperacao.Tipo.Delete, _colunaempresas,_valoresempresas, _condicoesempresas);
        }
        static public List<empresas> Obter()
        {
            List<empresas> lista = new List<empresas>();
            DataTable tabela = Select.SelectSQL("select * from empresas");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                empresas novo = new empresas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<empresas> Obter(string where)
        {
            List<empresas> lista = new List<empresas>();
            DataTable tabela = Select.SelectSQL("select * from empresas where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                empresas novo = new empresas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<empresas> ObterComFiltroAvancado(string sql)
        {
            List<empresas> lista = new List<empresas>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                empresas novo = new empresas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from empresas").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from empresas where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from empresas ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from empresas where " + where + "");
}


# endregion
    }
}
