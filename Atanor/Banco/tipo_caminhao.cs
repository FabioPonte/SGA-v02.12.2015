using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class tipo_caminhao
    {
        List<dynamic> _valorestipo_caminhao = new List<dynamic>();
        List<string> _colunatipo_caminhao = new List<string>();
        List<dynamic> _condicoestipo_caminhao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatipo_caminhao.Count; a++)
         {
             if (col == _colunatipo_caminhao[a])
                  {
                       return;
                  }
     }
_colunatipo_caminhao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestipo_caminhao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string foto="foto";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorestipo_caminhao.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valorestipo_caminhao.Add(value); }
        }

        static dynamic Ofoto;
        dynamic foto;
        public dynamic Foto
        {
            get { return foto; }
            set { foto = value; Add("foto"); _valorestipo_caminhao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("tipo_caminhao", TipoDeOperacao.Tipo.InsertMultiplo, _colunatipo_caminhao,_valorestipo_caminhao, _condicoestipo_caminhao);   
        }
        public int Alterar()
        {
if (_condicoestipo_caminhao.Count > 0)
{
return ExecuteNonSql.Executar("tipo_caminhao", TipoDeOperacao.Tipo.Update, _colunatipo_caminhao,_valorestipo_caminhao, _condicoestipo_caminhao);
}
else
{
List<string> Nometipo_caminhao = new List<string>();
List<dynamic> Valortipo_caminhao = new List<dynamic>();
_valorestipo_caminhao.Clear();
if(Id!=null){ Nometipo_caminhao.Add("id");
 Valortipo_caminhao.Add(Oid);
 _valorestipo_caminhao.Add(Id);
}if(Nome!=null){ Nometipo_caminhao.Add("nome");
 Valortipo_caminhao.Add(Onome);
 _valorestipo_caminhao.Add(Nome);
}if(Foto!=null){ Nometipo_caminhao.Add("foto");
 Valortipo_caminhao.Add(Ofoto);
 _valorestipo_caminhao.Add(Foto);
}List<dynamic> Condicaotipo_caminhao = new List<dynamic>();
Condicaotipo_caminhao.Add(Nometipo_caminhao);
Condicaotipo_caminhao.Add(Valortipo_caminhao);
return ExecuteNonSql.Executar("tipo_caminhao", TipoDeOperacao.Tipo.UpdateCondicional, _colunatipo_caminhao, _valorestipo_caminhao, Condicaotipo_caminhao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("tipo_caminhao", TipoDeOperacao.Tipo.Delete, _colunatipo_caminhao,_valorestipo_caminhao, _condicoestipo_caminhao);
        }
        static public List<tipo_caminhao> Obter()
        {
            List<tipo_caminhao> lista = new List<tipo_caminhao>();
            DataTable tabela = Select.SelectSQL("select * from tipo_caminhao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipo_caminhao novo = new tipo_caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tipo_caminhao> Obter(string where)
        {
            List<tipo_caminhao> lista = new List<tipo_caminhao>();
            DataTable tabela = Select.SelectSQL("select * from tipo_caminhao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipo_caminhao novo = new tipo_caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<tipo_caminhao> ObterComFiltroAvancado(string sql)
        {
            List<tipo_caminhao> lista = new List<tipo_caminhao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                tipo_caminhao novo = new tipo_caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from tipo_caminhao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from tipo_caminhao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from tipo_caminhao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from tipo_caminhao where " + where + "");
}


# endregion
    }
}
