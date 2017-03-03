using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class nomeclassificador
    {
        List<dynamic> _valoresnomeclassificador = new List<dynamic>();
        List<string> _colunanomeclassificador = new List<string>();
        List<dynamic> _condicoesnomeclassificador = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunanomeclassificador.Count; a++)
         {
             if (col == _colunanomeclassificador[a])
                  {
                       return;
                  }
     }
_colunanomeclassificador.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesnomeclassificador.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idclassificadores="idclassificadores";
        public const string nome="nome";
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
            set { id = value; Add("id"); _valoresnomeclassificador.Add(value); }
        }

        static int Oidclassificadores;
        int idclassificadores;
        public int Idclassificadores
        {
            get { return idclassificadores; }
            set { idclassificadores = value; Add("idclassificadores"); _valoresnomeclassificador.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresnomeclassificador.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresnomeclassificador.Add(value); }
        }

        static string Ocor;
        string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; Add("cor"); _valoresnomeclassificador.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("nomeclassificador", TipoDeOperacao.Tipo.InsertMultiplo, _colunanomeclassificador,_valoresnomeclassificador, _condicoesnomeclassificador);   
        }
        public int Alterar()
        {
if (_condicoesnomeclassificador.Count > 0)
{
return ExecuteNonSql.Executar("nomeclassificador", TipoDeOperacao.Tipo.Update, _colunanomeclassificador,_valoresnomeclassificador, _condicoesnomeclassificador);
}
else
{
List<string> Nomenomeclassificador = new List<string>();
List<dynamic> Valornomeclassificador = new List<dynamic>();
_valoresnomeclassificador.Clear();
if(Id!=null){ Nomenomeclassificador.Add("id");
 Valornomeclassificador.Add(Oid);
 _valoresnomeclassificador.Add(Id);
}if(Idclassificadores!=null){ Nomenomeclassificador.Add("idclassificadores");
 Valornomeclassificador.Add(Oidclassificadores);
 _valoresnomeclassificador.Add(Idclassificadores);
}if(Nome!=null){ Nomenomeclassificador.Add("nome");
 Valornomeclassificador.Add(Onome);
 _valoresnomeclassificador.Add(Nome);
}if(Obs!=null){ Nomenomeclassificador.Add("obs");
 Valornomeclassificador.Add(Oobs);
 _valoresnomeclassificador.Add(Obs);
}if(Cor!=null){ Nomenomeclassificador.Add("cor");
 Valornomeclassificador.Add(Ocor);
 _valoresnomeclassificador.Add(Cor);
}List<dynamic> Condicaonomeclassificador = new List<dynamic>();
Condicaonomeclassificador.Add(Nomenomeclassificador);
Condicaonomeclassificador.Add(Valornomeclassificador);
return ExecuteNonSql.Executar("nomeclassificador", TipoDeOperacao.Tipo.UpdateCondicional, _colunanomeclassificador, _valoresnomeclassificador, Condicaonomeclassificador);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("nomeclassificador", TipoDeOperacao.Tipo.Delete, _colunanomeclassificador,_valoresnomeclassificador, _condicoesnomeclassificador);
        }
        static public List<nomeclassificador> Obter()
        {
            List<nomeclassificador> lista = new List<nomeclassificador>();
            DataTable tabela = Select.SelectSQL("select * from nomeclassificador");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nomeclassificador novo = new nomeclassificador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idclassificadores = (int)tabela.Rows[a]["idclassificadores"]; Oidclassificadores = (int)tabela.Rows[a]["idclassificadores"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nomeclassificador> Obter(string where)
        {
            List<nomeclassificador> lista = new List<nomeclassificador>();
            DataTable tabela = Select.SelectSQL("select * from nomeclassificador where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nomeclassificador novo = new nomeclassificador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idclassificadores = (int)tabela.Rows[a]["idclassificadores"]; Oidclassificadores = (int)tabela.Rows[a]["idclassificadores"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nomeclassificador> ObterComFiltroAvancado(string sql)
        {
            List<nomeclassificador> lista = new List<nomeclassificador>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nomeclassificador novo = new nomeclassificador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idclassificadores = (int)tabela.Rows[a]["idclassificadores"]; Oidclassificadores = (int)tabela.Rows[a]["idclassificadores"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from nomeclassificador").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from nomeclassificador where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from nomeclassificador ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from nomeclassificador where " + where + "");
}


# endregion
    }
}
