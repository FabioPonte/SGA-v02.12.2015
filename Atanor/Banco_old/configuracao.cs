using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class configuracao
    {
        List<dynamic> _valoresconfiguracao = new List<dynamic>();
        List<string> _colunaconfiguracao = new List<string>();
        List<dynamic> _condicoesconfiguracao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaconfiguracao.Count; a++)
         {
             if (col == _colunaconfiguracao[a])
                  {
                       return;
                  }
     }
_colunaconfiguracao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesconfiguracao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string tempo_atualizacao_numero_chamado="tempo_atualizacao_numero_chamado";
        public const string caminho_pasta_anexos="caminho_pasta_anexos";
        public const string emailsgasuporte="emailsgasuporte";
        public const string senhaemailsgasuporte="senhaemailsgasuporte";
        public const string servidorsmtp="servidorsmtp";
        public const string portasmtp="portasmtp";
        public const string servidorpop3="servidorpop3";
        public const string portapop3="portapop3";
        public const string sslpop3="sslpop3";
        public const string sslsmtp="sslsmtp";
        public const string idmail="idmail";
        public const string reload="reload";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresconfiguracao.Add(value); }
        }

        static int Otempo_atualizacao_numero_chamado;
        int tempo_atualizacao_numero_chamado;
        public int Tempo_atualizacao_numero_chamado
        {
            get { return tempo_atualizacao_numero_chamado; }
            set { tempo_atualizacao_numero_chamado = value; Add("tempo_atualizacao_numero_chamado"); _valoresconfiguracao.Add(value); }
        }

        static string Ocaminho_pasta_anexos;
        string caminho_pasta_anexos;
        public string Caminho_pasta_anexos
        {
            get { return caminho_pasta_anexos; }
            set { caminho_pasta_anexos = value; Add("caminho_pasta_anexos"); _valoresconfiguracao.Add(value); }
        }

        static string Oemailsgasuporte;
        string emailsgasuporte;
        public string Emailsgasuporte
        {
            get { return emailsgasuporte; }
            set { emailsgasuporte = value; Add("emailsgasuporte"); _valoresconfiguracao.Add(value); }
        }

        static string Osenhaemailsgasuporte;
        string senhaemailsgasuporte;
        public string Senhaemailsgasuporte
        {
            get { return senhaemailsgasuporte; }
            set { senhaemailsgasuporte = value; Add("senhaemailsgasuporte"); _valoresconfiguracao.Add(value); }
        }

        static string Oservidorsmtp;
        string servidorsmtp;
        public string Servidorsmtp
        {
            get { return servidorsmtp; }
            set { servidorsmtp = value; Add("servidorsmtp"); _valoresconfiguracao.Add(value); }
        }

        static string Oportasmtp;
        string portasmtp;
        public string Portasmtp
        {
            get { return portasmtp; }
            set { portasmtp = value; Add("portasmtp"); _valoresconfiguracao.Add(value); }
        }

        static string Oservidorpop3;
        string servidorpop3;
        public string Servidorpop3
        {
            get { return servidorpop3; }
            set { servidorpop3 = value; Add("servidorpop3"); _valoresconfiguracao.Add(value); }
        }

        static string Oportapop3;
        string portapop3;
        public string Portapop3
        {
            get { return portapop3; }
            set { portapop3 = value; Add("portapop3"); _valoresconfiguracao.Add(value); }
        }

        static Boolean Osslpop3;
        Boolean sslpop3;
        public Boolean Sslpop3
        {
            get { return sslpop3; }
            set { sslpop3 = value; Add("sslpop3"); _valoresconfiguracao.Add(value); }
        }

        static Boolean Osslsmtp;
        Boolean sslsmtp;
        public Boolean Sslsmtp
        {
            get { return sslsmtp; }
            set { sslsmtp = value; Add("sslsmtp"); _valoresconfiguracao.Add(value); }
        }

        static int Oidmail;
        int idmail;
        public int Idmail
        {
            get { return idmail; }
            set { idmail = value; Add("idmail"); _valoresconfiguracao.Add(value); }
        }

        static int Oreload;
        int reload;
        public int Reload
        {
            get { return reload; }
            set { reload = value; Add("reload"); _valoresconfiguracao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("configuracao", TipoDeOperacao.Tipo.InsertMultiplo, _colunaconfiguracao,_valoresconfiguracao, _condicoesconfiguracao);   
        }
        public int Alterar()
        {
if (_condicoesconfiguracao.Count > 0)
{
return ExecuteNonSql.Executar("configuracao", TipoDeOperacao.Tipo.Update, _colunaconfiguracao,_valoresconfiguracao, _condicoesconfiguracao);
}
else
{
List<string> Nomeconfiguracao = new List<string>();
List<dynamic> Valorconfiguracao = new List<dynamic>();
_valoresconfiguracao.Clear();
if(Id!=null){ Nomeconfiguracao.Add("id");
 Valorconfiguracao.Add(Oid);
 _valoresconfiguracao.Add(Id);
}if(Tempo_atualizacao_numero_chamado!=null){ Nomeconfiguracao.Add("tempo_atualizacao_numero_chamado");
 Valorconfiguracao.Add(Otempo_atualizacao_numero_chamado);
 _valoresconfiguracao.Add(Tempo_atualizacao_numero_chamado);
}if(Caminho_pasta_anexos!=null){ Nomeconfiguracao.Add("caminho_pasta_anexos");
 Valorconfiguracao.Add(Ocaminho_pasta_anexos);
 _valoresconfiguracao.Add(Caminho_pasta_anexos);
}if(Emailsgasuporte!=null){ Nomeconfiguracao.Add("emailsgasuporte");
 Valorconfiguracao.Add(Oemailsgasuporte);
 _valoresconfiguracao.Add(Emailsgasuporte);
}if(Senhaemailsgasuporte!=null){ Nomeconfiguracao.Add("senhaemailsgasuporte");
 Valorconfiguracao.Add(Osenhaemailsgasuporte);
 _valoresconfiguracao.Add(Senhaemailsgasuporte);
}if(Servidorsmtp!=null){ Nomeconfiguracao.Add("servidorsmtp");
 Valorconfiguracao.Add(Oservidorsmtp);
 _valoresconfiguracao.Add(Servidorsmtp);
}if(Portasmtp!=null){ Nomeconfiguracao.Add("portasmtp");
 Valorconfiguracao.Add(Oportasmtp);
 _valoresconfiguracao.Add(Portasmtp);
}if(Servidorpop3!=null){ Nomeconfiguracao.Add("servidorpop3");
 Valorconfiguracao.Add(Oservidorpop3);
 _valoresconfiguracao.Add(Servidorpop3);
}if(Portapop3!=null){ Nomeconfiguracao.Add("portapop3");
 Valorconfiguracao.Add(Oportapop3);
 _valoresconfiguracao.Add(Portapop3);
}if(Sslpop3!=null){ Nomeconfiguracao.Add("sslpop3");
 Valorconfiguracao.Add(Osslpop3);
 _valoresconfiguracao.Add(Sslpop3);
}if(Sslsmtp!=null){ Nomeconfiguracao.Add("sslsmtp");
 Valorconfiguracao.Add(Osslsmtp);
 _valoresconfiguracao.Add(Sslsmtp);
}if(Idmail!=null){ Nomeconfiguracao.Add("idmail");
 Valorconfiguracao.Add(Oidmail);
 _valoresconfiguracao.Add(Idmail);
}if(Reload!=null){ Nomeconfiguracao.Add("reload");
 Valorconfiguracao.Add(Oreload);
 _valoresconfiguracao.Add(Reload);
}List<dynamic> Condicaoconfiguracao = new List<dynamic>();
Condicaoconfiguracao.Add(Nomeconfiguracao);
Condicaoconfiguracao.Add(Valorconfiguracao);
return ExecuteNonSql.Executar("configuracao", TipoDeOperacao.Tipo.UpdateCondicional, _colunaconfiguracao, _valoresconfiguracao, Condicaoconfiguracao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("configuracao", TipoDeOperacao.Tipo.Delete, _colunaconfiguracao,_valoresconfiguracao, _condicoesconfiguracao);
        }
        static public List<configuracao> Obter()
        {
            List<configuracao> lista = new List<configuracao>();
            DataTable tabela = Select.SelectSQL("select * from configuracao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                configuracao novo = new configuracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; Otempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; } catch { }
            try {   novo.Caminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; Ocaminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; } catch { }
            try {   novo.Emailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; Oemailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; } catch { }
            try {   novo.Senhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; Osenhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; } catch { }
            try {   novo.Servidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; Oservidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; } catch { }
            try {   novo.Portasmtp = (string)tabela.Rows[a]["portasmtp"]; Oportasmtp = (string)tabela.Rows[a]["portasmtp"]; } catch { }
            try {   novo.Servidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; Oservidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; } catch { }
            try {   novo.Portapop3 = (string)tabela.Rows[a]["portapop3"]; Oportapop3 = (string)tabela.Rows[a]["portapop3"]; } catch { }
            try {   novo.Sslpop3 = Convert.ToBoolean(tabela.Rows[a]["sslpop3"]);  Osslpop3= Convert.ToBoolean(tabela.Rows[a]["sslpop3"]); } catch { }
            try {   novo.Sslsmtp = Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]);  Osslsmtp= Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]); } catch { }
            try {   novo.Idmail = (int)tabela.Rows[a]["idmail"]; Oidmail = (int)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Reload = (int)tabela.Rows[a]["reload"]; Oreload = (int)tabela.Rows[a]["reload"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<configuracao> Obter(string where)
        {
            List<configuracao> lista = new List<configuracao>();
            DataTable tabela = Select.SelectSQL("select * from configuracao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                configuracao novo = new configuracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; Otempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; } catch { }
            try {   novo.Caminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; Ocaminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; } catch { }
            try {   novo.Emailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; Oemailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; } catch { }
            try {   novo.Senhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; Osenhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; } catch { }
            try {   novo.Servidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; Oservidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; } catch { }
            try {   novo.Portasmtp = (string)tabela.Rows[a]["portasmtp"]; Oportasmtp = (string)tabela.Rows[a]["portasmtp"]; } catch { }
            try {   novo.Servidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; Oservidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; } catch { }
            try {   novo.Portapop3 = (string)tabela.Rows[a]["portapop3"]; Oportapop3 = (string)tabela.Rows[a]["portapop3"]; } catch { }
            try {   novo.Sslpop3 = Convert.ToBoolean(tabela.Rows[a]["sslpop3"]);  Osslpop3= Convert.ToBoolean(tabela.Rows[a]["sslpop3"]); } catch { }
            try {   novo.Sslsmtp = Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]);  Osslsmtp= Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]); } catch { }
            try {   novo.Idmail = (int)tabela.Rows[a]["idmail"]; Oidmail = (int)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Reload = (int)tabela.Rows[a]["reload"]; Oreload = (int)tabela.Rows[a]["reload"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<configuracao> ObterComFiltroAvancado(string sql)
        {
            List<configuracao> lista = new List<configuracao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                configuracao novo = new configuracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; Otempo_atualizacao_numero_chamado = (int)tabela.Rows[a]["tempo_atualizacao_numero_chamado"]; } catch { }
            try {   novo.Caminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; Ocaminho_pasta_anexos = (string)tabela.Rows[a]["caminho_pasta_anexos"]; } catch { }
            try {   novo.Emailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; Oemailsgasuporte = (string)tabela.Rows[a]["emailsgasuporte"]; } catch { }
            try {   novo.Senhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; Osenhaemailsgasuporte = (string)tabela.Rows[a]["senhaemailsgasuporte"]; } catch { }
            try {   novo.Servidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; Oservidorsmtp = (string)tabela.Rows[a]["servidorsmtp"]; } catch { }
            try {   novo.Portasmtp = (string)tabela.Rows[a]["portasmtp"]; Oportasmtp = (string)tabela.Rows[a]["portasmtp"]; } catch { }
            try {   novo.Servidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; Oservidorpop3 = (string)tabela.Rows[a]["servidorpop3"]; } catch { }
            try {   novo.Portapop3 = (string)tabela.Rows[a]["portapop3"]; Oportapop3 = (string)tabela.Rows[a]["portapop3"]; } catch { }
            try {   novo.Sslpop3 = Convert.ToBoolean(tabela.Rows[a]["sslpop3"]);  Osslpop3= Convert.ToBoolean(tabela.Rows[a]["sslpop3"]); } catch { }
            try {   novo.Sslsmtp = Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]);  Osslsmtp= Convert.ToBoolean(tabela.Rows[a]["sslsmtp"]); } catch { }
            try {   novo.Idmail = (int)tabela.Rows[a]["idmail"]; Oidmail = (int)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Reload = (int)tabela.Rows[a]["reload"]; Oreload = (int)tabela.Rows[a]["reload"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from configuracao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from configuracao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from configuracao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from configuracao where " + where + "");
}


# endregion
    }
}
