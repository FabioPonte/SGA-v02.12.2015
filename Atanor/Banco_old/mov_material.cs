using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class mov_material
    {
        List<dynamic> _valoresmov_material = new List<dynamic>();
        List<string> _colunamov_material = new List<string>();
        List<dynamic> _condicoesmov_material = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunamov_material.Count; a++)
         {
             if (col == _colunamov_material[a])
                  {
                       return;
                  }
     }
_colunamov_material.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesmov_material.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string id_material="id_material";
        public const string volume="volume";
        public const string data="data";
        public const string usuario="usuario";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresmov_material.Add(value); }
        }

        static int Oid_material;
        int id_material;
        public int Id_material
        {
            get { return id_material; }
            set { id_material = value; Add("id_material"); _valoresmov_material.Add(value); }
        }

        static double Ovolume;
        double volume;
        public double Volume
        {
            get { return volume; }
            set { volume = value; Add("volume"); _valoresmov_material.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresmov_material.Add(value); }
        }

        static string Ousuario;
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; Add("usuario"); _valoresmov_material.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("mov_material", TipoDeOperacao.Tipo.InsertMultiplo, _colunamov_material,_valoresmov_material, _condicoesmov_material);   
        }
        public int Alterar()
        {
if (_condicoesmov_material.Count > 0)
{
return ExecuteNonSql.Executar("mov_material", TipoDeOperacao.Tipo.Update, _colunamov_material,_valoresmov_material, _condicoesmov_material);
}
else
{
List<string> Nomemov_material = new List<string>();
List<dynamic> Valormov_material = new List<dynamic>();
_valoresmov_material.Clear();
if(Id!=null){ Nomemov_material.Add("id");
 Valormov_material.Add(Oid);
 _valoresmov_material.Add(Id);
}if(Id_material!=null){ Nomemov_material.Add("id_material");
 Valormov_material.Add(Oid_material);
 _valoresmov_material.Add(Id_material);
}if(Volume!=null){ Nomemov_material.Add("volume");
 Valormov_material.Add(Ovolume);
 _valoresmov_material.Add(Volume);
}if(Data!=null){ Nomemov_material.Add("data");
 Valormov_material.Add(Odata);
 _valoresmov_material.Add(Data);
}if(Usuario!=null){ Nomemov_material.Add("usuario");
 Valormov_material.Add(Ousuario);
 _valoresmov_material.Add(Usuario);
}List<dynamic> Condicaomov_material = new List<dynamic>();
Condicaomov_material.Add(Nomemov_material);
Condicaomov_material.Add(Valormov_material);
return ExecuteNonSql.Executar("mov_material", TipoDeOperacao.Tipo.UpdateCondicional, _colunamov_material, _valoresmov_material, Condicaomov_material);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("mov_material", TipoDeOperacao.Tipo.Delete, _colunamov_material,_valoresmov_material, _condicoesmov_material);
        }
        static public List<mov_material> Obter()
        {
            List<mov_material> lista = new List<mov_material>();
            DataTable tabela = Select.SelectSQL("select * from mov_material");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                mov_material novo = new mov_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<mov_material> Obter(string where)
        {
            List<mov_material> lista = new List<mov_material>();
            DataTable tabela = Select.SelectSQL("select * from mov_material where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                mov_material novo = new mov_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<mov_material> ObterComFiltroAvancado(string sql)
        {
            List<mov_material> lista = new List<mov_material>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                mov_material novo = new mov_material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_material = (int)tabela.Rows[a]["id_material"]; Oid_material = (int)tabela.Rows[a]["id_material"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from mov_material").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from mov_material where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from mov_material ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from mov_material where " + where + "");
}


# endregion
    }
}
