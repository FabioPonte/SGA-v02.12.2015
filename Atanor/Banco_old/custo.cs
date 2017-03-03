using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class custo
    {
        List<dynamic> _valorescusto = new List<dynamic>();
        List<string> _colunacusto = new List<string>();
        List<dynamic> _condicoescusto = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacusto.Count; a++)
         {
             if (col == _colunacusto[a])
                  {
                       return;
                  }
     }
_colunacusto.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescusto.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string empresa="empresa";
        public const string docdate="docdate";
        public const string itemcode="itemcode";
        public const string calcprice="calcprice";
        public const string transnum="transnum";

         }
# endregion
#region Colunas


        static string Oempresa;
        string empresa;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; Add("empresa"); _valorescusto.Add(value); }
        }

        static DateTime Odocdate;
        DateTime docdate;
        public DateTime Docdate
        {
            get { return docdate; }
            set { docdate = value; Add("docdate"); _valorescusto.Add(value); }
        }

        static string Oitemcode;
        string itemcode;
        public string Itemcode
        {
            get { return itemcode; }
            set { itemcode = value; Add("itemcode"); _valorescusto.Add(value); }
        }

        static double Ocalcprice;
        double calcprice;
        public double Calcprice
        {
            get { return calcprice; }
            set { calcprice = value; Add("calcprice"); _valorescusto.Add(value); }
        }

        static string Otransnum;
        string transnum;
        public string Transnum
        {
            get { return transnum; }
            set { transnum = value; Add("transnum"); _valorescusto.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("custo", TipoDeOperacao.Tipo.InsertMultiplo, _colunacusto,_valorescusto, _condicoescusto);   
        }
        public int Alterar()
        {
if (_condicoescusto.Count > 0)
{
return ExecuteNonSql.Executar("custo", TipoDeOperacao.Tipo.Update, _colunacusto,_valorescusto, _condicoescusto);
}
else
{
List<string> Nomecusto = new List<string>();
List<dynamic> Valorcusto = new List<dynamic>();
_valorescusto.Clear();
if(Empresa!=null){ Nomecusto.Add("empresa");
 Valorcusto.Add(Oempresa);
 _valorescusto.Add(Empresa);
}if(Docdate!=null){ Nomecusto.Add("docdate");
 Valorcusto.Add(Odocdate);
 _valorescusto.Add(Docdate);
}if(Itemcode!=null){ Nomecusto.Add("itemcode");
 Valorcusto.Add(Oitemcode);
 _valorescusto.Add(Itemcode);
}if(Calcprice!=null){ Nomecusto.Add("calcprice");
 Valorcusto.Add(Ocalcprice);
 _valorescusto.Add(Calcprice);
}if(Transnum!=null){ Nomecusto.Add("transnum");
 Valorcusto.Add(Otransnum);
 _valorescusto.Add(Transnum);
}List<dynamic> Condicaocusto = new List<dynamic>();
Condicaocusto.Add(Nomecusto);
Condicaocusto.Add(Valorcusto);
return ExecuteNonSql.Executar("custo", TipoDeOperacao.Tipo.UpdateCondicional, _colunacusto, _valorescusto, Condicaocusto);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("custo", TipoDeOperacao.Tipo.Delete, _colunacusto,_valorescusto, _condicoescusto);
        }
        static public List<custo> Obter()
        {
            List<custo> lista = new List<custo>();
            DataTable tabela = Select.SelectSQL("select * from custo");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                custo novo = new custo();
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Docdate = (DateTime)tabela.Rows[a]["docdate"]; Odocdate = (DateTime)tabela.Rows[a]["docdate"]; } catch { }
            try {   novo.Itemcode = (string)tabela.Rows[a]["itemcode"]; Oitemcode = (string)tabela.Rows[a]["itemcode"]; } catch { }
            try {   novo.Calcprice = (double)tabela.Rows[a]["calcprice"]; Ocalcprice = (double)tabela.Rows[a]["calcprice"]; } catch { }
            try {   novo.Transnum = (string)tabela.Rows[a]["transnum"]; Otransnum = (string)tabela.Rows[a]["transnum"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<custo> Obter(string where)
        {
            List<custo> lista = new List<custo>();
            DataTable tabela = Select.SelectSQL("select * from custo where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                custo novo = new custo();
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Docdate = (DateTime)tabela.Rows[a]["docdate"]; Odocdate = (DateTime)tabela.Rows[a]["docdate"]; } catch { }
            try {   novo.Itemcode = (string)tabela.Rows[a]["itemcode"]; Oitemcode = (string)tabela.Rows[a]["itemcode"]; } catch { }
            try {   novo.Calcprice = (double)tabela.Rows[a]["calcprice"]; Ocalcprice = (double)tabela.Rows[a]["calcprice"]; } catch { }
            try {   novo.Transnum = (string)tabela.Rows[a]["transnum"]; Otransnum = (string)tabela.Rows[a]["transnum"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<custo> ObterComFiltroAvancado(string sql)
        {
            List<custo> lista = new List<custo>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                custo novo = new custo();
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Docdate = (DateTime)tabela.Rows[a]["docdate"]; Odocdate = (DateTime)tabela.Rows[a]["docdate"]; } catch { }
            try {   novo.Itemcode = (string)tabela.Rows[a]["itemcode"]; Oitemcode = (string)tabela.Rows[a]["itemcode"]; } catch { }
            try {   novo.Calcprice = (double)tabela.Rows[a]["calcprice"]; Ocalcprice = (double)tabela.Rows[a]["calcprice"]; } catch { }
            try {   novo.Transnum = (string)tabela.Rows[a]["transnum"]; Otransnum = (string)tabela.Rows[a]["transnum"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from custo").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from custo where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from custo ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from custo where " + where + "");
}


# endregion
    }
}
