using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class tabelafrete_truck
    {
        List<dynamic> _valorestabelafrete_truck = new List<dynamic>();
        List<string> _colunatabelafrete_truck = new List<string>();
        List<dynamic> _condicoestabelafrete_truck = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatabelafrete_truck.Count; a++)
         {
             if (col == _colunatabelafrete_truck[a])
                  {
                       return;
                  }
     }
_colunatabelafrete_truck.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestabelafrete_truck.Add(value); }
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
            set { id = value; Add("id"); _valorestabelafrete_truck.Add(value); }
        }

        static int Oidtransportadoras;
        int idtransportadoras;
        public int Idtransportadoras
        {
            get { return idtransportadoras; }
            set { idtransportadoras = value; Add("idtransportadoras"); _valorestabelafrete_truck.Add(value); }
        }

        static int Oidcentrodistribuicao;
        int idcentrodistribuicao;
        public int Idcentrodistribuicao
        {
            get { return idcentrodistribuicao; }
            set { idcentrodistribuicao = value; Add("idcentrodistribuicao"); _valorestabelafrete_truck.Add(value); }
        }

        static string Odestino;
        string destino;
        public string Destino
        {
            get { return destino; }
            set { destino = value; Add("destino"); _valorestabelafrete_truck.Add(value); }
        }

        static double Ovalor_icms;
        double valor_icms;
        public double Valor_icms
        {
            get { return valor_icms; }
            set { valor_icms = value; Add("valor_icms"); _valorestabelafrete_truck.Add(value); }
        }

        static double Ovalor_pallets;
        double valor_pallets;
        public double Valor_pallets
        {
            get { return valor_pallets; }
            set { valor_pallets = value; Add("valor_pallets"); _valorestabelafrete_truck.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("tabelafrete_truck", TipoDeOperacao.Tipo.InsertMultiplo, _colunatabelafrete_truck,_valorestabelafrete_truck, _condicoestabelafrete_truck);   
        }
        public int Alterar()
        {
if (_condicoestabelafrete_truck.Count > 0)
{
return ExecuteNonSql.Executar("tabelafrete_truck", TipoDeOperacao.Tipo.Update, _colunatabelafrete_truck,_valorestabelafrete_truck, _condicoestabelafrete_truck);
}
else
{
List<string> Nometabelafrete_truck = new List<string>();
List<dynamic> Valortabelafrete_truck = new List<dynamic>();
_valorestabelafrete_truck.Clear();
if(Id!=null){ Nometabelafrete_truck.Add("id");
 Valortabelafrete_truck.Add(Oid);
 _valorestabelafrete_truck.Add(Id);
}if(Idtransportadoras!=null){ Nometabelafrete_truck.Add("idtransportadoras");
 Valortabelafrete_truck.Add(Oidtransportadoras);
 _valorestabelafrete_truck.Add(Idtransportadoras);
}if(Idcentrodistribuicao!=null){ Nometabelafrete_truck.Add("idcentrodistribuicao");
 Valortabelafrete_truck.Add(Oidcentrodistribuicao);
 _valorestabelafrete_truck.Add(Idcentrodistribuicao);
}if(Destino!=null){ Nometabelafrete_truck.Add("destino");
 Valortabelafrete_truck.Add(Odestino);
 _valorestabelafrete_truck.Add(Destino);
}if(Valor_icms!=null){ Nometabelafrete_truck.Add("valor_icms");
 Valortabelafrete_truck.Add(Ovalor_icms);
 _valorestabelafrete_truck.Add(Valor_icms);
}if(Valor_pallets!=null){ Nometabelafrete_truck.Add("valor_pallets");
 Valortabelafrete_truck.Add(Ovalor_pallets);
 _valorestabelafrete_truck.Add(Valor_pallets);
}List<dynamic> Condicaotabelafrete_truck = new List<dynamic>();
Condicaotabelafrete_truck.Add(Nometabelafrete_truck);
Condicaotabelafrete_truck.Add(Valortabelafrete_truck);
return ExecuteNonSql.Executar("tabelafrete_truck", TipoDeOperacao.Tipo.UpdateCondicional, _colunatabelafrete_truck, _valorestabelafrete_truck, Condicaotabelafrete_truck);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("tabelafrete_truck", TipoDeOperacao.Tipo.Delete, _colunatabelafrete_truck,_valorestabelafrete_truck, _condicoestabelafrete_truck);
        }
        static public List<tabelafrete_truck> Obter()
        {
            List<tabelafrete_truck> lista = new List<tabelafrete_truck>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_truck");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_truck novo = new tabelafrete_truck();
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
        static public List<tabelafrete_truck> Obter(string where)
        {
            List<tabelafrete_truck> lista = new List<tabelafrete_truck>();
            DataTable tabela = Select.SelectSQL("select * from tabelafrete_truck where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_truck novo = new tabelafrete_truck();
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
        static public List<tabelafrete_truck> ObterComFiltroAvancado(string sql)
        {
            List<tabelafrete_truck> lista = new List<tabelafrete_truck>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tabelafrete_truck novo = new tabelafrete_truck();
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
return Select.SelectSQL("select * from tabelafrete_truck").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from tabelafrete_truck where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from tabelafrete_truck ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from tabelafrete_truck where " + where + "");
}


# endregion
    }
}
