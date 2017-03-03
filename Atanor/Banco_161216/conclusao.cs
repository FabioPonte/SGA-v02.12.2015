using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class conclusao
    {
        List<dynamic> _valoresconclusao = new List<dynamic>();
        List<string> _colunaconclusao = new List<string>();
        List<dynamic> _condicoesconclusao = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaconclusao.Count; a++)
         {
             if (col == _colunaconclusao[a])
                  {
                       return;
                  }
     }
_colunaconclusao.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesconclusao.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string data_inicio="data_inicio";
        public const string data_fim="data_fim";
        public const string tempo="tempo";
        public const string obs="obs";
        public const string cancelado="cancelado";
        public const string usuarios_id="usuarios_id";
        public const string codigo="codigo";
        public const string nomeusuario="nomeusuario";
        public const string data_acao="data_acao";
        public const string id_poschamadoreaberto="id_poschamadoreaberto";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresconclusao.Add(value); }
        }

        static DateTime Odata_inicio;
        DateTime data_inicio;
        public DateTime Data_inicio
        {
            get { return data_inicio; }
            set { data_inicio = value; Add("data_inicio"); _valoresconclusao.Add(value); }
        }

        static DateTime Odata_fim;
        DateTime data_fim;
        public DateTime Data_fim
        {
            get { return data_fim; }
            set { data_fim = value; Add("data_fim"); _valoresconclusao.Add(value); }
        }

        static int Otempo;
        int tempo;
        public int Tempo
        {
            get { return tempo; }
            set { tempo = value; Add("tempo"); _valoresconclusao.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresconclusao.Add(value); }
        }

        static Boolean Ocancelado;
        Boolean cancelado;
        public Boolean Cancelado
        {
            get { return cancelado; }
            set { cancelado = value; Add("cancelado"); _valoresconclusao.Add(value); }
        }

        static int Ousuarios_id;
        int usuarios_id;
        public int Usuarios_id
        {
            get { return usuarios_id; }
            set { usuarios_id = value; Add("usuarios_id"); _valoresconclusao.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresconclusao.Add(value); }
        }

        static string Onomeusuario;
        string nomeusuario;
        public string Nomeusuario
        {
            get { return nomeusuario; }
            set { nomeusuario = value; Add("nomeusuario"); _valoresconclusao.Add(value); }
        }

        static DateTime Odata_acao;
        DateTime data_acao;
        public DateTime Data_acao
        {
            get { return data_acao; }
            set { data_acao = value; Add("data_acao"); _valoresconclusao.Add(value); }
        }

        static int Oid_poschamadoreaberto;
        int id_poschamadoreaberto;
        public int Id_poschamadoreaberto
        {
            get { return id_poschamadoreaberto; }
            set { id_poschamadoreaberto = value; Add("id_poschamadoreaberto"); _valoresconclusao.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("conclusao", TipoDeOperacao.Tipo.InsertMultiplo, _colunaconclusao,_valoresconclusao, _condicoesconclusao);   
        }
        public int Alterar()
        {
if (_condicoesconclusao.Count > 0)
{
return ExecuteNonSql.Executar("conclusao", TipoDeOperacao.Tipo.Update, _colunaconclusao,_valoresconclusao, _condicoesconclusao);
}
else
{
List<string> Nomeconclusao = new List<string>();
List<dynamic> Valorconclusao = new List<dynamic>();
_valoresconclusao.Clear();
if(Id!=null){ Nomeconclusao.Add("id");
 Valorconclusao.Add(Oid);
 _valoresconclusao.Add(Id);
}if(Data_inicio!=null){ Nomeconclusao.Add("data_inicio");
 Valorconclusao.Add(Odata_inicio);
 _valoresconclusao.Add(Data_inicio);
}if(Data_fim!=null){ Nomeconclusao.Add("data_fim");
 Valorconclusao.Add(Odata_fim);
 _valoresconclusao.Add(Data_fim);
}if(Tempo!=null){ Nomeconclusao.Add("tempo");
 Valorconclusao.Add(Otempo);
 _valoresconclusao.Add(Tempo);
}if(Obs!=null){ Nomeconclusao.Add("obs");
 Valorconclusao.Add(Oobs);
 _valoresconclusao.Add(Obs);
}if(Cancelado!=null){ Nomeconclusao.Add("cancelado");
 Valorconclusao.Add(Ocancelado);
 _valoresconclusao.Add(Cancelado);
}if(Usuarios_id!=null){ Nomeconclusao.Add("usuarios_id");
 Valorconclusao.Add(Ousuarios_id);
 _valoresconclusao.Add(Usuarios_id);
}if(Codigo!=null){ Nomeconclusao.Add("codigo");
 Valorconclusao.Add(Ocodigo);
 _valoresconclusao.Add(Codigo);
}if(Nomeusuario!=null){ Nomeconclusao.Add("nomeusuario");
 Valorconclusao.Add(Onomeusuario);
 _valoresconclusao.Add(Nomeusuario);
}if(Data_acao!=null){ Nomeconclusao.Add("data_acao");
 Valorconclusao.Add(Odata_acao);
 _valoresconclusao.Add(Data_acao);
}if(Id_poschamadoreaberto!=null){ Nomeconclusao.Add("id_poschamadoreaberto");
 Valorconclusao.Add(Oid_poschamadoreaberto);
 _valoresconclusao.Add(Id_poschamadoreaberto);
}List<dynamic> Condicaoconclusao = new List<dynamic>();
Condicaoconclusao.Add(Nomeconclusao);
Condicaoconclusao.Add(Valorconclusao);
return ExecuteNonSql.Executar("conclusao", TipoDeOperacao.Tipo.UpdateCondicional, _colunaconclusao, _valoresconclusao, Condicaoconclusao);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("conclusao", TipoDeOperacao.Tipo.Delete, _colunaconclusao,_valoresconclusao, _condicoesconclusao);
        }
        static public List<conclusao> Obter()
        {
            List<conclusao> lista = new List<conclusao>();
            DataTable tabela = Select.SelectSQL("select * from conclusao");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conclusao novo = new conclusao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; Odata_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; } catch { }
            try {   novo.Data_fim = (DateTime)tabela.Rows[a]["data_fim"]; Odata_fim = (DateTime)tabela.Rows[a]["data_fim"]; } catch { }
            try {   novo.Tempo = (int)tabela.Rows[a]["tempo"]; Otempo = (int)tabela.Rows[a]["tempo"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cancelado = Convert.ToBoolean(tabela.Rows[a]["cancelado"]);  Ocancelado= Convert.ToBoolean(tabela.Rows[a]["cancelado"]); } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Nomeusuario = (string)tabela.Rows[a]["nomeusuario"]; Onomeusuario = (string)tabela.Rows[a]["nomeusuario"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Id_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; Oid_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<conclusao> Obter(string where)
        {
            List<conclusao> lista = new List<conclusao>();
            DataTable tabela = Select.SelectSQL("select * from conclusao where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conclusao novo = new conclusao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; Odata_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; } catch { }
            try {   novo.Data_fim = (DateTime)tabela.Rows[a]["data_fim"]; Odata_fim = (DateTime)tabela.Rows[a]["data_fim"]; } catch { }
            try {   novo.Tempo = (int)tabela.Rows[a]["tempo"]; Otempo = (int)tabela.Rows[a]["tempo"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cancelado = Convert.ToBoolean(tabela.Rows[a]["cancelado"]);  Ocancelado= Convert.ToBoolean(tabela.Rows[a]["cancelado"]); } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Nomeusuario = (string)tabela.Rows[a]["nomeusuario"]; Onomeusuario = (string)tabela.Rows[a]["nomeusuario"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Id_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; Oid_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<conclusao> ObterComFiltroAvancado(string sql)
        {
            List<conclusao> lista = new List<conclusao>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conclusao novo = new conclusao();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Data_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; Odata_inicio = (DateTime)tabela.Rows[a]["data_inicio"]; } catch { }
            try {   novo.Data_fim = (DateTime)tabela.Rows[a]["data_fim"]; Odata_fim = (DateTime)tabela.Rows[a]["data_fim"]; } catch { }
            try {   novo.Tempo = (int)tabela.Rows[a]["tempo"]; Otempo = (int)tabela.Rows[a]["tempo"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
            try {   novo.Cancelado = Convert.ToBoolean(tabela.Rows[a]["cancelado"]);  Ocancelado= Convert.ToBoolean(tabela.Rows[a]["cancelado"]); } catch { }
            try {   novo.Usuarios_id = (int)tabela.Rows[a]["usuarios_id"]; Ousuarios_id = (int)tabela.Rows[a]["usuarios_id"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Nomeusuario = (string)tabela.Rows[a]["nomeusuario"]; Onomeusuario = (string)tabela.Rows[a]["nomeusuario"]; } catch { }
            try {   novo.Data_acao = (DateTime)tabela.Rows[a]["data_acao"]; Odata_acao = (DateTime)tabela.Rows[a]["data_acao"]; } catch { }
            try {   novo.Id_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; Oid_poschamadoreaberto = (int)tabela.Rows[a]["id_poschamadoreaberto"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from conclusao").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from conclusao where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from conclusao ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from conclusao where " + where + "");
}


# endregion
    }
}
