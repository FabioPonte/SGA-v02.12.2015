using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class aviso
    {
        List<dynamic> _valoresaviso = new List<dynamic>();
        List<string> _colunaaviso = new List<string>();
        List<dynamic> _condicoesaviso = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaaviso.Count; a++)
         {
             if (col == _colunaaviso[a])
                  {
                       return;
                  }
     }
_colunaaviso.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesaviso.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string empresa="empresa";
        public const string produto="produto";
        public const string placa="placa";
        public const string motorista="motorista";
        public const string nota="nota";
        public const string idmotorista="idmotorista";
        public const string data="data";
        public const string container="container";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresaviso.Add(value); }
        }

        static string Oempresa;
        string empresa;
        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; Add("empresa"); _valoresaviso.Add(value); }
        }

        static string Oproduto;
        string produto;
        public string Produto
        {
            get { return produto; }
            set { produto = value; Add("produto"); _valoresaviso.Add(value); }
        }

        static string Oplaca;
        string placa;
        public string Placa
        {
            get { return placa; }
            set { placa = value; Add("placa"); _valoresaviso.Add(value); }
        }

        static string Omotorista;
        string motorista;
        public string Motorista
        {
            get { return motorista; }
            set { motorista = value; Add("motorista"); _valoresaviso.Add(value); }
        }

        static string Onota;
        string nota;
        public string Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresaviso.Add(value); }
        }

        static int Oidmotorista;
        int idmotorista;
        public int Idmotorista
        {
            get { return idmotorista; }
            set { idmotorista = value; Add("idmotorista"); _valoresaviso.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresaviso.Add(value); }
        }

        static string Ocontainer;
        string container;
        public string Container
        {
            get { return container; }
            set { container = value; Add("container"); _valoresaviso.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("aviso", TipoDeOperacao.Tipo.InsertMultiplo, _colunaaviso,_valoresaviso, _condicoesaviso);   
        }
        public int Alterar()
        {
if (_condicoesaviso.Count > 0)
{
return ExecuteNonSql.Executar("aviso", TipoDeOperacao.Tipo.Update, _colunaaviso,_valoresaviso, _condicoesaviso);
}
else
{
List<string> Nomeaviso = new List<string>();
List<dynamic> Valoraviso = new List<dynamic>();
_valoresaviso.Clear();
if(Id!=null){ Nomeaviso.Add("id");
 Valoraviso.Add(Oid);
 _valoresaviso.Add(Id);
}if(Empresa!=null){ Nomeaviso.Add("empresa");
 Valoraviso.Add(Oempresa);
 _valoresaviso.Add(Empresa);
}if(Produto!=null){ Nomeaviso.Add("produto");
 Valoraviso.Add(Oproduto);
 _valoresaviso.Add(Produto);
}if(Placa!=null){ Nomeaviso.Add("placa");
 Valoraviso.Add(Oplaca);
 _valoresaviso.Add(Placa);
}if(Motorista!=null){ Nomeaviso.Add("motorista");
 Valoraviso.Add(Omotorista);
 _valoresaviso.Add(Motorista);
}if(Nota!=null){ Nomeaviso.Add("nota");
 Valoraviso.Add(Onota);
 _valoresaviso.Add(Nota);
}if(Idmotorista!=null){ Nomeaviso.Add("idmotorista");
 Valoraviso.Add(Oidmotorista);
 _valoresaviso.Add(Idmotorista);
}if(Data!=null){ Nomeaviso.Add("data");
 Valoraviso.Add(Odata);
 _valoresaviso.Add(Data);
}if(Container!=null){ Nomeaviso.Add("container");
 Valoraviso.Add(Ocontainer);
 _valoresaviso.Add(Container);
}List<dynamic> Condicaoaviso = new List<dynamic>();
Condicaoaviso.Add(Nomeaviso);
Condicaoaviso.Add(Valoraviso);
return ExecuteNonSql.Executar("aviso", TipoDeOperacao.Tipo.UpdateCondicional, _colunaaviso, _valoresaviso, Condicaoaviso);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("aviso", TipoDeOperacao.Tipo.Delete, _colunaaviso,_valoresaviso, _condicoesaviso);
        }
        static public List<aviso> Obter()
        {
            List<aviso> lista = new List<aviso>();
            DataTable tabela = Select.SelectSQL("select * from aviso");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso novo = new aviso();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Container = (string)tabela.Rows[a]["container"]; Ocontainer = (string)tabela.Rows[a]["container"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<aviso> Obter(string where)
        {
            List<aviso> lista = new List<aviso>();
            DataTable tabela = Select.SelectSQL("select * from aviso where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso novo = new aviso();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Container = (string)tabela.Rows[a]["container"]; Ocontainer = (string)tabela.Rows[a]["container"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<aviso> ObterComFiltroAvancado(string sql)
        {
            List<aviso> lista = new List<aviso>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                aviso novo = new aviso();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Empresa = (string)tabela.Rows[a]["empresa"]; Oempresa = (string)tabela.Rows[a]["empresa"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Nota = (string)tabela.Rows[a]["nota"]; Onota = (string)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Idmotorista = (int)tabela.Rows[a]["idmotorista"]; Oidmotorista = (int)tabela.Rows[a]["idmotorista"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Container = (string)tabela.Rows[a]["container"]; Ocontainer = (string)tabela.Rows[a]["container"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from aviso").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from aviso where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from aviso ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from aviso where " + where + "");
}


# endregion
    }
}
