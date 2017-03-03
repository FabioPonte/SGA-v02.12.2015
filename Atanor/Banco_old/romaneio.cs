using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class romaneio
    {
        List<dynamic> _valoresromaneio = new List<dynamic>();
        List<string> _colunaromaneio = new List<string>();
        List<dynamic> _condicoesromaneio = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaromaneio.Count; a++)
         {
             if (col == _colunaromaneio[a])
                  {
                       return;
                  }
     }
_colunaromaneio.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesromaneio.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idmotorista="idmotorista";
        public const string idtransportadoras="idtransportadoras";
        public const string idcaminhao="idcaminhao";
        public const string idcd="idcd";
        public const string data="data";
        public const string obs="obs";
        public const string liquido="liquido";
        public const string bruto="bruto";
        public const string criador="criador";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresromaneio.Add(value); }
        }

        static int Oidmotorista;
        int idmotorista;
        public int Idmotorista
        {
            get { return idmotorista; }
            set { idmotorista = value; Add("idmotorista"); _valoresromaneio.Add(value); }
        }

        static int Oidtransportadoras;
        int idtransportadoras;
        public int Idtransportadoras
        {
            get { return idtransportadoras; }
            set { idtransportadoras = value; Add("idtransportadoras"); _valoresromaneio.Add(value); }
        }

        static int Oidcaminhao;
        int idcaminhao;
        public int Idcaminhao
        {
            get { return idcaminhao; }
            set { idcaminhao = value; Add("idcaminhao"); _valoresromaneio.Add(value); }
        }

        static int Oidcd;
        int idcd;
        public int Idcd
        {
            get { return idcd; }
            set { idcd = value; Add("idcd"); _valoresromaneio.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresromaneio.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresromaneio.Add(value); }
        }

        static double Oliquido;
        double liquido;
        public double Liquido
        {
            get { return liquido; }
            set { liquido = value; Add("liquido"); _valoresromaneio.Add(value); }
        }

        static double Obruto;
        double bruto;
        public double Bruto
        {
            get { return bruto; }
            set { bruto = value; Add("bruto"); _valoresromaneio.Add(value); }
        }

        static string Ocriador;
        string criador;
        public string Criador
        {
            get { return criador; }
            set { criador = value; Add("criador"); _valoresromaneio.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("romaneio", TipoDeOperacao.Tipo.InsertMultiplo, _colunaromaneio,_valoresromaneio, _condicoesromaneio);   
        }
        public int Alterar()
        {
if (_condicoesromaneio.Count > 0)
{
return ExecuteNonSql.Executar("romaneio", TipoDeOperacao.Tipo.Update, _colunaromaneio,_valoresromaneio, _condicoesromaneio);
}
else
{
List<string> Nomeromaneio = new List<string>();
List<dynamic> Valorromaneio = new List<dynamic>();
_valoresromaneio.Clear();
if(Id!=null){ Nomeromaneio.Add("id");
 Valorromaneio.Add(Oid);
 _valoresromaneio.Add(Id);
}if(Idmotorista!=null){ Nomeromaneio.Add("idmotorista");
 Valorromaneio.Add(Oidmotorista);
 _valoresromaneio.Add(Idmotorista);
}if(Idtransportadoras!=null){ Nomeromaneio.Add("idtransportadoras");
 Valorromaneio.Add(Oidtransportadoras);
 _valoresromaneio.Add(Idtransportadoras);
}if(Idcaminhao!=null){ Nomeromaneio.Add("idcaminhao");
 Valorromaneio.Add(Oidcaminhao);
 _valoresromaneio.Add(Idcaminhao);
}if(Idcd!=null){ Nomeromaneio.Add("idcd");
 Valorromaneio.Add(Oidcd);
 _valoresromaneio.Add(Idcd);
}if(Data!=null){ Nomeromaneio.Add("data");
 Valorromaneio.Add(Odata);
 _valoresromaneio.Add(Data);
}if(Obs!=null){ Nomeromaneio.Add("obs");
 Valorromaneio.Add(Oobs);
 _valoresromaneio.Add(Obs);
}if(Liquido!=null){ Nomeromaneio.Add("liquido");
 Valorromaneio.Add(Oliquido);
 _valoresromaneio.Add(Liquido);
}if(Bruto!=null){ Nomeromaneio.Add("bruto");
 Valorromaneio.Add(Obruto);
 _valoresromaneio.Add(Bruto);
}if(Criador!=null){ Nomeromaneio.Add("criador");
 Valorromaneio.Add(Ocriador);
 _valoresromaneio.Add(Criador);
}List<dynamic> Condicaoromaneio = new List<dynamic>();
Condicaoromaneio.Add(Nomeromaneio);
Condicaoromaneio.Add(Valorromaneio);
return ExecuteNonSql.Executar("romaneio", TipoDeOperacao.Tipo.UpdateCondicional, _colunaromaneio, _valoresromaneio, Condicaoromaneio);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("romaneio", TipoDeOperacao.Tipo.Delete, _colunaromaneio,_valoresromaneio, _condicoesromaneio);
        }
        static public List<romaneio> Obter()
        {
            List<romaneio> lista = new List<romaneio>();
            DataTable tabela = Select.SelectSQL("select * from romaneio");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                romaneio novo = new romaneio();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcaminhao = (int)tabela.Rows[a]["idcaminhao"]; Oidcaminhao = (int)tabela.Rows[a]["idcaminhao"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<romaneio> Obter(string where)
        {
            List<romaneio> lista = new List<romaneio>();
            DataTable tabela = Select.SelectSQL("select * from romaneio where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                romaneio novo = new romaneio();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcaminhao = (int)tabela.Rows[a]["idcaminhao"]; Oidcaminhao = (int)tabela.Rows[a]["idcaminhao"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<romaneio> ObterComFiltroAvancado(string sql)
        {
            List<romaneio> lista = new List<romaneio>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                romaneio novo = new romaneio();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Idtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; Oidtransportadoras = (int)tabela.Rows[a]["idtransportadoras"]; } catch { }
            try {   novo.Idcaminhao = (int)tabela.Rows[a]["idcaminhao"]; Oidcaminhao = (int)tabela.Rows[a]["idcaminhao"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Liquido = (double)tabela.Rows[a]["liquido"]; Oliquido = (double)tabela.Rows[a]["liquido"]; } catch { }
            try {   novo.Bruto = (double)tabela.Rows[a]["bruto"]; Obruto = (double)tabela.Rows[a]["bruto"]; } catch { }
            try {   novo.Criador = (string)tabela.Rows[a]["criador"]; Ocriador = (string)tabela.Rows[a]["criador"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from romaneio").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from romaneio where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from romaneio ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from romaneio where " + where + "");
}


# endregion
    }
}
