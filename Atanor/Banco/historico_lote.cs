using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class historico_lote
    {
        List<dynamic> _valoreshistorico_lote = new List<dynamic>();
        List<string> _colunahistorico_lote = new List<string>();
        List<dynamic> _condicoeshistorico_lote = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunahistorico_lote.Count; a++)
         {
             if (col == _colunahistorico_lote[a])
                  {
                       return;
                  }
     }
_colunahistorico_lote.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoeshistorico_lote.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string cod="cod";
        public const string produto="produto";
        public const string quantidade="quantidade";
        public const string lote="lote";
        public const string local="local";
        public const string desposito="desposito";
        public const string data="data";
        public const string oid="oid";
        public const string vencimento="vencimento";
        public const string fabricacao="fabricacao";
        public const string custo="custo";

         }
# endregion
#region Colunas


        static int Oiid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoreshistorico_lote.Add(value); }
        }

        static string Ocod;
        string cod;
        public string Cod
        {
            get { return cod; }
            set { cod = value; Add("cod"); _valoreshistorico_lote.Add(value); }
        }

        static string Oproduto;
        string produto;
        public string Produto
        {
            get { return produto; }
            set { produto = value; Add("produto"); _valoreshistorico_lote.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoreshistorico_lote.Add(value); }
        }

        static string Olote;
        string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; Add("lote"); _valoreshistorico_lote.Add(value); }
        }

        static string Olocal;
        string local;
        public string Local
        {
            get { return local; }
            set { local = value; Add("local"); _valoreshistorico_lote.Add(value); }
        }

        static string Odesposito;
        string desposito;
        public string Desposito
        {
            get { return desposito; }
            set { desposito = value; Add("desposito"); _valoreshistorico_lote.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoreshistorico_lote.Add(value); }
        }

        static string Ooid;
        string oid;
        public string Oid
        {
            get { return oid; }
            set { oid = value; Add("oid"); _valoreshistorico_lote.Add(value); }
        }

        static string Ovencimento;
        string vencimento;
        public string Vencimento
        {
            get { return vencimento; }
            set { vencimento = value; Add("vencimento"); _valoreshistorico_lote.Add(value); }
        }

        static string Ofabricacao;
        string fabricacao;
        public string Fabricacao
        {
            get { return fabricacao; }
            set { fabricacao = value; Add("fabricacao"); _valoreshistorico_lote.Add(value); }
        }

        static double Ocusto;
        double custo;
        public double Custo
        {
            get { return custo; }
            set { custo = value; Add("custo"); _valoreshistorico_lote.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("historico_lote", TipoDeOperacao.Tipo.InsertMultiplo, _colunahistorico_lote,_valoreshistorico_lote, _condicoeshistorico_lote);   
        }
        public int Alterar()
        {
if (_condicoeshistorico_lote.Count > 0)
{
return ExecuteNonSql.Executar("historico_lote", TipoDeOperacao.Tipo.Update, _colunahistorico_lote,_valoreshistorico_lote, _condicoeshistorico_lote);
}
else
{
List<string> Nomehistorico_lote = new List<string>();
List<dynamic> Valorhistorico_lote = new List<dynamic>();
_valoreshistorico_lote.Clear();
if(Id!=null){ Nomehistorico_lote.Add("id");
 Valorhistorico_lote.Add(Oid);
 _valoreshistorico_lote.Add(Id);
}if(Cod!=null){ Nomehistorico_lote.Add("cod");
 Valorhistorico_lote.Add(Ocod);
 _valoreshistorico_lote.Add(Cod);
}if(Produto!=null){ Nomehistorico_lote.Add("produto");
 Valorhistorico_lote.Add(Oproduto);
 _valoreshistorico_lote.Add(Produto);
}if(Quantidade!=null){ Nomehistorico_lote.Add("quantidade");
 Valorhistorico_lote.Add(Oquantidade);
 _valoreshistorico_lote.Add(Quantidade);
}if(Lote!=null){ Nomehistorico_lote.Add("lote");
 Valorhistorico_lote.Add(Olote);
 _valoreshistorico_lote.Add(Lote);
}if(Local!=null){ Nomehistorico_lote.Add("local");
 Valorhistorico_lote.Add(Olocal);
 _valoreshistorico_lote.Add(Local);
}if(Desposito!=null){ Nomehistorico_lote.Add("desposito");
 Valorhistorico_lote.Add(Odesposito);
 _valoreshistorico_lote.Add(Desposito);
}if(Data!=null){ Nomehistorico_lote.Add("data");
 Valorhistorico_lote.Add(Odata);
 _valoreshistorico_lote.Add(Data);
}if(Oid!=null){ Nomehistorico_lote.Add("oid");
 Valorhistorico_lote.Add(Ooid);
 _valoreshistorico_lote.Add(Oid);
}if(Vencimento!=null){ Nomehistorico_lote.Add("vencimento");
 Valorhistorico_lote.Add(Ovencimento);
 _valoreshistorico_lote.Add(Vencimento);
}if(Fabricacao!=null){ Nomehistorico_lote.Add("fabricacao");
 Valorhistorico_lote.Add(Ofabricacao);
 _valoreshistorico_lote.Add(Fabricacao);
}if(Custo!=null){ Nomehistorico_lote.Add("custo");
 Valorhistorico_lote.Add(Ocusto);
 _valoreshistorico_lote.Add(Custo);
}List<dynamic> Condicaohistorico_lote = new List<dynamic>();
Condicaohistorico_lote.Add(Nomehistorico_lote);
Condicaohistorico_lote.Add(Valorhistorico_lote);
return ExecuteNonSql.Executar("historico_lote", TipoDeOperacao.Tipo.UpdateCondicional, _colunahistorico_lote, _valoreshistorico_lote, Condicaohistorico_lote);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("historico_lote", TipoDeOperacao.Tipo.Delete, _colunahistorico_lote,_valoreshistorico_lote, _condicoeshistorico_lote);
        }
        static public List<historico_lote> Obter()
        {
            List<historico_lote> lista = new List<historico_lote>();
            DataTable tabela = Select.SelectSQL("select * from historico_lote");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                historico_lote novo = new historico_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oiid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cod = (string)tabela.Rows[a]["cod"]; Ocod = (string)tabela.Rows[a]["cod"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Desposito = (string)tabela.Rows[a]["desposito"]; Odesposito = (string)tabela.Rows[a]["desposito"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Oid = (string)tabela.Rows[a]["oid"]; Ooid = (string)tabela.Rows[a]["oid"]; } catch { }
            try {   novo.Vencimento = (string)tabela.Rows[a]["vencimento"]; Ovencimento = (string)tabela.Rows[a]["vencimento"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<historico_lote> Obter(string where)
        {
            List<historico_lote> lista = new List<historico_lote>();
            DataTable tabela = Select.SelectSQL("select * from historico_lote where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                historico_lote novo = new historico_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oiid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cod = (string)tabela.Rows[a]["cod"]; Ocod = (string)tabela.Rows[a]["cod"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Desposito = (string)tabela.Rows[a]["desposito"]; Odesposito = (string)tabela.Rows[a]["desposito"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Oid = (string)tabela.Rows[a]["oid"]; Ooid = (string)tabela.Rows[a]["oid"]; } catch { }
            try {   novo.Vencimento = (string)tabela.Rows[a]["vencimento"]; Ovencimento = (string)tabela.Rows[a]["vencimento"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<historico_lote> ObterComFiltroAvancado(string sql)
        {
            List<historico_lote> lista = new List<historico_lote>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                historico_lote novo = new historico_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oiid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cod = (string)tabela.Rows[a]["cod"]; Ocod = (string)tabela.Rows[a]["cod"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Desposito = (string)tabela.Rows[a]["desposito"]; Odesposito = (string)tabela.Rows[a]["desposito"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Oid = (string)tabela.Rows[a]["oid"]; Ooid = (string)tabela.Rows[a]["oid"]; } catch { }
            try {   novo.Vencimento = (string)tabela.Rows[a]["vencimento"]; Ovencimento = (string)tabela.Rows[a]["vencimento"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Custo = (double)tabela.Rows[a]["custo"]; Ocusto = (double)tabela.Rows[a]["custo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from historico_lote").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from historico_lote where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from historico_lote ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from historico_lote where " + where + "");
}


# endregion
    }
}
