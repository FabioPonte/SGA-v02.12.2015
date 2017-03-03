using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class emails
    {
        List<dynamic> _valoresemails = new List<dynamic>();
        List<string> _colunaemails = new List<string>();
        List<dynamic> _condicoesemails = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemails.Count; a++)
         {
             if (col == _colunaemails[a])
                  {
                       return;
                  }
     }
_colunaemails.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemails.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string titulo="titulo";
        public const string data_envio="data_envio";
        public const string usuarios_id="usuarios_id";
        public const string destinatario="destinatario";
        public const string poschamado_id="poschamado_id";
        public const string codigo="codigo";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemails.Add(value); }
        }

        static string Otitulo;
        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; Add("titulo"); _valoresemails.Add(value); }
        }

        static DateTime Odata_envio;
        DateTime data_envio;
        public DateTime Data_envio
        {
            get { return data_envio; }
            set { data_envio = value; Add("data_envio"); _valoresemails.Add(value); }
        }

        static int Ousuarios_id;
        int usuarios_id;
        public int Usuarios_id
        {
            get { return usuarios_id; }
            set { usuarios_id = value; Add("usuarios_id"); _valoresemails.Add(value); }
        }

        static string Odestinatario;
        string destinatario;
        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; Add("destinatario"); _valoresemails.Add(value); }
        }

        static int Oposchamado_id;
        int poschamado_id;
        public int Poschamado_id
        {
            get { return poschamado_id; }
            set { poschamado_id = value; Add("poschamado_id"); _valoresemails.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresemails.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("emails", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemails,_valoresemails, _condicoesemails);   
        }
        public int Alterar()
        {
if (_condicoesemails.Count > 0)
{
return ExecuteNonSql.Executar("emails", TipoDeOperacao.Tipo.Update, _colunaemails,_valoresemails, _condicoesemails);
}
else
{
List<string> Nomeemails = new List<string>();
List<dynamic> Valoremails = new List<dynamic>();
_valoresemails.Clear();
if(Id!=null){ Nomeemails.Add("id");
 Valoremails.Add(Oid);
 _valoresemails.Add(Id);
}if(Titulo!=null){ Nomeemails.Add("titulo");
 Valoremails.Add(Otitulo);
 _valoresemails.Add(Titulo);
}if(Data_envio!=null){ Nomeemails.Add("data_envio");
 Valoremails.Add(Odata_envio);
 _valoresemails.Add(Data_envio);
}if(Usuarios_id!=null){ Nomeemails.Add("usuarios_id");
 Valoremails.Add(Ousuarios_id);
 _valoresemails.Add(Usuarios_id);
}if(Destinatario!=null){ Nomeemails.Add("destinatario");
 Valoremails.Add(Odestinatario);
 _valoresemails.Add(Destinatario);
}if(Poschamado_id!=null){ Nomeemails.Add("poschamado_id");
 Valoremails.Add(Oposchamado_id);
 _valoresemails.Add(Poschamado_id);
}if(Codigo!=null){ Nomeemails.Add("codigo");
 Valoremails.Add(Ocodigo);
 _valoresemails.Add(Codigo);
}List<dynamic> Condicaoemails = new List<dynamic>();
Condicaoemails.Add(Nomeemails);
Condicaoemails.Add(Valoremails);
return ExecuteNonSql.Executar("emails", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemails, _valoresemails, Condicaoemails);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("emails", TipoDeOperacao.Tipo.Delete, _colunaemails,_valoresemails, _condicoesemails);
        }
        static public List<emails> Obter()
        {
            List<emails> lista = new List<emails>();
            DataTable tabela = Select.SelectSQL("select * from emails");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails novo = new emails();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_envio = (DateTime)tabela.Rows[a]["data_envio"]; Odata_envio = (DateTime)tabela.Rows[a]["data_envio"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Destinatario = (string)tabela.Rows[a]["destinatario"]; Odestinatario = (string)tabela.Rows[a]["destinatario"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails> Obter(string where)
        {
            List<emails> lista = new List<emails>();
            DataTable tabela = Select.SelectSQL("select * from emails where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails novo = new emails();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_envio = (DateTime)tabela.Rows[a]["data_envio"]; Odata_envio = (DateTime)tabela.Rows[a]["data_envio"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Destinatario = (string)tabela.Rows[a]["destinatario"]; Odestinatario = (string)tabela.Rows[a]["destinatario"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails> ObterComFiltroAvancado(string sql)
        {
            List<emails> lista = new List<emails>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails novo = new emails();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Data_envio = (DateTime)tabela.Rows[a]["data_envio"]; Odata_envio = (DateTime)tabela.Rows[a]["data_envio"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Destinatario = (string)tabela.Rows[a]["destinatario"]; Odestinatario = (string)tabela.Rows[a]["destinatario"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from emails").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from emails where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from emails ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from emails where " + where + "");
}


# endregion
    }
}
