using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class aviso_recebido
    {
        List<dynamic> _valoresaviso_recebido = new List<dynamic>();
        List<string> _colunaaviso_recebido = new List<string>();
        List<dynamic> _condicoesaviso_recebido = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaaviso_recebido.Count; a++)
         {
             if (col == _colunaaviso_recebido[a])
                  {
                       return;
                  }
     }
_colunaaviso_recebido.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesaviso_recebido.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idaviso="idaviso";
        public const string usuario="usuario";
        public const string data="data";
        public const string ok="ok";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresaviso_recebido.Add(value); }
        }

        static int Oidaviso;
        int idaviso;
        public int Idaviso
        {
            get { return idaviso; }
            set { idaviso = value; Add("idaviso"); _valoresaviso_recebido.Add(value); }
        }

        static string Ousuario;
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; Add("usuario"); _valoresaviso_recebido.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresaviso_recebido.Add(value); }
        }

        static int Ook;
        int ok;
        public int Ok
        {
            get { return ok; }
            set { ok = value; Add("ok"); _valoresaviso_recebido.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("aviso_recebido", TipoDeOperacao.Tipo.InsertMultiplo, _colunaaviso_recebido,_valoresaviso_recebido, _condicoesaviso_recebido);   
        }
        public int Alterar()
        {
if (_condicoesaviso_recebido.Count > 0)
{
return ExecuteNonSql.Executar("aviso_recebido", TipoDeOperacao.Tipo.Update, _colunaaviso_recebido,_valoresaviso_recebido, _condicoesaviso_recebido);
}
else
{
List<string> Nomeaviso_recebido = new List<string>();
List<dynamic> Valoraviso_recebido = new List<dynamic>();
_valoresaviso_recebido.Clear();
if(Id!=null){ Nomeaviso_recebido.Add("id");
 Valoraviso_recebido.Add(Oid);
 _valoresaviso_recebido.Add(Id);
}if(Idaviso!=null){ Nomeaviso_recebido.Add("idaviso");
 Valoraviso_recebido.Add(Oidaviso);
 _valoresaviso_recebido.Add(Idaviso);
}if(Usuario!=null){ Nomeaviso_recebido.Add("usuario");
 Valoraviso_recebido.Add(Ousuario);
 _valoresaviso_recebido.Add(Usuario);
}if(Data!=null){ Nomeaviso_recebido.Add("data");
 Valoraviso_recebido.Add(Odata);
 _valoresaviso_recebido.Add(Data);
}if(Ok!=null){ Nomeaviso_recebido.Add("ok");
 Valoraviso_recebido.Add(Ook);
 _valoresaviso_recebido.Add(Ok);
}List<dynamic> Condicaoaviso_recebido = new List<dynamic>();
Condicaoaviso_recebido.Add(Nomeaviso_recebido);
Condicaoaviso_recebido.Add(Valoraviso_recebido);
return ExecuteNonSql.Executar("aviso_recebido", TipoDeOperacao.Tipo.UpdateCondicional, _colunaaviso_recebido, _valoresaviso_recebido, Condicaoaviso_recebido);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("aviso_recebido", TipoDeOperacao.Tipo.Delete, _colunaaviso_recebido,_valoresaviso_recebido, _condicoesaviso_recebido);
        }
        static public List<aviso_recebido> Obter()
        {
            List<aviso_recebido> lista = new List<aviso_recebido>();
            DataTable tabela = Select.SelectSQL("select * from aviso_recebido");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso_recebido novo = new aviso_recebido();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idaviso = (int)tabela.Rows[a]["idaviso"]; Oidaviso = (int)tabela.Rows[a]["idaviso"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Ok = (int)tabela.Rows[a]["ok"]; Ook = (int)tabela.Rows[a]["ok"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<aviso_recebido> Obter(string where)
        {
            List<aviso_recebido> lista = new List<aviso_recebido>();
            DataTable tabela = Select.SelectSQL("select * from aviso_recebido where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso_recebido novo = new aviso_recebido();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idaviso = (int)tabela.Rows[a]["idaviso"]; Oidaviso = (int)tabela.Rows[a]["idaviso"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Ok = (int)tabela.Rows[a]["ok"]; Ook = (int)tabela.Rows[a]["ok"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<aviso_recebido> ObterComFiltroAvancado(string sql)
        {
            List<aviso_recebido> lista = new List<aviso_recebido>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso_recebido novo = new aviso_recebido();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idaviso = (int)tabela.Rows[a]["idaviso"]; Oidaviso = (int)tabela.Rows[a]["idaviso"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Ok = (int)tabela.Rows[a]["ok"]; Ook = (int)tabela.Rows[a]["ok"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from aviso_recebido").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from aviso_recebido where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from aviso_recebido ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from aviso_recebido where " + where + "");
}


# endregion
    }
}
