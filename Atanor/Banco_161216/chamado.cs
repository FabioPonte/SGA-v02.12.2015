using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class chamado
    {
        List<dynamic> _valoreschamado = new List<dynamic>();
        List<string> _colunachamado = new List<string>();
        List<dynamic> _condicoeschamado = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunachamado.Count; a++)
         {
             if (col == _colunachamado[a])
                  {
                       return;
                  }
     }
_colunachamado.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoeschamado.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string poschamado_id="poschamado_id";
        public const string usuarios_id="usuarios_id";
        public const string usuarioquedelegou_id="usuarioquedelegou_id";
        public const string transferencia="transferencia";
        public const string codigo="codigo";
        public const string data_acao="data_acao";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoreschamado.Add(value); }
        }

        static int Oposchamado_id;
        int poschamado_id;
        public int Poschamado_id
        {
            get { return poschamado_id; }
            set { poschamado_id = value; Add("poschamado_id"); _valoreschamado.Add(value); }
        }

        static int Ousuarios_id;
        int usuarios_id;
        public int Usuarios_id
        {
            get { return usuarios_id; }
            set { usuarios_id = value; Add("usuarios_id"); _valoreschamado.Add(value); }
        }

        static int Ousuarioquedelegou_id;
        int usuarioquedelegou_id;
        public int Usuarioquedelegou_id
        {
            get { return usuarioquedelegou_id; }
            set { usuarioquedelegou_id = value; Add("usuarioquedelegou_id"); _valoreschamado.Add(value); }
        }

        static Boolean Otransferencia;
        Boolean transferencia;
        public Boolean Transferencia
        {
            get { return transferencia; }
            set { transferencia = value; Add("transferencia"); _valoreschamado.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoreschamado.Add(value); }
        }

        static DateTime Odata_acao;
        DateTime data_acao;
        public DateTime Data_acao
        {
            get { return data_acao; }
            set { data_acao = value; Add("data_acao"); _valoreschamado.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("chamado", TipoDeOperacao.Tipo.InsertMultiplo, _colunachamado,_valoreschamado, _condicoeschamado);   
        }
        public int Alterar()
        {
if (_condicoeschamado.Count > 0)
{
return ExecuteNonSql.Executar("chamado", TipoDeOperacao.Tipo.Update, _colunachamado,_valoreschamado, _condicoeschamado);
}
else
{
List<string> Nomechamado = new List<string>();
List<dynamic> Valorchamado = new List<dynamic>();
_valoreschamado.Clear();
if(Id!=null){ Nomechamado.Add("id");
 Valorchamado.Add(Oid);
 _valoreschamado.Add(Id);
}if(Poschamado_id!=null){ Nomechamado.Add("poschamado_id");
 Valorchamado.Add(Oposchamado_id);
 _valoreschamado.Add(Poschamado_id);
}if(Usuarios_id!=null){ Nomechamado.Add("usuarios_id");
 Valorchamado.Add(Ousuarios_id);
 _valoreschamado.Add(Usuarios_id);
}if(Usuarioquedelegou_id!=null){ Nomechamado.Add("usuarioquedelegou_id");
 Valorchamado.Add(Ousuarioquedelegou_id);
 _valoreschamado.Add(Usuarioquedelegou_id);
}if(Transferencia!=null){ Nomechamado.Add("transferencia");
 Valorchamado.Add(Otransferencia);
 _valoreschamado.Add(Transferencia);
}if(Codigo!=null){ Nomechamado.Add("codigo");
 Valorchamado.Add(Ocodigo);
 _valoreschamado.Add(Codigo);
}if(Data_acao!=null){ Nomechamado.Add("data_acao");
 Valorchamado.Add(Odata_acao);
 _valoreschamado.Add(Data_acao);
}List<dynamic> Condicaochamado = new List<dynamic>();
Condicaochamado.Add(Nomechamado);
Condicaochamado.Add(Valorchamado);
return ExecuteNonSql.Executar("chamado", TipoDeOperacao.Tipo.UpdateCondicional, _colunachamado, _valoreschamado, Condicaochamado);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("chamado", TipoDeOperacao.Tipo.Delete, _colunachamado,_valoreschamado, _condicoeschamado);
        }
        static public List<chamado> Obter()
        {
            List<chamado> lista = new List<chamado>();
            DataTable tabela = Select.SelectSQL("select * from chamado");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado novo = new chamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Usuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; Ousuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; } catch { }
            try {   novo.Transferencia = Convert.ToBoolean(tabela.Rows[a]["transferencia"]);  Otransferencia= Convert.ToBoolean(tabela.Rows[a]["transferencia"]); } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<chamado> Obter(string where)
        {
            List<chamado> lista = new List<chamado>();
            DataTable tabela = Select.SelectSQL("select * from chamado where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado novo = new chamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Usuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; Ousuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; } catch { }
            try {   novo.Transferencia = Convert.ToBoolean(tabela.Rows[a]["transferencia"]);  Otransferencia= Convert.ToBoolean(tabela.Rows[a]["transferencia"]); } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<chamado> ObterComFiltroAvancado(string sql)
        {
            List<chamado> lista = new List<chamado>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado novo = new chamado();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Usuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; Ousuarioquedelegou_id = (int)tabela.Rows[a]["usuarioquedelegou_id"]; } catch { }
            try {   novo.Transferencia = Convert.ToBoolean(tabela.Rows[a]["transferencia"]);  Otransferencia= Convert.ToBoolean(tabela.Rows[a]["transferencia"]); } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from chamado").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from chamado where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from chamado ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from chamado where " + where + "");
}


# endregion
    }
}
