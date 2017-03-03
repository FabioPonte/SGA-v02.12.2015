using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class add_itens
    {
        List<dynamic> _valoresadd_itens = new List<dynamic>();
        List<string> _colunaadd_itens = new List<string>();
        List<dynamic> _condicoesadd_itens = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaadd_itens.Count; a++)
         {
             if (col == _colunaadd_itens[a])
                  {
                       return;
                  }
     }
_colunaadd_itens.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesadd_itens.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string iditens="iditens";
        public const string pedido="pedido";
        public const string data_entrada="data_entrada";
        public const string data_pedido="data_pedido";
        public const string quantidade="quantidade";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresadd_itens.Add(value); }
        }

        static int Oiditens;
        int iditens;
        public int Iditens
        {
            get { return iditens; }
            set { iditens = value; Add("iditens"); _valoresadd_itens.Add(value); }
        }

        static string Opedido;
        string pedido;
        public string Pedido
        {
            get { return pedido; }
            set { pedido = value; Add("pedido"); _valoresadd_itens.Add(value); }
        }

        static DateTime Odata_entrada;
        DateTime data_entrada;
        public DateTime Data_entrada
        {
            get { return data_entrada; }
            set { data_entrada = value; Add("data_entrada"); _valoresadd_itens.Add(value); }
        }

        static DateTime Odata_pedido;
        DateTime data_pedido;
        public DateTime Data_pedido
        {
            get { return data_pedido; }
            set { data_pedido = value; Add("data_pedido"); _valoresadd_itens.Add(value); }
        }

        static double Oquantidade;
        double quantidade;
        public double Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; Add("quantidade"); _valoresadd_itens.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("add_itens", TipoDeOperacao.Tipo.InsertMultiplo, _colunaadd_itens,_valoresadd_itens, _condicoesadd_itens);   
        }
        public int Alterar()
        {
if (_condicoesadd_itens.Count > 0)
{
return ExecuteNonSql.Executar("add_itens", TipoDeOperacao.Tipo.Update, _colunaadd_itens,_valoresadd_itens, _condicoesadd_itens);
}
else
{
List<string> Nomeadd_itens = new List<string>();
List<dynamic> Valoradd_itens = new List<dynamic>();
_valoresadd_itens.Clear();
if(Id!=null){ Nomeadd_itens.Add("id");
 Valoradd_itens.Add(Oid);
 _valoresadd_itens.Add(Id);
}if(Iditens!=null){ Nomeadd_itens.Add("iditens");
 Valoradd_itens.Add(Oiditens);
 _valoresadd_itens.Add(Iditens);
}if(Pedido!=null){ Nomeadd_itens.Add("pedido");
 Valoradd_itens.Add(Opedido);
 _valoresadd_itens.Add(Pedido);
}if(Data_entrada!=null){ Nomeadd_itens.Add("data_entrada");
 Valoradd_itens.Add(Odata_entrada);
 _valoresadd_itens.Add(Data_entrada);
}if(Data_pedido!=null){ Nomeadd_itens.Add("data_pedido");
 Valoradd_itens.Add(Odata_pedido);
 _valoresadd_itens.Add(Data_pedido);
}if(Quantidade!=null){ Nomeadd_itens.Add("quantidade");
 Valoradd_itens.Add(Oquantidade);
 _valoresadd_itens.Add(Quantidade);
}List<dynamic> Condicaoadd_itens = new List<dynamic>();
Condicaoadd_itens.Add(Nomeadd_itens);
Condicaoadd_itens.Add(Valoradd_itens);
return ExecuteNonSql.Executar("add_itens", TipoDeOperacao.Tipo.UpdateCondicional, _colunaadd_itens, _valoresadd_itens, Condicaoadd_itens);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("add_itens", TipoDeOperacao.Tipo.Delete, _colunaadd_itens,_valoresadd_itens, _condicoesadd_itens);
        }
        static public List<add_itens> Obter()
        {
            List<add_itens> lista = new List<add_itens>();
            DataTable tabela = Select.SelectSQL("select * from add_itens");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                add_itens novo = new add_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Pedido = (string)tabela.Rows[a]["pedido"]; Opedido = (string)tabela.Rows[a]["pedido"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Data_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; Odata_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<add_itens> Obter(string where)
        {
            List<add_itens> lista = new List<add_itens>();
            DataTable tabela = Select.SelectSQL("select * from add_itens where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                add_itens novo = new add_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Pedido = (string)tabela.Rows[a]["pedido"]; Opedido = (string)tabela.Rows[a]["pedido"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Data_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; Odata_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<add_itens> ObterComFiltroAvancado(string sql)
        {
            List<add_itens> lista = new List<add_itens>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                add_itens novo = new add_itens();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Iditens = (int)tabela.Rows[a]["iditens"]; Oiditens = (int)tabela.Rows[a]["iditens"]; } catch { }
            try {   novo.Pedido = (string)tabela.Rows[a]["pedido"]; Opedido = (string)tabela.Rows[a]["pedido"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Data_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; Odata_pedido = (DateTime)tabela.Rows[a]["data_pedido"]; } catch { }
            try {   novo.Quantidade = (double)tabela.Rows[a]["quantidade"]; Oquantidade = (double)tabela.Rows[a]["quantidade"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from add_itens").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from add_itens where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from add_itens ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from add_itens where " + where + "");
}


# endregion
    }
}
