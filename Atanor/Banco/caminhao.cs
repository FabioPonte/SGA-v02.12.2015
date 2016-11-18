using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class caminhao
    {
        List<dynamic> _valorescaminhao = new List<dynamic>();
        List<string> _colunacaminhao = new List<string>();
        List<dynamic> _condicoescaminhao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacaminhao.Count; a++)
         {
             if (col == _colunacaminhao[a])
                  {
                       return;
                  }
     }
_colunacaminhao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescaminhao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idtipo_caminhao="idtipo_caminhao";
        public const string placa="placa";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescaminhao.Add(value); }
        }

        static int Oidtipo_caminhao;
        int idtipo_caminhao;
        public int Idtipo_caminhao
        {
            get { return idtipo_caminhao; }
            set { idtipo_caminhao = value; Add("idtipo_caminhao"); _valorescaminhao.Add(value); }
        }

        static string Oplaca;
        string placa;
        public string Placa
        {
            get { return placa; }
            set { placa = value; Add("placa"); _valorescaminhao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.InsertMultiplo, _colunacaminhao,_valorescaminhao, _condicoescaminhao);   
        }
        public int Alterar()
        {
if (_condicoescaminhao.Count > 0)
{
return ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.Update, _colunacaminhao,_valorescaminhao, _condicoescaminhao);
}
else
{
List<string> Nomecaminhao = new List<string>();
List<dynamic> Valorcaminhao = new List<dynamic>();
_valorescaminhao.Clear();
if(Id!=null){ Nomecaminhao.Add("id");
 Valorcaminhao.Add(Oid);
 _valorescaminhao.Add(Id);
}if(Idtipo_caminhao!=null){ Nomecaminhao.Add("idtipo_caminhao");
 Valorcaminhao.Add(Oidtipo_caminhao);
 _valorescaminhao.Add(Idtipo_caminhao);
}if(Placa!=null){ Nomecaminhao.Add("placa");
 Valorcaminhao.Add(Oplaca);
 _valorescaminhao.Add(Placa);
}List<dynamic> Condicaocaminhao = new List<dynamic>();
Condicaocaminhao.Add(Nomecaminhao);
Condicaocaminhao.Add(Valorcaminhao);
return ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.UpdateCondicional, _colunacaminhao, _valorescaminhao, Condicaocaminhao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("caminhao", TipoDeOperacao.Tipo.Delete, _colunacaminhao,_valorescaminhao, _condicoescaminhao);
        }
        static public List<caminhao> Obter()
        {
            List<caminhao> lista = new List<caminhao>();
            DataTable tabela = Select.SelectSQL("select * from caminhao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                caminhao novo = new caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; Oidtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<caminhao> Obter(string where)
        {
            List<caminhao> lista = new List<caminhao>();
            DataTable tabela = Select.SelectSQL("select * from caminhao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                caminhao novo = new caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; Oidtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<caminhao> ObterComFiltroAvancado(string sql)
        {
            List<caminhao> lista = new List<caminhao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                caminhao novo = new caminhao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; Oidtipo_caminhao = (int)tabela.Rows[a]["idtipo_caminhao"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from caminhao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from caminhao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from caminhao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from caminhao where " + where + "");
}


# endregion
    }
}
