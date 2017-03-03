using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class motorista
    {
        List<dynamic> _valoresmotorista = new List<dynamic>();
        List<string> _colunamotorista = new List<string>();
        List<dynamic> _condicoesmotorista = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunamotorista.Count; a++)
         {
             if (col == _colunamotorista[a])
                  {
                       return;
                  }
     }
_colunamotorista.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesmotorista.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string cnh="cnh";
        public const string cpf="cpf";
        public const string vencimento="vencimento";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresmotorista.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresmotorista.Add(value); }
        }

        static string Ocnh;
        string cnh;
        public string Cnh
        {
            get { return cnh; }
            set { cnh = value; Add("cnh"); _valoresmotorista.Add(value); }
        }

        static string Ocpf;
        string cpf;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; Add("cpf"); _valoresmotorista.Add(value); }
        }

        static DateTime Ovencimento;
        DateTime vencimento;
        public DateTime Vencimento
        {
            get { return vencimento; }
            set { vencimento = value; Add("vencimento"); _valoresmotorista.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.InsertMultiplo, _colunamotorista,_valoresmotorista, _condicoesmotorista);   
        }
        public int Alterar()
        {
if (_condicoesmotorista.Count > 0)
{
return ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.Update, _colunamotorista,_valoresmotorista, _condicoesmotorista);
}
else
{
List<string> Nomemotorista = new List<string>();
List<dynamic> Valormotorista = new List<dynamic>();
_valoresmotorista.Clear();
if(Id!=null){ Nomemotorista.Add("id");
 Valormotorista.Add(Oid);
 _valoresmotorista.Add(Id);
}if(Nome!=null){ Nomemotorista.Add("nome");
 Valormotorista.Add(Onome);
 _valoresmotorista.Add(Nome);
}if(Cnh!=null){ Nomemotorista.Add("cnh");
 Valormotorista.Add(Ocnh);
 _valoresmotorista.Add(Cnh);
}if(Cpf!=null){ Nomemotorista.Add("cpf");
 Valormotorista.Add(Ocpf);
 _valoresmotorista.Add(Cpf);
}if(Vencimento!=null){ Nomemotorista.Add("vencimento");
 Valormotorista.Add(Ovencimento);
 _valoresmotorista.Add(Vencimento);
}List<dynamic> Condicaomotorista = new List<dynamic>();
Condicaomotorista.Add(Nomemotorista);
Condicaomotorista.Add(Valormotorista);
return ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.UpdateCondicional, _colunamotorista, _valoresmotorista, Condicaomotorista);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("motorista", TipoDeOperacao.Tipo.Delete, _colunamotorista,_valoresmotorista, _condicoesmotorista);
        }
        static public List<motorista> Obter()
        {
            List<motorista> lista = new List<motorista>();
            DataTable tabela = Select.SelectSQL("select * from motorista");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                motorista novo = new motorista();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnh = (string)tabela.Rows[a]["cnh"]; Ocnh = (string)tabela.Rows[a]["cnh"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Vencimento = (DateTime)tabela.Rows[a]["vencimento"]; Ovencimento = (DateTime)tabela.Rows[a]["vencimento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<motorista> Obter(string where)
        {
            List<motorista> lista = new List<motorista>();
            DataTable tabela = Select.SelectSQL("select * from motorista where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                motorista novo = new motorista();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnh = (string)tabela.Rows[a]["cnh"]; Ocnh = (string)tabela.Rows[a]["cnh"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Vencimento = (DateTime)tabela.Rows[a]["vencimento"]; Ovencimento = (DateTime)tabela.Rows[a]["vencimento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<motorista> ObterComFiltroAvancado(string sql)
        {
            List<motorista> lista = new List<motorista>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                motorista novo = new motorista();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Cnh = (string)tabela.Rows[a]["cnh"]; Ocnh = (string)tabela.Rows[a]["cnh"]; } catch { }
            try {   novo.Cpf = (string)tabela.Rows[a]["cpf"]; Ocpf = (string)tabela.Rows[a]["cpf"]; } catch { }
            try {   novo.Vencimento = (DateTime)tabela.Rows[a]["vencimento"]; Ovencimento = (DateTime)tabela.Rows[a]["vencimento"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from motorista").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from motorista where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from motorista ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from motorista where " + where + "");
}


# endregion
    }
}
