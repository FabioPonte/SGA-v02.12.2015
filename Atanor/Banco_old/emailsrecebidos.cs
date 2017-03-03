using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class emailsrecebidos
    {
        List<dynamic> _valoresemailsrecebidos = new List<dynamic>();
        List<string> _colunaemailsrecebidos = new List<string>();
        List<dynamic> _condicoesemailsrecebidos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemailsrecebidos.Count; a++)
         {
             if (col == _colunaemailsrecebidos[a])
                  {
                       return;
                  }
     }
_colunaemailsrecebidos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemailsrecebidos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string poschamado_id="poschamado_id";
        public const string email="email";
        public const string nome="nome";
        public const string ohost="ohost";
        public const string usuario="usuario";
        public const string oto="oto";
        public const string cc="cc";
        public const string bcc="bcc";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemailsrecebidos.Add(value); }
        }

        static int Oposchamado_id;
        int poschamado_id;
        public int Poschamado_id
        {
            get { return poschamado_id; }
            set { poschamado_id = value; Add("poschamado_id"); _valoresemailsrecebidos.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresemailsrecebidos.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresemailsrecebidos.Add(value); }
        }

        static string Oohost;
        string ohost;
        public string Ohost
        {
            get { return ohost; }
            set { ohost = value; Add("ohost"); _valoresemailsrecebidos.Add(value); }
        }

        static string Ousuario;
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; Add("usuario"); _valoresemailsrecebidos.Add(value); }
        }

        static Boolean Ooto;
        Boolean oto;
        public Boolean Oto
        {
            get { return oto; }
            set { oto = value; Add("oto"); _valoresemailsrecebidos.Add(value); }
        }

        static Boolean Occ;
        Boolean cc;
        public Boolean Cc
        {
            get { return cc; }
            set { cc = value; Add("cc"); _valoresemailsrecebidos.Add(value); }
        }

        static Boolean Obcc;
        Boolean bcc;
        public Boolean Bcc
        {
            get { return bcc; }
            set { bcc = value; Add("bcc"); _valoresemailsrecebidos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("emailsrecebidos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemailsrecebidos,_valoresemailsrecebidos, _condicoesemailsrecebidos);   
        }
        public int Alterar()
        {
if (_condicoesemailsrecebidos.Count > 0)
{
return ExecuteNonSql.Executar("emailsrecebidos", TipoDeOperacao.Tipo.Update, _colunaemailsrecebidos,_valoresemailsrecebidos, _condicoesemailsrecebidos);
}
else
{
List<string> Nomeemailsrecebidos = new List<string>();
List<dynamic> Valoremailsrecebidos = new List<dynamic>();
_valoresemailsrecebidos.Clear();
if(Id!=null){ Nomeemailsrecebidos.Add("id");
 Valoremailsrecebidos.Add(Oid);
 _valoresemailsrecebidos.Add(Id);
}if(Poschamado_id!=null){ Nomeemailsrecebidos.Add("poschamado_id");
 Valoremailsrecebidos.Add(Oposchamado_id);
 _valoresemailsrecebidos.Add(Poschamado_id);
}if(Email!=null){ Nomeemailsrecebidos.Add("email");
 Valoremailsrecebidos.Add(Oemail);
 _valoresemailsrecebidos.Add(Email);
}if(Nome!=null){ Nomeemailsrecebidos.Add("nome");
 Valoremailsrecebidos.Add(Onome);
 _valoresemailsrecebidos.Add(Nome);
}if(Ohost!=null){ Nomeemailsrecebidos.Add("ohost");
 Valoremailsrecebidos.Add(Oohost);
 _valoresemailsrecebidos.Add(Ohost);
}if(Usuario!=null){ Nomeemailsrecebidos.Add("usuario");
 Valoremailsrecebidos.Add(Ousuario);
 _valoresemailsrecebidos.Add(Usuario);
}if(Oto!=null){ Nomeemailsrecebidos.Add("oto");
 Valoremailsrecebidos.Add(Ooto);
 _valoresemailsrecebidos.Add(Oto);
}if(Cc!=null){ Nomeemailsrecebidos.Add("cc");
 Valoremailsrecebidos.Add(Occ);
 _valoresemailsrecebidos.Add(Cc);
}if(Bcc!=null){ Nomeemailsrecebidos.Add("bcc");
 Valoremailsrecebidos.Add(Obcc);
 _valoresemailsrecebidos.Add(Bcc);
}List<dynamic> Condicaoemailsrecebidos = new List<dynamic>();
Condicaoemailsrecebidos.Add(Nomeemailsrecebidos);
Condicaoemailsrecebidos.Add(Valoremailsrecebidos);
return ExecuteNonSql.Executar("emailsrecebidos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemailsrecebidos, _valoresemailsrecebidos, Condicaoemailsrecebidos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("emailsrecebidos", TipoDeOperacao.Tipo.Delete, _colunaemailsrecebidos,_valoresemailsrecebidos, _condicoesemailsrecebidos);
        }
        static public List<emailsrecebidos> Obter()
        {
            List<emailsrecebidos> lista = new List<emailsrecebidos>();
            DataTable tabela = Select.SelectSQL("select * from emailsrecebidos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emailsrecebidos novo = new emailsrecebidos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ohost = (string)tabela.Rows[a]["ohost"]; Oohost = (string)tabela.Rows[a]["ohost"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Oto = Convert.ToBoolean(tabela.Rows[a]["oto"]);  Ooto= Convert.ToBoolean(tabela.Rows[a]["oto"]); } catch { }
            try {   novo.Cc = Convert.ToBoolean(tabela.Rows[a]["cc"]);  Occ= Convert.ToBoolean(tabela.Rows[a]["cc"]); } catch { }
            try {   novo.Bcc = Convert.ToBoolean(tabela.Rows[a]["bcc"]);  Obcc= Convert.ToBoolean(tabela.Rows[a]["bcc"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emailsrecebidos> Obter(string where)
        {
            List<emailsrecebidos> lista = new List<emailsrecebidos>();
            DataTable tabela = Select.SelectSQL("select * from emailsrecebidos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emailsrecebidos novo = new emailsrecebidos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ohost = (string)tabela.Rows[a]["ohost"]; Oohost = (string)tabela.Rows[a]["ohost"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Oto = Convert.ToBoolean(tabela.Rows[a]["oto"]);  Ooto= Convert.ToBoolean(tabela.Rows[a]["oto"]); } catch { }
            try {   novo.Cc = Convert.ToBoolean(tabela.Rows[a]["cc"]);  Occ= Convert.ToBoolean(tabela.Rows[a]["cc"]); } catch { }
            try {   novo.Bcc = Convert.ToBoolean(tabela.Rows[a]["bcc"]);  Obcc= Convert.ToBoolean(tabela.Rows[a]["bcc"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<emailsrecebidos> ObterComFiltroAvancado(string sql)
        {
            List<emailsrecebidos> lista = new List<emailsrecebidos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                emailsrecebidos novo = new emailsrecebidos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Ohost = (string)tabela.Rows[a]["ohost"]; Oohost = (string)tabela.Rows[a]["ohost"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Oto = Convert.ToBoolean(tabela.Rows[a]["oto"]);  Ooto= Convert.ToBoolean(tabela.Rows[a]["oto"]); } catch { }
            try {   novo.Cc = Convert.ToBoolean(tabela.Rows[a]["cc"]);  Occ= Convert.ToBoolean(tabela.Rows[a]["cc"]); } catch { }
            try {   novo.Bcc = Convert.ToBoolean(tabela.Rows[a]["bcc"]);  Obcc= Convert.ToBoolean(tabela.Rows[a]["bcc"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from emailsrecebidos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from emailsrecebidos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from emailsrecebidos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from emailsrecebidos where " + where + "");
}


# endregion
    }
}
