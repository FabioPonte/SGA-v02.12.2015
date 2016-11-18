using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class nota_config
    {
        List<dynamic> _valoresnota_config = new List<dynamic>();
        List<string> _colunanota_config = new List<string>();
        List<dynamic> _condicoesnota_config = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunanota_config.Count; a++)
         {
             if (col == _colunanota_config[a])
                  {
                       return;
                  }
     }
_colunanota_config.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesnota_config.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idcd="idcd";
        public const string email="email";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresnota_config.Add(value); }
        }

        static int Oidcd;
        int idcd;
        public int Idcd
        {
            get { return idcd; }
            set { idcd = value; Add("idcd"); _valoresnota_config.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresnota_config.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("nota_config", TipoDeOperacao.Tipo.InsertMultiplo, _colunanota_config,_valoresnota_config, _condicoesnota_config);   
        }
        public int Alterar()
        {
if (_condicoesnota_config.Count > 0)
{
return ExecuteNonSql.Executar("nota_config", TipoDeOperacao.Tipo.Update, _colunanota_config,_valoresnota_config, _condicoesnota_config);
}
else
{
List<string> Nomenota_config = new List<string>();
List<dynamic> Valornota_config = new List<dynamic>();
_valoresnota_config.Clear();
if(Id!=null){ Nomenota_config.Add("id");
 Valornota_config.Add(Oid);
 _valoresnota_config.Add(Id);
}if(Idcd!=null){ Nomenota_config.Add("idcd");
 Valornota_config.Add(Oidcd);
 _valoresnota_config.Add(Idcd);
}if(Email!=null){ Nomenota_config.Add("email");
 Valornota_config.Add(Oemail);
 _valoresnota_config.Add(Email);
}List<dynamic> Condicaonota_config = new List<dynamic>();
Condicaonota_config.Add(Nomenota_config);
Condicaonota_config.Add(Valornota_config);
return ExecuteNonSql.Executar("nota_config", TipoDeOperacao.Tipo.UpdateCondicional, _colunanota_config, _valoresnota_config, Condicaonota_config);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("nota_config", TipoDeOperacao.Tipo.Delete, _colunanota_config,_valoresnota_config, _condicoesnota_config);
        }
        static public List<nota_config> Obter()
        {
            List<nota_config> lista = new List<nota_config>();
            DataTable tabela = Select.SelectSQL("select * from nota_config");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_config novo = new nota_config();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nota_config> Obter(string where)
        {
            List<nota_config> lista = new List<nota_config>();
            DataTable tabela = Select.SelectSQL("select * from nota_config where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_config novo = new nota_config();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nota_config> ObterComFiltroAvancado(string sql)
        {
            List<nota_config> lista = new List<nota_config>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_config novo = new nota_config();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idcd = (int)tabela.Rows[a]["idcd"]; Oidcd = (int)tabela.Rows[a]["idcd"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from nota_config").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from nota_config where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from nota_config ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from nota_config where " + where + "");
}


# endregion
    }
}
