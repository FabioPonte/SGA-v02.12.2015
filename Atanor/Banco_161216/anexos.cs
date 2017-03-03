using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class anexos
    {
        List<dynamic> _valoresanexos = new List<dynamic>();
        List<string> _colunaanexos = new List<string>();
        List<dynamic> _condicoesanexos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaanexos.Count; a++)
         {
             if (col == _colunaanexos[a])
                  {
                       return;
                  }
     }
_colunaanexos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesanexos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idposchamado="idposchamado";
        public const string nomeoriginal="nomeoriginal";
        public const string caminhooriginal="caminhooriginal";
        public const string tamanho="tamanho";
        public const string caminhoreal="caminhoreal";
        public const string nomereal="nomereal";
        public const string extensao="extensao";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresanexos.Add(value); }
        }

        static int Oidposchamado;
        int idposchamado;
        public int Idposchamado
        {
            get { return idposchamado; }
            set { idposchamado = value; Add("idposchamado"); _valoresanexos.Add(value); }
        }

        static string Onomeoriginal;
        string nomeoriginal;
        public string Nomeoriginal
        {
            get { return nomeoriginal; }
            set { nomeoriginal = value; Add("nomeoriginal"); _valoresanexos.Add(value); }
        }

        static string Ocaminhooriginal;
        string caminhooriginal;
        public string Caminhooriginal
        {
            get { return caminhooriginal; }
            set { caminhooriginal = value; Add("caminhooriginal"); _valoresanexos.Add(value); }
        }

        static double Otamanho;
        double tamanho;
        public double Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; Add("tamanho"); _valoresanexos.Add(value); }
        }

        static string Ocaminhoreal;
        string caminhoreal;
        public string Caminhoreal
        {
            get { return caminhoreal; }
            set { caminhoreal = value; Add("caminhoreal"); _valoresanexos.Add(value); }
        }

        static string Onomereal;
        string nomereal;
        public string Nomereal
        {
            get { return nomereal; }
            set { nomereal = value; Add("nomereal"); _valoresanexos.Add(value); }
        }

        static string Oextensao;
        string extensao;
        public string Extensao
        {
            get { return extensao; }
            set { extensao = value; Add("extensao"); _valoresanexos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("anexos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaanexos,_valoresanexos, _condicoesanexos);   
        }
        public int Alterar()
        {
if (_condicoesanexos.Count > 0)
{
return ExecuteNonSql.Executar("anexos", TipoDeOperacao.Tipo.Update, _colunaanexos,_valoresanexos, _condicoesanexos);
}
else
{
List<string> Nomeanexos = new List<string>();
List<dynamic> Valoranexos = new List<dynamic>();
_valoresanexos.Clear();
if(Id!=null){ Nomeanexos.Add("id");
 Valoranexos.Add(Oid);
 _valoresanexos.Add(Id);
}if(Idposchamado!=null){ Nomeanexos.Add("idposchamado");
 Valoranexos.Add(Oidposchamado);
 _valoresanexos.Add(Idposchamado);
}if(Nomeoriginal!=null){ Nomeanexos.Add("nomeoriginal");
 Valoranexos.Add(Onomeoriginal);
 _valoresanexos.Add(Nomeoriginal);
}if(Caminhooriginal!=null){ Nomeanexos.Add("caminhooriginal");
 Valoranexos.Add(Ocaminhooriginal);
 _valoresanexos.Add(Caminhooriginal);
}if(Tamanho!=null){ Nomeanexos.Add("tamanho");
 Valoranexos.Add(Otamanho);
 _valoresanexos.Add(Tamanho);
}if(Caminhoreal!=null){ Nomeanexos.Add("caminhoreal");
 Valoranexos.Add(Ocaminhoreal);
 _valoresanexos.Add(Caminhoreal);
}if(Nomereal!=null){ Nomeanexos.Add("nomereal");
 Valoranexos.Add(Onomereal);
 _valoresanexos.Add(Nomereal);
}if(Extensao!=null){ Nomeanexos.Add("extensao");
 Valoranexos.Add(Oextensao);
 _valoresanexos.Add(Extensao);
}List<dynamic> Condicaoanexos = new List<dynamic>();
Condicaoanexos.Add(Nomeanexos);
Condicaoanexos.Add(Valoranexos);
return ExecuteNonSql.Executar("anexos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaanexos, _valoresanexos, Condicaoanexos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("anexos", TipoDeOperacao.Tipo.Delete, _colunaanexos,_valoresanexos, _condicoesanexos);
        }
        static public List<anexos> Obter()
        {
            List<anexos> lista = new List<anexos>();
            DataTable tabela = Select.SelectSQL("select * from anexos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                anexos novo = new anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idposchamado = (int)tabela.Rows[a]["idposchamado"]; Oidposchamado = (int)tabela.Rows[a]["idposchamado"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<anexos> Obter(string where)
        {
            List<anexos> lista = new List<anexos>();
            DataTable tabela = Select.SelectSQL("select * from anexos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                anexos novo = new anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idposchamado = (int)tabela.Rows[a]["idposchamado"]; Oidposchamado = (int)tabela.Rows[a]["idposchamado"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<anexos> ObterComFiltroAvancado(string sql)
        {
            List<anexos> lista = new List<anexos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                anexos novo = new anexos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idposchamado = (int)tabela.Rows[a]["idposchamado"]; Oidposchamado = (int)tabela.Rows[a]["idposchamado"]; } catch { }
            try {   novo.Nomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; Onomeoriginal = (string)tabela.Rows[a]["nomeoriginal"]; } catch { }
            try {   novo.Caminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; Ocaminhooriginal = (string)tabela.Rows[a]["caminhooriginal"]; } catch { }
            try {   novo.Tamanho = (double)tabela.Rows[a]["tamanho"]; Otamanho = (double)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Caminhoreal = (string)tabela.Rows[a]["caminhoreal"]; Ocaminhoreal = (string)tabela.Rows[a]["caminhoreal"]; } catch { }
            try {   novo.Nomereal = (string)tabela.Rows[a]["nomereal"]; Onomereal = (string)tabela.Rows[a]["nomereal"]; } catch { }
            try {   novo.Extensao = (string)tabela.Rows[a]["extensao"]; Oextensao = (string)tabela.Rows[a]["extensao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from anexos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from anexos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from anexos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from anexos where " + where + "");
}


# endregion
    }
}
