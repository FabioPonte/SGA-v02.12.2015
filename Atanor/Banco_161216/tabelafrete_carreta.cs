using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class tabelafrete_carreta
    {
        List<dynamic> _valorestabelafrete_carreta = new List<dynamic>();
        List<string> _colunatabelafrete_carreta = new List<string>();
        List<dynamic> _condicoestabelafrete_carreta = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatabelafrete_carreta.Count; a++)
         {
             if (col == _colunatabelafrete_carreta[a])
                  {
                       return;
                  }
     }
_colunatabelafrete_carreta.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestabelafrete_carreta.Add(value); }
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
            set { id = value; Add("id"); _valorestabelafrete_carreta.Add(value); }
        }

        static int Oidtransportadoras;
        int idtransportadoras;
        public int Idtransportadoras
        {
            get { return idtransportadoras; }
            set { idtransportadoras = value; Add("idtransportadoras"); _valorestabelafrete_carreta.Add(value); }
        }

        static int Oidcentrodistribuicao;
        int idcentrodistribuicao;
        public int Idcentrodistribuicao
        {
            get { return idcentrodistribuicao; }
            set { idcentrodistribuicao = value; Add("idcentrodistribuicao"); _valorestabelafrete_carreta.Add(value); }
        }

        static string Odestino;
        string destino;
        public string Destino
        {
            get { return destino; }
            set { destino = value; Add("destino"); _valorestabelafrete_carreta.Add(value); }
        }

        static double Ovalor_icms;
        double valor_icms;
        public double Valor_icms
        {
            get { return valor_icms; }
            set { valor_icms = value; Add("valor_icms"); _valorestabelafrete_carreta.Add(value); }
        }

        static double Ovalor_pallets;
        double valor_pallets;
        public double Valor_pallets
        {
            get { return valor_pallets; }
            set { valor_pallets = value; Add("valor_pallets"); _valorestabelafrete_carreta.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("tabelafrete_carreta", TipoDeOperacao.Tipo.InsertMultiplo, _colunatabelafrete_carreta,_valorestabelafrete_carreta, _condicoestabelafrete_carreta);   
        }
        public int Alterar()
        {
if (_condicoestabelafrete_carreta.Count > 0)
{
return ExecuteNonSql.Executar("tabelafrete_carreta", TipoDeOperacao.Tipo.Update, _colunatabelafrete_carreta,_valorestabelafrete_carreta, _condicoestabelafrete_carreta);
}
else
{
List<string> Nometabelafrete_carreta = new List<string>();
List<dynamic> Valortabelafrete_carreta = new List<dynamic>();
_valorestabelafrete_carreta.Clear();
if(Id!=null){ Nometabelafrete_carreta.Add("id");
 Valortabelafrete_carreta.Add(Oid);
 _valorestabelafrete_carreta.Add(Id);
}if(Idtransportadoras!=null){ Nometabelafrete_carreta.Add("idtransportadoras");
 Valortabelafrete_carreta.Add(Oidtransportadoras);
 _valorestabelafrete_carreta.Add(Idtransportadoras);
}if(Idcentrodistribuicao!=null){ Nometabelafrete_carreta.Add("idcentrodistribuicao");
 Valortabelafrete_carreta.Add(Oidcentrodistribuicao);
 _valorestabelafrete_carreta.Add(Idcentrodistribuicao);
}if(Destino!=null){ Nometabelafrete_carreta.Add("destino");
 Valortabelafrete_carreta.Add(Odestino);
 _valorestabelafrete_carreta.Add(Destino);
}if(Valor_icms!=null){ Nometabelafrete_carreta.Add("valor_icms");
 Valortabelafrete_carreta.Add(Ovalor_icms);
 _valorestabelafrete_carreta.Add(Valor_icms);
}if(Valor_pallets!=null){ Nometabelafrete_carreta.Add("valor_pallets");
 Valortabelafrete_carreta.Add(Ovalor_pallets);
 _valorestabelafrete_carreta.Add(Valor_pallets);
}List<dynamic> Condicaotabelafrete_carreta = new List<dynamic>();
Condicaotabelafrete_carreta.Add(Nometabelafrete_carreta);
Condicaotabelafrete_carreta.Add(Valortabelafrete_carreta);
return ExecuteNonSql.Executar("tabelafrete_carreta", TipoDeOperacao.Tipo.UpdateCondicional, _colunatabelafrete_carreta, _valorestabelafrete_carreta, Condicaotabelafrete_carreta);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("tabelafrete_carreta", TipoDeOperacao.Tipo.Delete, _colunatabelafrete_carreta,_valorestabelafrete_carreta, _condicoestabelafrete_carreta);
        }
        static public List<tabelafrete_carreta> Obter()
        {
            List<tabelafrete_carreta> lista = new List<tabelafrete_carreta>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_carreta");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_carreta novo = new tabelafrete_carreta();
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
        static public List<tabelafrete_carreta> Obter(string where)
        {
            List<tabelafrete_carreta> lista = new List<tabelafrete_carreta>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_carreta where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_carreta novo = new tabelafrete_carreta();
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
        static public List<tabelafrete_carreta> ObterComFiltroAvancado(string sql)
        {
            List<tabelafrete_carreta> lista = new List<tabelafrete_carreta>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_carreta novo = new tabelafrete_carreta();
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
return Select.SelectSQL("select * from tabelafrete_carreta").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from tabelafrete_carreta where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from tabelafrete_carreta ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from tabelafrete_carreta where " + where + "");
}


# endregion
    }
}
