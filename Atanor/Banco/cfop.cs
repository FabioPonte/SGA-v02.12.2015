using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class cfop
    {
        List<dynamic> _valorescfop = new List<dynamic>();
        List<string> _colunacfop = new List<string>();
        List<dynamic> _condicoescfop = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacfop.Count; a++)
         {
             if (col == _colunacfop[a])
                  {
                       return;
                  }
     }
_colunacfop.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescfop.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string ocfop="ocfop";
        public const string cor="cor";
        public const string ignorar="ignorar";
        public const string apelido="apelido";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescfop.Add(value); }
        }

        static string Oocfop;
        string ocfop;
        public string Ocfop
        {
            get { return ocfop; }
            set { ocfop = value; Add("ocfop"); _valorescfop.Add(value); }
        }

        static string Ocor;
        string cor;
        public string Cor
        {
            get { return cor; }
            set { cor = value; Add("cor"); _valorescfop.Add(value); }
        }

        static int Oignorar;
        int ignorar;
        public int Ignorar
        {
            get { return ignorar; }
            set { ignorar = value; Add("ignorar"); _valorescfop.Add(value); }
        }

        static string Oapelido;
        string apelido;
        public string Apelido
        {
            get { return apelido; }
            set { apelido = value; Add("apelido"); _valorescfop.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("cfop", TipoDeOperacao.Tipo.InsertMultiplo, _colunacfop,_valorescfop, _condicoescfop);   
        }
        public int Alterar()
        {
if (_condicoescfop.Count > 0)
{
return ExecuteNonSql.Executar("cfop", TipoDeOperacao.Tipo.Update, _colunacfop,_valorescfop, _condicoescfop);
}
else
{
List<string> Nomecfop = new List<string>();
List<dynamic> Valorcfop = new List<dynamic>();
_valorescfop.Clear();
if(Id!=null){ Nomecfop.Add("id");
 Valorcfop.Add(Oid);
 _valorescfop.Add(Id);
}if(Ocfop!=null){ Nomecfop.Add("ocfop");
 Valorcfop.Add(Oocfop);
 _valorescfop.Add(Ocfop);
}if(Cor!=null){ Nomecfop.Add("cor");
 Valorcfop.Add(Ocor);
 _valorescfop.Add(Cor);
}if(Ignorar!=null){ Nomecfop.Add("ignorar");
 Valorcfop.Add(Oignorar);
 _valorescfop.Add(Ignorar);
}if(Apelido!=null){ Nomecfop.Add("apelido");
 Valorcfop.Add(Oapelido);
 _valorescfop.Add(Apelido);
}List<dynamic> Condicaocfop = new List<dynamic>();
Condicaocfop.Add(Nomecfop);
Condicaocfop.Add(Valorcfop);
return ExecuteNonSql.Executar("cfop", TipoDeOperacao.Tipo.UpdateCondicional, _colunacfop, _valorescfop, Condicaocfop);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("cfop", TipoDeOperacao.Tipo.Delete, _colunacfop,_valorescfop, _condicoescfop);
        }
        static public List<cfop> Obter()
        {
            List<cfop> lista = new List<cfop>();
            DataTable tabela = Select.SelectSQL("select * from cfop");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cfop novo = new cfop();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Ocfop = (string)tabela.Rows[a]["ocfop"]; Oocfop = (string)tabela.Rows[a]["ocfop"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
            try {   novo.Ignorar = (int)tabela.Rows[a]["ignorar"]; Oignorar = (int)tabela.Rows[a]["ignorar"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<cfop> Obter(string where)
        {
            List<cfop> lista = new List<cfop>();
            DataTable tabela = Select.SelectSQL("select * from cfop where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cfop novo = new cfop();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Ocfop = (string)tabela.Rows[a]["ocfop"]; Oocfop = (string)tabela.Rows[a]["ocfop"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
            try {   novo.Ignorar = (int)tabela.Rows[a]["ignorar"]; Oignorar = (int)tabela.Rows[a]["ignorar"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<cfop> ObterComFiltroAvancado(string sql)
        {
            List<cfop> lista = new List<cfop>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cfop novo = new cfop();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Ocfop = (string)tabela.Rows[a]["ocfop"]; Oocfop = (string)tabela.Rows[a]["ocfop"]; } catch { }
            try {   novo.Cor = (string)tabela.Rows[a]["cor"]; Ocor = (string)tabela.Rows[a]["cor"]; } catch { }
            try {   novo.Ignorar = (int)tabela.Rows[a]["ignorar"]; Oignorar = (int)tabela.Rows[a]["ignorar"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from cfop").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from cfop where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from cfop ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from cfop where " + where + "");
}


# endregion
    }
}
