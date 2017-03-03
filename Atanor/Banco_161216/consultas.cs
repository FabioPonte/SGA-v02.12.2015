using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class consultas
    {
        List<dynamic> _valoresconsultas = new List<dynamic>();
        List<string> _colunaconsultas = new List<string>();
        List<dynamic> _condicoesconsultas = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaconsultas.Count; a++)
         {
             if (col == _colunaconsultas[a])
                  {
                       return;
                  }
     }
_colunaconsultas.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesconsultas.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string consulta="consulta";
        public const string nome="nome";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresconsultas.Add(value); }
        }

        static string Oconsulta;
        string consulta;
        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; Add("consulta"); _valoresconsultas.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresconsultas.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresconsultas.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("consultas", TipoDeOperacao.Tipo.InsertMultiplo, _colunaconsultas,_valoresconsultas, _condicoesconsultas);   
        }
        public int Alterar()
        {
if (_condicoesconsultas.Count > 0)
{
return ExecuteNonSql.Executar("consultas", TipoDeOperacao.Tipo.Update, _colunaconsultas,_valoresconsultas, _condicoesconsultas);
}
else
{
List<string> Nomeconsultas = new List<string>();
List<dynamic> Valorconsultas = new List<dynamic>();
_valoresconsultas.Clear();
if(Id!=null){ Nomeconsultas.Add("id");
 Valorconsultas.Add(Oid);
 _valoresconsultas.Add(Id);
}if(Consulta!=null){ Nomeconsultas.Add("consulta");
 Valorconsultas.Add(Oconsulta);
 _valoresconsultas.Add(Consulta);
}if(Nome!=null){ Nomeconsultas.Add("nome");
 Valorconsultas.Add(Onome);
 _valoresconsultas.Add(Nome);
}if(Obs!=null){ Nomeconsultas.Add("obs");
 Valorconsultas.Add(Oobs);
 _valoresconsultas.Add(Obs);
}List<dynamic> Condicaoconsultas = new List<dynamic>();
Condicaoconsultas.Add(Nomeconsultas);
Condicaoconsultas.Add(Valorconsultas);
return ExecuteNonSql.Executar("consultas", TipoDeOperacao.Tipo.UpdateCondicional, _colunaconsultas, _valoresconsultas, Condicaoconsultas);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("consultas", TipoDeOperacao.Tipo.Delete, _colunaconsultas,_valoresconsultas, _condicoesconsultas);
        }
        static public List<consultas> Obter()
        {
            List<consultas> lista = new List<consultas>();
            DataTable tabela = Select.SelectSQL("select * from consultas");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                consultas novo = new consultas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Consulta = (string)tabela.Rows[a]["consulta"]; Oconsulta = (string)tabela.Rows[a]["consulta"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<consultas> Obter(string where)
        {
            List<consultas> lista = new List<consultas>();
            DataTable tabela = Select.SelectSQL("select * from consultas where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                consultas novo = new consultas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Consulta = (string)tabela.Rows[a]["consulta"]; Oconsulta = (string)tabela.Rows[a]["consulta"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<consultas> ObterComFiltroAvancado(string sql)
        {
            List<consultas> lista = new List<consultas>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                consultas novo = new consultas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Consulta = (string)tabela.Rows[a]["consulta"]; Oconsulta = (string)tabela.Rows[a]["consulta"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from consultas").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from consultas where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from consultas ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from consultas where " + where + "");
}


# endregion
    }
}
