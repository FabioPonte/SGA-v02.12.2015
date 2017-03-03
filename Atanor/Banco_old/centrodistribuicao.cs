using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class centrodistribuicao
    {
        List<dynamic> _valorescentrodistribuicao = new List<dynamic>();
        List<string> _colunacentrodistribuicao = new List<string>();
        List<dynamic> _condicoescentrodistribuicao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunacentrodistribuicao.Count; a++)
         {
             if (col == _colunacentrodistribuicao[a])
                  {
                       return;
                  }
     }
_colunacentrodistribuicao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoescentrodistribuicao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string cidade="cidade";
        public const string cnpj="cnpj";
        public const string estado="estado";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valorescentrodistribuicao.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valorescentrodistribuicao.Add(value); }
        }

        static string Ocidade;
        string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; Add("cidade"); _valorescentrodistribuicao.Add(value); }
        }

        static string Ocnpj;
        string cnpj;
        public string Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; Add("cnpj"); _valorescentrodistribuicao.Add(value); }
        }

        static string Oestado;
        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; Add("estado"); _valorescentrodistribuicao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.InsertMultiplo, _colunacentrodistribuicao,_valorescentrodistribuicao, _condicoescentrodistribuicao);   
        }
        public int Alterar()
        {
if (_condicoescentrodistribuicao.Count > 0)
{
return ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.Update, _colunacentrodistribuicao,_valorescentrodistribuicao, _condicoescentrodistribuicao);
}
else
{
List<string> Nomecentrodistribuicao = new List<string>();
List<dynamic> Valorcentrodistribuicao = new List<dynamic>();
_valorescentrodistribuicao.Clear();
if(Id!=null){ Nomecentrodistribuicao.Add("id");
 Valorcentrodistribuicao.Add(Oid);
 _valorescentrodistribuicao.Add(Id);
}if(Nome!=null){ Nomecentrodistribuicao.Add("nome");
 Valorcentrodistribuicao.Add(Onome);
 _valorescentrodistribuicao.Add(Nome);
}if(Cidade!=null){ Nomecentrodistribuicao.Add("cidade");
 Valorcentrodistribuicao.Add(Ocidade);
 _valorescentrodistribuicao.Add(Cidade);
}if(Cnpj!=null){ Nomecentrodistribuicao.Add("cnpj");
 Valorcentrodistribuicao.Add(Ocnpj);
 _valorescentrodistribuicao.Add(Cnpj);
}if(Estado!=null){ Nomecentrodistribuicao.Add("estado");
 Valorcentrodistribuicao.Add(Oestado);
 _valorescentrodistribuicao.Add(Estado);
}List<dynamic> Condicaocentrodistribuicao = new List<dynamic>();
Condicaocentrodistribuicao.Add(Nomecentrodistribuicao);
Condicaocentrodistribuicao.Add(Valorcentrodistribuicao);
return ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.UpdateCondicional, _colunacentrodistribuicao, _valorescentrodistribuicao, Condicaocentrodistribuicao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("centrodistribuicao", TipoDeOperacao.Tipo.Delete, _colunacentrodistribuicao,_valorescentrodistribuicao, _condicoescentrodistribuicao);
        }
        static public List<centrodistribuicao> Obter()
        {
            List<centrodistribuicao> lista = new List<centrodistribuicao>();
            DataTable tabela = Select.SelectSQL("select * from centrodistribuicao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                centrodistribuicao novo = new centrodistribuicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<centrodistribuicao> Obter(string where)
        {
            List<centrodistribuicao> lista = new List<centrodistribuicao>();
            DataTable tabela = Select.SelectSQL("select * from centrodistribuicao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                centrodistribuicao novo = new centrodistribuicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<centrodistribuicao> ObterComFiltroAvancado(string sql)
        {
            List<centrodistribuicao> lista = new List<centrodistribuicao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                centrodistribuicao novo = new centrodistribuicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Cnpj = (string)tabela.Rows[a]["cnpj"]; Ocnpj = (string)tabela.Rows[a]["cnpj"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from centrodistribuicao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from centrodistribuicao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from centrodistribuicao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from centrodistribuicao where " + where + "");
}


# endregion
    }
}
