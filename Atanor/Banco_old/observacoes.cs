using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class observacoes
    {
        List<dynamic> _valoresobservacoes = new List<dynamic>();
        List<string> _colunaobservacoes = new List<string>();
        List<dynamic> _condicoesobservacoes = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaobservacoes.Count; a++)
         {
             if (col == _colunaobservacoes[a])
                  {
                       return;
                  }
     }
_colunaobservacoes.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesobservacoes.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string obs="obs";
        public const string idchamado="idchamado";
        public const string data_acao="data_acao";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresobservacoes.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresobservacoes.Add(value); }
        }

        static int Oidchamado;
        int idchamado;
        public int Idchamado
        {
            get { return idchamado; }
            set { idchamado = value; Add("idchamado"); _valoresobservacoes.Add(value); }
        }

        static DateTime Odata_acao;
        DateTime data_acao;
        public DateTime Data_acao
        {
            get { return data_acao; }
            set { data_acao = value; Add("data_acao"); _valoresobservacoes.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("observacoes", TipoDeOperacao.Tipo.InsertMultiplo, _colunaobservacoes,_valoresobservacoes, _condicoesobservacoes);   
        }
        public int Alterar()
        {
if (_condicoesobservacoes.Count > 0)
{
return ExecuteNonSql.Executar("observacoes", TipoDeOperacao.Tipo.Update, _colunaobservacoes,_valoresobservacoes, _condicoesobservacoes);
}
else
{
List<string> Nomeobservacoes = new List<string>();
List<dynamic> Valorobservacoes = new List<dynamic>();
_valoresobservacoes.Clear();
if(Id!=null){ Nomeobservacoes.Add("id");
 Valorobservacoes.Add(Oid);
 _valoresobservacoes.Add(Id);
}if(Obs!=null){ Nomeobservacoes.Add("obs");
 Valorobservacoes.Add(Oobs);
 _valoresobservacoes.Add(Obs);
}if(Idchamado!=null){ Nomeobservacoes.Add("idchamado");
 Valorobservacoes.Add(Oidchamado);
 _valoresobservacoes.Add(Idchamado);
}if(Data_acao!=null){ Nomeobservacoes.Add("data_acao");
 Valorobservacoes.Add(Odata_acao);
 _valoresobservacoes.Add(Data_acao);
}List<dynamic> Condicaoobservacoes = new List<dynamic>();
Condicaoobservacoes.Add(Nomeobservacoes);
Condicaoobservacoes.Add(Valorobservacoes);
return ExecuteNonSql.Executar("observacoes", TipoDeOperacao.Tipo.UpdateCondicional, _colunaobservacoes, _valoresobservacoes, Condicaoobservacoes);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("observacoes", TipoDeOperacao.Tipo.Delete, _colunaobservacoes,_valoresobservacoes, _condicoesobservacoes);
        }
        static public List<observacoes> Obter()
        {
            List<observacoes> lista = new List<observacoes>();
            DataTable tabela = Select.SelectSQL("select * from observacoes");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                observacoes novo = new observacoes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Idchamado = (int)tabela.Rows[a]["idchamado"]; Oidchamado = (int)tabela.Rows[a]["idchamado"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<observacoes> Obter(string where)
        {
            List<observacoes> lista = new List<observacoes>();
            DataTable tabela = Select.SelectSQL("select * from observacoes where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                observacoes novo = new observacoes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Idchamado = (int)tabela.Rows[a]["idchamado"]; Oidchamado = (int)tabela.Rows[a]["idchamado"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<observacoes> ObterComFiltroAvancado(string sql)
        {
            List<observacoes> lista = new List<observacoes>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                observacoes novo = new observacoes();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Idchamado = (int)tabela.Rows[a]["idchamado"]; Oidchamado = (int)tabela.Rows[a]["idchamado"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from observacoes").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from observacoes where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from observacoes ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from observacoes where " + where + "");
}


# endregion
    }
}
