using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class condicaoestoque
    {
        List<dynamic> _valorescondicaoestoque = new List<dynamic>();
        List<string> _colunacondicaoestoque = new List<string>();
        List<dynamic> _condicoescondicaoestoque = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacondicaoestoque.Count; a++)
         {
             if (col == _colunacondicaoestoque[a])
                  {
                       return;
                  }
     }
_colunacondicaoestoque.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescondicaoestoque.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string data="data";
        public const string posicao="posicao";
        public const string numeroitem="numeroitem";
        public const string descricao="descricao";
        public const string quantidade="quantidade";
        public const string custo="custo";
        public const string valor="valor";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescondicaoestoque.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valorescondicaoestoque.Add(value); }
        }

        static string Oposicao;
        string posicao;
        public string Posicao
        {
            get { return posicao; }
            set { posicao = value; Add("posicao"); _valorescondicaoestoque.Add(value); }
        }

        static string Onumeroitem;
        string numeroitem;
        public string Numeroitem
        {
            get { return numeroitem; }
            set { numeroitem = value; Add("numeroitem"); _valorescondicaoestoque.Add(value); }
        }

        static string Odescricao;
        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; Add("descricao"); _valorescondicaoestoque.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valorescondicaoestoque.Add(value); }
        }

        static double Ocusto;
        double custo;
        public double Custo
        {
            get { return custo; }
            set { custo = value; Add("custo"); _valorescondicaoestoque.Add(value); }
        }

        static double Ovalor;
        double valor;
        public double Valor
        {
            get { return valor; }
            set { valor = value; Add("valor"); _valorescondicaoestoque.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.InsertMultiplo, _colunacondicaoestoque,_valorescondicaoestoque, _condicoescondicaoestoque);   
        }
        public int Alterar()
        {
if (_condicoescondicaoestoque.Count > 0)
{
return ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.Update, _colunacondicaoestoque,_valorescondicaoestoque, _condicoescondicaoestoque);
}
else
{
List<string> Nomecondicaoestoque = new List<string>();
List<dynamic> Valorcondicaoestoque = new List<dynamic>();
_valorescondicaoestoque.Clear();
if(Id!=null){ Nomecondicaoestoque.Add("id");
 Valorcondicaoestoque.Add(Oid);
 _valorescondicaoestoque.Add(Id);
}if(Data!=null){ Nomecondicaoestoque.Add("data");
 Valorcondicaoestoque.Add(Odata);
 _valorescondicaoestoque.Add(Data);
}if(Posicao!=null){ Nomecondicaoestoque.Add("posicao");
 Valorcondicaoestoque.Add(Oposicao);
 _valorescondicaoestoque.Add(Posicao);
}if(Numeroitem!=null){ Nomecondicaoestoque.Add("numeroitem");
 Valorcondicaoestoque.Add(Onumeroitem);
 _valorescondicaoestoque.Add(Numeroitem);
}if(Descricao!=null){ Nomecondicaoestoque.Add("descricao");
 Valorcondicaoestoque.Add(Odescricao);
 _valorescondicaoestoque.Add(Descricao);
}if(Quantidade!=null){ Nomecondicaoestoque.Add("quantidade");
 Valorcondicaoestoque.Add(Oquantidade);
 _valorescondicaoestoque.Add(Quantidade);
}if(Custo!=null){ Nomecondicaoestoque.Add("custo");
 Valorcondicaoestoque.Add(Ocusto);
 _valorescondicaoestoque.Add(Custo);
}if(Valor!=null){ Nomecondicaoestoque.Add("valor");
 Valorcondicaoestoque.Add(Ovalor);
 _valorescondicaoestoque.Add(Valor);
}List<dynamic> Condicaocondicaoestoque = new List<dynamic>();
Condicaocondicaoestoque.Add(Nomecondicaoestoque);
Condicaocondicaoestoque.Add(Valorcondicaoestoque);
return ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.UpdateCondicional, _colunacondicaoestoque, _valorescondicaoestoque, Condicaocondicaoestoque);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.Delete, _colunacondicaoestoque,_valorescondicaoestoque, _condicoescondicaoestoque);
        }
        static public List<condicaoestoque> Obter()
        {
            List<condicaoestoque> lista = new List<condicaoestoque>();
            DataTable tabela = Select.SelectSQL("select * from condicaoestoque");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                condicaoestoque novo = new condicaoestoque();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Posicao = (string)tabela.Rows[a]["posicao"]; Oposicao = (string)tabela.Rows[a]["posicao"]; } catch { }
            try {   novo.Numeroitem = (string)tabela.Rows[a]["numeroitem"]; Onumeroitem = (string)tabela.Rows[a]["numeroitem"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<condicaoestoque> Obter(string where)
        {
            List<condicaoestoque> lista = new List<condicaoestoque>();
            DataTable tabela = Select.SelectSQL("select * from condicaoestoque where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                condicaoestoque novo = new condicaoestoque();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Posicao = (string)tabela.Rows[a]["posicao"]; Oposicao = (string)tabela.Rows[a]["posicao"]; } catch { }
            try {   novo.Numeroitem = (string)tabela.Rows[a]["numeroitem"]; Onumeroitem = (string)tabela.Rows[a]["numeroitem"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<condicaoestoque> ObterComFiltroAvancado(string sql)
        {
            List<condicaoestoque> lista = new List<condicaoestoque>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                condicaoestoque novo = new condicaoestoque();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Posicao = (string)tabela.Rows[a]["posicao"]; Oposicao = (string)tabela.Rows[a]["posicao"]; } catch { }
            try {   novo.Numeroitem = (string)tabela.Rows[a]["numeroitem"]; Onumeroitem = (string)tabela.Rows[a]["numeroitem"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from condicaoestoque").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from condicaoestoque where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from condicaoestoque ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from condicaoestoque where " + where + "");
}


# endregion
    }
}
