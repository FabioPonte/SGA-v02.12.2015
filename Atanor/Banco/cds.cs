using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class cds
    {
        List<dynamic> _valorescds = new List<dynamic>();
        List<string> _colunacds = new List<string>();
        List<dynamic> _condicoescds = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacds.Count; a++)
         {
             if (col == _colunacds[a])
                  {
                       return;
                  }
     }
_colunacds.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescds.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string centro="centro";
        public const string uf="uf";
        public const string nome="nome";
        public const string local="local";
        public const string cnpj="cnpj";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescds.Add(value); }
        }

        static string Ocentro;
        string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; Add("centro"); _valorescds.Add(value); }
        }

        static string Ouf;
        string uf;
        public string Uf
        {
            get { return uf; }
            set { uf = value; Add("uf"); _valorescds.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valorescds.Add(value); }
        }

        static string Olocal;
        string local;
        public string Local
        {
            get { return local; }
            set { local = value; Add("local"); _valorescds.Add(value); }
        }

        static string Ocnpj;
        string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; Add("cnpj"); _valorescds.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("cds", TipoDeOperacao.Tipo.InsertMultiplo, _colunacds,_valorescds, _condicoescds);   
        }
        public int Alterar()
        {
if (_condicoescds.Count > 0)
{
return ExecuteNonSql.Executar("cds", TipoDeOperacao.Tipo.Update, _colunacds,_valorescds, _condicoescds);
}
else
{
List<string> Nomecds = new List<string>();
List<dynamic> Valorcds = new List<dynamic>();
_valorescds.Clear();
if(Id!=null){ Nomecds.Add("id");
 Valorcds.Add(Oid);
 _valorescds.Add(Id);
}if(Centro!=null){ Nomecds.Add("centro");
 Valorcds.Add(Ocentro);
 _valorescds.Add(Centro);
}if(Uf!=null){ Nomecds.Add("uf");
 Valorcds.Add(Ouf);
 _valorescds.Add(Uf);
}if(Nome!=null){ Nomecds.Add("nome");
 Valorcds.Add(Onome);
 _valorescds.Add(Nome);
}if(Local!=null){ Nomecds.Add("local");
 Valorcds.Add(Olocal);
 _valorescds.Add(Local);
}if(Cnpj!=null){ Nomecds.Add("cnpj");
 Valorcds.Add(Ocnpj);
 _valorescds.Add(Cnpj);
}List<dynamic> Condicaocds = new List<dynamic>();
Condicaocds.Add(Nomecds);
Condicaocds.Add(Valorcds);
return ExecuteNonSql.Executar("cds", TipoDeOperacao.Tipo.UpdateCondicional, _colunacds, _valorescds, Condicaocds);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("cds", TipoDeOperacao.Tipo.Delete, _colunacds,_valorescds, _condicoescds);
        }
        static public List<cds> Obter()
        {
            List<cds> lista = new List<cds>();
            DataTable tabela = Select.SelectSQL("select * from cds");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cds novo = new cds();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Centro = (string)tabela.Rows[a]["centro"]; Ocentro = (string)tabela.Rows[a]["centro"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<cds> Obter(string where)
        {
            List<cds> lista = new List<cds>();
            DataTable tabela = Select.SelectSQL("select * from cds where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cds novo = new cds();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Centro = (string)tabela.Rows[a]["centro"]; Ocentro = (string)tabela.Rows[a]["centro"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<cds> ObterComFiltroAvancado(string sql)
        {
            List<cds> lista = new List<cds>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                cds novo = new cds();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Centro = (string)tabela.Rows[a]["centro"]; Ocentro = (string)tabela.Rows[a]["centro"]; } catch { }
            try {   novo.Uf = (string)tabela.Rows[a]["uf"]; Ouf = (string)tabela.Rows[a]["uf"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Local = (string)tabela.Rows[a]["local"]; Olocal = (string)tabela.Rows[a]["local"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from cds").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from cds where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from cds ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from cds where " + where + "");
}


# endregion
    }
}
