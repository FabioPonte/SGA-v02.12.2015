using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class entradasaida
    {
        List<dynamic> _valoresentradasaida = new List<dynamic>();
        List<string> _colunaentradasaida = new List<string>();
        List<dynamic> _condicoesentradasaida = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaentradasaida.Count; a++)
         {
             if (col == _colunaentradasaida[a])
                  {
                       return;
                  }
     }
_colunaentradasaida.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesentradasaida.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idcolaborador="idcolaborador";
        public const string idempresa="idempresa";
        public const string idsetor="idsetor";
        public const string retorno="retorno";
        public const string entrada_autorizada="entrada_autorizada";
        public const string data_entrada="data_entrada";
        public const string saida_autorizada="saida_autorizada";
        public const string data_saida="data_saida";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresentradasaida.Add(value); }
        }

        static int Oidcolaborador;
        int idcolaborador;
        public int Idcolaborador
        {
            get { return idcolaborador; }
            set { idcolaborador = value; Add("idcolaborador"); _valoresentradasaida.Add(value); }
        }

        static int Oidempresa;
        int idempresa;
        public int Idempresa
        {
            get { return idempresa; }
            set { idempresa = value; Add("idempresa"); _valoresentradasaida.Add(value); }
        }

        static int Oidsetor;
        int idsetor;
        public int Idsetor
        {
            get { return idsetor; }
            set { idsetor = value; Add("idsetor"); _valoresentradasaida.Add(value); }
        }

        static Boolean Oretorno;
        Boolean retorno;
        public Boolean Retorno
        {
            get { return retorno; }
            set { retorno = value; Add("retorno"); _valoresentradasaida.Add(value); }
        }

        static string Oentrada_autorizada;
        string entrada_autorizada;
        public string Entrada_autorizada
        {
            get { return entrada_autorizada; }
            set { entrada_autorizada = value; Add("entrada_autorizada"); _valoresentradasaida.Add(value); }
        }

        static DateTime Odata_entrada;
        DateTime data_entrada;
        public DateTime Data_entrada
        {
            get { return data_entrada; }
            set { data_entrada = value; Add("data_entrada"); _valoresentradasaida.Add(value); }
        }

        static string Osaida_autorizada;
        string saida_autorizada;
        public string Saida_autorizada
        {
            get { return saida_autorizada; }
            set { saida_autorizada = value; Add("saida_autorizada"); _valoresentradasaida.Add(value); }
        }

        static DateTime Odata_saida;
        DateTime data_saida;
        public DateTime Data_saida
        {
            get { return data_saida; }
            set { data_saida = value; Add("data_saida"); _valoresentradasaida.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("entradasaida", TipoDeOperacao.Tipo.InsertMultiplo, _colunaentradasaida,_valoresentradasaida, _condicoesentradasaida);   
        }
        public int Alterar()
        {
if (_condicoesentradasaida.Count > 0)
{
return ExecuteNonSql.Executar("entradasaida", TipoDeOperacao.Tipo.Update, _colunaentradasaida,_valoresentradasaida, _condicoesentradasaida);
}
else
{
List<string> Nomeentradasaida = new List<string>();
List<dynamic> Valorentradasaida = new List<dynamic>();
_valoresentradasaida.Clear();
if(Id!=null){ Nomeentradasaida.Add("id");
 Valorentradasaida.Add(Oid);
 _valoresentradasaida.Add(Id);
}if(Idcolaborador!=null){ Nomeentradasaida.Add("idcolaborador");
 Valorentradasaida.Add(Oidcolaborador);
 _valoresentradasaida.Add(Idcolaborador);
}if(Idempresa!=null){ Nomeentradasaida.Add("idempresa");
 Valorentradasaida.Add(Oidempresa);
 _valoresentradasaida.Add(Idempresa);
}if(Idsetor!=null){ Nomeentradasaida.Add("idsetor");
 Valorentradasaida.Add(Oidsetor);
 _valoresentradasaida.Add(Idsetor);
}if(Retorno!=null){ Nomeentradasaida.Add("retorno");
 Valorentradasaida.Add(Oretorno);
 _valoresentradasaida.Add(Retorno);
}if(Entrada_autorizada!=null){ Nomeentradasaida.Add("entrada_autorizada");
 Valorentradasaida.Add(Oentrada_autorizada);
 _valoresentradasaida.Add(Entrada_autorizada);
}if(Data_entrada!=null){ Nomeentradasaida.Add("data_entrada");
 Valorentradasaida.Add(Odata_entrada);
 _valoresentradasaida.Add(Data_entrada);
}if(Saida_autorizada!=null){ Nomeentradasaida.Add("saida_autorizada");
 Valorentradasaida.Add(Osaida_autorizada);
 _valoresentradasaida.Add(Saida_autorizada);
}if(Data_saida!=null){ Nomeentradasaida.Add("data_saida");
 Valorentradasaida.Add(Odata_saida);
 _valoresentradasaida.Add(Data_saida);
}List<dynamic> Condicaoentradasaida = new List<dynamic>();
Condicaoentradasaida.Add(Nomeentradasaida);
Condicaoentradasaida.Add(Valorentradasaida);
return ExecuteNonSql.Executar("entradasaida", TipoDeOperacao.Tipo.UpdateCondicional, _colunaentradasaida, _valoresentradasaida, Condicaoentradasaida);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("entradasaida", TipoDeOperacao.Tipo.Delete, _colunaentradasaida,_valoresentradasaida, _condicoesentradasaida);
        }
        static public List<entradasaida> Obter()
        {
            List<entradasaida> lista = new List<entradasaida>();
            DataTable tabela = Select.SelectSQL("select * from entradasaida");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entradasaida novo = new entradasaida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcolaborador = (int)tabela.Rows[a]["idcolaborador"]; Oidcolaborador = (int)tabela.Rows[a]["idcolaborador"]; } catch { }
            try {   novo.Idempresa = (int)tabela.Rows[a]["idempresa"]; Oidempresa = (int)tabela.Rows[a]["idempresa"]; } catch { }
            try {   novo.Idsetor = (int)tabela.Rows[a]["idsetor"]; Oidsetor = (int)tabela.Rows[a]["idsetor"]; } catch { }
            try {   novo.Retorno = Convert.ToBoolean(tabela.Rows[a]["retorno"]);  Oretorno= Convert.ToBoolean(tabela.Rows[a]["retorno"]); } catch { }
            try {   novo.Entrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; Oentrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Saida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; Osaida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; } catch { }
            try {   novo.Data_saida = (DateTime)tabela.Rows[a]["data_saida"]; Odata_saida = (DateTime)tabela.Rows[a]["data_saida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<entradasaida> Obter(string where)
        {
            List<entradasaida> lista = new List<entradasaida>();
            DataTable tabela = Select.SelectSQL("select * from entradasaida where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entradasaida novo = new entradasaida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcolaborador = (int)tabela.Rows[a]["idcolaborador"]; Oidcolaborador = (int)tabela.Rows[a]["idcolaborador"]; } catch { }
            try {   novo.Idempresa = (int)tabela.Rows[a]["idempresa"]; Oidempresa = (int)tabela.Rows[a]["idempresa"]; } catch { }
            try {   novo.Idsetor = (int)tabela.Rows[a]["idsetor"]; Oidsetor = (int)tabela.Rows[a]["idsetor"]; } catch { }
            try {   novo.Retorno = Convert.ToBoolean(tabela.Rows[a]["retorno"]);  Oretorno= Convert.ToBoolean(tabela.Rows[a]["retorno"]); } catch { }
            try {   novo.Entrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; Oentrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Saida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; Osaida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; } catch { }
            try {   novo.Data_saida = (DateTime)tabela.Rows[a]["data_saida"]; Odata_saida = (DateTime)tabela.Rows[a]["data_saida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<entradasaida> ObterComFiltroAvancado(string sql)
        {
            List<entradasaida> lista = new List<entradasaida>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                entradasaida novo = new entradasaida();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcolaborador = (int)tabela.Rows[a]["idcolaborador"]; Oidcolaborador = (int)tabela.Rows[a]["idcolaborador"]; } catch { }
            try {   novo.Idempresa = (int)tabela.Rows[a]["idempresa"]; Oidempresa = (int)tabela.Rows[a]["idempresa"]; } catch { }
            try {   novo.Idsetor = (int)tabela.Rows[a]["idsetor"]; Oidsetor = (int)tabela.Rows[a]["idsetor"]; } catch { }
            try {   novo.Retorno = Convert.ToBoolean(tabela.Rows[a]["retorno"]);  Oretorno= Convert.ToBoolean(tabela.Rows[a]["retorno"]); } catch { }
            try {   novo.Entrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; Oentrada_autorizada = (string)tabela.Rows[a]["entrada_autorizada"]; } catch { }
            try {   novo.Data_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; Odata_entrada = (DateTime)tabela.Rows[a]["data_entrada"]; } catch { }
            try {   novo.Saida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; Osaida_autorizada = (string)tabela.Rows[a]["saida_autorizada"]; } catch { }
            try {   novo.Data_saida = (DateTime)tabela.Rows[a]["data_saida"]; Odata_saida = (DateTime)tabela.Rows[a]["data_saida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from entradasaida").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from entradasaida where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from entradasaida ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from entradasaida where " + where + "");
}


# endregion
    }
}
