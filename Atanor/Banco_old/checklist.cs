using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class checklist
    {
        List<dynamic> _valoreschecklist = new List<dynamic>();
        List<string> _colunachecklist = new List<string>();
        List<dynamic> _condicoeschecklist = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunachecklist.Count; a++)
         {
             if (col == _colunachecklist[a])
                  {
                       return;
                  }
     }
_colunachecklist.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoeschecklist.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idromaneio="idromaneio";
        public const string m1="m1";
        public const string m2="m2";
        public const string m3="m3";
        public const string m4="m4";
        public const string m5="m5";
        public const string i1="i1";
        public const string i2="i2";
        public const string i3="i3";
        public const string i4="i4";
        public const string i5="i5";
        public const string i6="i6";
        public const string l1="l1";
        public const string l2="l2";
        public const string l3="l3";
        public const string l4="l4";
        public const string l5="l5";
        public const string l6="l6";
        public const string l7="l7";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoreschecklist.Add(value); }
        }

        static int Oidromaneio;
        int idromaneio;
        public int Idromaneio
        {
            get { return idromaneio; }
            set { idromaneio = value; Add("idromaneio"); _valoreschecklist.Add(value); }
        }

        static Boolean Om1;
        Boolean m1;
        public Boolean M1
        {
            get { return m1; }
            set { m1 = value; Add("m1"); _valoreschecklist.Add(value); }
        }

        static Boolean Om2;
        Boolean m2;
        public Boolean M2
        {
            get { return m2; }
            set { m2 = value; Add("m2"); _valoreschecklist.Add(value); }
        }

        static Boolean Om3;
        Boolean m3;
        public Boolean M3
        {
            get { return m3; }
            set { m3 = value; Add("m3"); _valoreschecklist.Add(value); }
        }

        static Boolean Om4;
        Boolean m4;
        public Boolean M4
        {
            get { return m4; }
            set { m4 = value; Add("m4"); _valoreschecklist.Add(value); }
        }

        static Boolean Om5;
        Boolean m5;
        public Boolean M5
        {
            get { return m5; }
            set { m5 = value; Add("m5"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi1;
        Boolean i1;
        public Boolean I1
        {
            get { return i1; }
            set { i1 = value; Add("i1"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi2;
        Boolean i2;
        public Boolean I2
        {
            get { return i2; }
            set { i2 = value; Add("i2"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi3;
        Boolean i3;
        public Boolean I3
        {
            get { return i3; }
            set { i3 = value; Add("i3"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi4;
        Boolean i4;
        public Boolean I4
        {
            get { return i4; }
            set { i4 = value; Add("i4"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi5;
        Boolean i5;
        public Boolean I5
        {
            get { return i5; }
            set { i5 = value; Add("i5"); _valoreschecklist.Add(value); }
        }

        static Boolean Oi6;
        Boolean i6;
        public Boolean I6
        {
            get { return i6; }
            set { i6 = value; Add("i6"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol1;
        Boolean l1;
        public Boolean L1
        {
            get { return l1; }
            set { l1 = value; Add("l1"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol2;
        Boolean l2;
        public Boolean L2
        {
            get { return l2; }
            set { l2 = value; Add("l2"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol3;
        Boolean l3;
        public Boolean L3
        {
            get { return l3; }
            set { l3 = value; Add("l3"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol4;
        Boolean l4;
        public Boolean L4
        {
            get { return l4; }
            set { l4 = value; Add("l4"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol5;
        Boolean l5;
        public Boolean L5
        {
            get { return l5; }
            set { l5 = value; Add("l5"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol6;
        Boolean l6;
        public Boolean L6
        {
            get { return l6; }
            set { l6 = value; Add("l6"); _valoreschecklist.Add(value); }
        }

        static Boolean Ol7;
        Boolean l7;
        public Boolean L7
        {
            get { return l7; }
            set { l7 = value; Add("l7"); _valoreschecklist.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("checklist", TipoDeOperacao.Tipo.InsertMultiplo, _colunachecklist,_valoreschecklist, _condicoeschecklist);   
        }
        public int Alterar()
        {
if (_condicoeschecklist.Count > 0)
{
return ExecuteNonSql.Executar("checklist", TipoDeOperacao.Tipo.Update, _colunachecklist,_valoreschecklist, _condicoeschecklist);
}
else
{
List<string> Nomechecklist = new List<string>();
List<dynamic> Valorchecklist = new List<dynamic>();
_valoreschecklist.Clear();
if(Id!=null){ Nomechecklist.Add("id");
 Valorchecklist.Add(Oid);
 _valoreschecklist.Add(Id);
}if(Idromaneio!=null){ Nomechecklist.Add("idromaneio");
 Valorchecklist.Add(Oidromaneio);
 _valoreschecklist.Add(Idromaneio);
}if(M1!=null){ Nomechecklist.Add("m1");
 Valorchecklist.Add(Om1);
 _valoreschecklist.Add(M1);
}if(M2!=null){ Nomechecklist.Add("m2");
 Valorchecklist.Add(Om2);
 _valoreschecklist.Add(M2);
}if(M3!=null){ Nomechecklist.Add("m3");
 Valorchecklist.Add(Om3);
 _valoreschecklist.Add(M3);
}if(M4!=null){ Nomechecklist.Add("m4");
 Valorchecklist.Add(Om4);
 _valoreschecklist.Add(M4);
}if(M5!=null){ Nomechecklist.Add("m5");
 Valorchecklist.Add(Om5);
 _valoreschecklist.Add(M5);
}if(I1!=null){ Nomechecklist.Add("i1");
 Valorchecklist.Add(Oi1);
 _valoreschecklist.Add(I1);
}if(I2!=null){ Nomechecklist.Add("i2");
 Valorchecklist.Add(Oi2);
 _valoreschecklist.Add(I2);
}if(I3!=null){ Nomechecklist.Add("i3");
 Valorchecklist.Add(Oi3);
 _valoreschecklist.Add(I3);
}if(I4!=null){ Nomechecklist.Add("i4");
 Valorchecklist.Add(Oi4);
 _valoreschecklist.Add(I4);
}if(I5!=null){ Nomechecklist.Add("i5");
 Valorchecklist.Add(Oi5);
 _valoreschecklist.Add(I5);
}if(I6!=null){ Nomechecklist.Add("i6");
 Valorchecklist.Add(Oi6);
 _valoreschecklist.Add(I6);
}if(L1!=null){ Nomechecklist.Add("l1");
 Valorchecklist.Add(Ol1);
 _valoreschecklist.Add(L1);
}if(L2!=null){ Nomechecklist.Add("l2");
 Valorchecklist.Add(Ol2);
 _valoreschecklist.Add(L2);
}if(L3!=null){ Nomechecklist.Add("l3");
 Valorchecklist.Add(Ol3);
 _valoreschecklist.Add(L3);
}if(L4!=null){ Nomechecklist.Add("l4");
 Valorchecklist.Add(Ol4);
 _valoreschecklist.Add(L4);
}if(L5!=null){ Nomechecklist.Add("l5");
 Valorchecklist.Add(Ol5);
 _valoreschecklist.Add(L5);
}if(L6!=null){ Nomechecklist.Add("l6");
 Valorchecklist.Add(Ol6);
 _valoreschecklist.Add(L6);
}if(L7!=null){ Nomechecklist.Add("l7");
 Valorchecklist.Add(Ol7);
 _valoreschecklist.Add(L7);
}List<dynamic> Condicaochecklist = new List<dynamic>();
Condicaochecklist.Add(Nomechecklist);
Condicaochecklist.Add(Valorchecklist);
return ExecuteNonSql.Executar("checklist", TipoDeOperacao.Tipo.UpdateCondicional, _colunachecklist, _valoreschecklist, Condicaochecklist);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("checklist", TipoDeOperacao.Tipo.Delete, _colunachecklist,_valoreschecklist, _condicoeschecklist);
        }
        static public List<checklist> Obter()
        {
            List<checklist> lista = new List<checklist>();
            DataTable tabela = Select.SelectSQL("select * from checklist");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                checklist novo = new checklist();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.M1 = Convert.ToBoolean(tabela.Rows[a]["m1"]);  Om1= Convert.ToBoolean(tabela.Rows[a]["m1"]); } catch { }
            try {   novo.M2 = Convert.ToBoolean(tabela.Rows[a]["m2"]);  Om2= Convert.ToBoolean(tabela.Rows[a]["m2"]); } catch { }
            try {   novo.M3 = Convert.ToBoolean(tabela.Rows[a]["m3"]);  Om3= Convert.ToBoolean(tabela.Rows[a]["m3"]); } catch { }
            try {   novo.M4 = Convert.ToBoolean(tabela.Rows[a]["m4"]);  Om4= Convert.ToBoolean(tabela.Rows[a]["m4"]); } catch { }
            try {   novo.M5 = Convert.ToBoolean(tabela.Rows[a]["m5"]);  Om5= Convert.ToBoolean(tabela.Rows[a]["m5"]); } catch { }
            try {   novo.I1 = Convert.ToBoolean(tabela.Rows[a]["i1"]);  Oi1= Convert.ToBoolean(tabela.Rows[a]["i1"]); } catch { }
            try {   novo.I2 = Convert.ToBoolean(tabela.Rows[a]["i2"]);  Oi2= Convert.ToBoolean(tabela.Rows[a]["i2"]); } catch { }
            try {   novo.I3 = Convert.ToBoolean(tabela.Rows[a]["i3"]);  Oi3= Convert.ToBoolean(tabela.Rows[a]["i3"]); } catch { }
            try {   novo.I4 = Convert.ToBoolean(tabela.Rows[a]["i4"]);  Oi4= Convert.ToBoolean(tabela.Rows[a]["i4"]); } catch { }
            try {   novo.I5 = Convert.ToBoolean(tabela.Rows[a]["i5"]);  Oi5= Convert.ToBoolean(tabela.Rows[a]["i5"]); } catch { }
            try {   novo.I6 = Convert.ToBoolean(tabela.Rows[a]["i6"]);  Oi6= Convert.ToBoolean(tabela.Rows[a]["i6"]); } catch { }
            try {   novo.L1 = Convert.ToBoolean(tabela.Rows[a]["l1"]);  Ol1= Convert.ToBoolean(tabela.Rows[a]["l1"]); } catch { }
            try {   novo.L2 = Convert.ToBoolean(tabela.Rows[a]["l2"]);  Ol2= Convert.ToBoolean(tabela.Rows[a]["l2"]); } catch { }
            try {   novo.L3 = Convert.ToBoolean(tabela.Rows[a]["l3"]);  Ol3= Convert.ToBoolean(tabela.Rows[a]["l3"]); } catch { }
            try {   novo.L4 = Convert.ToBoolean(tabela.Rows[a]["l4"]);  Ol4= Convert.ToBoolean(tabela.Rows[a]["l4"]); } catch { }
            try {   novo.L5 = Convert.ToBoolean(tabela.Rows[a]["l5"]);  Ol5= Convert.ToBoolean(tabela.Rows[a]["l5"]); } catch { }
            try {   novo.L6 = Convert.ToBoolean(tabela.Rows[a]["l6"]);  Ol6= Convert.ToBoolean(tabela.Rows[a]["l6"]); } catch { }
            try {   novo.L7 = Convert.ToBoolean(tabela.Rows[a]["l7"]);  Ol7= Convert.ToBoolean(tabela.Rows[a]["l7"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<checklist> Obter(string where)
        {
            List<checklist> lista = new List<checklist>();
            DataTable tabela = Select.SelectSQL("select * from checklist where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                checklist novo = new checklist();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.M1 = Convert.ToBoolean(tabela.Rows[a]["m1"]);  Om1= Convert.ToBoolean(tabela.Rows[a]["m1"]); } catch { }
            try {   novo.M2 = Convert.ToBoolean(tabela.Rows[a]["m2"]);  Om2= Convert.ToBoolean(tabela.Rows[a]["m2"]); } catch { }
            try {   novo.M3 = Convert.ToBoolean(tabela.Rows[a]["m3"]);  Om3= Convert.ToBoolean(tabela.Rows[a]["m3"]); } catch { }
            try {   novo.M4 = Convert.ToBoolean(tabela.Rows[a]["m4"]);  Om4= Convert.ToBoolean(tabela.Rows[a]["m4"]); } catch { }
            try {   novo.M5 = Convert.ToBoolean(tabela.Rows[a]["m5"]);  Om5= Convert.ToBoolean(tabela.Rows[a]["m5"]); } catch { }
            try {   novo.I1 = Convert.ToBoolean(tabela.Rows[a]["i1"]);  Oi1= Convert.ToBoolean(tabela.Rows[a]["i1"]); } catch { }
            try {   novo.I2 = Convert.ToBoolean(tabela.Rows[a]["i2"]);  Oi2= Convert.ToBoolean(tabela.Rows[a]["i2"]); } catch { }
            try {   novo.I3 = Convert.ToBoolean(tabela.Rows[a]["i3"]);  Oi3= Convert.ToBoolean(tabela.Rows[a]["i3"]); } catch { }
            try {   novo.I4 = Convert.ToBoolean(tabela.Rows[a]["i4"]);  Oi4= Convert.ToBoolean(tabela.Rows[a]["i4"]); } catch { }
            try {   novo.I5 = Convert.ToBoolean(tabela.Rows[a]["i5"]);  Oi5= Convert.ToBoolean(tabela.Rows[a]["i5"]); } catch { }
            try {   novo.I6 = Convert.ToBoolean(tabela.Rows[a]["i6"]);  Oi6= Convert.ToBoolean(tabela.Rows[a]["i6"]); } catch { }
            try {   novo.L1 = Convert.ToBoolean(tabela.Rows[a]["l1"]);  Ol1= Convert.ToBoolean(tabela.Rows[a]["l1"]); } catch { }
            try {   novo.L2 = Convert.ToBoolean(tabela.Rows[a]["l2"]);  Ol2= Convert.ToBoolean(tabela.Rows[a]["l2"]); } catch { }
            try {   novo.L3 = Convert.ToBoolean(tabela.Rows[a]["l3"]);  Ol3= Convert.ToBoolean(tabela.Rows[a]["l3"]); } catch { }
            try {   novo.L4 = Convert.ToBoolean(tabela.Rows[a]["l4"]);  Ol4= Convert.ToBoolean(tabela.Rows[a]["l4"]); } catch { }
            try {   novo.L5 = Convert.ToBoolean(tabela.Rows[a]["l5"]);  Ol5= Convert.ToBoolean(tabela.Rows[a]["l5"]); } catch { }
            try {   novo.L6 = Convert.ToBoolean(tabela.Rows[a]["l6"]);  Ol6= Convert.ToBoolean(tabela.Rows[a]["l6"]); } catch { }
            try {   novo.L7 = Convert.ToBoolean(tabela.Rows[a]["l7"]);  Ol7= Convert.ToBoolean(tabela.Rows[a]["l7"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<checklist> ObterComFiltroAvancado(string sql)
        {
            List<checklist> lista = new List<checklist>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                checklist novo = new checklist();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idromaneio = (int)tabela.Rows[a]["idromaneio"]; Oidromaneio = (int)tabela.Rows[a]["idromaneio"]; } catch { }
            try {   novo.M1 = Convert.ToBoolean(tabela.Rows[a]["m1"]);  Om1= Convert.ToBoolean(tabela.Rows[a]["m1"]); } catch { }
            try {   novo.M2 = Convert.ToBoolean(tabela.Rows[a]["m2"]);  Om2= Convert.ToBoolean(tabela.Rows[a]["m2"]); } catch { }
            try {   novo.M3 = Convert.ToBoolean(tabela.Rows[a]["m3"]);  Om3= Convert.ToBoolean(tabela.Rows[a]["m3"]); } catch { }
            try {   novo.M4 = Convert.ToBoolean(tabela.Rows[a]["m4"]);  Om4= Convert.ToBoolean(tabela.Rows[a]["m4"]); } catch { }
            try {   novo.M5 = Convert.ToBoolean(tabela.Rows[a]["m5"]);  Om5= Convert.ToBoolean(tabela.Rows[a]["m5"]); } catch { }
            try {   novo.I1 = Convert.ToBoolean(tabela.Rows[a]["i1"]);  Oi1= Convert.ToBoolean(tabela.Rows[a]["i1"]); } catch { }
            try {   novo.I2 = Convert.ToBoolean(tabela.Rows[a]["i2"]);  Oi2= Convert.ToBoolean(tabela.Rows[a]["i2"]); } catch { }
            try {   novo.I3 = Convert.ToBoolean(tabela.Rows[a]["i3"]);  Oi3= Convert.ToBoolean(tabela.Rows[a]["i3"]); } catch { }
            try {   novo.I4 = Convert.ToBoolean(tabela.Rows[a]["i4"]);  Oi4= Convert.ToBoolean(tabela.Rows[a]["i4"]); } catch { }
            try {   novo.I5 = Convert.ToBoolean(tabela.Rows[a]["i5"]);  Oi5= Convert.ToBoolean(tabela.Rows[a]["i5"]); } catch { }
            try {   novo.I6 = Convert.ToBoolean(tabela.Rows[a]["i6"]);  Oi6= Convert.ToBoolean(tabela.Rows[a]["i6"]); } catch { }
            try {   novo.L1 = Convert.ToBoolean(tabela.Rows[a]["l1"]);  Ol1= Convert.ToBoolean(tabela.Rows[a]["l1"]); } catch { }
            try {   novo.L2 = Convert.ToBoolean(tabela.Rows[a]["l2"]);  Ol2= Convert.ToBoolean(tabela.Rows[a]["l2"]); } catch { }
            try {   novo.L3 = Convert.ToBoolean(tabela.Rows[a]["l3"]);  Ol3= Convert.ToBoolean(tabela.Rows[a]["l3"]); } catch { }
            try {   novo.L4 = Convert.ToBoolean(tabela.Rows[a]["l4"]);  Ol4= Convert.ToBoolean(tabela.Rows[a]["l4"]); } catch { }
            try {   novo.L5 = Convert.ToBoolean(tabela.Rows[a]["l5"]);  Ol5= Convert.ToBoolean(tabela.Rows[a]["l5"]); } catch { }
            try {   novo.L6 = Convert.ToBoolean(tabela.Rows[a]["l6"]);  Ol6= Convert.ToBoolean(tabela.Rows[a]["l6"]); } catch { }
            try {   novo.L7 = Convert.ToBoolean(tabela.Rows[a]["l7"]);  Ol7= Convert.ToBoolean(tabela.Rows[a]["l7"]); } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from checklist").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from checklist where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from checklist ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from checklist where " + where + "");
}


# endregion
    }
}
