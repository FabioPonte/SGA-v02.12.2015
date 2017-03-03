using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class expedicao_notas
    {
        List<dynamic> _valoresexpedicao_notas = new List<dynamic>();
        List<string> _colunaexpedicao_notas = new List<string>();
        List<dynamic> _condicoesexpedicao_notas = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaexpedicao_notas.Count; a++)
         {
             if (col == _colunaexpedicao_notas[a])
                  {
                       return;
                  }
     }
_colunaexpedicao_notas.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesexpedicao_notas.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nota="nota";
        public const string expedida="expedida";
        public const string motivo="motivo";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresexpedicao_notas.Add(value); }
        }

        static string Onota;
        string nota;
        public string Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresexpedicao_notas.Add(value); }
        }

        static Boolean Oexpedida;
        Boolean expedida;
        public Boolean Expedida
        {
            get { return expedida; }
            set { expedida = value; Add("expedida"); _valoresexpedicao_notas.Add(value); }
        }

        static string Omotivo;
        string motivo;
        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; Add("motivo"); _valoresexpedicao_notas.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("expedicao_notas", TipoDeOperacao.Tipo.InsertMultiplo, _colunaexpedicao_notas,_valoresexpedicao_notas, _condicoesexpedicao_notas);   
        }
        public int Alterar()
        {
if (_condicoesexpedicao_notas.Count > 0)
{
return ExecuteNonSql.Executar("expedicao_notas", TipoDeOperacao.Tipo.Update, _colunaexpedicao_notas,_valoresexpedicao_notas, _condicoesexpedicao_notas);
}
else
{
List<string> Nomeexpedicao_notas = new List<string>();
List<dynamic> Valorexpedicao_notas = new List<dynamic>();
_valoresexpedicao_notas.Clear();
if(Id!=null){ Nomeexpedicao_notas.Add("id");
 Valorexpedicao_notas.Add(Oid);
 _valoresexpedicao_notas.Add(Id);
}if(Nota!=null){ Nomeexpedicao_notas.Add("nota");
 Valorexpedicao_notas.Add(Onota);
 _valoresexpedicao_notas.Add(Nota);
}if(Expedida!=null){ Nomeexpedicao_notas.Add("expedida");
 Valorexpedicao_notas.Add(Oexpedida);
 _valoresexpedicao_notas.Add(Expedida);
}if(Motivo!=null){ Nomeexpedicao_notas.Add("motivo");
 Valorexpedicao_notas.Add(Omotivo);
 _valoresexpedicao_notas.Add(Motivo);
}List<dynamic> Condicaoexpedicao_notas = new List<dynamic>();
Condicaoexpedicao_notas.Add(Nomeexpedicao_notas);
Condicaoexpedicao_notas.Add(Valorexpedicao_notas);
return ExecuteNonSql.Executar("expedicao_notas", TipoDeOperacao.Tipo.UpdateCondicional, _colunaexpedicao_notas, _valoresexpedicao_notas, Condicaoexpedicao_notas);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("expedicao_notas", TipoDeOperacao.Tipo.Delete, _colunaexpedicao_notas,_valoresexpedicao_notas, _condicoesexpedicao_notas);
        }
        static public List<expedicao_notas> Obter()
        {
            List<expedicao_notas> lista = new List<expedicao_notas>();
            DataTable tabela = Select.SelectSQL("select * from expedicao_notas");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao_notas novo = new expedicao_notas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Expedida = Convert.ToBoolean(tabela.Rows[a]["expedida"]);  Oexpedida= Convert.ToBoolean(tabela.Rows[a]["expedida"]); } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<expedicao_notas> Obter(string where)
        {
            List<expedicao_notas> lista = new List<expedicao_notas>();
            DataTable tabela = Select.SelectSQL("select * from expedicao_notas where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao_notas novo = new expedicao_notas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Expedida = Convert.ToBoolean(tabela.Rows[a]["expedida"]);  Oexpedida= Convert.ToBoolean(tabela.Rows[a]["expedida"]); } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<expedicao_notas> ObterComFiltroAvancado(string sql)
        {
            List<expedicao_notas> lista = new List<expedicao_notas>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                expedicao_notas novo = new expedicao_notas();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Expedida = Convert.ToBoolean(tabela.Rows[a]["expedida"]);  Oexpedida= Convert.ToBoolean(tabela.Rows[a]["expedida"]); } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from expedicao_notas").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from expedicao_notas where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from expedicao_notas ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from expedicao_notas where " + where + "");
}


# endregion
    }
}
