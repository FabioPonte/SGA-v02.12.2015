using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class estilos
    {
        List<dynamic> _valoresestilos = new List<dynamic>();
        List<string> _colunaestilos = new List<string>();
        List<dynamic> _condicoesestilos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaestilos.Count; a++)
         {
             if (col == _colunaestilos[a])
                  {
                       return;
                  }
     }
_colunaestilos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesestilos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idconsulta="idconsulta";
        public const string idusuario="idusuario";
        public const string nome="nome";
        public const string filtrar="filtrar";
        public const string autoajustar="autoajustar";
        public const string congelar="congelar";
        public const string zebrada="zebrada";
        public const string aba="aba";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresestilos.Add(value); }
        }

        static string Oidconsulta;
        string idconsulta;
        public string Idconsulta
        {
            get { return idconsulta; }
            set { idconsulta = value; Add("idconsulta"); _valoresestilos.Add(value); }
        }

        static int Oidusuario;
        int idusuario;
        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; Add("idusuario"); _valoresestilos.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresestilos.Add(value); }
        }

        static Boolean Ofiltrar;
        Boolean filtrar;
        public Boolean Filtrar
        {
            get { return filtrar; }
            set { filtrar = value; Add("filtrar"); _valoresestilos.Add(value); }
        }

        static Boolean Oautoajustar;
        Boolean autoajustar;
        public Boolean Autoajustar
        {
            get { return autoajustar; }
            set { autoajustar = value; Add("autoajustar"); _valoresestilos.Add(value); }
        }

        static Boolean Ocongelar;
        Boolean congelar;
        public Boolean Congelar
        {
            get { return congelar; }
            set { congelar = value; Add("congelar"); _valoresestilos.Add(value); }
        }

        static Boolean Ozebrada;
        Boolean zebrada;
        public Boolean Zebrada
        {
            get { return zebrada; }
            set { zebrada = value; Add("zebrada"); _valoresestilos.Add(value); }
        }

        static string Oaba;
        string aba;
        public string Aba
        {
            get { return aba; }
            set { aba = value; Add("aba"); _valoresestilos.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresestilos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("estilos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaestilos,_valoresestilos, _condicoesestilos);   
        }
        public int Alterar()
        {
if (_condicoesestilos.Count > 0)
{
return ExecuteNonSql.Executar("estilos", TipoDeOperacao.Tipo.Update, _colunaestilos,_valoresestilos, _condicoesestilos);
}
else
{
List<string> Nomeestilos = new List<string>();
List<dynamic> Valorestilos = new List<dynamic>();
_valoresestilos.Clear();
if(Id!=null){ Nomeestilos.Add("id");
 Valorestilos.Add(Oid);
 _valoresestilos.Add(Id);
}if(Idconsulta!=null){ Nomeestilos.Add("idconsulta");
 Valorestilos.Add(Oidconsulta);
 _valoresestilos.Add(Idconsulta);
}if(Idusuario!=null){ Nomeestilos.Add("idusuario");
 Valorestilos.Add(Oidusuario);
 _valoresestilos.Add(Idusuario);
}if(Nome!=null){ Nomeestilos.Add("nome");
 Valorestilos.Add(Onome);
 _valoresestilos.Add(Nome);
}if(Filtrar!=null){ Nomeestilos.Add("filtrar");
 Valorestilos.Add(Ofiltrar);
 _valoresestilos.Add(Filtrar);
}if(Autoajustar!=null){ Nomeestilos.Add("autoajustar");
 Valorestilos.Add(Oautoajustar);
 _valoresestilos.Add(Autoajustar);
}if(Congelar!=null){ Nomeestilos.Add("congelar");
 Valorestilos.Add(Ocongelar);
 _valoresestilos.Add(Congelar);
}if(Zebrada!=null){ Nomeestilos.Add("zebrada");
 Valorestilos.Add(Ozebrada);
 _valoresestilos.Add(Zebrada);
}if(Aba!=null){ Nomeestilos.Add("aba");
 Valorestilos.Add(Oaba);
 _valoresestilos.Add(Aba);
}if(Obs!=null){ Nomeestilos.Add("obs");
 Valorestilos.Add(Oobs);
 _valoresestilos.Add(Obs);
}List<dynamic> Condicaoestilos = new List<dynamic>();
Condicaoestilos.Add(Nomeestilos);
Condicaoestilos.Add(Valorestilos);
return ExecuteNonSql.Executar("estilos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaestilos, _valoresestilos, Condicaoestilos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("estilos", TipoDeOperacao.Tipo.Delete, _colunaestilos,_valoresestilos, _condicoesestilos);
        }
        static public List<estilos> Obter()
        {
            List<estilos> lista = new List<estilos>();
            DataTable tabela = Select.SelectSQL("select * from estilos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilos novo = new estilos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idconsulta = (string)tabela.Rows[a]["idconsulta"]; Oidconsulta = (string)tabela.Rows[a]["idconsulta"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Filtrar = Convert.ToBoolean(tabela.Rows[a]["filtrar"]);  Ofiltrar= Convert.ToBoolean(tabela.Rows[a]["filtrar"]); } catch { }
            try {   novo.Autoajustar = Convert.ToBoolean(tabela.Rows[a]["autoajustar"]);  Oautoajustar= Convert.ToBoolean(tabela.Rows[a]["autoajustar"]); } catch { }
            try {   novo.Congelar = Convert.ToBoolean(tabela.Rows[a]["congelar"]);  Ocongelar= Convert.ToBoolean(tabela.Rows[a]["congelar"]); } catch { }
            try {   novo.Zebrada = Convert.ToBoolean(tabela.Rows[a]["zebrada"]);  Ozebrada= Convert.ToBoolean(tabela.Rows[a]["zebrada"]); } catch { }
            try {   novo.Aba = (string)tabela.Rows[a]["aba"]; Oaba = (string)tabela.Rows[a]["aba"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilos> Obter(string where)
        {
            List<estilos> lista = new List<estilos>();
            DataTable tabela = Select.SelectSQL("select * from estilos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilos novo = new estilos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idconsulta = (string)tabela.Rows[a]["idconsulta"]; Oidconsulta = (string)tabela.Rows[a]["idconsulta"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Filtrar = Convert.ToBoolean(tabela.Rows[a]["filtrar"]);  Ofiltrar= Convert.ToBoolean(tabela.Rows[a]["filtrar"]); } catch { }
            try {   novo.Autoajustar = Convert.ToBoolean(tabela.Rows[a]["autoajustar"]);  Oautoajustar= Convert.ToBoolean(tabela.Rows[a]["autoajustar"]); } catch { }
            try {   novo.Congelar = Convert.ToBoolean(tabela.Rows[a]["congelar"]);  Ocongelar= Convert.ToBoolean(tabela.Rows[a]["congelar"]); } catch { }
            try {   novo.Zebrada = Convert.ToBoolean(tabela.Rows[a]["zebrada"]);  Ozebrada= Convert.ToBoolean(tabela.Rows[a]["zebrada"]); } catch { }
            try {   novo.Aba = (string)tabela.Rows[a]["aba"]; Oaba = (string)tabela.Rows[a]["aba"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilos> ObterComFiltroAvancado(string sql)
        {
            List<estilos> lista = new List<estilos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilos novo = new estilos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idconsulta = (string)tabela.Rows[a]["idconsulta"]; Oidconsulta = (string)tabela.Rows[a]["idconsulta"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Filtrar = Convert.ToBoolean(tabela.Rows[a]["filtrar"]);  Ofiltrar= Convert.ToBoolean(tabela.Rows[a]["filtrar"]); } catch { }
            try {   novo.Autoajustar = Convert.ToBoolean(tabela.Rows[a]["autoajustar"]);  Oautoajustar= Convert.ToBoolean(tabela.Rows[a]["autoajustar"]); } catch { }
            try {   novo.Congelar = Convert.ToBoolean(tabela.Rows[a]["congelar"]);  Ocongelar= Convert.ToBoolean(tabela.Rows[a]["congelar"]); } catch { }
            try {   novo.Zebrada = Convert.ToBoolean(tabela.Rows[a]["zebrada"]);  Ozebrada= Convert.ToBoolean(tabela.Rows[a]["zebrada"]); } catch { }
            try {   novo.Aba = (string)tabela.Rows[a]["aba"]; Oaba = (string)tabela.Rows[a]["aba"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from estilos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from estilos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from estilos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from estilos where " + where + "");
}


# endregion
    }
}
