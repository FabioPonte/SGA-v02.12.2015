using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class itens
    {
        List<dynamic> _valoresitens = new List<dynamic>();
        List<string> _colunaitens = new List<string>();
        List<dynamic> _condicoesitens = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaitens.Count; a++)
         {
             if (col == _colunaitens[a])
                  {
                       return;
                  }
     }
_colunaitens.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesitens.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idfabricantes="idfabricantes";
        public const string idgrupo_itens="idgrupo_itens";
        public const string idprioridades="idprioridades";
        public const string nome="nome";
        public const string ncm="ncm";
        public const string valor="valor";
        public const string localizacao="localizacao";
        public const string obs="obs";
        public const string item_estoque="item_estoque";
        public const string maetrial_consumo="maetrial_consumo";
        public const string quantidade="quantidade";
        public const string min="min";
        public const string medio="medio";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresitens.Add(value); }
        }

        static int Oidfabricantes;
        int idfabricantes;
        public int Idfabricantes
        {
            get { return idfabricantes; }
            set { idfabricantes = value; Add("idfabricantes"); _valoresitens.Add(value); }
        }

        static int Oidgrupo_itens;
        int idgrupo_itens;
        public int Idgrupo_itens
        {
            get { return idgrupo_itens; }
            set { idgrupo_itens = value; Add("idgrupo_itens"); _valoresitens.Add(value); }
        }

        static int Oidprioridades;
        int idprioridades;
        public int Idprioridades
        {
            get { return idprioridades; }
            set { idprioridades = value; Add("idprioridades"); _valoresitens.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresitens.Add(value); }
        }

        static string Oncm;
        string ncm;
        public string Ncm
        {
            get { return ncm; }
            set { ncm = value; Add("ncm"); _valoresitens.Add(value); }
        }

        static double Ovalor;
        double valor;
        public double Valor
        {
            get { return valor; }
            set { valor = value; Add("valor"); _valoresitens.Add(value); }
        }

        static string Olocalizacao;
        string localizacao;
        public string Localizacao
        {
            get { return localizacao; }
            set { localizacao = value; Add("localizacao"); _valoresitens.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresitens.Add(value); }
        }

        static Boolean Oitem_estoque;
        Boolean item_estoque;
        public Boolean Item_estoque
        {
            get { return item_estoque; }
            set { item_estoque = value; Add("item_estoque"); _valoresitens.Add(value); }
        }

        static Boolean Omaetrial_consumo;
        Boolean maetrial_consumo;
        public Boolean Maetrial_consumo
        {
            get { return maetrial_consumo; }
            set { maetrial_consumo = value; Add("maetrial_consumo"); _valoresitens.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresitens.Add(value); }
        }

        static double Omin;
        double min;
        public double Min
        {
            get { return min; }
            set { min = value; Add("min"); _valoresitens.Add(value); }
        }

        static double Omedio;
        double medio;
        public double Medio
        {
            get { return medio; }
            set { medio = value; Add("medio"); _valoresitens.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("itens", TipoDeOperacao.Tipo.InsertMultiplo, _colunaitens,_valoresitens, _condicoesitens);   
        }
        public int Alterar()
        {
if (_condicoesitens.Count > 0)
{
return ExecuteNonSql.Executar("itens", TipoDeOperacao.Tipo.Update, _colunaitens,_valoresitens, _condicoesitens);
}
else
{
List<string> Nomeitens = new List<string>();
List<dynamic> Valoritens = new List<dynamic>();
_valoresitens.Clear();
if(Id!=null){ Nomeitens.Add("id");
 Valoritens.Add(Oid);
 _valoresitens.Add(Id);
}if(Idfabricantes!=null){ Nomeitens.Add("idfabricantes");
 Valoritens.Add(Oidfabricantes);
 _valoresitens.Add(Idfabricantes);
}if(Idgrupo_itens!=null){ Nomeitens.Add("idgrupo_itens");
 Valoritens.Add(Oidgrupo_itens);
 _valoresitens.Add(Idgrupo_itens);
}if(Idprioridades!=null){ Nomeitens.Add("idprioridades");
 Valoritens.Add(Oidprioridades);
 _valoresitens.Add(Idprioridades);
}if(Nome!=null){ Nomeitens.Add("nome");
 Valoritens.Add(Onome);
 _valoresitens.Add(Nome);
}if(Ncm!=null){ Nomeitens.Add("ncm");
 Valoritens.Add(Oncm);
 _valoresitens.Add(Ncm);
}if(Valor!=null){ Nomeitens.Add("valor");
 Valoritens.Add(Ovalor);
 _valoresitens.Add(Valor);
}if(Localizacao!=null){ Nomeitens.Add("localizacao");
 Valoritens.Add(Olocalizacao);
 _valoresitens.Add(Localizacao);
}if(Obs!=null){ Nomeitens.Add("obs");
 Valoritens.Add(Oobs);
 _valoresitens.Add(Obs);
}if(Item_estoque!=null){ Nomeitens.Add("item_estoque");
 Valoritens.Add(Oitem_estoque);
 _valoresitens.Add(Item_estoque);
}if(Maetrial_consumo!=null){ Nomeitens.Add("maetrial_consumo");
 Valoritens.Add(Omaetrial_consumo);
 _valoresitens.Add(Maetrial_consumo);
}if(Quantidade!=null){ Nomeitens.Add("quantidade");
 Valoritens.Add(Oquantidade);
 _valoresitens.Add(Quantidade);
}if(Min!=null){ Nomeitens.Add("min");
 Valoritens.Add(Omin);
 _valoresitens.Add(Min);
}if(Medio!=null){ Nomeitens.Add("medio");
 Valoritens.Add(Omedio);
 _valoresitens.Add(Medio);
}List<dynamic> Condicaoitens = new List<dynamic>();
Condicaoitens.Add(Nomeitens);
Condicaoitens.Add(Valoritens);
return ExecuteNonSql.Executar("itens", TipoDeOperacao.Tipo.UpdateCondicional, _colunaitens, _valoresitens, Condicaoitens);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("itens", TipoDeOperacao.Tipo.Delete, _colunaitens,_valoresitens, _condicoesitens);
        }
        static public List<itens> Obter()
        {
            List<itens> lista = new List<itens>();
            DataTable tabela = Select.SelectSQL("select * from itens");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens novo = new itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfabricantes = (int)tabela.Rows[a]["idfabricantes"]; Oidfabricantes = (int)tabela.Rows[a]["idfabricantes"]; } catch { }
            try {   novo.Idgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; Oidgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; } catch { }
            try {   novo.Idprioridades = (int)tabela.Rows[a]["idprioridades"]; Oidprioridades = (int)tabela.Rows[a]["idprioridades"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ncm = (string)tabela.Rows[a]["ncm"]; Oncm = (string)tabela.Rows[a]["ncm"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
            try {   novo.Localizacao = (string)tabela.Rows[a]["localizacao"]; Olocalizacao = (string)tabela.Rows[a]["localizacao"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Item_estoque = Convert.ToBoolean(tabela.Rows[a]["item_estoque"]);  Oitem_estoque= Convert.ToBoolean(tabela.Rows[a]["item_estoque"]); } catch { }
            try {   novo.Maetrial_consumo = Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]);  Omaetrial_consumo= Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]); } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Medio = (double)tabela.Rows[a]["medio"]; Omedio = (double)tabela.Rows[a]["medio"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens> Obter(string where)
        {
            List<itens> lista = new List<itens>();
            DataTable tabela = Select.SelectSQL("select * from itens where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens novo = new itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfabricantes = (int)tabela.Rows[a]["idfabricantes"]; Oidfabricantes = (int)tabela.Rows[a]["idfabricantes"]; } catch { }
            try {   novo.Idgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; Oidgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; } catch { }
            try {   novo.Idprioridades = (int)tabela.Rows[a]["idprioridades"]; Oidprioridades = (int)tabela.Rows[a]["idprioridades"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ncm = (string)tabela.Rows[a]["ncm"]; Oncm = (string)tabela.Rows[a]["ncm"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
            try {   novo.Localizacao = (string)tabela.Rows[a]["localizacao"]; Olocalizacao = (string)tabela.Rows[a]["localizacao"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Item_estoque = Convert.ToBoolean(tabela.Rows[a]["item_estoque"]);  Oitem_estoque= Convert.ToBoolean(tabela.Rows[a]["item_estoque"]); } catch { }
            try {   novo.Maetrial_consumo = Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]);  Omaetrial_consumo= Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]); } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Medio = (double)tabela.Rows[a]["medio"]; Omedio = (double)tabela.Rows[a]["medio"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens> ObterComFiltroAvancado(string sql)
        {
            List<itens> lista = new List<itens>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens novo = new itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfabricantes = (int)tabela.Rows[a]["idfabricantes"]; Oidfabricantes = (int)tabela.Rows[a]["idfabricantes"]; } catch { }
            try {   novo.Idgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; Oidgrupo_itens = (int)tabela.Rows[a]["idgrupo_itens"]; } catch { }
            try {   novo.Idprioridades = (int)tabela.Rows[a]["idprioridades"]; Oidprioridades = (int)tabela.Rows[a]["idprioridades"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ncm = (string)tabela.Rows[a]["ncm"]; Oncm = (string)tabela.Rows[a]["ncm"]; } catch { }
            try {   novo.Valor = (double)tabela.Rows[a]["valor"]; Ovalor = (double)tabela.Rows[a]["valor"]; } catch { }
            try {   novo.Localizacao = (string)tabela.Rows[a]["localizacao"]; Olocalizacao = (string)tabela.Rows[a]["localizacao"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Item_estoque = Convert.ToBoolean(tabela.Rows[a]["item_estoque"]);  Oitem_estoque= Convert.ToBoolean(tabela.Rows[a]["item_estoque"]); } catch { }
            try {   novo.Maetrial_consumo = Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]);  Omaetrial_consumo= Convert.ToBoolean(tabela.Rows[a]["maetrial_consumo"]); } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Medio = (double)tabela.Rows[a]["medio"]; Omedio = (double)tabela.Rows[a]["medio"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from itens").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from itens where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from itens ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from itens where " + where + "");
}


# endregion
    }
}
