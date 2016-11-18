using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class config_material
    {
        List<dynamic> _valoresconfig_material = new List<dynamic>();
        List<string> _colunaconfig_material = new List<string>();
        List<dynamic> _condicoesconfig_material = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaconfig_material.Count; a++)
         {
             if (col == _colunaconfig_material[a])
                  {
                       return;
                  }
     }
_colunaconfig_material.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesconfig_material.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string id_material="id_material";
        public const string avisar_min="avisar_min";
        public const string avisar_mov="avisar_mov";
        public const string avisar_cad="avisar_cad";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresconfig_material.Add(value); }
        }

        static int Oid_material;
        int id_material;
        public int Id_material
        {
            get { return id_material; }
            set { id_material = value; Add("id_material"); _valoresconfig_material.Add(value); }
        }

        static Boolean Oavisar_min;
        Boolean avisar_min;
        public Boolean Avisar_min
        {
            get { return avisar_min; }
            set { avisar_min = value; Add("avisar_min"); _valoresconfig_material.Add(value); }
        }

        static Boolean Oavisar_mov;
        Boolean avisar_mov;
        public Boolean Avisar_mov
        {
            get { return avisar_mov; }
            set { avisar_mov = value; Add("avisar_mov"); _valoresconfig_material.Add(value); }
        }

        static Boolean Oavisar_cad;
        Boolean avisar_cad;
        public Boolean Avisar_cad
        {
            get { return avisar_cad; }
            set { avisar_cad = value; Add("avisar_cad"); _valoresconfig_material.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("config_material", TipoDeOperacao.Tipo.InsertMultiplo, _colunaconfig_material,_valoresconfig_material, _condicoesconfig_material);   
        }
        public int Alterar()
        {
if (_condicoesconfig_material.Count > 0)
{
return ExecuteNonSql.Executar("config_material", TipoDeOperacao.Tipo.Update, _colunaconfig_material,_valoresconfig_material, _condicoesconfig_material);
}
else
{
List<string> Nomeconfig_material = new List<string>();
List<dynamic> Valorconfig_material = new List<dynamic>();
_valoresconfig_material.Clear();
if(Id!=null){ Nomeconfig_material.Add("id");
 Valorconfig_material.Add(Oid);
 _valoresconfig_material.Add(Id);
}if(Id_material!=null){ Nomeconfig_material.Add("id_material");
 Valorconfig_material.Add(Oid_material);
 _valoresconfig_material.Add(Id_material);
}if(Avisar_min!=null){ Nomeconfig_material.Add("avisar_min");
 Valorconfig_material.Add(Oavisar_min);
 _valoresconfig_material.Add(Avisar_min);
}if(Avisar_mov!=null){ Nomeconfig_material.Add("avisar_mov");
 Valorconfig_material.Add(Oavisar_mov);
 _valoresconfig_material.Add(Avisar_mov);
}if(Avisar_cad!=null){ Nomeconfig_material.Add("avisar_cad");
 Valorconfig_material.Add(Oavisar_cad);
 _valoresconfig_material.Add(Avisar_cad);
}List<dynamic> Condicaoconfig_material = new List<dynamic>();
Condicaoconfig_material.Add(Nomeconfig_material);
Condicaoconfig_material.Add(Valorconfig_material);
return ExecuteNonSql.Executar("config_material", TipoDeOperacao.Tipo.UpdateCondicional, _colunaconfig_material, _valoresconfig_material, Condicaoconfig_material);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("config_material", TipoDeOperacao.Tipo.Delete, _colunaconfig_material,_valoresconfig_material, _condicoesconfig_material);
        }
        static public List<config_material> Obter()
        {
            List<config_material> lista = new List<config_material>();
            DataTable tabela = Select.SelectSQL("select * from config_material");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                config_material novo = new config_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Avisar_min = Convert.ToBoolean(tabela.Rows[a]["avisar_min"]);  Oavisar_min= Convert.ToBoolean(tabela.Rows[a]["avisar_min"]); } catch { }
            try {   novo.Avisar_mov = Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]);  Oavisar_mov= Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]); } catch { }
            try {   novo.Avisar_cad = Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]);  Oavisar_cad= Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<config_material> Obter(string where)
        {
            List<config_material> lista = new List<config_material>();
            DataTable tabela = Select.SelectSQL("select * from config_material where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                config_material novo = new config_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Avisar_min = Convert.ToBoolean(tabela.Rows[a]["avisar_min"]);  Oavisar_min= Convert.ToBoolean(tabela.Rows[a]["avisar_min"]); } catch { }
            try {   novo.Avisar_mov = Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]);  Oavisar_mov= Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]); } catch { }
            try {   novo.Avisar_cad = Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]);  Oavisar_cad= Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<config_material> ObterComFiltroAvancado(string sql)
        {
            List<config_material> lista = new List<config_material>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                config_material novo = new config_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Avisar_min = Convert.ToBoolean(tabela.Rows[a]["avisar_min"]);  Oavisar_min= Convert.ToBoolean(tabela.Rows[a]["avisar_min"]); } catch { }
            try {   novo.Avisar_mov = Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]);  Oavisar_mov= Convert.ToBoolean(tabela.Rows[a]["avisar_mov"]); } catch { }
            try {   novo.Avisar_cad = Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]);  Oavisar_cad= Convert.ToBoolean(tabela.Rows[a]["avisar_cad"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from config_material").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from config_material where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from config_material ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from config_material where " + where + "");
}


# endregion
    }
}
