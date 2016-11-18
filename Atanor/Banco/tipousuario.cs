using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class tipousuario
    {
        List<dynamic> _valorestipousuario = new List<dynamic>();
        List<string> _colunatipousuario = new List<string>();
        List<dynamic> _condicoestipousuario = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatipousuario.Count; a++)
         {
             if (col == _colunatipousuario[a])
                  {
                       return;
                  }
     }
_colunatipousuario.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestipousuario.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string tipo="tipo";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorestipousuario.Add(value); }
        }

        static string Otipo;
        string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; Add("tipo"); _valorestipousuario.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.InsertMultiplo, _colunatipousuario,_valorestipousuario, _condicoestipousuario);   
        }
        public int Alterar()
        {
if (_condicoestipousuario.Count > 0)
{
return ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.Update, _colunatipousuario,_valorestipousuario, _condicoestipousuario);
}
else
{
List<string> Nometipousuario = new List<string>();
List<dynamic> Valortipousuario = new List<dynamic>();
_valorestipousuario.Clear();
if(Id!=null){ Nometipousuario.Add("id");
 Valortipousuario.Add(Oid);
 _valorestipousuario.Add(Id);
}if(Tipo!=null){ Nometipousuario.Add("tipo");
 Valortipousuario.Add(Otipo);
 _valorestipousuario.Add(Tipo);
}List<dynamic> Condicaotipousuario = new List<dynamic>();
Condicaotipousuario.Add(Nometipousuario);
Condicaotipousuario.Add(Valortipousuario);
return ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.UpdateCondicional, _colunatipousuario, _valorestipousuario, Condicaotipousuario);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("tipousuario", TipoDeOperacao.Tipo.Delete, _colunatipousuario,_valorestipousuario, _condicoestipousuario);
        }
        static public List<tipousuario> Obter()
        {
            List<tipousuario> lista = new List<tipousuario>();
            DataTable tabela = Select.SelectSQL("select * from tipousuario");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipousuario novo = new tipousuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tipo = (string)tabela.Rows[a]["tipo"]; Otipo = (string)tabela.Rows[a]["tipo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tipousuario> Obter(string where)
        {
            List<tipousuario> lista = new List<tipousuario>();
            DataTable tabela = Select.SelectSQL("select * from tipousuario where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipousuario novo = new tipousuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tipo = (string)tabela.Rows[a]["tipo"]; Otipo = (string)tabela.Rows[a]["tipo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tipousuario> ObterComFiltroAvancado(string sql)
        {
            List<tipousuario> lista = new List<tipousuario>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipousuario novo = new tipousuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Tipo = (string)tabela.Rows[a]["tipo"]; Otipo = (string)tabela.Rows[a]["tipo"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from tipousuario").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from tipousuario where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from tipousuario ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from tipousuario where " + where + "");
}


# endregion
    }
}
