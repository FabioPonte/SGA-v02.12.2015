using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class material
    {
        List<dynamic> _valoresmaterial = new List<dynamic>();
        List<string> _colunamaterial = new List<string>();
        List<dynamic> _condicoesmaterial = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunamaterial.Count; a++)
         {
             if (col == _colunamaterial[a])
                  {
                       return;
                  }
     }
_colunamaterial.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesmaterial.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string nome="nome";
        public const string min="min";
        public const string max="max";
        public const string volume="volume";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresmaterial.Add(value); }
        }

        static string Onome;
        string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; Add("nome"); _valoresmaterial.Add(value); }
        }

        static double Omin;
        double min;
        public double Min
        {
            get { return min; }
            set { min = value; Add("min"); _valoresmaterial.Add(value); }
        }

        static double Omax;
        double max;
        public double Max
        {
            get { return max; }
            set { max = value; Add("max"); _valoresmaterial.Add(value); }
        }

        static double Ovolume;
        double volume;
        public double Volume
        {
            get { return volume; }
            set { volume = value; Add("volume"); _valoresmaterial.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("material", TipoDeOperacao.Tipo.InsertMultiplo, _colunamaterial,_valoresmaterial, _condicoesmaterial);   
        }
        public int Alterar()
        {
if (_condicoesmaterial.Count > 0)
{
return ExecuteNonSql.Executar("material", TipoDeOperacao.Tipo.Update, _colunamaterial,_valoresmaterial, _condicoesmaterial);
}
else
{
List<string> Nomematerial = new List<string>();
List<dynamic> Valormaterial = new List<dynamic>();
_valoresmaterial.Clear();
if(Id!=null){ Nomematerial.Add("id");
 Valormaterial.Add(Oid);
 _valoresmaterial.Add(Id);
}if(Nome!=null){ Nomematerial.Add("nome");
 Valormaterial.Add(Onome);
 _valoresmaterial.Add(Nome);
}if(Min!=null){ Nomematerial.Add("min");
 Valormaterial.Add(Omin);
 _valoresmaterial.Add(Min);
}if(Max!=null){ Nomematerial.Add("max");
 Valormaterial.Add(Omax);
 _valoresmaterial.Add(Max);
}if(Volume!=null){ Nomematerial.Add("volume");
 Valormaterial.Add(Ovolume);
 _valoresmaterial.Add(Volume);
}List<dynamic> Condicaomaterial = new List<dynamic>();
Condicaomaterial.Add(Nomematerial);
Condicaomaterial.Add(Valormaterial);
return ExecuteNonSql.Executar("material", TipoDeOperacao.Tipo.UpdateCondicional, _colunamaterial, _valoresmaterial, Condicaomaterial);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("material", TipoDeOperacao.Tipo.Delete, _colunamaterial,_valoresmaterial, _condicoesmaterial);
        }
        static public List<material> Obter()
        {
            List<material> lista = new List<material>();
            DataTable tabela = Select.SelectSQL("select * from material");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                material novo = new material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Max = (double)tabela.Rows[a]["max"]; Omax = (double)tabela.Rows[a]["max"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<material> Obter(string where)
        {
            List<material> lista = new List<material>();
            DataTable tabela = Select.SelectSQL("select * from material where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                material novo = new material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Max = (double)tabela.Rows[a]["max"]; Omax = (double)tabela.Rows[a]["max"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<material> ObterComFiltroAvancado(string sql)
        {
            List<material> lista = new List<material>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                material novo = new material();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Nome = (string)tabela.Rows[a]["nome"]; Onome = (string)tabela.Rows[a]["nome"]; } catch { }
            try {   novo.Min = (double)tabela.Rows[a]["min"]; Omin = (double)tabela.Rows[a]["min"]; } catch { }
            try {   novo.Max = (double)tabela.Rows[a]["max"]; Omax = (double)tabela.Rows[a]["max"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from material").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from material where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from material ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from material where " + where + "");
}


# endregion
    }
}
