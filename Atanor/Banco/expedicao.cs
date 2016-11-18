using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class expedicao
    {
        List<dynamic> _valoresexpedicao = new List<dynamic>();
        List<string> _colunaexpedicao = new List<string>();
        List<dynamic> _condicoesexpedicao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaexpedicao.Count; a++)
         {
             if (col == _colunaexpedicao[a])
                  {
                       return;
                  }
     }
_colunaexpedicao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesexpedicao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idromaneio="idromaneio";
        public const string idprodutos="idprodutos";
        public const string nota="nota";
        public const string data="data";
        public const string cidade="cidade";
        public const string estado="estado";
        public const string lote="lote";
        public const string liquido="liquido";
        public const string bruto="bruto";
        public const string cliente="cliente";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresexpedicao.Add(value); }
        }

        static int Oidromaneio;
        int idromaneio;
        public int Idromaneio
        {
            get { return idromaneio; }
            set { idromaneio = value; Add("idromaneio"); _valoresexpedicao.Add(value); }
        }

        static int Oidprodutos;
        int idprodutos;
        public int Idprodutos
        {
            get { return idprodutos; }
            set { idprodutos = value; Add("idprodutos"); _valoresexpedicao.Add(value); }
        }

        static double Onota;
        double nota;
        public double Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresexpedicao.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresexpedicao.Add(value); }
        }

        static string Ocidade;
        string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; Add("cidade"); _valoresexpedicao.Add(value); }
        }

        static string Oestado;
        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; Add("estado"); _valoresexpedicao.Add(value); }
        }

        static string Olote;
        string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; Add("lote"); _valoresexpedicao.Add(value); }
        }

        static double Oliquido;
        double liquido;
        public double Liquido
        {
            get { return liquido; }
            set { liquido = value; Add("liquido"); _valoresexpedicao.Add(value); }
        }

        static double Obruto;
        double bruto;
        public double Bruto
        {
            get { return bruto; }
            set { bruto = value; Add("bruto"); _valoresexpedicao.Add(value); }
        }

        static string Ocliente;
        string cliente;
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; Add("cliente"); _valoresexpedicao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("expedicao", TipoDeOperacao.Tipo.InsertMultiplo, _colunaexpedicao,_valoresexpedicao, _condicoesexpedicao);   
        }
        public int Alterar()
        {
if (_condicoesexpedicao.Count > 0)
{
return ExecuteNonSql.Executar("expedicao", TipoDeOperacao.Tipo.Update, _colunaexpedicao,_valoresexpedicao, _condicoesexpedicao);
}
else
{
List<string> Nomeexpedicao = new List<string>();
List<dynamic> Valorexpedicao = new List<dynamic>();
_valoresexpedicao.Clear();
if(Id!=null){ Nomeexpedicao.Add("id");
 Valorexpedicao.Add(Oid);
 _valoresexpedicao.Add(Id);
}if(Idromaneio!=null){ Nomeexpedicao.Add("idromaneio");
 Valorexpedicao.Add(Oidromaneio);
 _valoresexpedicao.Add(Idromaneio);
}if(Idprodutos!=null){ Nomeexpedicao.Add("idprodutos");
 Valorexpedicao.Add(Oidprodutos);
 _valoresexpedicao.Add(Idprodutos);
}if(Nota!=null){ Nomeexpedicao.Add("nota");
 Valorexpedicao.Add(Onota);
 _valoresexpedicao.Add(Nota);
}if(Data!=null){ Nomeexpedicao.Add("data");
 Valorexpedicao.Add(Odata);
 _valoresexpedicao.Add(Data);
}if(Cidade!=null){ Nomeexpedicao.Add("cidade");
 Valorexpedicao.Add(Ocidade);
 _valoresexpedicao.Add(Cidade);
}if(Estado!=null){ Nomeexpedicao.Add("estado");
 Valorexpedicao.Add(Oestado);
 _valoresexpedicao.Add(Estado);
}if(Lote!=null){ Nomeexpedicao.Add("lote");
 Valorexpedicao.Add(Olote);
 _valoresexpedicao.Add(Lote);
}if(Liquido!=null){ Nomeexpedicao.Add("liquido");
 Valorexpedicao.Add(Oliquido);
 _valoresexpedicao.Add(Liquido);
}if(Bruto!=null){ Nomeexpedicao.Add("bruto");
 Valorexpedicao.Add(Obruto);
 _valoresexpedicao.Add(Bruto);
}if(Cliente!=null){ Nomeexpedicao.Add("cliente");
 Valorexpedicao.Add(Ocliente);
 _valoresexpedicao.Add(Cliente);
}List<dynamic> Condicaoexpedicao = new List<dynamic>();
Condicaoexpedicao.Add(Nomeexpedicao);
Condicaoexpedicao.Add(Valorexpedicao);
return ExecuteNonSql.Executar("expedicao", TipoDeOperacao.Tipo.UpdateCondicional, _colunaexpedicao, _valoresexpedicao, Condicaoexpedicao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("expedicao", TipoDeOperacao.Tipo.Delete, _colunaexpedicao,_valoresexpedicao, _condicoesexpedicao);
        }
        static public List<expedicao> Obter()
        {
            List<expedicao> lista = new List<expedicao>();
            DataTable tabela = Select.SelectSQL("select * from expedicao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao novo = new expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.Idprodutos = (int)tabela.Rows[a]["idprodutos"]; Oidprodutos = (int)tabela.Rows[a]["idprodutos"]; } catch { }
            try {   novo.Nota = (double)tabela.Rows[a]["nota"]; Onota = (double)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<expedicao> Obter(string where)
        {
            List<expedicao> lista = new List<expedicao>();
            DataTable tabela = Select.SelectSQL("select * from expedicao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao novo = new expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.Idprodutos = (int)tabela.Rows[a]["idprodutos"]; Oidprodutos = (int)tabela.Rows[a]["idprodutos"]; } catch { }
            try {   novo.Nota = (double)tabela.Rows[a]["nota"]; Onota = (double)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<expedicao> ObterComFiltroAvancado(string sql)
        {
            List<expedicao> lista = new List<expedicao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao novo = new expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.Idprodutos = (int)tabela.Rows[a]["idprodutos"]; Oidprodutos = (int)tabela.Rows[a]["idprodutos"]; } catch { }
            try {   novo.Nota = (double)tabela.Rows[a]["nota"]; Onota = (double)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from expedicao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from expedicao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from expedicao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from expedicao where " + where + "");
}


# endregion
    }
}
