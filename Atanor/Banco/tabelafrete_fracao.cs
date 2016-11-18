using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class tabelafrete_fracao
    {
        List<dynamic> _valorestabelafrete_fracao = new List<dynamic>();
        List<string> _colunatabelafrete_fracao = new List<string>();
        List<dynamic> _condicoestabelafrete_fracao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatabelafrete_fracao.Count; a++)
         {
             if (col == _colunatabelafrete_fracao[a])
                  {
                       return;
                  }
     }
_colunatabelafrete_fracao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestabelafrete_fracao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idtransportadoras="idtransportadoras";
        public const string idcentrodistribuicao="idcentrodistribuicao";
        public const string destino="destino";
        public const string valor_icms="valor_icms";
        public const string valor_pallets="valor_pallets";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorestabelafrete_fracao.Add(value); }
        }

        static int Oidtransportadoras;
        int idtransportadoras;
        public int Idtransportadoras
        {
            get { return idtransportadoras; }
            set { idtransportadoras = value; Add("idtransportadoras"); _valorestabelafrete_fracao.Add(value); }
        }

        static int Oidcentrodistribuicao;
        int idcentrodistribuicao;
        public int Idcentrodistribuicao
        {
            get { return idcentrodistribuicao; }
            set { idcentrodistribuicao = value; Add("idcentrodistribuicao"); _valorestabelafrete_fracao.Add(value); }
        }

        static string Odestino;
        string destino;
        public string Destino
        {
            get { return destino; }
            set { destino = value; Add("destino"); _valorestabelafrete_fracao.Add(value); }
        }

        static double Ovalor_icms;
        double valor_icms;
        public double Valor_icms
        {
            get { return valor_icms; }
            set { valor_icms = value; Add("valor_icms"); _valorestabelafrete_fracao.Add(value); }
        }

        static double Ovalor_pallets;
        double valor_pallets;
        public double Valor_pallets
        {
            get { return valor_pallets; }
            set { valor_pallets = value; Add("valor_pallets"); _valorestabelafrete_fracao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("tabelafrete_fracao", TipoDeOperacao.Tipo.InsertMultiplo, _colunatabelafrete_fracao,_valorestabelafrete_fracao, _condicoestabelafrete_fracao);   
        }
        public int Alterar()
        {
if (_condicoestabelafrete_fracao.Count > 0)
{
return ExecuteNonSql.Executar("tabelafrete_fracao", TipoDeOperacao.Tipo.Update, _colunatabelafrete_fracao,_valorestabelafrete_fracao, _condicoestabelafrete_fracao);
}
else
{
List<string> Nometabelafrete_fracao = new List<string>();
List<dynamic> Valortabelafrete_fracao = new List<dynamic>();
_valorestabelafrete_fracao.Clear();
if(Id!=null){ Nometabelafrete_fracao.Add("id");
 Valortabelafrete_fracao.Add(Oid);
 _valorestabelafrete_fracao.Add(Id);
}if(Idtransportadoras!=null){ Nometabelafrete_fracao.Add("idtransportadoras");
 Valortabelafrete_fracao.Add(Oidtransportadoras);
 _valorestabelafrete_fracao.Add(Idtransportadoras);
}if(Idcentrodistribuicao!=null){ Nometabelafrete_fracao.Add("idcentrodistribuicao");
 Valortabelafrete_fracao.Add(Oidcentrodistribuicao);
 _valorestabelafrete_fracao.Add(Idcentrodistribuicao);
}if(Destino!=null){ Nometabelafrete_fracao.Add("destino");
 Valortabelafrete_fracao.Add(Odestino);
 _valorestabelafrete_fracao.Add(Destino);
}if(Valor_icms!=null){ Nometabelafrete_fracao.Add("valor_icms");
 Valortabelafrete_fracao.Add(Ovalor_icms);
 _valorestabelafrete_fracao.Add(Valor_icms);
}if(Valor_pallets!=null){ Nometabelafrete_fracao.Add("valor_pallets");
 Valortabelafrete_fracao.Add(Ovalor_pallets);
 _valorestabelafrete_fracao.Add(Valor_pallets);
}List<dynamic> Condicaotabelafrete_fracao = new List<dynamic>();
Condicaotabelafrete_fracao.Add(Nometabelafrete_fracao);
Condicaotabelafrete_fracao.Add(Valortabelafrete_fracao);
return ExecuteNonSql.Executar("tabelafrete_fracao", TipoDeOperacao.Tipo.UpdateCondicional, _colunatabelafrete_fracao, _valorestabelafrete_fracao, Condicaotabelafrete_fracao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("tabelafrete_fracao", TipoDeOperacao.Tipo.Delete, _colunatabelafrete_fracao,_valorestabelafrete_fracao, _condicoestabelafrete_fracao);
        }
        static public List<tabelafrete_fracao> Obter()
        {
            List<tabelafrete_fracao> lista = new List<tabelafrete_fracao>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_fracao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_fracao novo = new tabelafrete_fracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Destino = (string)tabela.Rows[a]["destino"]; Odestino = (string)tabela.Rows[a]["destino"]; } catch { }
            try {   novo.Valor_icms = (double)tabela.Rows[a]["valor_icms"]; Ovalor_icms = (double)tabela.Rows[a]["valor_icms"]; } catch { }
            try {   novo.Valor_pallets = (double)tabela.Rows[a]["valor_pallets"]; Ovalor_pallets = (double)tabela.Rows[a]["valor_pallets"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tabelafrete_fracao> Obter(string where)
        {
            List<tabelafrete_fracao> lista = new List<tabelafrete_fracao>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_fracao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_fracao novo = new tabelafrete_fracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Destino = (string)tabela.Rows[a]["destino"]; Odestino = (string)tabela.Rows[a]["destino"]; } catch { }
            try {   novo.Valor_icms = (double)tabela.Rows[a]["valor_icms"]; Ovalor_icms = (double)tabela.Rows[a]["valor_icms"]; } catch { }
            try {   novo.Valor_pallets = (double)tabela.Rows[a]["valor_pallets"]; Ovalor_pallets = (double)tabela.Rows[a]["valor_pallets"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tabelafrete_fracao> ObterComFiltroAvancado(string sql)
        {
            List<tabelafrete_fracao> lista = new List<tabelafrete_fracao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_fracao novo = new tabelafrete_fracao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Destino = (string)tabela.Rows[a]["destino"]; Odestino = (string)tabela.Rows[a]["destino"]; } catch { }
            try {   novo.Valor_icms = (double)tabela.Rows[a]["valor_icms"]; Ovalor_icms = (double)tabela.Rows[a]["valor_icms"]; } catch { }
            try {   novo.Valor_pallets = (double)tabela.Rows[a]["valor_pallets"]; Ovalor_pallets = (double)tabela.Rows[a]["valor_pallets"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from tabelafrete_fracao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from tabelafrete_fracao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from tabelafrete_fracao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from tabelafrete_fracao where " + where + "");
}


# endregion
    }
}
