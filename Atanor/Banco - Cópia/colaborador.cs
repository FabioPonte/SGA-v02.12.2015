using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class colaborador
    {
        List<dynamic> _valorescolaborador = new List<dynamic>();
        List<string> _colunacolaborador = new List<string>();
        List<dynamic> _condicoescolaborador = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacolaborador.Count; a++)
         {
             if (col == _colunacolaborador[a])
                  {
                       return;
                  }
     }
_colunacolaborador.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescolaborador.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string cpf="cpf";
        public const string rg="rg";
        public const string cnpj="cnpj";
        public const string setor="setor";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescolaborador.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valorescolaborador.Add(value); }
        }

        static string Ocpf;
        string cpf;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; Add("cpf"); _valorescolaborador.Add(value); }
        }

        static string Org;
        string rg;
        public string Rg
        {
            get { return rg; }
            set { rg = value; Add("rg"); _valorescolaborador.Add(value); }
        }

        static string Ocnpj;
        string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; Add("cnpj"); _valorescolaborador.Add(value); }
        }

        static string Osetor;
        string setor;
        public string Setor
        {
            get { return setor; }
            set { setor = value; Add("setor"); _valorescolaborador.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("colaborador", TipoDeOperacao.Tipo.InsertMultiplo, _colunacolaborador,_valorescolaborador, _condicoescolaborador);   
        }
        public int Alterar()
        {
if (_condicoescolaborador.Count > 0)
{
return ExecuteNonSql.Executar("colaborador", TipoDeOperacao.Tipo.Update, _colunacolaborador,_valorescolaborador, _condicoescolaborador);
}
else
{
List<string> Nomecolaborador = new List<string>();
List<dynamic> Valorcolaborador = new List<dynamic>();
_valorescolaborador.Clear();
if(Id!=null){ Nomecolaborador.Add("id");
 Valorcolaborador.Add(Oid);
 _valorescolaborador.Add(Id);
}if(Nome!=null){ Nomecolaborador.Add("nome");
 Valorcolaborador.Add(Onome);
 _valorescolaborador.Add(Nome);
}if(Cpf!=null){ Nomecolaborador.Add("cpf");
 Valorcolaborador.Add(Ocpf);
 _valorescolaborador.Add(Cpf);
}if(Rg!=null){ Nomecolaborador.Add("rg");
 Valorcolaborador.Add(Org);
 _valorescolaborador.Add(Rg);
}if(Cnpj!=null){ Nomecolaborador.Add("cnpj");
 Valorcolaborador.Add(Ocnpj);
 _valorescolaborador.Add(Cnpj);
}if(Setor!=null){ Nomecolaborador.Add("setor");
 Valorcolaborador.Add(Osetor);
 _valorescolaborador.Add(Setor);
}List<dynamic> Condicaocolaborador = new List<dynamic>();
Condicaocolaborador.Add(Nomecolaborador);
Condicaocolaborador.Add(Valorcolaborador);
return ExecuteNonSql.Executar("colaborador", TipoDeOperacao.Tipo.UpdateCondicional, _colunacolaborador, _valorescolaborador, Condicaocolaborador);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("colaborador", TipoDeOperacao.Tipo.Delete, _colunacolaborador,_valorescolaborador, _condicoescolaborador);
        }
        static public List<colaborador> Obter()
        {
            List<colaborador> lista = new List<colaborador>();
            DataTable tabela = Select.SelectSQL("select * from colaborador");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                colaborador novo = new colaborador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Rg = (string)tabela.Rows[a]["rg"]; Org = (string)tabela.Rows[a]["rg"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<colaborador> Obter(string where)
        {
            List<colaborador> lista = new List<colaborador>();
            DataTable tabela = Select.SelectSQL("select * from colaborador where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                colaborador novo = new colaborador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Rg = (string)tabela.Rows[a]["rg"]; Org = (string)tabela.Rows[a]["rg"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<colaborador> ObterComFiltroAvancado(string sql)
        {
            List<colaborador> lista = new List<colaborador>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                colaborador novo = new colaborador();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Rg = (string)tabela.Rows[a]["rg"]; Org = (string)tabela.Rows[a]["rg"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Setor = (string)tabela.Rows[a]["setor"]; Osetor = (string)tabela.Rows[a]["setor"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from colaborador").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from colaborador where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from colaborador ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from colaborador where " + where + "");
}


# endregion
    }
}
