using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class produtos
    {
        List<dynamic> _valoresprodutos = new List<dynamic>();
        List<string> _colunaprodutos = new List<string>();
        List<dynamic> _condicoesprodutos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaprodutos.Count; a++)
         {
             if (col == _colunaprodutos[a])
                  {
                       return;
                  }
     }
_colunaprodutos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesprodutos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idsap="idsap";
        public const string nome="nome";
        public const string peso="peso";
        public const string conversao="conversao";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresprodutos.Add(value); }
        }

        static string Oidsap;
        string idsap;
        public string Idsap
        {
            get { return idsap; }
            set { idsap = value; Add("idsap"); _valoresprodutos.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresprodutos.Add(value); }
        }

        static double Opeso;
        double peso;
        public double Peso
        {
            get { return peso; }
            set { peso = value; Add("peso"); _valoresprodutos.Add(value); }
        }

        static double Oconversao;
        double conversao;
        public double Conversao
        {
            get { return conversao; }
            set { conversao = value; Add("conversao"); _valoresprodutos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaprodutos,_valoresprodutos, _condicoesprodutos);   
        }
        public int Alterar()
        {
if (_condicoesprodutos.Count > 0)
{
return ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.Update, _colunaprodutos,_valoresprodutos, _condicoesprodutos);
}
else
{
List<string> Nomeprodutos = new List<string>();
List<dynamic> Valorprodutos = new List<dynamic>();
_valoresprodutos.Clear();
if(Id!=null){ Nomeprodutos.Add("id");
 Valorprodutos.Add(Oid);
 _valoresprodutos.Add(Id);
}if(Idsap!=null){ Nomeprodutos.Add("idsap");
 Valorprodutos.Add(Oidsap);
 _valoresprodutos.Add(Idsap);
}if(Nome!=null){ Nomeprodutos.Add("nome");
 Valorprodutos.Add(Onome);
 _valoresprodutos.Add(Nome);
}if(Peso!=null){ Nomeprodutos.Add("peso");
 Valorprodutos.Add(Opeso);
 _valoresprodutos.Add(Peso);
}if(Conversao!=null){ Nomeprodutos.Add("conversao");
 Valorprodutos.Add(Oconversao);
 _valoresprodutos.Add(Conversao);
}List<dynamic> Condicaoprodutos = new List<dynamic>();
Condicaoprodutos.Add(Nomeprodutos);
Condicaoprodutos.Add(Valorprodutos);
return ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaprodutos, _valoresprodutos, Condicaoprodutos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("produtos", TipoDeOperacao.Tipo.Delete, _colunaprodutos,_valoresprodutos, _condicoesprodutos);
        }
        static public List<produtos> Obter()
        {
            List<produtos> lista = new List<produtos>();
            DataTable tabela = Select.SelectSQL("select * from produtos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                produtos novo = new produtos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idsap = (string)tabela.Rows[a]["idsap"]; Oidsap = (string)tabela.Rows[a]["idsap"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Conversao = (double)tabela.Rows[a]["conversao"]; Oconversao = (double)tabela.Rows[a]["conversao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<produtos> Obter(string where)
        {
            List<produtos> lista = new List<produtos>();
            DataTable tabela = Select.SelectSQL("select * from produtos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                produtos novo = new produtos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idsap = (string)tabela.Rows[a]["idsap"]; Oidsap = (string)tabela.Rows[a]["idsap"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Conversao = (double)tabela.Rows[a]["conversao"]; Oconversao = (double)tabela.Rows[a]["conversao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<produtos> ObterComFiltroAvancado(string sql)
        {
            List<produtos> lista = new List<produtos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                produtos novo = new produtos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idsap = (string)tabela.Rows[a]["idsap"]; Oidsap = (string)tabela.Rows[a]["idsap"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Conversao = (double)tabela.Rows[a]["conversao"]; Oconversao = (double)tabela.Rows[a]["conversao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from produtos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from produtos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from produtos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from produtos where " + where + "");
}


# endregion
    }
}
