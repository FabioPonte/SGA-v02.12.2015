using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class itens_io
    {
        List<dynamic> _valoresitens_io = new List<dynamic>();
        List<string> _colunaitens_io = new List<string>();
        List<dynamic> _condicoesitens_io = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaitens_io.Count; a++)
         {
             if (col == _colunaitens_io[a])
                  {
                       return;
                  }
     }
_colunaitens_io.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesitens_io.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string marca="marca";
        public const string fabricante="fabricante";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresitens_io.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresitens_io.Add(value); }
        }

        static string Omarca;
        string marca;
        public string Marca
        {
            get { return marca; }
            set { marca = value; Add("marca"); _valoresitens_io.Add(value); }
        }

        static string Ofabricante;
        string fabricante;
        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; Add("fabricante"); _valoresitens_io.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("itens_io", TipoDeOperacao.Tipo.InsertMultiplo, _colunaitens_io,_valoresitens_io, _condicoesitens_io);   
        }
        public int Alterar()
        {
if (_condicoesitens_io.Count > 0)
{
return ExecuteNonSql.Executar("itens_io", TipoDeOperacao.Tipo.Update, _colunaitens_io,_valoresitens_io, _condicoesitens_io);
}
else
{
List<string> Nomeitens_io = new List<string>();
List<dynamic> Valoritens_io = new List<dynamic>();
_valoresitens_io.Clear();
if(Id!=null){ Nomeitens_io.Add("id");
 Valoritens_io.Add(Oid);
 _valoresitens_io.Add(Id);
}if(Nome!=null){ Nomeitens_io.Add("nome");
 Valoritens_io.Add(Onome);
 _valoresitens_io.Add(Nome);
}if(Marca!=null){ Nomeitens_io.Add("marca");
 Valoritens_io.Add(Omarca);
 _valoresitens_io.Add(Marca);
}if(Fabricante!=null){ Nomeitens_io.Add("fabricante");
 Valoritens_io.Add(Ofabricante);
 _valoresitens_io.Add(Fabricante);
}List<dynamic> Condicaoitens_io = new List<dynamic>();
Condicaoitens_io.Add(Nomeitens_io);
Condicaoitens_io.Add(Valoritens_io);
return ExecuteNonSql.Executar("itens_io", TipoDeOperacao.Tipo.UpdateCondicional, _colunaitens_io, _valoresitens_io, Condicaoitens_io);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("itens_io", TipoDeOperacao.Tipo.Delete, _colunaitens_io,_valoresitens_io, _condicoesitens_io);
        }
        static public List<itens_io> Obter()
        {
            List<itens_io> lista = new List<itens_io>();
            DataTable tabela = Select.SelectSQL("select * from itens_io");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_io novo = new itens_io();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Marca = (string)tabela.Rows[a]["marca"]; Omarca = (string)tabela.Rows[a]["marca"]; } catch { }
            try {   novo.Fabricante = (string)tabela.Rows[a]["fabricante"]; Ofabricante = (string)tabela.Rows[a]["fabricante"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens_io> Obter(string where)
        {
            List<itens_io> lista = new List<itens_io>();
            DataTable tabela = Select.SelectSQL("select * from itens_io where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_io novo = new itens_io();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Marca = (string)tabela.Rows[a]["marca"]; Omarca = (string)tabela.Rows[a]["marca"]; } catch { }
            try {   novo.Fabricante = (string)tabela.Rows[a]["fabricante"]; Ofabricante = (string)tabela.Rows[a]["fabricante"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<itens_io> ObterComFiltroAvancado(string sql)
        {
            List<itens_io> lista = new List<itens_io>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                itens_io novo = new itens_io();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Marca = (string)tabela.Rows[a]["marca"]; Omarca = (string)tabela.Rows[a]["marca"]; } catch { }
            try {   novo.Fabricante = (string)tabela.Rows[a]["fabricante"]; Ofabricante = (string)tabela.Rows[a]["fabricante"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from itens_io").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from itens_io where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from itens_io ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from itens_io where " + where + "");
}


# endregion
    }
}
