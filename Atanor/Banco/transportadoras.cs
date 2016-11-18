using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class transportadoras
    {
        List<dynamic> _valorestransportadoras = new List<dynamic>();
        List<string> _colunatransportadoras = new List<string>();
        List<dynamic> _condicoestransportadoras = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunatransportadoras.Count; a++)
         {
             if (col == _colunatransportadoras[a])
                  {
                       return;
                  }
     }
_colunatransportadoras.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoestransportadoras.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string apelido="apelido";
        public const string cnpj="cnpj";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorestransportadoras.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valorestransportadoras.Add(value); }
        }

        static string Oapelido;
        string apelido;
        public string Apelido
        {
            get { return apelido; }
            set { apelido = value; Add("apelido"); _valorestransportadoras.Add(value); }
        }

        static string Ocnpj;
        string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; Add("cnpj"); _valorestransportadoras.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("transportadoras", TipoDeOperacao.Tipo.InsertMultiplo, _colunatransportadoras,_valorestransportadoras, _condicoestransportadoras);   
        }
        public int Alterar()
        {
if (_condicoestransportadoras.Count > 0)
{
return ExecuteNonSql.Executar("transportadoras", TipoDeOperacao.Tipo.Update, _colunatransportadoras,_valorestransportadoras, _condicoestransportadoras);
}
else
{
List<string> Nometransportadoras = new List<string>();
List<dynamic> Valortransportadoras = new List<dynamic>();
_valorestransportadoras.Clear();
if(Id!=null){ Nometransportadoras.Add("id");
 Valortransportadoras.Add(Oid);
 _valorestransportadoras.Add(Id);
}if(Nome!=null){ Nometransportadoras.Add("nome");
 Valortransportadoras.Add(Onome);
 _valorestransportadoras.Add(Nome);
}if(Apelido!=null){ Nometransportadoras.Add("apelido");
 Valortransportadoras.Add(Oapelido);
 _valorestransportadoras.Add(Apelido);
}if(Cnpj!=null){ Nometransportadoras.Add("cnpj");
 Valortransportadoras.Add(Ocnpj);
 _valorestransportadoras.Add(Cnpj);
}List<dynamic> Condicaotransportadoras = new List<dynamic>();
Condicaotransportadoras.Add(Nometransportadoras);
Condicaotransportadoras.Add(Valortransportadoras);
return ExecuteNonSql.Executar("transportadoras", TipoDeOperacao.Tipo.UpdateCondicional, _colunatransportadoras, _valorestransportadoras, Condicaotransportadoras);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("transportadoras", TipoDeOperacao.Tipo.Delete, _colunatransportadoras,_valorestransportadoras, _condicoestransportadoras);
        }
        static public List<transportadoras> Obter()
        {
            List<transportadoras> lista = new List<transportadoras>();
            DataTable tabela = Select.SelectSQL("select * from transportadoras");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                transportadoras novo = new transportadoras();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<transportadoras> Obter(string where)
        {
            List<transportadoras> lista = new List<transportadoras>();
            DataTable tabela = Select.SelectSQL("select * from transportadoras where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                transportadoras novo = new transportadoras();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<transportadoras> ObterComFiltroAvancado(string sql)
        {
            List<transportadoras> lista = new List<transportadoras>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                transportadoras novo = new transportadoras();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Apelido = (string)tabela.Rows[a]["apelido"]; Oapelido = (string)tabela.Rows[a]["apelido"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from transportadoras").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from transportadoras where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from transportadoras ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from transportadoras where " + where + "");
}


# endregion
    }
}
