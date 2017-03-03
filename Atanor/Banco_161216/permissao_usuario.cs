using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class permissao_usuario
    {
        List<dynamic> _valorespermissao_usuario = new List<dynamic>();
        List<string> _colunapermissao_usuario = new List<string>();
        List<dynamic> _condicoespermissao_usuario = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunapermissao_usuario.Count; a++)
         {
             if (col == _colunapermissao_usuario[a])
                  {
                       return;
                  }
     }
_colunapermissao_usuario.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoespermissao_usuario.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idusuario="idusuario";
        public const string idpermissao="idpermissao";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorespermissao_usuario.Add(value); }
        }

        static int Oidusuario;
        int idusuario;
        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; Add("idusuario"); _valorespermissao_usuario.Add(value); }
        }

        static int Oidpermissao;
        int idpermissao;
        public int Idpermissao
        {
            get { return idpermissao; }
            set { idpermissao = value; Add("idpermissao"); _valorespermissao_usuario.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("permissao_usuario", TipoDeOperacao.Tipo.InsertMultiplo, _colunapermissao_usuario,_valorespermissao_usuario, _condicoespermissao_usuario);   
        }
        public int Alterar()
        {
if (_condicoespermissao_usuario.Count > 0)
{
return ExecuteNonSql.Executar("permissao_usuario", TipoDeOperacao.Tipo.Update, _colunapermissao_usuario,_valorespermissao_usuario, _condicoespermissao_usuario);
}
else
{
List<string> Nomepermissao_usuario = new List<string>();
List<dynamic> Valorpermissao_usuario = new List<dynamic>();
_valorespermissao_usuario.Clear();
if(Id!=null){ Nomepermissao_usuario.Add("id");
 Valorpermissao_usuario.Add(Oid);
 _valorespermissao_usuario.Add(Id);
}if(Idusuario!=null){ Nomepermissao_usuario.Add("idusuario");
 Valorpermissao_usuario.Add(Oidusuario);
 _valorespermissao_usuario.Add(Idusuario);
}if(Idpermissao!=null){ Nomepermissao_usuario.Add("idpermissao");
 Valorpermissao_usuario.Add(Oidpermissao);
 _valorespermissao_usuario.Add(Idpermissao);
}List<dynamic> Condicaopermissao_usuario = new List<dynamic>();
Condicaopermissao_usuario.Add(Nomepermissao_usuario);
Condicaopermissao_usuario.Add(Valorpermissao_usuario);
return ExecuteNonSql.Executar("permissao_usuario", TipoDeOperacao.Tipo.UpdateCondicional, _colunapermissao_usuario, _valorespermissao_usuario, Condicaopermissao_usuario);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("permissao_usuario", TipoDeOperacao.Tipo.Delete, _colunapermissao_usuario,_valorespermissao_usuario, _condicoespermissao_usuario);
        }
        static public List<permissao_usuario> Obter()
        {
            List<permissao_usuario> lista = new List<permissao_usuario>();
            DataTable tabela = Select.SelectSQL("select * from permissao_usuario");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao_usuario novo = new permissao_usuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Idpermissao = (int)tabela.Rows[a]["idpermissao"]; Oidpermissao = (int)tabela.Rows[a]["idpermissao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<permissao_usuario> Obter(string where)
        {
            List<permissao_usuario> lista = new List<permissao_usuario>();
            DataTable tabela = Select.SelectSQL("select * from permissao_usuario where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao_usuario novo = new permissao_usuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Idpermissao = (int)tabela.Rows[a]["idpermissao"]; Oidpermissao = (int)tabela.Rows[a]["idpermissao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<permissao_usuario> ObterComFiltroAvancado(string sql)
        {
            List<permissao_usuario> lista = new List<permissao_usuario>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                permissao_usuario novo = new permissao_usuario();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idusuario = (int)tabela.Rows[a]["idusuario"]; Oidusuario = (int)tabela.Rows[a]["idusuario"]; } catch { }
            try {   novo.Idpermissao = (int)tabela.Rows[a]["idpermissao"]; Oidpermissao = (int)tabela.Rows[a]["idpermissao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from permissao_usuario").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from permissao_usuario where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from permissao_usuario ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from permissao_usuario where " + where + "");
}


# endregion
    }
}
