using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class acerto_lote
    {
        List<dynamic> _valoresacerto_lote = new List<dynamic>();
        List<string> _colunaacerto_lote = new List<string>();
        List<dynamic> _condicoesacerto_lote = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaacerto_lote.Count; a++)
         {
             if (col == _colunaacerto_lote[a])
                  {
                       return;
                  }
     }
_colunaacerto_lote.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesacerto_lote.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string cd="cd";
        public const string item="item";
        public const string descricao="descricao";
        public const string lote="lote";
        public const string quantidade="quantidade";
        public const string obs="obs";
        public const string fabricacao="fabricacao";
        public const string validade="validade";
        public const string nota_siger="nota_siger";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresacerto_lote.Add(value); }
        }

        static string Ocd;
        string cd;
        public string Cd
        {
            get { return cd; }
            set { cd = value; Add("cd"); _valoresacerto_lote.Add(value); }
        }

        static string Oitem;
        string item;
        public string Item
        {
            get { return item; }
            set { item = value; Add("item"); _valoresacerto_lote.Add(value); }
        }

        static string Odescricao;
        string descricao;
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; Add("descricao"); _valoresacerto_lote.Add(value); }
        }

        static string Olote;
        string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; Add("lote"); _valoresacerto_lote.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresacerto_lote.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresacerto_lote.Add(value); }
        }

        static string Ofabricacao;
        string fabricacao;
        public string Fabricacao
        {
            get { return fabricacao; }
            set { fabricacao = value; Add("fabricacao"); _valoresacerto_lote.Add(value); }
        }

        static string Ovalidade;
        string validade;
        public string Validade
        {
            get { return validade; }
            set { validade = value; Add("validade"); _valoresacerto_lote.Add(value); }
        }

        static string Onota_siger;
        string nota_siger;
        public string Nota_siger
        {
            get { return nota_siger; }
            set { nota_siger = value; Add("nota_siger"); _valoresacerto_lote.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("acerto_lote", TipoDeOperacao.Tipo.InsertMultiplo, _colunaacerto_lote,_valoresacerto_lote, _condicoesacerto_lote);   
        }
        public int Alterar()
        {
if (_condicoesacerto_lote.Count > 0)
{
return ExecuteNonSql.Executar("acerto_lote", TipoDeOperacao.Tipo.Update, _colunaacerto_lote,_valoresacerto_lote, _condicoesacerto_lote);
}
else
{
List<string> Nomeacerto_lote = new List<string>();
List<dynamic> Valoracerto_lote = new List<dynamic>();
_valoresacerto_lote.Clear();
if(Id!=null){ Nomeacerto_lote.Add("id");
 Valoracerto_lote.Add(Oid);
 _valoresacerto_lote.Add(Id);
}if(Cd!=null){ Nomeacerto_lote.Add("cd");
 Valoracerto_lote.Add(Ocd);
 _valoresacerto_lote.Add(Cd);
}if(Item!=null){ Nomeacerto_lote.Add("item");
 Valoracerto_lote.Add(Oitem);
 _valoresacerto_lote.Add(Item);
}if(Descricao!=null){ Nomeacerto_lote.Add("descricao");
 Valoracerto_lote.Add(Odescricao);
 _valoresacerto_lote.Add(Descricao);
}if(Lote!=null){ Nomeacerto_lote.Add("lote");
 Valoracerto_lote.Add(Olote);
 _valoresacerto_lote.Add(Lote);
}if(Quantidade!=null){ Nomeacerto_lote.Add("quantidade");
 Valoracerto_lote.Add(Oquantidade);
 _valoresacerto_lote.Add(Quantidade);
}if(Obs!=null){ Nomeacerto_lote.Add("obs");
 Valoracerto_lote.Add(Oobs);
 _valoresacerto_lote.Add(Obs);
}if(Fabricacao!=null){ Nomeacerto_lote.Add("fabricacao");
 Valoracerto_lote.Add(Ofabricacao);
 _valoresacerto_lote.Add(Fabricacao);
}if(Validade!=null){ Nomeacerto_lote.Add("validade");
 Valoracerto_lote.Add(Ovalidade);
 _valoresacerto_lote.Add(Validade);
}if(Nota_siger!=null){ Nomeacerto_lote.Add("nota_siger");
 Valoracerto_lote.Add(Onota_siger);
 _valoresacerto_lote.Add(Nota_siger);
}List<dynamic> Condicaoacerto_lote = new List<dynamic>();
Condicaoacerto_lote.Add(Nomeacerto_lote);
Condicaoacerto_lote.Add(Valoracerto_lote);
return ExecuteNonSql.Executar("acerto_lote", TipoDeOperacao.Tipo.UpdateCondicional, _colunaacerto_lote, _valoresacerto_lote, Condicaoacerto_lote);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("acerto_lote", TipoDeOperacao.Tipo.Delete, _colunaacerto_lote,_valoresacerto_lote, _condicoesacerto_lote);
        }
        static public List<acerto_lote> Obter()
        {
            List<acerto_lote> lista = new List<acerto_lote>();
            DataTable tabela = Select.SelectSQL("select * from acerto_lote");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                acerto_lote novo = new acerto_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Item = (string)tabela.Rows[a]["item"]; Oitem = (string)tabela.Rows[a]["item"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Validade = (string)tabela.Rows[a]["validade"]; Ovalidade = (string)tabela.Rows[a]["validade"]; } catch { }
            try {   novo.Nota_siger = (string)tabela.Rows[a]["nota_siger"]; Onota_siger = (string)tabela.Rows[a]["nota_siger"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<acerto_lote> Obter(string where)
        {
            List<acerto_lote> lista = new List<acerto_lote>();
            DataTable tabela = Select.SelectSQL("select * from acerto_lote where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                acerto_lote novo = new acerto_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Item = (string)tabela.Rows[a]["item"]; Oitem = (string)tabela.Rows[a]["item"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Validade = (string)tabela.Rows[a]["validade"]; Ovalidade = (string)tabela.Rows[a]["validade"]; } catch { }
            try {   novo.Nota_siger = (string)tabela.Rows[a]["nota_siger"]; Onota_siger = (string)tabela.Rows[a]["nota_siger"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<acerto_lote> ObterComFiltroAvancado(string sql)
        {
            List<acerto_lote> lista = new List<acerto_lote>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                acerto_lote novo = new acerto_lote();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Item = (string)tabela.Rows[a]["item"]; Oitem = (string)tabela.Rows[a]["item"]; } catch { }
            try {   novo.Descricao = (string)tabela.Rows[a]["descricao"]; Odescricao = (string)tabela.Rows[a]["descricao"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Fabricacao = (string)tabela.Rows[a]["fabricacao"]; Ofabricacao = (string)tabela.Rows[a]["fabricacao"]; } catch { }
            try {   novo.Validade = (string)tabela.Rows[a]["validade"]; Ovalidade = (string)tabela.Rows[a]["validade"]; } catch { }
            try {   novo.Nota_siger = (string)tabela.Rows[a]["nota_siger"]; Onota_siger = (string)tabela.Rows[a]["nota_siger"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from acerto_lote").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from acerto_lote where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from acerto_lote ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from acerto_lote where " + where + "");
}


# endregion
    }
}
