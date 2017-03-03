using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class info_usuarios
    {
        List<dynamic> _valoresinfo_usuarios = new List<dynamic>();
        List<string> _colunainfo_usuarios = new List<string>();
        List<dynamic> _condicoesinfo_usuarios = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunainfo_usuarios.Count; a++)
         {
             if (col == _colunainfo_usuarios[a])
                  {
                       return;
                  }
     }
_colunainfo_usuarios.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesinfo_usuarios.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string email="email";
        public const string nome="nome";
        public const string telefone1="telefone1";
        public const string telefone2="telefone2";
        public const string telefone3="telefone3";
        public const string ramal="ramal";
        public const string empresa="empresa";
        public const string setor="setor";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresinfo_usuarios.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresinfo_usuarios.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresinfo_usuarios.Add(value); }
        }

        static string Otelefone1;
        string telefone1;
        public string Telefone1
        {
            get { return telefone1; }
            set { telefone1 = value; Add("telefone1"); _valoresinfo_usuarios.Add(value); }
        }

        static string Otelefone2;
        string telefone2;
        public string Telefone2
        {
            get { return telefone2; }
            set { telefone2 = value; Add("telefone2"); _valoresinfo_usuarios.Add(value); }
        }

        static string Otelefone3;
        string telefone3;
        public string Telefone3
        {
            get { return telefone3; }
            set { telefone3 = value; Add("telefone3"); _valoresinfo_usuarios.Add(value); }
        }

        static string Oramal;
        string ramal;
        public string Ramal
        {
            get { return ramal; }
            set { ramal = value; Add("ramal"); _valoresinfo_usuarios.Add(value); }
        }

        static string Oempresa;
        string empresa;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; Add("empresa"); _valoresinfo_usuarios.Add(value); }
        }

        static string Osetor;
        string setor;
        public string Setor
        {
            get { return setor; }
            set { setor = value; Add("setor"); _valoresinfo_usuarios.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("info_usuarios", TipoDeOperacao.Tipo.InsertMultiplo, _colunainfo_usuarios,_valoresinfo_usuarios, _condicoesinfo_usuarios);   
        }
        public int Alterar()
        {
if (_condicoesinfo_usuarios.Count > 0)
{
return ExecuteNonSql.Executar("info_usuarios", TipoDeOperacao.Tipo.Update, _colunainfo_usuarios,_valoresinfo_usuarios, _condicoesinfo_usuarios);
}
else
{
List<string> Nomeinfo_usuarios = new List<string>();
List<dynamic> Valorinfo_usuarios = new List<dynamic>();
_valoresinfo_usuarios.Clear();
if(Id!=null){ Nomeinfo_usuarios.Add("id");
 Valorinfo_usuarios.Add(Oid);
 _valoresinfo_usuarios.Add(Id);
}if(Email!=null){ Nomeinfo_usuarios.Add("email");
 Valorinfo_usuarios.Add(Oemail);
 _valoresinfo_usuarios.Add(Email);
}if(Nome!=null){ Nomeinfo_usuarios.Add("nome");
 Valorinfo_usuarios.Add(Onome);
 _valoresinfo_usuarios.Add(Nome);
}if(Telefone1!=null){ Nomeinfo_usuarios.Add("telefone1");
 Valorinfo_usuarios.Add(Otelefone1);
 _valoresinfo_usuarios.Add(Telefone1);
}if(Telefone2!=null){ Nomeinfo_usuarios.Add("telefone2");
 Valorinfo_usuarios.Add(Otelefone2);
 _valoresinfo_usuarios.Add(Telefone2);
}if(Telefone3!=null){ Nomeinfo_usuarios.Add("telefone3");
 Valorinfo_usuarios.Add(Otelefone3);
 _valoresinfo_usuarios.Add(Telefone3);
}if(Ramal!=null){ Nomeinfo_usuarios.Add("ramal");
 Valorinfo_usuarios.Add(Oramal);
 _valoresinfo_usuarios.Add(Ramal);
}if(Empresa!=null){ Nomeinfo_usuarios.Add("empresa");
 Valorinfo_usuarios.Add(Oempresa);
 _valoresinfo_usuarios.Add(Empresa);
}if(Setor!=null){ Nomeinfo_usuarios.Add("setor");
 Valorinfo_usuarios.Add(Osetor);
 _valoresinfo_usuarios.Add(Setor);
}List<dynamic> Condicaoinfo_usuarios = new List<dynamic>();
Condicaoinfo_usuarios.Add(Nomeinfo_usuarios);
Condicaoinfo_usuarios.Add(Valorinfo_usuarios);
return ExecuteNonSql.Executar("info_usuarios", TipoDeOperacao.Tipo.UpdateCondicional, _colunainfo_usuarios, _valoresinfo_usuarios, Condicaoinfo_usuarios);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("info_usuarios", TipoDeOperacao.Tipo.Delete, _colunainfo_usuarios,_valoresinfo_usuarios, _condicoesinfo_usuarios);
        }
        static public List<info_usuarios> Obter()
        {
            List<info_usuarios> lista = new List<info_usuarios>();
            DataTable tabela = Select.SelectSQL("select * from info_usuarios");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                info_usuarios novo = new info_usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Telefone1 = (string)tabela.Rows[a]["telefone1"]; Otelefone1 = (string)tabela.Rows[a]["telefone1"]; } catch { }
            try {   novo.Telefone2 = (string)tabela.Rows[a]["telefone2"]; Otelefone2 = (string)tabela.Rows[a]["telefone2"]; } catch { }
            try {   novo.Telefone3 = (string)tabela.Rows[a]["telefone3"]; Otelefone3 = (string)tabela.Rows[a]["telefone3"]; } catch { }
            try {   novo.Ramal = (string)tabela.Rows[a]["ramal"]; Oramal = (string)tabela.Rows[a]["ramal"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<info_usuarios> Obter(string where)
        {
            List<info_usuarios> lista = new List<info_usuarios>();
            DataTable tabela = Select.SelectSQL("select * from info_usuarios where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                info_usuarios novo = new info_usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Telefone1 = (string)tabela.Rows[a]["telefone1"]; Otelefone1 = (string)tabela.Rows[a]["telefone1"]; } catch { }
            try {   novo.Telefone2 = (string)tabela.Rows[a]["telefone2"]; Otelefone2 = (string)tabela.Rows[a]["telefone2"]; } catch { }
            try {   novo.Telefone3 = (string)tabela.Rows[a]["telefone3"]; Otelefone3 = (string)tabela.Rows[a]["telefone3"]; } catch { }
            try {   novo.Ramal = (string)tabela.Rows[a]["ramal"]; Oramal = (string)tabela.Rows[a]["ramal"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<info_usuarios> ObterComFiltroAvancado(string sql)
        {
            List<info_usuarios> lista = new List<info_usuarios>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                info_usuarios novo = new info_usuarios();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Telefone1 = (string)tabela.Rows[a]["telefone1"]; Otelefone1 = (string)tabela.Rows[a]["telefone1"]; } catch { }
            try {   novo.Telefone2 = (string)tabela.Rows[a]["telefone2"]; Otelefone2 = (string)tabela.Rows[a]["telefone2"]; } catch { }
            try {   novo.Telefone3 = (string)tabela.Rows[a]["telefone3"]; Otelefone3 = (string)tabela.Rows[a]["telefone3"]; } catch { }
            try {   novo.Ramal = (string)tabela.Rows[a]["ramal"]; Oramal = (string)tabela.Rows[a]["ramal"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from info_usuarios").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from info_usuarios where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from info_usuarios ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from info_usuarios where " + where + "");
}


# endregion
    }
}
