using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class estilosbase
    {
        List<dynamic> _valoresestilosbase = new List<dynamic>();
        List<string> _colunaestilosbase = new List<string>();
        List<dynamic> _condicoesestilosbase = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaestilosbase.Count; a++)
         {
             if (col == _colunaestilosbase[a])
                  {
                       return;
                  }
     }
_colunaestilosbase.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesestilosbase.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string idestilos="idestilos";
        public const string idestilostipos="idestilostipos";
        public const string removercolunas="removercolunas";
        public const string reorganizarcolunas="reorganizarcolunas";
        public const string todasascolunas="todasascolunas";
        public const string colunasespecificas="colunasespecificas";
        public const string colunasespecificasl="colunasespecificasl";
        public const string celulaindividuais="celulaindividuais";
        public const string linhasimpares="linhasimpares";
        public const string linhaspares="linhaspares";
        public const string linhascondicionais="linhascondicionais";
        public const string sobreportitulos="sobreportitulos";

         }
# endregion
#region Colunas


        static int Oidestilos;
        int idestilos;
        public int Idestilos
        {
            get { return idestilos; }
            set { idestilos = value; Add("idestilos"); _valoresestilosbase.Add(value); }
        }

        static int Oidestilostipos;
        int idestilostipos;
        public int Idestilostipos
        {
            get { return idestilostipos; }
            set { idestilostipos = value; Add("idestilostipos"); _valoresestilosbase.Add(value); }
        }

        static Boolean Oremovercolunas;
        Boolean removercolunas;
        public Boolean Removercolunas
        {
            get { return removercolunas; }
            set { removercolunas = value; Add("removercolunas"); _valoresestilosbase.Add(value); }
        }

        static Boolean Oreorganizarcolunas;
        Boolean reorganizarcolunas;
        public Boolean Reorganizarcolunas
        {
            get { return reorganizarcolunas; }
            set { reorganizarcolunas = value; Add("reorganizarcolunas"); _valoresestilosbase.Add(value); }
        }

        static Boolean Otodasascolunas;
        Boolean todasascolunas;
        public Boolean Todasascolunas
        {
            get { return todasascolunas; }
            set { todasascolunas = value; Add("todasascolunas"); _valoresestilosbase.Add(value); }
        }

        static Boolean Ocolunasespecificas;
        Boolean colunasespecificas;
        public Boolean Colunasespecificas
        {
            get { return colunasespecificas; }
            set { colunasespecificas = value; Add("colunasespecificas"); _valoresestilosbase.Add(value); }
        }

        static Boolean Ocolunasespecificasl;
        Boolean colunasespecificasl;
        public Boolean Colunasespecificasl
        {
            get { return colunasespecificasl; }
            set { colunasespecificasl = value; Add("colunasespecificasl"); _valoresestilosbase.Add(value); }
        }

        static Boolean Ocelulaindividuais;
        Boolean celulaindividuais;
        public Boolean Celulaindividuais
        {
            get { return celulaindividuais; }
            set { celulaindividuais = value; Add("celulaindividuais"); _valoresestilosbase.Add(value); }
        }

        static Boolean Olinhasimpares;
        Boolean linhasimpares;
        public Boolean Linhasimpares
        {
            get { return linhasimpares; }
            set { linhasimpares = value; Add("linhasimpares"); _valoresestilosbase.Add(value); }
        }

        static Boolean Olinhaspares;
        Boolean linhaspares;
        public Boolean Linhaspares
        {
            get { return linhaspares; }
            set { linhaspares = value; Add("linhaspares"); _valoresestilosbase.Add(value); }
        }

        static Boolean Olinhascondicionais;
        Boolean linhascondicionais;
        public Boolean Linhascondicionais
        {
            get { return linhascondicionais; }
            set { linhascondicionais = value; Add("linhascondicionais"); _valoresestilosbase.Add(value); }
        }

        static Boolean Osobreportitulos;
        Boolean sobreportitulos;
        public Boolean Sobreportitulos
        {
            get { return sobreportitulos; }
            set { sobreportitulos = value; Add("sobreportitulos"); _valoresestilosbase.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("estilosbase", TipoDeOperacao.Tipo.InsertMultiplo, _colunaestilosbase,_valoresestilosbase, _condicoesestilosbase);   
        }
        public int Alterar()
        {
if (_condicoesestilosbase.Count > 0)
{
return ExecuteNonSql.Executar("estilosbase", TipoDeOperacao.Tipo.Update, _colunaestilosbase,_valoresestilosbase, _condicoesestilosbase);
}
else
{
List<string> Nomeestilosbase = new List<string>();
List<dynamic> Valorestilosbase = new List<dynamic>();
_valoresestilosbase.Clear();
if(Idestilos!=null){ Nomeestilosbase.Add("idestilos");
 Valorestilosbase.Add(Oidestilos);
 _valoresestilosbase.Add(Idestilos);
}if(Idestilostipos!=null){ Nomeestilosbase.Add("idestilostipos");
 Valorestilosbase.Add(Oidestilostipos);
 _valoresestilosbase.Add(Idestilostipos);
}if(Removercolunas!=null){ Nomeestilosbase.Add("removercolunas");
 Valorestilosbase.Add(Oremovercolunas);
 _valoresestilosbase.Add(Removercolunas);
}if(Reorganizarcolunas!=null){ Nomeestilosbase.Add("reorganizarcolunas");
 Valorestilosbase.Add(Oreorganizarcolunas);
 _valoresestilosbase.Add(Reorganizarcolunas);
}if(Todasascolunas!=null){ Nomeestilosbase.Add("todasascolunas");
 Valorestilosbase.Add(Otodasascolunas);
 _valoresestilosbase.Add(Todasascolunas);
}if(Colunasespecificas!=null){ Nomeestilosbase.Add("colunasespecificas");
 Valorestilosbase.Add(Ocolunasespecificas);
 _valoresestilosbase.Add(Colunasespecificas);
}if(Colunasespecificasl!=null){ Nomeestilosbase.Add("colunasespecificasl");
 Valorestilosbase.Add(Ocolunasespecificasl);
 _valoresestilosbase.Add(Colunasespecificasl);
}if(Celulaindividuais!=null){ Nomeestilosbase.Add("celulaindividuais");
 Valorestilosbase.Add(Ocelulaindividuais);
 _valoresestilosbase.Add(Celulaindividuais);
}if(Linhasimpares!=null){ Nomeestilosbase.Add("linhasimpares");
 Valorestilosbase.Add(Olinhasimpares);
 _valoresestilosbase.Add(Linhasimpares);
}if(Linhaspares!=null){ Nomeestilosbase.Add("linhaspares");
 Valorestilosbase.Add(Olinhaspares);
 _valoresestilosbase.Add(Linhaspares);
}if(Linhascondicionais!=null){ Nomeestilosbase.Add("linhascondicionais");
 Valorestilosbase.Add(Olinhascondicionais);
 _valoresestilosbase.Add(Linhascondicionais);
}if(Sobreportitulos!=null){ Nomeestilosbase.Add("sobreportitulos");
 Valorestilosbase.Add(Osobreportitulos);
 _valoresestilosbase.Add(Sobreportitulos);
}List<dynamic> Condicaoestilosbase = new List<dynamic>();
Condicaoestilosbase.Add(Nomeestilosbase);
Condicaoestilosbase.Add(Valorestilosbase);
return ExecuteNonSql.Executar("estilosbase", TipoDeOperacao.Tipo.UpdateCondicional, _colunaestilosbase, _valoresestilosbase, Condicaoestilosbase);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("estilosbase", TipoDeOperacao.Tipo.Delete, _colunaestilosbase,_valoresestilosbase, _condicoesestilosbase);
        }
        static public List<estilosbase> Obter()
        {
            List<estilosbase> lista = new List<estilosbase>();
            DataTable tabela = Select.SelectSQL("select * from estilosbase");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilosbase novo = new estilosbase();
            try {   novo.Idestilos = (int)tabela.Rows[a]["idestilos"]; Oidestilos = (int)tabela.Rows[a]["idestilos"]; } catch { }
            try {   novo.Idestilostipos = (int)tabela.Rows[a]["idestilostipos"]; Oidestilostipos = (int)tabela.Rows[a]["idestilostipos"]; } catch { }
            try {   novo.Removercolunas = Convert.ToBoolean(tabela.Rows[a]["removercolunas"]);  Oremovercolunas= Convert.ToBoolean(tabela.Rows[a]["removercolunas"]); } catch { }
            try {   novo.Reorganizarcolunas = Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]);  Oreorganizarcolunas= Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]); } catch { }
            try {   novo.Todasascolunas = Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]);  Otodasascolunas= Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]); } catch { }
            try {   novo.Colunasespecificas = Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]);  Ocolunasespecificas= Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]); } catch { }
            try {   novo.Colunasespecificasl = Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]);  Ocolunasespecificasl= Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]); } catch { }
            try {   novo.Celulaindividuais = Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]);  Ocelulaindividuais= Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]); } catch { }
            try {   novo.Linhasimpares = Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]);  Olinhasimpares= Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]); } catch { }
            try {   novo.Linhaspares = Convert.ToBoolean(tabela.Rows[a]["linhaspares"]);  Olinhaspares= Convert.ToBoolean(tabela.Rows[a]["linhaspares"]); } catch { }
            try {   novo.Linhascondicionais = Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]);  Olinhascondicionais= Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]); } catch { }
            try {   novo.Sobreportitulos = Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]);  Osobreportitulos= Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilosbase> Obter(string where)
        {
            List<estilosbase> lista = new List<estilosbase>();
            DataTable tabela = Select.SelectSQL("select * from estilosbase where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilosbase novo = new estilosbase();
            try {   novo.Idestilos = (int)tabela.Rows[a]["idestilos"]; Oidestilos = (int)tabela.Rows[a]["idestilos"]; } catch { }
            try {   novo.Idestilostipos = (int)tabela.Rows[a]["idestilostipos"]; Oidestilostipos = (int)tabela.Rows[a]["idestilostipos"]; } catch { }
            try {   novo.Removercolunas = Convert.ToBoolean(tabela.Rows[a]["removercolunas"]);  Oremovercolunas= Convert.ToBoolean(tabela.Rows[a]["removercolunas"]); } catch { }
            try {   novo.Reorganizarcolunas = Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]);  Oreorganizarcolunas= Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]); } catch { }
            try {   novo.Todasascolunas = Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]);  Otodasascolunas= Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]); } catch { }
            try {   novo.Colunasespecificas = Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]);  Ocolunasespecificas= Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]); } catch { }
            try {   novo.Colunasespecificasl = Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]);  Ocolunasespecificasl= Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]); } catch { }
            try {   novo.Celulaindividuais = Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]);  Ocelulaindividuais= Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]); } catch { }
            try {   novo.Linhasimpares = Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]);  Olinhasimpares= Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]); } catch { }
            try {   novo.Linhaspares = Convert.ToBoolean(tabela.Rows[a]["linhaspares"]);  Olinhaspares= Convert.ToBoolean(tabela.Rows[a]["linhaspares"]); } catch { }
            try {   novo.Linhascondicionais = Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]);  Olinhascondicionais= Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]); } catch { }
            try {   novo.Sobreportitulos = Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]);  Osobreportitulos= Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilosbase> ObterComFiltroAvancado(string sql)
        {
            List<estilosbase> lista = new List<estilosbase>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilosbase novo = new estilosbase();
            try {   novo.Idestilos = (int)tabela.Rows[a]["idestilos"]; Oidestilos = (int)tabela.Rows[a]["idestilos"]; } catch { }
            try {   novo.Idestilostipos = (int)tabela.Rows[a]["idestilostipos"]; Oidestilostipos = (int)tabela.Rows[a]["idestilostipos"]; } catch { }
            try {   novo.Removercolunas = Convert.ToBoolean(tabela.Rows[a]["removercolunas"]);  Oremovercolunas= Convert.ToBoolean(tabela.Rows[a]["removercolunas"]); } catch { }
            try {   novo.Reorganizarcolunas = Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]);  Oreorganizarcolunas= Convert.ToBoolean(tabela.Rows[a]["reorganizarcolunas"]); } catch { }
            try {   novo.Todasascolunas = Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]);  Otodasascolunas= Convert.ToBoolean(tabela.Rows[a]["todasascolunas"]); } catch { }
            try {   novo.Colunasespecificas = Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]);  Ocolunasespecificas= Convert.ToBoolean(tabela.Rows[a]["colunasespecificas"]); } catch { }
            try {   novo.Colunasespecificasl = Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]);  Ocolunasespecificasl= Convert.ToBoolean(tabela.Rows[a]["colunasespecificasl"]); } catch { }
            try {   novo.Celulaindividuais = Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]);  Ocelulaindividuais= Convert.ToBoolean(tabela.Rows[a]["celulaindividuais"]); } catch { }
            try {   novo.Linhasimpares = Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]);  Olinhasimpares= Convert.ToBoolean(tabela.Rows[a]["linhasimpares"]); } catch { }
            try {   novo.Linhaspares = Convert.ToBoolean(tabela.Rows[a]["linhaspares"]);  Olinhaspares= Convert.ToBoolean(tabela.Rows[a]["linhaspares"]); } catch { }
            try {   novo.Linhascondicionais = Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]);  Olinhascondicionais= Convert.ToBoolean(tabela.Rows[a]["linhascondicionais"]); } catch { }
            try {   novo.Sobreportitulos = Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]);  Osobreportitulos= Convert.ToBoolean(tabela.Rows[a]["sobreportitulos"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from estilosbase").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from estilosbase where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from estilosbase ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from estilosbase where " + where + "");
}


# endregion
    }
}
