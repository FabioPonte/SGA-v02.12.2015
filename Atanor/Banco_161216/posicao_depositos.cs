using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class posicao_depositos
    {
        List<dynamic> _valoresposicao_depositos = new List<dynamic>();
        List<string> _colunaposicao_depositos = new List<string>();
        List<dynamic> _condicoesposicao_depositos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaposicao_depositos.Count; a++)
         {
             if (col == _colunaposicao_depositos[a])
                  {
                       return;
                  }
     }
_colunaposicao_depositos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesposicao_depositos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string x="x";
        public const string y="y";
        public const string nome1="nome1";
        public const string nome2="nome2";
        public const string nome3="nome3";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresposicao_depositos.Add(value); }
        }

        static int Ox;
        int x;
        public int X
        {
            get { return x; }
            set { x = value; Add("x"); _valoresposicao_depositos.Add(value); }
        }

        static int Oy;
        int y;
        public int Y
        {
            get { return y; }
            set { y = value; Add("y"); _valoresposicao_depositos.Add(value); }
        }

        static string Onome1;
        string nome1;
        public string Nome1
        {
            get { return nome1; }
            set { nome1 = value; Add("nome1"); _valoresposicao_depositos.Add(value); }
        }

        static string Onome2;
        string nome2;
        public string Nome2
        {
            get { return nome2; }
            set { nome2 = value; Add("nome2"); _valoresposicao_depositos.Add(value); }
        }

        static string Onome3;
        string nome3;
        public string Nome3
        {
            get { return nome3; }
            set { nome3 = value; Add("nome3"); _valoresposicao_depositos.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresposicao_depositos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("posicao_depositos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaposicao_depositos,_valoresposicao_depositos, _condicoesposicao_depositos);   
        }
        public int Alterar()
        {
if (_condicoesposicao_depositos.Count > 0)
{
return ExecuteNonSql.Executar("posicao_depositos", TipoDeOperacao.Tipo.Update, _colunaposicao_depositos,_valoresposicao_depositos, _condicoesposicao_depositos);
}
else
{
List<string> Nomeposicao_depositos = new List<string>();
List<dynamic> Valorposicao_depositos = new List<dynamic>();
_valoresposicao_depositos.Clear();
if(Id!=null){ Nomeposicao_depositos.Add("id");
 Valorposicao_depositos.Add(Oid);
 _valoresposicao_depositos.Add(Id);
}if(X!=null){ Nomeposicao_depositos.Add("x");
 Valorposicao_depositos.Add(Ox);
 _valoresposicao_depositos.Add(X);
}if(Y!=null){ Nomeposicao_depositos.Add("y");
 Valorposicao_depositos.Add(Oy);
 _valoresposicao_depositos.Add(Y);
}if(Nome1!=null){ Nomeposicao_depositos.Add("nome1");
 Valorposicao_depositos.Add(Onome1);
 _valoresposicao_depositos.Add(Nome1);
}if(Nome2!=null){ Nomeposicao_depositos.Add("nome2");
 Valorposicao_depositos.Add(Onome2);
 _valoresposicao_depositos.Add(Nome2);
}if(Nome3!=null){ Nomeposicao_depositos.Add("nome3");
 Valorposicao_depositos.Add(Onome3);
 _valoresposicao_depositos.Add(Nome3);
}if(Obs!=null){ Nomeposicao_depositos.Add("obs");
 Valorposicao_depositos.Add(Oobs);
 _valoresposicao_depositos.Add(Obs);
}List<dynamic> Condicaoposicao_depositos = new List<dynamic>();
Condicaoposicao_depositos.Add(Nomeposicao_depositos);
Condicaoposicao_depositos.Add(Valorposicao_depositos);
return ExecuteNonSql.Executar("posicao_depositos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaposicao_depositos, _valoresposicao_depositos, Condicaoposicao_depositos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("posicao_depositos", TipoDeOperacao.Tipo.Delete, _colunaposicao_depositos,_valoresposicao_depositos, _condicoesposicao_depositos);
        }
        static public List<posicao_depositos> Obter()
        {
            List<posicao_depositos> lista = new List<posicao_depositos>();
            DataTable tabela = Select.SelectSQL("select * from posicao_depositos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_depositos novo = new posicao_depositos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.X = (int)tabela.Rows[a]["x"]; Ox = (int)tabela.Rows[a]["x"]; } catch { }
            try {   novo.Y = (int)tabela.Rows[a]["y"]; Oy = (int)tabela.Rows[a]["y"]; } catch { }
            try {   novo.Nome1 = (string)tabela.Rows[a]["nome1"]; Onome1 = (string)tabela.Rows[a]["nome1"]; } catch { }
            try {   novo.Nome2 = (string)tabela.Rows[a]["nome2"]; Onome2 = (string)tabela.Rows[a]["nome2"]; } catch { }
            try {   novo.Nome3 = (string)tabela.Rows[a]["nome3"]; Onome3 = (string)tabela.Rows[a]["nome3"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_depositos> Obter(string where)
        {
            List<posicao_depositos> lista = new List<posicao_depositos>();
            DataTable tabela = Select.SelectSQL("select * from posicao_depositos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_depositos novo = new posicao_depositos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.X = (int)tabela.Rows[a]["x"]; Ox = (int)tabela.Rows[a]["x"]; } catch { }
            try {   novo.Y = (int)tabela.Rows[a]["y"]; Oy = (int)tabela.Rows[a]["y"]; } catch { }
            try {   novo.Nome1 = (string)tabela.Rows[a]["nome1"]; Onome1 = (string)tabela.Rows[a]["nome1"]; } catch { }
            try {   novo.Nome2 = (string)tabela.Rows[a]["nome2"]; Onome2 = (string)tabela.Rows[a]["nome2"]; } catch { }
            try {   novo.Nome3 = (string)tabela.Rows[a]["nome3"]; Onome3 = (string)tabela.Rows[a]["nome3"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_depositos> ObterComFiltroAvancado(string sql)
        {
            List<posicao_depositos> lista = new List<posicao_depositos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_depositos novo = new posicao_depositos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.X = (int)tabela.Rows[a]["x"]; Ox = (int)tabela.Rows[a]["x"]; } catch { }
            try {   novo.Y = (int)tabela.Rows[a]["y"]; Oy = (int)tabela.Rows[a]["y"]; } catch { }
            try {   novo.Nome1 = (string)tabela.Rows[a]["nome1"]; Onome1 = (string)tabela.Rows[a]["nome1"]; } catch { }
            try {   novo.Nome2 = (string)tabela.Rows[a]["nome2"]; Onome2 = (string)tabela.Rows[a]["nome2"]; } catch { }
            try {   novo.Nome3 = (string)tabela.Rows[a]["nome3"]; Onome3 = (string)tabela.Rows[a]["nome3"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from posicao_depositos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from posicao_depositos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from posicao_depositos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from posicao_depositos where " + where + "");
}


# endregion
    }
}
