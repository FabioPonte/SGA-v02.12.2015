using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class emails_anexos
    {
        List<dynamic> _valoresemails_anexos = new List<dynamic>();
        List<string> _colunaemails_anexos = new List<string>();
        List<dynamic> _condicoesemails_anexos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemails_anexos.Count; a++)
         {
             if (col == _colunaemails_anexos[a])
                  {
                       return;
                  }
     }
_colunaemails_anexos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemails_anexos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nomeoriginal="nomeoriginal";
        public const string nomereal="nomereal";
        public const string extensao="extensao";
        public const string tamanho="tamanho";
        public const string emails_id="emails_id";
        public const string caminhoreal="caminhoreal";
        public const string caminhooriginal="caminhooriginal";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemails_anexos.Add(value); }
        }

        static string Onomeoriginal;
        string nomeoriginal;
        public string Nomeoriginal
        {
            get { return nomeoriginal; }
            set { nomeoriginal = value; Add("nomeoriginal"); _valoresemails_anexos.Add(value); }
        }

        static string Onomereal;
        string nomereal;
        public string Nomereal
        {
            get { return nomereal; }
            set { nomereal = value; Add("nomereal"); _valoresemails_anexos.Add(value); }
        }

        static string Oextensao;
        string extensao;
        public string Extensao
        {
            get { return extensao; }
            set { extensao = value; Add("extensao"); _valoresemails_anexos.Add(value); }
        }

        static double Otamanho;
        double tamanho;
        public double Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; Add("tamanho"); _valoresemails_anexos.Add(value); }
        }

        static int Oemails_id;
        int emails_id;
        public int Emails_id
        {
            get { return emails_id; }
            set { emails_id = value; Add("emails_id"); _valoresemails_anexos.Add(value); }
        }

        static string Ocaminhoreal;
        string caminhoreal;
        public string Caminhoreal
        {
            get { return caminhoreal; }
            set { caminhoreal = value; Add("caminhoreal"); _valoresemails_anexos.Add(value); }
        }

        static string Ocaminhooriginal;
        string caminhooriginal;
        public string Caminhooriginal
        {
            get { return caminhooriginal; }
            set { caminhooriginal = value; Add("caminhooriginal"); _valoresemails_anexos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("emails_anexos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemails_anexos,_valoresemails_anexos, _condicoesemails_anexos);   
        }
        public int Alterar()
        {
if (_condicoesemails_anexos.Count > 0)
{
return ExecuteNonSql.Executar("emails_anexos", TipoDeOperacao.Tipo.Update, _colunaemails_anexos,_valoresemails_anexos, _condicoesemails_anexos);
}
else
{
List<string> Nomeemails_anexos = new List<string>();
List<dynamic> Valoremails_anexos = new List<dynamic>();
_valoresemails_anexos.Clear();
if(Id!=null){ Nomeemails_anexos.Add("id");
 Valoremails_anexos.Add(Oid);
 _valoresemails_anexos.Add(Id);
}if(Nomeoriginal!=null){ Nomeemails_anexos.Add("nomeoriginal");
 Valoremails_anexos.Add(Onomeoriginal);
 _valoresemails_anexos.Add(Nomeoriginal);
}if(Nomereal!=null){ Nomeemails_anexos.Add("nomereal");
 Valoremails_anexos.Add(Onomereal);
 _valoresemails_anexos.Add(Nomereal);
}if(Extensao!=null){ Nomeemails_anexos.Add("extensao");
 Valoremails_anexos.Add(Oextensao);
 _valoresemails_anexos.Add(Extensao);
}if(Tamanho!=null){ Nomeemails_anexos.Add("tamanho");
 Valoremails_anexos.Add(Otamanho);
 _valoresemails_anexos.Add(Tamanho);
}if(Emails_id!=null){ Nomeemails_anexos.Add("emails_id");
 Valoremails_anexos.Add(Oemails_id);
 _valoresemails_anexos.Add(Emails_id);
}if(Caminhoreal!=null){ Nomeemails_anexos.Add("caminhoreal");
 Valoremails_anexos.Add(Ocaminhoreal);
 _valoresemails_anexos.Add(Caminhoreal);
}if(Caminhooriginal!=null){ Nomeemails_anexos.Add("caminhooriginal");
 Valoremails_anexos.Add(Ocaminhooriginal);
 _valoresemails_anexos.Add(Caminhooriginal);
}List<dynamic> Condicaoemails_anexos = new List<dynamic>();
Condicaoemails_anexos.Add(Nomeemails_anexos);
Condicaoemails_anexos.Add(Valoremails_anexos);
return ExecuteNonSql.Executar("emails_anexos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemails_anexos, _valoresemails_anexos, Condicaoemails_anexos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("emails_anexos", TipoDeOperacao.Tipo.Delete, _colunaemails_anexos,_valoresemails_anexos, _condicoesemails_anexos);
        }
        static public List<emails_anexos> Obter()
        {
            List<emails_anexos> lista = new List<emails_anexos>();
            DataTable tabela = Select.SelectSQL("select * from emails_anexos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_anexos novo = new emails_anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_anexos> Obter(string where)
        {
            List<emails_anexos> lista = new List<emails_anexos>();
            DataTable tabela = Select.SelectSQL("select * from emails_anexos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_anexos novo = new emails_anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emails_anexos> ObterComFiltroAvancado(string sql)
        {
            List<emails_anexos> lista = new List<emails_anexos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emails_anexos novo = new emails_anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Emails_id = (int)tabela.Rows[a]["emails_id"]; Oemails_id = (int)tabela.Rows[a]["emails_id"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from emails_anexos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from emails_anexos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from emails_anexos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from emails_anexos where " + where + "");
}


# endregion
    }
}
