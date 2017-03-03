using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class nota_expedicao
    {
        List<dynamic> _valoresnota_expedicao = new List<dynamic>();
        List<string> _colunanota_expedicao = new List<string>();
        List<dynamic> _condicoesnota_expedicao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunanota_expedicao.Count; a++)
         {
             if (col == _colunanota_expedicao[a])
                  {
                       return;
                  }
     }
_colunanota_expedicao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesnota_expedicao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nota="nota";
        public const string nota_triangulacao="nota_triangulacao";
        public const string triangulacao="triangulacao";
        public const string cd="cd";
        public const string expedida="expedida";
        public const string obs="obs";
        public const string cfop="cfop";
        public const string cliente="cliente";
        public const string cidade="cidade";
        public const string estado="estado";
        public const string data="data";
        public const string motivo="motivo";
        public const string excluida="excluida";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresnota_expedicao.Add(value); }
        }

        static int Onota;
        int nota;
        public int Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresnota_expedicao.Add(value); }
        }

        static int Onota_triangulacao;
        int nota_triangulacao;
        public int Nota_triangulacao
        {
            get { return nota_triangulacao; }
            set { nota_triangulacao = value; Add("nota_triangulacao"); _valoresnota_expedicao.Add(value); }
        }

        static int Otriangulacao;
        int triangulacao;
        public int Triangulacao
        {
            get { return triangulacao; }
            set { triangulacao = value; Add("triangulacao"); _valoresnota_expedicao.Add(value); }
        }

        static string Ocd;
        string cd;
        public string Cd
        {
            get { return cd; }
            set { cd = value; Add("cd"); _valoresnota_expedicao.Add(value); }
        }

        static int Oexpedida;
        int expedida;
        public int Expedida
        {
            get { return expedida; }
            set { expedida = value; Add("expedida"); _valoresnota_expedicao.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresnota_expedicao.Add(value); }
        }

        static string Ocfop;
        string cfop;
        public string Cfop
        {
            get { return cfop; }
            set { cfop = value; Add("cfop"); _valoresnota_expedicao.Add(value); }
        }

        static string Ocliente;
        string cliente;
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; Add("cliente"); _valoresnota_expedicao.Add(value); }
        }

        static string Ocidade;
        string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; Add("cidade"); _valoresnota_expedicao.Add(value); }
        }

        static string Oestado;
        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; Add("estado"); _valoresnota_expedicao.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresnota_expedicao.Add(value); }
        }

        static string Omotivo;
        string motivo;
        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; Add("motivo"); _valoresnota_expedicao.Add(value); }
        }

        static int Oexcluida;
        int excluida;
        public int Excluida
        {
            get { return excluida; }
            set { excluida = value; Add("excluida"); _valoresnota_expedicao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("nota_expedicao", TipoDeOperacao.Tipo.InsertMultiplo, _colunanota_expedicao,_valoresnota_expedicao, _condicoesnota_expedicao);   
        }
        public int Alterar()
        {
if (_condicoesnota_expedicao.Count > 0)
{
return ExecuteNonSql.Executar("nota_expedicao", TipoDeOperacao.Tipo.Update, _colunanota_expedicao,_valoresnota_expedicao, _condicoesnota_expedicao);
}
else
{
List<string> Nomenota_expedicao = new List<string>();
List<dynamic> Valornota_expedicao = new List<dynamic>();
_valoresnota_expedicao.Clear();
if(Id!=null){ Nomenota_expedicao.Add("id");
 Valornota_expedicao.Add(Oid);
 _valoresnota_expedicao.Add(Id);
}if(Nota!=null){ Nomenota_expedicao.Add("nota");
 Valornota_expedicao.Add(Onota);
 _valoresnota_expedicao.Add(Nota);
}if(Nota_triangulacao!=null){ Nomenota_expedicao.Add("nota_triangulacao");
 Valornota_expedicao.Add(Onota_triangulacao);
 _valoresnota_expedicao.Add(Nota_triangulacao);
}if(Triangulacao!=null){ Nomenota_expedicao.Add("triangulacao");
 Valornota_expedicao.Add(Otriangulacao);
 _valoresnota_expedicao.Add(Triangulacao);
}if(Cd!=null){ Nomenota_expedicao.Add("cd");
 Valornota_expedicao.Add(Ocd);
 _valoresnota_expedicao.Add(Cd);
}if(Expedida!=null){ Nomenota_expedicao.Add("expedida");
 Valornota_expedicao.Add(Oexpedida);
 _valoresnota_expedicao.Add(Expedida);
}if(Obs!=null){ Nomenota_expedicao.Add("obs");
 Valornota_expedicao.Add(Oobs);
 _valoresnota_expedicao.Add(Obs);
}if(Cfop!=null){ Nomenota_expedicao.Add("cfop");
 Valornota_expedicao.Add(Ocfop);
 _valoresnota_expedicao.Add(Cfop);
}if(Cliente!=null){ Nomenota_expedicao.Add("cliente");
 Valornota_expedicao.Add(Ocliente);
 _valoresnota_expedicao.Add(Cliente);
}if(Cidade!=null){ Nomenota_expedicao.Add("cidade");
 Valornota_expedicao.Add(Ocidade);
 _valoresnota_expedicao.Add(Cidade);
}if(Estado!=null){ Nomenota_expedicao.Add("estado");
 Valornota_expedicao.Add(Oestado);
 _valoresnota_expedicao.Add(Estado);
}if(Data!=null){ Nomenota_expedicao.Add("data");
 Valornota_expedicao.Add(Odata);
 _valoresnota_expedicao.Add(Data);
}if(Motivo!=null){ Nomenota_expedicao.Add("motivo");
 Valornota_expedicao.Add(Omotivo);
 _valoresnota_expedicao.Add(Motivo);
}if(Excluida!=null){ Nomenota_expedicao.Add("excluida");
 Valornota_expedicao.Add(Oexcluida);
 _valoresnota_expedicao.Add(Excluida);
}List<dynamic> Condicaonota_expedicao = new List<dynamic>();
Condicaonota_expedicao.Add(Nomenota_expedicao);
Condicaonota_expedicao.Add(Valornota_expedicao);
return ExecuteNonSql.Executar("nota_expedicao", TipoDeOperacao.Tipo.UpdateCondicional, _colunanota_expedicao, _valoresnota_expedicao, Condicaonota_expedicao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("nota_expedicao", TipoDeOperacao.Tipo.Delete, _colunanota_expedicao,_valoresnota_expedicao, _condicoesnota_expedicao);
        }
        static public List<nota_expedicao> Obter()
        {
            List<nota_expedicao> lista = new List<nota_expedicao>();
            DataTable tabela = Select.SelectSQL("select * from nota_expedicao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_expedicao novo = new nota_expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Nota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; Onota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; } catch { }
            try {   novo.Triangulacao = (int)tabela.Rows[a]["triangulacao"]; Otriangulacao = (int)tabela.Rows[a]["triangulacao"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Expedida = (int)tabela.Rows[a]["expedida"]; Oexpedida = (int)tabela.Rows[a]["expedida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cfop = (string)tabela.Rows[a]["cfop"]; Ocfop = (string)tabela.Rows[a]["cfop"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
            try {   novo.Excluida = (int)tabela.Rows[a]["excluida"]; Oexcluida = (int)tabela.Rows[a]["excluida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nota_expedicao> Obter(string where)
        {
            List<nota_expedicao> lista = new List<nota_expedicao>();
            DataTable tabela = Select.SelectSQL("select * from nota_expedicao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_expedicao novo = new nota_expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Nota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; Onota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; } catch { }
            try {   novo.Triangulacao = (int)tabela.Rows[a]["triangulacao"]; Otriangulacao = (int)tabela.Rows[a]["triangulacao"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Expedida = (int)tabela.Rows[a]["expedida"]; Oexpedida = (int)tabela.Rows[a]["expedida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cfop = (string)tabela.Rows[a]["cfop"]; Ocfop = (string)tabela.Rows[a]["cfop"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
            try {   novo.Excluida = (int)tabela.Rows[a]["excluida"]; Oexcluida = (int)tabela.Rows[a]["excluida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<nota_expedicao> ObterComFiltroAvancado(string sql)
        {
            List<nota_expedicao> lista = new List<nota_expedicao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                nota_expedicao novo = new nota_expedicao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Nota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; Onota_triangulacao = (int)tabela.Rows[a]["nota_triangulacao"]; } catch { }
            try {   novo.Triangulacao = (int)tabela.Rows[a]["triangulacao"]; Otriangulacao = (int)tabela.Rows[a]["triangulacao"]; } catch { }
            try {   novo.Cd = (string)tabela.Rows[a]["cd"]; Ocd = (string)tabela.Rows[a]["cd"]; } catch { }
            try {   novo.Expedida = (int)tabela.Rows[a]["expedida"]; Oexpedida = (int)tabela.Rows[a]["expedida"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cfop = (string)tabela.Rows[a]["cfop"]; Ocfop = (string)tabela.Rows[a]["cfop"]; } catch { }
            try {   novo.Cliente = (string)tabela.Rows[a]["cliente"]; Ocliente = (string)tabela.Rows[a]["cliente"]; } catch { }
            try {   novo.Cidade = (string)tabela.Rows[a]["cidade"]; Ocidade = (string)tabela.Rows[a]["cidade"]; } catch { }
            try {   novo.Estado = (string)tabela.Rows[a]["estado"]; Oestado = (string)tabela.Rows[a]["estado"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Motivo = (string)tabela.Rows[a]["motivo"]; Omotivo = (string)tabela.Rows[a]["motivo"]; } catch { }
            try {   novo.Excluida = (int)tabela.Rows[a]["excluida"]; Oexcluida = (int)tabela.Rows[a]["excluida"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from nota_expedicao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from nota_expedicao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from nota_expedicao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from nota_expedicao where " + where + "");
}


# endregion
    }
}
