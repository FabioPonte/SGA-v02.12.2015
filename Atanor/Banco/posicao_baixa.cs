using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class posicao_baixa
    {
        List<dynamic> _valoresposicao_baixa = new List<dynamic>();
        List<string> _colunaposicao_baixa = new List<string>();
        List<dynamic> _condicoesposicao_baixa = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaposicao_baixa.Count; a++)
         {
             if (col == _colunaposicao_baixa[a])
                  {
                       return;
                  }
     }
_colunaposicao_baixa.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesposicao_baixa.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string id_produto="id_produto";
        public const string qtd_baixada="qtd_baixada";
        public const string qtd_antes="qtd_antes";
        public const string qtd_depois="qtd_depois";
        public const string io="io";
        public const string usuario="usuario";
        public const string data="data";
        public const string nota="nota";
        public const string deposito="deposito";
        public const string lado1="lado1";
        public const string lado2="lado2";
        public const string lote="lote";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresposicao_baixa.Add(value); }
        }

        static int Oid_produto;
        int id_produto;
        public int Id_produto
        {
            get { return id_produto; }
            set { id_produto = value; Add("id_produto"); _valoresposicao_baixa.Add(value); }
        }

        static double Oqtd_baixada;
        double qtd_baixada;
        public double Qtd_baixada
        {
            get { return qtd_baixada; }
            set { qtd_baixada = value; Add("qtd_baixada"); _valoresposicao_baixa.Add(value); }
        }

        static double Oqtd_antes;
        double qtd_antes;
        public double Qtd_antes
        {
            get { return qtd_antes; }
            set { qtd_antes = value; Add("qtd_antes"); _valoresposicao_baixa.Add(value); }
        }

        static double Oqtd_depois;
        double qtd_depois;
        public double Qtd_depois
        {
            get { return qtd_depois; }
            set { qtd_depois = value; Add("qtd_depois"); _valoresposicao_baixa.Add(value); }
        }

        static string Oio;
        string io;
        public string Io
        {
            get { return io; }
            set { io = value; Add("io"); _valoresposicao_baixa.Add(value); }
        }

        static string Ousuario;
        string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; Add("usuario"); _valoresposicao_baixa.Add(value); }
        }

        static DateTime Odata;
        DateTime data;
        public DateTime Data
        {
            get { return data; }
            set { data = value; Add("data"); _valoresposicao_baixa.Add(value); }
        }

        static int Onota;
        int nota;
        public int Nota
        {
            get { return nota; }
            set { nota = value; Add("nota"); _valoresposicao_baixa.Add(value); }
        }

        static string Odeposito;
        string deposito;
        public string Deposito
        {
            get { return deposito; }
            set { deposito = value; Add("deposito"); _valoresposicao_baixa.Add(value); }
        }

        static string Olado1;
        string lado1;
        public string Lado1
        {
            get { return lado1; }
            set { lado1 = value; Add("lado1"); _valoresposicao_baixa.Add(value); }
        }

        static string Olado2;
        string lado2;
        public string Lado2
        {
            get { return lado2; }
            set { lado2 = value; Add("lado2"); _valoresposicao_baixa.Add(value); }
        }

        static string Olote;
        string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; Add("lote"); _valoresposicao_baixa.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("posicao_baixa", TipoDeOperacao.Tipo.InsertMultiplo, _colunaposicao_baixa,_valoresposicao_baixa, _condicoesposicao_baixa);   
        }
        public int Alterar()
        {
if (_condicoesposicao_baixa.Count > 0)
{
return ExecuteNonSql.Executar("posicao_baixa", TipoDeOperacao.Tipo.Update, _colunaposicao_baixa,_valoresposicao_baixa, _condicoesposicao_baixa);
}
else
{
List<string> Nomeposicao_baixa = new List<string>();
List<dynamic> Valorposicao_baixa = new List<dynamic>();
_valoresposicao_baixa.Clear();
if(Id!=null){ Nomeposicao_baixa.Add("id");
 Valorposicao_baixa.Add(Oid);
 _valoresposicao_baixa.Add(Id);
}if(Id_produto!=null){ Nomeposicao_baixa.Add("id_produto");
 Valorposicao_baixa.Add(Oid_produto);
 _valoresposicao_baixa.Add(Id_produto);
}if(Qtd_baixada!=null){ Nomeposicao_baixa.Add("qtd_baixada");
 Valorposicao_baixa.Add(Oqtd_baixada);
 _valoresposicao_baixa.Add(Qtd_baixada);
}if(Qtd_antes!=null){ Nomeposicao_baixa.Add("qtd_antes");
 Valorposicao_baixa.Add(Oqtd_antes);
 _valoresposicao_baixa.Add(Qtd_antes);
}if(Qtd_depois!=null){ Nomeposicao_baixa.Add("qtd_depois");
 Valorposicao_baixa.Add(Oqtd_depois);
 _valoresposicao_baixa.Add(Qtd_depois);
}if(Io!=null){ Nomeposicao_baixa.Add("io");
 Valorposicao_baixa.Add(Oio);
 _valoresposicao_baixa.Add(Io);
}if(Usuario!=null){ Nomeposicao_baixa.Add("usuario");
 Valorposicao_baixa.Add(Ousuario);
 _valoresposicao_baixa.Add(Usuario);
}if(Data!=null){ Nomeposicao_baixa.Add("data");
 Valorposicao_baixa.Add(Odata);
 _valoresposicao_baixa.Add(Data);
}if(Nota!=null){ Nomeposicao_baixa.Add("nota");
 Valorposicao_baixa.Add(Onota);
 _valoresposicao_baixa.Add(Nota);
}if(Deposito!=null){ Nomeposicao_baixa.Add("deposito");
 Valorposicao_baixa.Add(Odeposito);
 _valoresposicao_baixa.Add(Deposito);
}if(Lado1!=null){ Nomeposicao_baixa.Add("lado1");
 Valorposicao_baixa.Add(Olado1);
 _valoresposicao_baixa.Add(Lado1);
}if(Lado2!=null){ Nomeposicao_baixa.Add("lado2");
 Valorposicao_baixa.Add(Olado2);
 _valoresposicao_baixa.Add(Lado2);
}if(Lote!=null){ Nomeposicao_baixa.Add("lote");
 Valorposicao_baixa.Add(Olote);
 _valoresposicao_baixa.Add(Lote);
}List<dynamic> Condicaoposicao_baixa = new List<dynamic>();
Condicaoposicao_baixa.Add(Nomeposicao_baixa);
Condicaoposicao_baixa.Add(Valorposicao_baixa);
return ExecuteNonSql.Executar("posicao_baixa", TipoDeOperacao.Tipo.UpdateCondicional, _colunaposicao_baixa, _valoresposicao_baixa, Condicaoposicao_baixa);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("posicao_baixa", TipoDeOperacao.Tipo.Delete, _colunaposicao_baixa,_valoresposicao_baixa, _condicoesposicao_baixa);
        }
        static public List<posicao_baixa> Obter()
        {
            List<posicao_baixa> lista = new List<posicao_baixa>();
            DataTable tabela = Select.SelectSQL("select * from posicao_baixa");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_baixa novo = new posicao_baixa();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Qtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; Oqtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; } catch { }
            try {   novo.Qtd_antes = (double)tabela.Rows[a]["qtd_antes"]; Oqtd_antes = (double)tabela.Rows[a]["qtd_antes"]; } catch { }
            try {   novo.Qtd_depois = (double)tabela.Rows[a]["qtd_depois"]; Oqtd_depois = (double)tabela.Rows[a]["qtd_depois"]; } catch { }
            try {   novo.Io = (string)tabela.Rows[a]["io"]; Oio = (string)tabela.Rows[a]["io"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Deposito = (string)tabela.Rows[a]["deposito"]; Odeposito = (string)tabela.Rows[a]["deposito"]; } catch { }
            try {   novo.Lado1 = (string)tabela.Rows[a]["lado1"]; Olado1 = (string)tabela.Rows[a]["lado1"]; } catch { }
            try {   novo.Lado2 = (string)tabela.Rows[a]["lado2"]; Olado2 = (string)tabela.Rows[a]["lado2"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_baixa> Obter(string where)
        {
            List<posicao_baixa> lista = new List<posicao_baixa>();
            DataTable tabela = Select.SelectSQL("select * from posicao_baixa where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_baixa novo = new posicao_baixa();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Qtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; Oqtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; } catch { }
            try {   novo.Qtd_antes = (double)tabela.Rows[a]["qtd_antes"]; Oqtd_antes = (double)tabela.Rows[a]["qtd_antes"]; } catch { }
            try {   novo.Qtd_depois = (double)tabela.Rows[a]["qtd_depois"]; Oqtd_depois = (double)tabela.Rows[a]["qtd_depois"]; } catch { }
            try {   novo.Io = (string)tabela.Rows[a]["io"]; Oio = (string)tabela.Rows[a]["io"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Deposito = (string)tabela.Rows[a]["deposito"]; Odeposito = (string)tabela.Rows[a]["deposito"]; } catch { }
            try {   novo.Lado1 = (string)tabela.Rows[a]["lado1"]; Olado1 = (string)tabela.Rows[a]["lado1"]; } catch { }
            try {   novo.Lado2 = (string)tabela.Rows[a]["lado2"]; Olado2 = (string)tabela.Rows[a]["lado2"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<posicao_baixa> ObterComFiltroAvancado(string sql)
        {
            List<posicao_baixa> lista = new List<posicao_baixa>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                posicao_baixa novo = new posicao_baixa();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Id_produto = (int)tabela.Rows[a]["id_produto"]; Oid_produto = (int)tabela.Rows[a]["id_produto"]; } catch { }
            try {   novo.Qtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; Oqtd_baixada = (double)tabela.Rows[a]["qtd_baixada"]; } catch { }
            try {   novo.Qtd_antes = (double)tabela.Rows[a]["qtd_antes"]; Oqtd_antes = (double)tabela.Rows[a]["qtd_antes"]; } catch { }
            try {   novo.Qtd_depois = (double)tabela.Rows[a]["qtd_depois"]; Oqtd_depois = (double)tabela.Rows[a]["qtd_depois"]; } catch { }
            try {   novo.Io = (string)tabela.Rows[a]["io"]; Oio = (string)tabela.Rows[a]["io"]; } catch { }
            try {   novo.Usuario = (string)tabela.Rows[a]["usuario"]; Ousuario = (string)tabela.Rows[a]["usuario"]; } catch { }
            try {   novo.Data = (DateTime)tabela.Rows[a]["data"]; Odata = (DateTime)tabela.Rows[a]["data"]; } catch { }
            try {   novo.Nota = (int)tabela.Rows[a]["nota"]; Onota = (int)tabela.Rows[a]["nota"]; } catch { }
            try {   novo.Deposito = (string)tabela.Rows[a]["deposito"]; Odeposito = (string)tabela.Rows[a]["deposito"]; } catch { }
            try {   novo.Lado1 = (string)tabela.Rows[a]["lado1"]; Olado1 = (string)tabela.Rows[a]["lado1"]; } catch { }
            try {   novo.Lado2 = (string)tabela.Rows[a]["lado2"]; Olado2 = (string)tabela.Rows[a]["lado2"]; } catch { }
            try {   novo.Lote = (string)tabela.Rows[a]["lote"]; Olote = (string)tabela.Rows[a]["lote"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from posicao_baixa").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from posicao_baixa where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from posicao_baixa ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from posicao_baixa where " + where + "");
}


# endregion
    }
}
