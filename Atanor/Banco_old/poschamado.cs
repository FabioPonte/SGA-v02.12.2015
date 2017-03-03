using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class poschamado
    {
        List<dynamic> _valoresposchamado = new List<dynamic>();
        List<string> _colunaposchamado = new List<string>();
        List<dynamic> _condicoesposchamado = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaposchamado.Count; a++)
         {
             if (col == _colunaposchamado[a])
                  {
                       return;
                  }
     }
_colunaposchamado.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesposchamado.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string titulo="titulo";
        public const string data_recebimento="data_recebimento";
        public const string emitente="emitente";
        public const string ativo="ativo";
        public const string obs="obs";
        public const string status_id="status_id";
        public const string conclusao_id="conclusao_id";
        public const string idposchamadopai="idposchamadopai";
        public const string codigo="codigo";
        public const string data_acao="data_acao";
        public const string modificadoem="modificadoem";
        public const string nome_emitente="nome_emitente";
        public const string idmail="idmail";
        public const string nome_emitente_original="nome_emitente_original";
        public const string emitente_original="emitente_original";
        public const string aviso_recebimento="aviso_recebimento";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresposchamado.Add(value); }
        }

        static string Otitulo;
        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; Add("titulo"); _valoresposchamado.Add(value); }
        }

        static DateTime Odata_recebimento;
        DateTime data_recebimento;
        public DateTime Data_recebimento
        {
            get { return data_recebimento; }
            set { data_recebimento = value; Add("data_recebimento"); _valoresposchamado.Add(value); }
        }

        static string Oemitente;
        string emitente;
        public string Emitente
        {
            get { return emitente; }
            set { emitente = value; Add("emitente"); _valoresposchamado.Add(value); }
        }

        static Boolean Oativo;
        Boolean ativo;
        public Boolean Ativo
        {
            get { return ativo; }
            set { ativo = value; Add("ativo"); _valoresposchamado.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresposchamado.Add(value); }
        }

        static int Ostatus_id;
        int status_id;
        public int Status_id
        {
            get { return status_id; }
            set { status_id = value; Add("status_id"); _valoresposchamado.Add(value); }
        }

        static int Oconclusao_id;
        int conclusao_id;
        public int Conclusao_id
        {
            get { return conclusao_id; }
            set { conclusao_id = value; Add("conclusao_id"); _valoresposchamado.Add(value); }
        }

        static int Oidposchamadopai;
        int idposchamadopai;
        public int Idposchamadopai
        {
            get { return idposchamadopai; }
            set { idposchamadopai = value; Add("idposchamadopai"); _valoresposchamado.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresposchamado.Add(value); }
        }

        static DateTime Odata_acao;
        DateTime data_acao;
        public DateTime Data_acao
        {
            get { return data_acao; }
            set { data_acao = value; Add("data_acao"); _valoresposchamado.Add(value); }
        }

        static DateTime Omodificadoem;
        DateTime modificadoem;
        public DateTime Modificadoem
        {
            get { return modificadoem; }
            set { modificadoem = value; Add("modificadoem"); _valoresposchamado.Add(value); }
        }

        static string Onome_emitente;
        string nome_emitente;
        public string Nome_emitente
        {
            get { return nome_emitente; }
            set { nome_emitente = value; Add("nome_emitente"); _valoresposchamado.Add(value); }
        }

        static string Oidmail;
        string idmail;
        public string Idmail
        {
            get { return idmail; }
            set { idmail = value; Add("idmail"); _valoresposchamado.Add(value); }
        }

        static string Onome_emitente_original;
        string nome_emitente_original;
        public string Nome_emitente_original
        {
            get { return nome_emitente_original; }
            set { nome_emitente_original = value; Add("nome_emitente_original"); _valoresposchamado.Add(value); }
        }

        static string Oemitente_original;
        string emitente_original;
        public string Emitente_original
        {
            get { return emitente_original; }
            set { emitente_original = value; Add("emitente_original"); _valoresposchamado.Add(value); }
        }

        static Boolean Oaviso_recebimento;
        Boolean aviso_recebimento;
        public Boolean Aviso_recebimento
        {
            get { return aviso_recebimento; }
            set { aviso_recebimento = value; Add("aviso_recebimento"); _valoresposchamado.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("poschamado", TipoDeOperacao.Tipo.InsertMultiplo, _colunaposchamado,_valoresposchamado, _condicoesposchamado);   
        }
        public int Alterar()
        {
if (_condicoesposchamado.Count > 0)
{
return ExecuteNonSql.Executar("poschamado", TipoDeOperacao.Tipo.Update, _colunaposchamado,_valoresposchamado, _condicoesposchamado);
}
else
{
List<string> Nomeposchamado = new List<string>();
List<dynamic> Valorposchamado = new List<dynamic>();
_valoresposchamado.Clear();
if(Id!=null){ Nomeposchamado.Add("id");
 Valorposchamado.Add(Oid);
 _valoresposchamado.Add(Id);
}if(Titulo!=null){ Nomeposchamado.Add("titulo");
 Valorposchamado.Add(Otitulo);
 _valoresposchamado.Add(Titulo);
}if(Data_recebimento!=null){ Nomeposchamado.Add("data_recebimento");
 Valorposchamado.Add(Odata_recebimento);
 _valoresposchamado.Add(Data_recebimento);
}if(Emitente!=null){ Nomeposchamado.Add("emitente");
 Valorposchamado.Add(Oemitente);
 _valoresposchamado.Add(Emitente);
}if(Ativo!=null){ Nomeposchamado.Add("ativo");
 Valorposchamado.Add(Oativo);
 _valoresposchamado.Add(Ativo);
}if(Obs!=null){ Nomeposchamado.Add("obs");
 Valorposchamado.Add(Oobs);
 _valoresposchamado.Add(Obs);
}if(Status_id!=null){ Nomeposchamado.Add("status_id");
 Valorposchamado.Add(Ostatus_id);
 _valoresposchamado.Add(Status_id);
}if(Conclusao_id!=null){ Nomeposchamado.Add("conclusao_id");
 Valorposchamado.Add(Oconclusao_id);
 _valoresposchamado.Add(Conclusao_id);
}if(Idposchamadopai!=null){ Nomeposchamado.Add("idposchamadopai");
 Valorposchamado.Add(Oidposchamadopai);
 _valoresposchamado.Add(Idposchamadopai);
}if(Codigo!=null){ Nomeposchamado.Add("codigo");
 Valorposchamado.Add(Ocodigo);
 _valoresposchamado.Add(Codigo);
}if(Data_acao!=null){ Nomeposchamado.Add("data_acao");
 Valorposchamado.Add(Odata_acao);
 _valoresposchamado.Add(Data_acao);
}if(Modificadoem!=null){ Nomeposchamado.Add("modificadoem");
 Valorposchamado.Add(Omodificadoem);
 _valoresposchamado.Add(Modificadoem);
}if(Nome_emitente!=null){ Nomeposchamado.Add("nome_emitente");
 Valorposchamado.Add(Onome_emitente);
 _valoresposchamado.Add(Nome_emitente);
}if(Idmail!=null){ Nomeposchamado.Add("idmail");
 Valorposchamado.Add(Oidmail);
 _valoresposchamado.Add(Idmail);
}if(Nome_emitente_original!=null){ Nomeposchamado.Add("nome_emitente_original");
 Valorposchamado.Add(Onome_emitente_original);
 _valoresposchamado.Add(Nome_emitente_original);
}if(Emitente_original!=null){ Nomeposchamado.Add("emitente_original");
 Valorposchamado.Add(Oemitente_original);
 _valoresposchamado.Add(Emitente_original);
}if(Aviso_recebimento!=null){ Nomeposchamado.Add("aviso_recebimento");
 Valorposchamado.Add(Oaviso_recebimento);
 _valoresposchamado.Add(Aviso_recebimento);
}List<dynamic> Condicaoposchamado = new List<dynamic>();
Condicaoposchamado.Add(Nomeposchamado);
Condicaoposchamado.Add(Valorposchamado);
return ExecuteNonSql.Executar("poschamado", TipoDeOperacao.Tipo.UpdateCondicional, _colunaposchamado, _valoresposchamado, Condicaoposchamado);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("poschamado", TipoDeOperacao.Tipo.Delete, _colunaposchamado,_valoresposchamado, _condicoesposchamado);
        }
        static public List<poschamado> Obter()
        {
            List<poschamado> lista = new List<poschamado>();
            DataTable tabela = Select.SelectSQL("select * from poschamado");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                poschamado novo = new poschamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; Odata_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; } catch { }
            try {   novo.Emitente = (string)tabela.Rows[a]["emitente"]; Oemitente = (string)tabela.Rows[a]["emitente"]; } catch { }
            try {   novo.Ativo = Convert.ToBoolean(tabela.Rows[a]["ativo"]);  Oativo= Convert.ToBoolean(tabela.Rows[a]["ativo"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Status_id = (int)tabela.Rows[a]["status_id"]; Ostatus_id = (int)tabela.Rows[a]["status_id"]; } catch { }
            try {   novo.Conclusao_id = (int)tabela.Rows[a]["conclusao_id"]; Oconclusao_id = (int)tabela.Rows[a]["conclusao_id"]; } catch { }
            try {   novo.Idposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; Oidposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Modificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; Omodificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; } catch { }
            try {   novo.Nome_emitente = (string)tabela.Rows[a]["nome_emitente"]; Onome_emitente = (string)tabela.Rows[a]["nome_emitente"]; } catch { }
            try {   novo.Idmail = (string)tabela.Rows[a]["idmail"]; Oidmail = (string)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Nome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; Onome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; } catch { }
            try {   novo.Emitente_original = (string)tabela.Rows[a]["emitente_original"]; Oemitente_original = (string)tabela.Rows[a]["emitente_original"]; } catch { }
            try {   novo.Aviso_recebimento = Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]);  Oaviso_recebimento= Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<poschamado> Obter(string where)
        {
            List<poschamado> lista = new List<poschamado>();
            DataTable tabela = Select.SelectSQL("select * from poschamado where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                poschamado novo = new poschamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; Odata_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; } catch { }
            try {   novo.Emitente = (string)tabela.Rows[a]["emitente"]; Oemitente = (string)tabela.Rows[a]["emitente"]; } catch { }
            try {   novo.Ativo = Convert.ToBoolean(tabela.Rows[a]["ativo"]);  Oativo= Convert.ToBoolean(tabela.Rows[a]["ativo"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Status_id = (int)tabela.Rows[a]["status_id"]; Ostatus_id = (int)tabela.Rows[a]["status_id"]; } catch { }
            try {   novo.Conclusao_id = (int)tabela.Rows[a]["conclusao_id"]; Oconclusao_id = (int)tabela.Rows[a]["conclusao_id"]; } catch { }
            try {   novo.Idposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; Oidposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Modificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; Omodificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; } catch { }
            try {   novo.Nome_emitente = (string)tabela.Rows[a]["nome_emitente"]; Onome_emitente = (string)tabela.Rows[a]["nome_emitente"]; } catch { }
            try {   novo.Idmail = (string)tabela.Rows[a]["idmail"]; Oidmail = (string)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Nome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; Onome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; } catch { }
            try {   novo.Emitente_original = (string)tabela.Rows[a]["emitente_original"]; Oemitente_original = (string)tabela.Rows[a]["emitente_original"]; } catch { }
            try {   novo.Aviso_recebimento = Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]);  Oaviso_recebimento= Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<poschamado> ObterComFiltroAvancado(string sql)
        {
            List<poschamado> lista = new List<poschamado>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                poschamado novo = new poschamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; Odata_recebimento = (DateTime)tabela.Rows[a]["data_recebimento"]; } catch { }
            try {   novo.Emitente = (string)tabela.Rows[a]["emitente"]; Oemitente = (string)tabela.Rows[a]["emitente"]; } catch { }
            try {   novo.Ativo = Convert.ToBoolean(tabela.Rows[a]["ativo"]);  Oativo= Convert.ToBoolean(tabela.Rows[a]["ativo"]); } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Status_id = (int)tabela.Rows[a]["status_id"]; Ostatus_id = (int)tabela.Rows[a]["status_id"]; } catch { }
            try {   novo.Conclusao_id = (int)tabela.Rows[a]["conclusao_id"]; Oconclusao_id = (int)tabela.Rows[a]["conclusao_id"]; } catch { }
            try {   novo.Idposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; Oidposchamadopai = (int)tabela.Rows[a]["idposchamadopai"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Modificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; Omodificadoem = (DateTime)tabela.Rows[a]["modificadoem"]; } catch { }
            try {   novo.Nome_emitente = (string)tabela.Rows[a]["nome_emitente"]; Onome_emitente = (string)tabela.Rows[a]["nome_emitente"]; } catch { }
            try {   novo.Idmail = (string)tabela.Rows[a]["idmail"]; Oidmail = (string)tabela.Rows[a]["idmail"]; } catch { }
            try {   novo.Nome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; Onome_emitente_original = (string)tabela.Rows[a]["nome_emitente_original"]; } catch { }
            try {   novo.Emitente_original = (string)tabela.Rows[a]["emitente_original"]; Oemitente_original = (string)tabela.Rows[a]["emitente_original"]; } catch { }
            try {   novo.Aviso_recebimento = Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]);  Oaviso_recebimento= Convert.ToBoolean(tabela.Rows[a]["aviso_recebimento"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from poschamado").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from poschamado where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from poschamado ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from poschamado where " + where + "");
}


# endregion
    }
}
