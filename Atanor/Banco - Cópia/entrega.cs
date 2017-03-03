using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class entrega
    {
        List<dynamic> _valoresentrega = new List<dynamic>();
        List<string> _colunaentrega = new List<string>();
        List<dynamic> _condicoesentrega = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaentrega.Count; a++)
         {
             if (col == _colunaentrega[a])
                  {
                       return;
                  }
     }
_colunaentrega.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesentrega.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nota="nota";
        public const string data="data";
        public const string criador="criador";
        public const string datadocumento="datadocumento";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresentrega.Add(value); }
        }

        static int Onota;
        int nota;
        public int Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresentrega.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresentrega.Add(value); }
        }

        static string Ocriador;
        string criador;
        public string Criador
        {
            get { return criador; }
            set { criador = value; Add("criador"); _valoresentrega.Add(value); }
        }

        static DateTime Odatadocumento;
        DateTime datadocumento;
        public DateTime Datadocumento
        {
            get { return datadocumento; }
            set { datadocumento = value; Add("datadocumento"); _valoresentrega.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.InsertMultiplo, _colunaentrega,_valoresentrega, _condicoesentrega);   
        }
        public int Alterar()
        {
if (_condicoesentrega.Count > 0)
{
return ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.Update, _colunaentrega,_valoresentrega, _condicoesentrega);
}
else
{
List<string> Nomeentrega = new List<string>();
List<dynamic> Valorentrega = new List<dynamic>();
_valoresentrega.Clear();
if(Id!=null){ Nomeentrega.Add("id");
 Valorentrega.Add(Oid);
 _valoresentrega.Add(Id);
}if(Nota!=null){ Nomeentrega.Add("nota");
 Valorentrega.Add(Onota);
 _valoresentrega.Add(Nota);
}if(Data!=null){ Nomeentrega.Add("data");
 Valorentrega.Add(Odata);
 _valoresentrega.Add(Data);
}if(Criador!=null){ Nomeentrega.Add("criador");
 Valorentrega.Add(Ocriador);
 _valoresentrega.Add(Criador);
}if(Datadocumento!=null){ Nomeentrega.Add("datadocumento");
 Valorentrega.Add(Odatadocumento);
 _valoresentrega.Add(Datadocumento);
}List<dynamic> Condicaoentrega = new List<dynamic>();
Condicaoentrega.Add(Nomeentrega);
Condicaoentrega.Add(Valorentrega);
return ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.UpdateCondicional, _colunaentrega, _valoresentrega, Condicaoentrega);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.Delete, _colunaentrega,_valoresentrega, _condicoesentrega);
        }
        static public List<entrega> Obter()
        {
            List<entrega> lista = new List<entrega>();
            DataTable tabela = Select.SelectSQL("select * from entrega");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entrega novo = new entrega();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
            try {   novo.Datadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; Odatadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<entrega> Obter(string where)
        {
            List<entrega> lista = new List<entrega>();
            DataTable tabela = Select.SelectSQL("select * from entrega where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entrega novo = new entrega();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
            try {   novo.Datadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; Odatadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<entrega> ObterComFiltroAvancado(string sql)
        {
            List<entrega> lista = new List<entrega>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entrega novo = new entrega();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
            try {   novo.Datadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; Odatadocumento = (DateTime)tabela.Rows[a]["datadocumento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from entrega").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from entrega where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from entrega ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from entrega where " + where + "");
}


# endregion
    }
}
