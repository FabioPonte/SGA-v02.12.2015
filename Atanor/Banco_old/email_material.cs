using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class email_material
    {
        List<dynamic> _valoresemail_material = new List<dynamic>();
        List<string> _colunaemail_material = new List<string>();
        List<dynamic> _condicoesemail_material = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaemail_material.Count; a++)
         {
             if (col == _colunaemail_material[a])
                  {
                       return;
                  }
     }
_colunaemail_material.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesemail_material.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string email="email";
        public const string id_config_material="id_config_material";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresemail_material.Add(value); }
        }

        static string Oemail;
        string email;
        public string Email
        {
            get { return email; }
            set { email = value; Add("email"); _valoresemail_material.Add(value); }
        }

        static int Oid_config_material;
        int id_config_material;
        public int Id_config_material
        {
            get { return id_config_material; }
            set { id_config_material = value; Add("id_config_material"); _valoresemail_material.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("email_material", TipoDeOperacao.Tipo.InsertMultiplo, _colunaemail_material,_valoresemail_material, _condicoesemail_material);   
        }
        public int Alterar()
        {
if (_condicoesemail_material.Count > 0)
{
return ExecuteNonSql.Executar("email_material", TipoDeOperacao.Tipo.Update, _colunaemail_material,_valoresemail_material, _condicoesemail_material);
}
else
{
List<string> Nomeemail_material = new List<string>();
List<dynamic> Valoremail_material = new List<dynamic>();
_valoresemail_material.Clear();
if(Id!=null){ Nomeemail_material.Add("id");
 Valoremail_material.Add(Oid);
 _valoresemail_material.Add(Id);
}if(Email!=null){ Nomeemail_material.Add("email");
 Valoremail_material.Add(Oemail);
 _valoresemail_material.Add(Email);
}if(Id_config_material!=null){ Nomeemail_material.Add("id_config_material");
 Valoremail_material.Add(Oid_config_material);
 _valoresemail_material.Add(Id_config_material);
}List<dynamic> Condicaoemail_material = new List<dynamic>();
Condicaoemail_material.Add(Nomeemail_material);
Condicaoemail_material.Add(Valoremail_material);
return ExecuteNonSql.Executar("email_material", TipoDeOperacao.Tipo.UpdateCondicional, _colunaemail_material, _valoresemail_material, Condicaoemail_material);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("email_material", TipoDeOperacao.Tipo.Delete, _colunaemail_material,_valoresemail_material, _condicoesemail_material);
        }
        static public List<email_material> Obter()
        {
            List<email_material> lista = new List<email_material>();
            DataTable tabela = Select.SelectSQL("select * from email_material");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                email_material novo = new email_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Id_config_material = (int)tabela.Rows[a]["id_config_material"]; Oid_config_material = (int)tabela.Rows[a]["id_config_material"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<email_material> Obter(string where)
        {
            List<email_material> lista = new List<email_material>();
            DataTable tabela = Select.SelectSQL("select * from email_material where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                email_material novo = new email_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Id_config_material = (int)tabela.Rows[a]["id_config_material"]; Oid_config_material = (int)tabela.Rows[a]["id_config_material"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<email_material> ObterComFiltroAvancado(string sql)
        {
            List<email_material> lista = new List<email_material>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                email_material novo = new email_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Email = (string)tabela.Rows[a]["email"]; Oemail = (string)tabela.Rows[a]["email"]; } catch { }
            try {   novo.Id_config_material = (int)tabela.Rows[a]["id_config_material"]; Oid_config_material = (int)tabela.Rows[a]["id_config_material"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from email_material").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from email_material where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from email_material ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from email_material where " + where + "");
}


# endregion
    }
}
