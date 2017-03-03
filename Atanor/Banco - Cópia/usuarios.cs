using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class usuarios
    {
        List<dynamic> _valoresusuarios = new List<dynamic>();
        List<string> _colunausuarios = new List<string>();
        List<dynamic> _condicoesusuarios = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunausuarios.Count; a++)
         {
             if (col == _colunausuarios[a])
                  {
                       return;
                  }
     }
_colunausuarios.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesusuarios.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idtipousuario="idtipousuario";
        public const string usuario="usuario";
        public const string senha="senha";
        public const string nome="nome";
        public const string foto="foto";
        public const string email="email";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresusuarios.Add(value); }
        }

        static int Oidtipousuario;
        int idtipousuario;
        public int Idtipousuario
        {
            get { return idtipousuario; }
            set { idtipousuario = value; Add("idtipousuario"); _valoresusuarios.Add(value); }
        }

        static string Ousuario;
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; Add("usuario"); _valoresusuarios.Add(value); }
        }

        static string Osenha;
        string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; Add("senha"); _valoresusuarios.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresusuarios.Add(value); }
        }

        static dynamic Ofoto;
        dynamic foto;
        public dynamic Foto
        {
            get { return foto; }
            set { foto = value; Add("foto"); _valoresusuarios.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresusuarios.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.InsertMultiplo, _colunausuarios,_valoresusuarios, _condicoesusuarios);   
        }
        public int Alterar()
        {
if (_condicoesusuarios.Count > 0)
{
return ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Update, _colunausuarios,_valoresusuarios, _condicoesusuarios);
}
else
{
List<string> Nomeusuarios = new List<string>();
List<dynamic> Valorusuarios = new List<dynamic>();
_valoresusuarios.Clear();
if(Id!=null){ Nomeusuarios.Add("id");
 Valorusuarios.Add(Oid);
 _valoresusuarios.Add(Id);
}if(Idtipousuario!=null){ Nomeusuarios.Add("idtipousuario");
 Valorusuarios.Add(Oidtipousuario);
 _valoresusuarios.Add(Idtipousuario);
}if(Usuario!=null){ Nomeusuarios.Add("usuario");
 Valorusuarios.Add(Ousuario);
 _valoresusuarios.Add(Usuario);
}if(Senha!=null){ Nomeusuarios.Add("senha");
 Valorusuarios.Add(Osenha);
 _valoresusuarios.Add(Senha);
}if(Nome!=null){ Nomeusuarios.Add("nome");
 Valorusuarios.Add(Onome);
 _valoresusuarios.Add(Nome);
}if(Foto!=null){ Nomeusuarios.Add("foto");
 Valorusuarios.Add(Ofoto);
 _valoresusuarios.Add(Foto);
}if(Email!=null){ Nomeusuarios.Add("email");
 Valorusuarios.Add(Oemail);
 _valoresusuarios.Add(Email);
}List<dynamic> Condicaousuarios = new List<dynamic>();
Condicaousuarios.Add(Nomeusuarios);
Condicaousuarios.Add(Valorusuarios);
return ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.UpdateCondicional, _colunausuarios, _valoresusuarios, Condicaousuarios);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("usuarios", TipoDeOperacao.Tipo.Delete, _colunausuarios,_valoresusuarios, _condicoesusuarios);
        }
        static public List<usuarios> Obter()
        {
            List<usuarios> lista = new List<usuarios>();
            DataTable tabela = Select.SelectSQL("select * from usuarios");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                usuarios novo = new usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipousuario = (int)tabela.Rows[a]["idtipousuario"]; Oidtipousuario = (int)tabela.Rows[a]["idtipousuario"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Senha = (string)tabela.Rows[a]["senha"]; Osenha = (string)tabela.Rows[a]["senha"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<usuarios> Obter(string where)
        {
            List<usuarios> lista = new List<usuarios>();
            DataTable tabela = Select.SelectSQL("select * from usuarios where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                usuarios novo = new usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipousuario = (int)tabela.Rows[a]["idtipousuario"]; Oidtipousuario = (int)tabela.Rows[a]["idtipousuario"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Senha = (string)tabela.Rows[a]["senha"]; Osenha = (string)tabela.Rows[a]["senha"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<usuarios> ObterComFiltroAvancado(string sql)
        {
            List<usuarios> lista = new List<usuarios>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                usuarios novo = new usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idtipousuario = (int)tabela.Rows[a]["idtipousuario"]; Oidtipousuario = (int)tabela.Rows[a]["idtipousuario"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Senha = (string)tabela.Rows[a]["senha"]; Osenha = (string)tabela.Rows[a]["senha"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Foto = tabela.Rows[a]["foto"];  Ofoto= tabela.Rows[a]["foto"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from usuarios").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from usuarios where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from usuarios ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from usuarios where " + where + "");
}


# endregion
    }
}
