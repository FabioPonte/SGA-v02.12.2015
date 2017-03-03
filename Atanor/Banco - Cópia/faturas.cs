using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class faturas
    {
        List<dynamic> _valoresfaturas = new List<dynamic>();
        List<string> _colunafaturas = new List<string>();
        List<dynamic> _condicoesfaturas = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunafaturas.Count; a++)
         {
             if (col == _colunafaturas[a])
                  {
                       return;
                  }
     }
_colunafaturas.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesfaturas.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idtransportadoras="idtransportadoras";
        public const string idcentrodistribuicao="idcentrodistribuicao";
        public const string fatura="fatura";
        public const string vlr_bruto="vlr_bruto";
        public const string vlr_liquido="vlr_liquido";
        public const string data_vencimento="data_vencimento";
        public const string data_emissao="data_emissao";
        public const string data_inclusao="data_inclusao";
        public const string nomesacado="nomesacado";
        public const string endereco="endereco";
        public const string municipio="municipio";
        public const string bairro="bairro";
        public const string estado="estado";
        public const string cep="cep";
        public const string inscest="inscest";
        public const string cnpjmf="cnpjmf";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresfaturas.Add(value); }
        }

        static int Oidtransportadoras;
        int idtransportadoras;
        public int Idtransportadoras
        {
            get { return idtransportadoras; }
            set { idtransportadoras = value; Add("idtransportadoras"); _valoresfaturas.Add(value); }
        }

        static int Oidcentrodistribuicao;
        int idcentrodistribuicao;
        public int Idcentrodistribuicao
        {
            get { return idcentrodistribuicao; }
            set { idcentrodistribuicao = value; Add("idcentrodistribuicao"); _valoresfaturas.Add(value); }
        }

        static string Ofatura;
        string fatura;
        public string Fatura
        {
            get { return fatura; }
            set { fatura = value; Add("fatura"); _valoresfaturas.Add(value); }
        }

        static double Ovlr_bruto;
        double vlr_bruto;
        public double Vlr_bruto
        {
            get { return vlr_bruto; }
            set { vlr_bruto = value; Add("vlr_bruto"); _valoresfaturas.Add(value); }
        }

        static double Ovlr_liquido;
        double vlr_liquido;
        public double Vlr_liquido
        {
            get { return vlr_liquido; }
            set { vlr_liquido = value; Add("vlr_liquido"); _valoresfaturas.Add(value); }
        }

        static DateTime Odata_vencimento;
        DateTime data_vencimento;
        public DateTime Data_vencimento
        {
            get { return data_vencimento; }
            set { data_vencimento = value; Add("data_vencimento"); _valoresfaturas.Add(value); }
        }

        static DateTime Odata_emissao;
        DateTime data_emissao;
        public DateTime Data_emissao
        {
            get { return data_emissao; }
            set { data_emissao = value; Add("data_emissao"); _valoresfaturas.Add(value); }
        }

        static DateTime Odata_inclusao;
        DateTime data_inclusao;
        public DateTime Data_inclusao
        {
            get { return data_inclusao; }
            set { data_inclusao = value; Add("data_inclusao"); _valoresfaturas.Add(value); }
        }

        static string Onomesacado;
        string nomesacado;
        public string Nomesacado
        {
            get { return nomesacado; }
            set { nomesacado = value; Add("nomesacado"); _valoresfaturas.Add(value); }
        }

        static string Oendereco;
        string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; Add("endereco"); _valoresfaturas.Add(value); }
        }

        static string Omunicipio;
        string municipio;
        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; Add("municipio"); _valoresfaturas.Add(value); }
        }

        static string Obairro;
        string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; Add("bairro"); _valoresfaturas.Add(value); }
        }

        static string Oestado;
        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; Add("estado"); _valoresfaturas.Add(value); }
        }

        static string Ocep;
        string cep;
        public string Cep
        {
            get { return cep; }
            set { cep = value; Add("cep"); _valoresfaturas.Add(value); }
        }

        static string Oinscest;
        string inscest;
        public string Inscest
        {
            get { return inscest; }
            set { inscest = value; Add("inscest"); _valoresfaturas.Add(value); }
        }

        static string Ocnpjmf;
        string cnpjmf;
        public string Cnpjmf
        {
            get { return cnpjmf; }
            set { cnpjmf = value; Add("cnpjmf"); _valoresfaturas.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresfaturas.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("faturas", TipoDeOperacao.Tipo.InsertMultiplo, _colunafaturas,_valoresfaturas, _condicoesfaturas);   
        }
        public int Alterar()
        {
if (_condicoesfaturas.Count > 0)
{
return ExecuteNonSql.Executar("faturas", TipoDeOperacao.Tipo.Update, _colunafaturas,_valoresfaturas, _condicoesfaturas);
}
else
{
List<string> Nomefaturas = new List<string>();
List<dynamic> Valorfaturas = new List<dynamic>();
_valoresfaturas.Clear();
if(Id!=null){ Nomefaturas.Add("id");
 Valorfaturas.Add(Oid);
 _valoresfaturas.Add(Id);
}if(Idtransportadoras!=null){ Nomefaturas.Add("idtransportadoras");
 Valorfaturas.Add(Oidtransportadoras);
 _valoresfaturas.Add(Idtransportadoras);
}if(Idcentrodistribuicao!=null){ Nomefaturas.Add("idcentrodistribuicao");
 Valorfaturas.Add(Oidcentrodistribuicao);
 _valoresfaturas.Add(Idcentrodistribuicao);
}if(Fatura!=null){ Nomefaturas.Add("fatura");
 Valorfaturas.Add(Ofatura);
 _valoresfaturas.Add(Fatura);
}if(Vlr_bruto!=null){ Nomefaturas.Add("vlr_bruto");
 Valorfaturas.Add(Ovlr_bruto);
 _valoresfaturas.Add(Vlr_bruto);
}if(Vlr_liquido!=null){ Nomefaturas.Add("vlr_liquido");
 Valorfaturas.Add(Ovlr_liquido);
 _valoresfaturas.Add(Vlr_liquido);
}if(Data_vencimento!=null){ Nomefaturas.Add("data_vencimento");
 Valorfaturas.Add(Odata_vencimento);
 _valoresfaturas.Add(Data_vencimento);
}if(Data_emissao!=null){ Nomefaturas.Add("data_emissao");
 Valorfaturas.Add(Odata_emissao);
 _valoresfaturas.Add(Data_emissao);
}if(Data_inclusao!=null){ Nomefaturas.Add("data_inclusao");
 Valorfaturas.Add(Odata_inclusao);
 _valoresfaturas.Add(Data_inclusao);
}if(Nomesacado!=null){ Nomefaturas.Add("nomesacado");
 Valorfaturas.Add(Onomesacado);
 _valoresfaturas.Add(Nomesacado);
}if(Endereco!=null){ Nomefaturas.Add("endereco");
 Valorfaturas.Add(Oendereco);
 _valoresfaturas.Add(Endereco);
}if(Municipio!=null){ Nomefaturas.Add("municipio");
 Valorfaturas.Add(Omunicipio);
 _valoresfaturas.Add(Municipio);
}if(Bairro!=null){ Nomefaturas.Add("bairro");
 Valorfaturas.Add(Obairro);
 _valoresfaturas.Add(Bairro);
}if(Estado!=null){ Nomefaturas.Add("estado");
 Valorfaturas.Add(Oestado);
 _valoresfaturas.Add(Estado);
}if(Cep!=null){ Nomefaturas.Add("cep");
 Valorfaturas.Add(Ocep);
 _valoresfaturas.Add(Cep);
}if(Inscest!=null){ Nomefaturas.Add("inscest");
 Valorfaturas.Add(Oinscest);
 _valoresfaturas.Add(Inscest);
}if(Cnpjmf!=null){ Nomefaturas.Add("cnpjmf");
 Valorfaturas.Add(Ocnpjmf);
 _valoresfaturas.Add(Cnpjmf);
}if(Obs!=null){ Nomefaturas.Add("obs");
 Valorfaturas.Add(Oobs);
 _valoresfaturas.Add(Obs);
}List<dynamic> Condicaofaturas = new List<dynamic>();
Condicaofaturas.Add(Nomefaturas);
Condicaofaturas.Add(Valorfaturas);
return ExecuteNonSql.Executar("faturas", TipoDeOperacao.Tipo.UpdateCondicional, _colunafaturas, _valoresfaturas, Condicaofaturas);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("faturas", TipoDeOperacao.Tipo.Delete, _colunafaturas,_valoresfaturas, _condicoesfaturas);
        }
        static public List<faturas> Obter()
        {
            List<faturas> lista = new List<faturas>();
            DataTable tabela = Select.SelectSQL("select * from faturas");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                faturas novo = new faturas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Fatura = (string)tabela.Rows[a]["fatura"]; Ofatura = (string)tabela.Rows[a]["fatura"]; } catch { }
            try {   novo.Vlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; Ovlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; } catch { }
            try {   novo.Vlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; Ovlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; } catch { }
            try {   novo.Data_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; Odata_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; } catch { }
            try {   novo.Data_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; Odata_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; } catch { }
            try {   novo.Data_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; Odata_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; } catch { }
            try {   novo.Nomesacado = (string)tabela.Rows[a]["nomesacado"]; Onomesacado = (string)tabela.Rows[a]["nomesacado"]; } catch { }
            try {   novo.Endereco = (string)tabela.Rows[a]["endereco"]; Oendereco = (string)tabela.Rows[a]["endereco"]; } catch { }
            try {   novo.Municipio = (string)tabela.Rows[a]["municipio"]; Omunicipio = (string)tabela.Rows[a]["municipio"]; } catch { }
            try {   novo.Bairro = (string)tabela.Rows[a]["bairro"]; Obairro = (string)tabela.Rows[a]["bairro"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Cep = (string)tabela.Rows[a]["cep"]; Ocep = (string)tabela.Rows[a]["cep"]; } catch { }
            try {   novo.Inscest = (string)tabela.Rows[a]["inscest"]; Oinscest = (string)tabela.Rows[a]["inscest"]; } catch { }
            try {   novo.Cnpjmf = (string)tabela.Rows[a]["cnpjmf"]; Ocnpjmf = (string)tabela.Rows[a]["cnpjmf"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<faturas> Obter(string where)
        {
            List<faturas> lista = new List<faturas>();
            DataTable tabela = Select.SelectSQL("select * from faturas where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                faturas novo = new faturas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Fatura = (string)tabela.Rows[a]["fatura"]; Ofatura = (string)tabela.Rows[a]["fatura"]; } catch { }
            try {   novo.Vlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; Ovlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; } catch { }
            try {   novo.Vlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; Ovlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; } catch { }
            try {   novo.Data_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; Odata_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; } catch { }
            try {   novo.Data_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; Odata_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; } catch { }
            try {   novo.Data_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; Odata_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; } catch { }
            try {   novo.Nomesacado = (string)tabela.Rows[a]["nomesacado"]; Onomesacado = (string)tabela.Rows[a]["nomesacado"]; } catch { }
            try {   novo.Endereco = (string)tabela.Rows[a]["endereco"]; Oendereco = (string)tabela.Rows[a]["endereco"]; } catch { }
            try {   novo.Municipio = (string)tabela.Rows[a]["municipio"]; Omunicipio = (string)tabela.Rows[a]["municipio"]; } catch { }
            try {   novo.Bairro = (string)tabela.Rows[a]["bairro"]; Obairro = (string)tabela.Rows[a]["bairro"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Cep = (string)tabela.Rows[a]["cep"]; Ocep = (string)tabela.Rows[a]["cep"]; } catch { }
            try {   novo.Inscest = (string)tabela.Rows[a]["inscest"]; Oinscest = (string)tabela.Rows[a]["inscest"]; } catch { }
            try {   novo.Cnpjmf = (string)tabela.Rows[a]["cnpjmf"]; Ocnpjmf = (string)tabela.Rows[a]["cnpjmf"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<faturas> ObterComFiltroAvancado(string sql)
        {
            List<faturas> lista = new List<faturas>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                faturas novo = new faturas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; Oidcentrodistribuicao = (int)tabela.Rows[a]["idcentrodistribuicao"]; } catch { }
            try {   novo.Fatura = (string)tabela.Rows[a]["fatura"]; Ofatura = (string)tabela.Rows[a]["fatura"]; } catch { }
            try {   novo.Vlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; Ovlr_bruto = (double)tabela.Rows[a]["vlr_bruto"]; } catch { }
            try {   novo.Vlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; Ovlr_liquido = (double)tabela.Rows[a]["vlr_liquido"]; } catch { }
            try {   novo.Data_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; Odata_vencimento = (DateTime)tabela.Rows[a]["data_vencimento"]; } catch { }
            try {   novo.Data_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; Odata_emissao = (DateTime)tabela.Rows[a]["data_emissao"]; } catch { }
            try {   novo.Data_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; Odata_inclusao = (DateTime)tabela.Rows[a]["data_inclusao"]; } catch { }
            try {   novo.Nomesacado = (string)tabela.Rows[a]["nomesacado"]; Onomesacado = (string)tabela.Rows[a]["nomesacado"]; } catch { }
            try {   novo.Endereco = (string)tabela.Rows[a]["endereco"]; Oendereco = (string)tabela.Rows[a]["endereco"]; } catch { }
            try {   novo.Municipio = (string)tabela.Rows[a]["municipio"]; Omunicipio = (string)tabela.Rows[a]["municipio"]; } catch { }
            try {   novo.Bairro = (string)tabela.Rows[a]["bairro"]; Obairro = (string)tabela.Rows[a]["bairro"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Cep = (string)tabela.Rows[a]["cep"]; Ocep = (string)tabela.Rows[a]["cep"]; } catch { }
            try {   novo.Inscest = (string)tabela.Rows[a]["inscest"]; Oinscest = (string)tabela.Rows[a]["inscest"]; } catch { }
            try {   novo.Cnpjmf = (string)tabela.Rows[a]["cnpjmf"]; Ocnpjmf = (string)tabela.Rows[a]["cnpjmf"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from faturas").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from faturas where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from faturas ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from faturas where " + where + "");
}


# endregion
    }
}
