using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class relatorios
    {
        List<dynamic> _valoresrelatorios = new List<dynamic>();
        List<string> _colunarelatorios = new List<string>();
        List<dynamic> _condicoesrelatorios = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunarelatorios.Count; a++)
         {
             if (col == _colunarelatorios[a])
                  {
                       return;
                  }
     }
_colunarelatorios.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesrelatorios.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string descricao="descricao";
        public const string osql="osql";
        public const string idusuarios="idusuarios";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresrelatorios.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresrelatorios.Add(value); }
        }

        static string Odescricao;
        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; Add("descricao"); _valoresrelatorios.Add(value); }
        }

        static string Oosql;
        string osql;
        public string Osql
        {
            get { return osql; }
            set { osql = value; Add("osql"); _valoresrelatorios.Add(value); }
        }

        static int Oidusuarios;
        int idusuarios;
        public int Idusuarios
        {
            get { return idusuarios; }
            set { idusuarios = value; Add("idusuarios"); _valoresrelatorios.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("relatorios", TipoDeOperacao.Tipo.InsertMultiplo, _colunarelatorios,_valoresrelatorios, _condicoesrelatorios);   
        }
        public int Alterar()
        {
if (_condicoesrelatorios.Count > 0)
{
return ExecuteNonSql.Executar("relatorios", TipoDeOperacao.Tipo.Update, _colunarelatorios,_valoresrelatorios, _condicoesrelatorios);
}
else
{
List<string> Nomerelatorios = new List<string>();
List<dynamic> Valorrelatorios = new List<dynamic>();
_valoresrelatorios.Clear();
if(Id!=null){ Nomerelatorios.Add("id");
 Valorrelatorios.Add(Oid);
 _valoresrelatorios.Add(Id);
}if(Nome!=null){ Nomerelatorios.Add("nome");
 Valorrelatorios.Add(Onome);
 _valoresrelatorios.Add(Nome);
}if(Descricao!=null){ Nomerelatorios.Add("descricao");
 Valorrelatorios.Add(Odescricao);
 _valoresrelatorios.Add(Descricao);
}if(Osql!=null){ Nomerelatorios.Add("osql");
 Valorrelatorios.Add(Oosql);
 _valoresrelatorios.Add(Osql);
}if(Idusuarios!=null){ Nomerelatorios.Add("idusuarios");
 Valorrelatorios.Add(Oidusuarios);
 _valoresrelatorios.Add(Idusuarios);
}List<dynamic> Condicaorelatorios = new List<dynamic>();
Condicaorelatorios.Add(Nomerelatorios);
Condicaorelatorios.Add(Valorrelatorios);
return ExecuteNonSql.Executar("relatorios", TipoDeOperacao.Tipo.UpdateCondicional, _colunarelatorios, _valoresrelatorios, Condicaorelatorios);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("relatorios", TipoDeOperacao.Tipo.Delete, _colunarelatorios,_valoresrelatorios, _condicoesrelatorios);
        }
        static public List<relatorios> Obter()
        {
            List<relatorios> lista = new List<relatorios>();
            DataTable tabela = Select.SelectSQL("select * from relatorios");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                relatorios novo = new relatorios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Osql = (string)tabela.Rows[a]["osql"]; Oosql = (string)tabela.Rows[a]["osql"]; } catch { }
            try {   novo.Idusuarios = (int)tabela.Rows[a]["idusuarios"]; Oidusuarios = (int)tabela.Rows[a]["idusuarios"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<relatorios> Obter(string where)
        {
            List<relatorios> lista = new List<relatorios>();
            DataTable tabela = Select.SelectSQL("select * from relatorios where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                relatorios novo = new relatorios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Osql = (string)tabela.Rows[a]["osql"]; Oosql = (string)tabela.Rows[a]["osql"]; } catch { }
            try {   novo.Idusuarios = (int)tabela.Rows[a]["idusuarios"]; Oidusuarios = (int)tabela.Rows[a]["idusuarios"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<relatorios> ObterComFiltroAvancado(string sql)
        {
            List<relatorios> lista = new List<relatorios>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                relatorios novo = new relatorios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Osql = (string)tabela.Rows[a]["osql"]; Oosql = (string)tabela.Rows[a]["osql"]; } catch { }
            try {   novo.Idusuarios = (int)tabela.Rows[a]["idusuarios"]; Oidusuarios = (int)tabela.Rows[a]["idusuarios"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from relatorios").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from relatorios where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from relatorios ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from relatorios where " + where + "");
}


# endregion
    }
}
