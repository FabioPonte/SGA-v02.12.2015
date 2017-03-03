using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class alarme
    {
        List<dynamic> _valoresalarme = new List<dynamic>();
        List<string> _colunaalarme = new List<string>();
        List<dynamic> _condicoesalarme = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaalarme.Count; a++)
         {
             if (col == _colunaalarme[a])
                  {
                       return;
                  }
     }
_colunaalarme.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesalarme.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string titulo="titulo";
        public const string msg="msg";
        public const string dia="dia";
        public const string mes="mes";
        public const string ano="ano";
        public const string hora="hora";
        public const string minuto="minuto";
        public const string unico="unico";
        public const string diario="diario";
        public const string semanal="semanal";
        public const string mensal="mensal";
        public const string ativo="ativo";
        public const string idusuario="idusuario";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresalarme.Add(value); }
        }

        static string Otitulo;
        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; Add("titulo"); _valoresalarme.Add(value); }
        }

        static string Omsg;
        string msg;
        public string Msg
        {
            get { return msg; }
            set { msg = value; Add("msg"); _valoresalarme.Add(value); }
        }

        static int Odia;
        int dia;
        public int Dia
        {
            get { return dia; }
            set { dia = value; Add("dia"); _valoresalarme.Add(value); }
        }

        static int Omes;
        int mes;
        public int Mes
        {
            get { return mes; }
            set { mes = value; Add("mes"); _valoresalarme.Add(value); }
        }

        static int Oano;
        int ano;
        public int Ano
        {
            get { return ano; }
            set { ano = value; Add("ano"); _valoresalarme.Add(value); }
        }

        static int Ohora;
        int hora;
        public int Hora
        {
            get { return hora; }
            set { hora = value; Add("hora"); _valoresalarme.Add(value); }
        }

        static int Ominuto;
        int minuto;
        public int Minuto
        {
            get { return minuto; }
            set { minuto = value; Add("minuto"); _valoresalarme.Add(value); }
        }

        static int Ounico;
        int unico;
        public int Unico
        {
            get { return unico; }
            set { unico = value; Add("unico"); _valoresalarme.Add(value); }
        }

        static int Odiario;
        int diario;
        public int Diario
        {
            get { return diario; }
            set { diario = value; Add("diario"); _valoresalarme.Add(value); }
        }

        static int Osemanal;
        int semanal;
        public int Semanal
        {
            get { return semanal; }
            set { semanal = value; Add("semanal"); _valoresalarme.Add(value); }
        }

        static int Omensal;
        int mensal;
        public int Mensal
        {
            get { return mensal; }
            set { mensal = value; Add("mensal"); _valoresalarme.Add(value); }
        }

        static int Oativo;
        int ativo;
        public int Ativo
        {
            get { return ativo; }
            set { ativo = value; Add("ativo"); _valoresalarme.Add(value); }
        }

        static int Oidusuario;
        int idusuario;
        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; Add("idusuario"); _valoresalarme.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.InsertMultiplo, _colunaalarme,_valoresalarme, _condicoesalarme);   
        }
        public int Alterar()
        {
if (_condicoesalarme.Count > 0)
{
return ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Update, _colunaalarme,_valoresalarme, _condicoesalarme);
}
else
{
List<string> Nomealarme = new List<string>();
List<dynamic> Valoralarme = new List<dynamic>();
_valoresalarme.Clear();
if(Id!=null){ Nomealarme.Add("id");
 Valoralarme.Add(Oid);
 _valoresalarme.Add(Id);
}if(Titulo!=null){ Nomealarme.Add("titulo");
 Valoralarme.Add(Otitulo);
 _valoresalarme.Add(Titulo);
}if(Msg!=null){ Nomealarme.Add("msg");
 Valoralarme.Add(Omsg);
 _valoresalarme.Add(Msg);
}if(Dia!=null){ Nomealarme.Add("dia");
 Valoralarme.Add(Odia);
 _valoresalarme.Add(Dia);
}if(Mes!=null){ Nomealarme.Add("mes");
 Valoralarme.Add(Omes);
 _valoresalarme.Add(Mes);
}if(Ano!=null){ Nomealarme.Add("ano");
 Valoralarme.Add(Oano);
 _valoresalarme.Add(Ano);
}if(Hora!=null){ Nomealarme.Add("hora");
 Valoralarme.Add(Ohora);
 _valoresalarme.Add(Hora);
}if(Minuto!=null){ Nomealarme.Add("minuto");
 Valoralarme.Add(Ominuto);
 _valoresalarme.Add(Minuto);
}if(Unico!=null){ Nomealarme.Add("unico");
 Valoralarme.Add(Ounico);
 _valoresalarme.Add(Unico);
}if(Diario!=null){ Nomealarme.Add("diario");
 Valoralarme.Add(Odiario);
 _valoresalarme.Add(Diario);
}if(Semanal!=null){ Nomealarme.Add("semanal");
 Valoralarme.Add(Osemanal);
 _valoresalarme.Add(Semanal);
}if(Mensal!=null){ Nomealarme.Add("mensal");
 Valoralarme.Add(Omensal);
 _valoresalarme.Add(Mensal);
}if(Ativo!=null){ Nomealarme.Add("ativo");
 Valoralarme.Add(Oativo);
 _valoresalarme.Add(Ativo);
}if(Idusuario!=null){ Nomealarme.Add("idusuario");
 Valoralarme.Add(Oidusuario);
 _valoresalarme.Add(Idusuario);
}List<dynamic> Condicaoalarme = new List<dynamic>();
Condicaoalarme.Add(Nomealarme);
Condicaoalarme.Add(Valoralarme);
return ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.UpdateCondicional, _colunaalarme, _valoresalarme, Condicaoalarme);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Delete, _colunaalarme,_valoresalarme, _condicoesalarme);
        }
        static public List<alarme> Obter()
        {
            List<alarme> lista = new List<alarme>();
            DataTable tabela = Select.SelectSQL("select * from alarme");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                alarme novo = new alarme();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Msg = (string)tabela.Rows[a]["msg"]; Omsg = (string)tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Dia = (int)tabela.Rows[a]["dia"]; Odia = (int)tabela.Rows[a]["dia"]; } catch { }
            try {   novo.Mes = (int)tabela.Rows[a]["mes"]; Omes = (int)tabela.Rows[a]["mes"]; } catch { }
            try {   novo.Ano = (int)tabela.Rows[a]["ano"]; Oano = (int)tabela.Rows[a]["ano"]; } catch { }
            try {   novo.Hora = (int)tabela.Rows[a]["hora"]; Ohora = (int)tabela.Rows[a]["hora"]; } catch { }
            try {   novo.Minuto = (int)tabela.Rows[a]["minuto"]; Ominuto = (int)tabela.Rows[a]["minuto"]; } catch { }
            try {   novo.Unico = (int)tabela.Rows[a]["unico"]; Ounico = (int)tabela.Rows[a]["unico"]; } catch { }
            try {   novo.Diario = (int)tabela.Rows[a]["diario"]; Odiario = (int)tabela.Rows[a]["diario"]; } catch { }
            try {   novo.Semanal = (int)tabela.Rows[a]["semanal"]; Osemanal = (int)tabela.Rows[a]["semanal"]; } catch { }
            try {   novo.Mensal = (int)tabela.Rows[a]["mensal"]; Omensal = (int)tabela.Rows[a]["mensal"]; } catch { }
            try {   novo.Ativo = (int)tabela.Rows[a]["ativo"]; Oativo = (int)tabela.Rows[a]["ativo"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<alarme> Obter(string where)
        {
            List<alarme> lista = new List<alarme>();
            DataTable tabela = Select.SelectSQL("select * from alarme where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                alarme novo = new alarme();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Msg = (string)tabela.Rows[a]["msg"]; Omsg = (string)tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Dia = (int)tabela.Rows[a]["dia"]; Odia = (int)tabela.Rows[a]["dia"]; } catch { }
            try {   novo.Mes = (int)tabela.Rows[a]["mes"]; Omes = (int)tabela.Rows[a]["mes"]; } catch { }
            try {   novo.Ano = (int)tabela.Rows[a]["ano"]; Oano = (int)tabela.Rows[a]["ano"]; } catch { }
            try {   novo.Hora = (int)tabela.Rows[a]["hora"]; Ohora = (int)tabela.Rows[a]["hora"]; } catch { }
            try {   novo.Minuto = (int)tabela.Rows[a]["minuto"]; Ominuto = (int)tabela.Rows[a]["minuto"]; } catch { }
            try {   novo.Unico = (int)tabela.Rows[a]["unico"]; Ounico = (int)tabela.Rows[a]["unico"]; } catch { }
            try {   novo.Diario = (int)tabela.Rows[a]["diario"]; Odiario = (int)tabela.Rows[a]["diario"]; } catch { }
            try {   novo.Semanal = (int)tabela.Rows[a]["semanal"]; Osemanal = (int)tabela.Rows[a]["semanal"]; } catch { }
            try {   novo.Mensal = (int)tabela.Rows[a]["mensal"]; Omensal = (int)tabela.Rows[a]["mensal"]; } catch { }
            try {   novo.Ativo = (int)tabela.Rows[a]["ativo"]; Oativo = (int)tabela.Rows[a]["ativo"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<alarme> ObterComFiltroAvancado(string sql)
        {
            List<alarme> lista = new List<alarme>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                alarme novo = new alarme();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Titulo = (string)tabela.Rows[a]["titulo"]; Otitulo = (string)tabela.Rows[a]["titulo"]; } catch { }
            try {   novo.Msg = (string)tabela.Rows[a]["msg"]; Omsg = (string)tabela.Rows[a]["msg"]; } catch { }
            try {   novo.Dia = (int)tabela.Rows[a]["dia"]; Odia = (int)tabela.Rows[a]["dia"]; } catch { }
            try {   novo.Mes = (int)tabela.Rows[a]["mes"]; Omes = (int)tabela.Rows[a]["mes"]; } catch { }
            try {   novo.Ano = (int)tabela.Rows[a]["ano"]; Oano = (int)tabela.Rows[a]["ano"]; } catch { }
            try {   novo.Hora = (int)tabela.Rows[a]["hora"]; Ohora = (int)tabela.Rows[a]["hora"]; } catch { }
            try {   novo.Minuto = (int)tabela.Rows[a]["minuto"]; Ominuto = (int)tabela.Rows[a]["minuto"]; } catch { }
            try {   novo.Unico = (int)tabela.Rows[a]["unico"]; Ounico = (int)tabela.Rows[a]["unico"]; } catch { }
            try {   novo.Diario = (int)tabela.Rows[a]["diario"]; Odiario = (int)tabela.Rows[a]["diario"]; } catch { }
            try {   novo.Semanal = (int)tabela.Rows[a]["semanal"]; Osemanal = (int)tabela.Rows[a]["semanal"]; } catch { }
            try {   novo.Mensal = (int)tabela.Rows[a]["mensal"]; Omensal = (int)tabela.Rows[a]["mensal"]; } catch { }
            try {   novo.Ativo = (int)tabela.Rows[a]["ativo"]; Oativo = (int)tabela.Rows[a]["ativo"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from alarme").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from alarme where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from alarme ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from alarme where " + where + "");
}


# endregion
    }
}
