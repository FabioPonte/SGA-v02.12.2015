using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class chamado_grupo
    {
        List<dynamic> _valoreschamado_grupo = new List<dynamic>();
        List<string> _colunachamado_grupo = new List<string>();
        List<dynamic> _condicoeschamado_grupo = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunachamado_grupo.Count; a++)
         {
             if (col == _colunachamado_grupo[a])
                  {
                       return;
                  }
     }
_colunachamado_grupo.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoeschamado_grupo.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string poschamado_id="poschamado_id";
        public const string nomeclassificador_id="nomeclassificador_id";
        public const string classificadores_id="classificadores_id";
        public const string data_acao="data_acao";

         }
# endregion
#region Colunas


        static int Oposchamado_id;
        int poschamado_id;
        public int Poschamado_id
        {
            get { return poschamado_id; }
            set { poschamado_id = value; Add("poschamado_id"); _valoreschamado_grupo.Add(value); }
        }

        static int Onomeclassificador_id;
        int nomeclassificador_id;
        public int Nomeclassificador_id
        {
            get { return nomeclassificador_id; }
            set { nomeclassificador_id = value; Add("nomeclassificador_id"); _valoreschamado_grupo.Add(value); }
        }

        static int Oclassificadores_id;
        int classificadores_id;
        public int Classificadores_id
        {
            get { return classificadores_id; }
            set { classificadores_id = value; Add("classificadores_id"); _valoreschamado_grupo.Add(value); }
        }

        static DateTime Odata_acao;
        DateTime data_acao;
        public DateTime Data_acao
        {
            get { return data_acao; }
            set { data_acao = value; Add("data_acao"); _valoreschamado_grupo.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("chamado_grupo", TipoDeOperacao.Tipo.InsertMultiplo, _colunachamado_grupo,_valoreschamado_grupo, _condicoeschamado_grupo);   
        }
        public int Alterar()
        {
if (_condicoeschamado_grupo.Count > 0)
{
return ExecuteNonSql.Executar("chamado_grupo", TipoDeOperacao.Tipo.Update, _colunachamado_grupo,_valoreschamado_grupo, _condicoeschamado_grupo);
}
else
{
List<string> Nomechamado_grupo = new List<string>();
List<dynamic> Valorchamado_grupo = new List<dynamic>();
_valoreschamado_grupo.Clear();
if(Poschamado_id!=null){ Nomechamado_grupo.Add("poschamado_id");
 Valorchamado_grupo.Add(Oposchamado_id);
 _valoreschamado_grupo.Add(Poschamado_id);
}if(Nomeclassificador_id!=null){ Nomechamado_grupo.Add("nomeclassificador_id");
 Valorchamado_grupo.Add(Onomeclassificador_id);
 _valoreschamado_grupo.Add(Nomeclassificador_id);
}if(Classificadores_id!=null){ Nomechamado_grupo.Add("classificadores_id");
 Valorchamado_grupo.Add(Oclassificadores_id);
 _valoreschamado_grupo.Add(Classificadores_id);
}if(Data_acao!=null){ Nomechamado_grupo.Add("data_acao");
 Valorchamado_grupo.Add(Odata_acao);
 _valoreschamado_grupo.Add(Data_acao);
}List<dynamic> Condicaochamado_grupo = new List<dynamic>();
Condicaochamado_grupo.Add(Nomechamado_grupo);
Condicaochamado_grupo.Add(Valorchamado_grupo);
return ExecuteNonSql.Executar("chamado_grupo", TipoDeOperacao.Tipo.UpdateCondicional, _colunachamado_grupo, _valoreschamado_grupo, Condicaochamado_grupo);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("chamado_grupo", TipoDeOperacao.Tipo.Delete, _colunachamado_grupo,_valoreschamado_grupo, _condicoeschamado_grupo);
        }
        static public List<chamado_grupo> Obter()
        {
            List<chamado_grupo> lista = new List<chamado_grupo>();
            DataTable tabela = Select.SelectSQL("select * from chamado_grupo");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado_grupo novo = new chamado_grupo();
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Nomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; Onomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; } catch { }
            try {   novo.Classificadores_id = (int)tabela.Rows[a]["classificadores_id"]; Oclassificadores_id = (int)tabela.Rows[a]["classificadores_id"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<chamado_grupo> Obter(string where)
        {
            List<chamado_grupo> lista = new List<chamado_grupo>();
            DataTable tabela = Select.SelectSQL("select * from chamado_grupo where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado_grupo novo = new chamado_grupo();
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Nomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; Onomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; } catch { }
            try {   novo.Classificadores_id = (int)tabela.Rows[a]["classificadores_id"]; Oclassificadores_id = (int)tabela.Rows[a]["classificadores_id"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<chamado_grupo> ObterComFiltroAvancado(string sql)
        {
            List<chamado_grupo> lista = new List<chamado_grupo>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                chamado_grupo novo = new chamado_grupo();
            try {   novo.Poschamado_id = (int)tabela.Rows[a]["poschamado_id"]; Oposchamado_id = (int)tabela.Rows[a]["poschamado_id"]; } catch { }
            try {   novo.Nomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; Onomeclassificador_id = (int)tabela.Rows[a]["nomeclassificador_id"]; } catch { }
            try {   novo.Classificadores_id = (int)tabela.Rows[a]["classificadores_id"]; Oclassificadores_id = (int)tabela.Rows[a]["classificadores_id"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from chamado_grupo").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from chamado_grupo where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from chamado_grupo ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from chamado_grupo where " + where + "");
}


# endregion
    }
}
