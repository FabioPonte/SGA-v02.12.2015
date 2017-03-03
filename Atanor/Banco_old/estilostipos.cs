using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class estilostipos
    {
        List<dynamic> _valoresestilostipos = new List<dynamic>();
        List<string> _colunaestilostipos = new List<string>();
        List<dynamic> _condicoesestilostipos = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaestilostipos.Count; a++)
         {
             if (col == _colunaestilostipos[a])
                  {
                       return;
                  }
     }
_colunaestilostipos.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesestilostipos.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string font="font";
        public const string tamanho="tamanho";
        public const string negrito="negrito";
        public const string hexcor_texto="hexcor_texto";
        public const string hexcor_fundo="hexcor_fundo";
        public const string hexcor_bordaesquerda="hexcor_bordaesquerda";
        public const string hexcor_bordadireita="hexcor_bordadireita";
        public const string hexcor_bordasuperior="hexcor_bordasuperior";
        public const string hexcor_bordainfeiror="hexcor_bordainfeiror";
        public const string borda_esquerda="borda_esquerda";
        public const string borda_direita="borda_direita";
        public const string borda_superior="borda_superior";
        public const string borda_inferior="borda_inferior";
        public const string primeira_celula_linha="primeira_celula_linha";
        public const string primeira_celula_coluna="primeira_celula_coluna";
        public const string segunda_celula_linha="segunda_celula_linha";
        public const string segunda_celula_coluna="segunda_celula_coluna";
        public const string condicaocontem="condicaocontem";
        public const string condicaocoluna="condicaocoluna";
        public const string original="original";
        public const string novo="novo";
        public const string codigo="codigo";
        public const string pos="pos";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresestilostipos.Add(value); }
        }

        static string Ofont;
        string font;
        public string Font
        {
            get { return font; }
            set { font = value; Add("font"); _valoresestilostipos.Add(value); }
        }

        static int Otamanho;
        int tamanho;
        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; Add("tamanho"); _valoresestilostipos.Add(value); }
        }

        static Boolean Onegrito;
        Boolean negrito;
        public Boolean Negrito
        {
            get { return negrito; }
            set { negrito = value; Add("negrito"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_texto;
        string hexcor_texto;
        public string Hexcor_texto
        {
            get { return hexcor_texto; }
            set { hexcor_texto = value; Add("hexcor_texto"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_fundo;
        string hexcor_fundo;
        public string Hexcor_fundo
        {
            get { return hexcor_fundo; }
            set { hexcor_fundo = value; Add("hexcor_fundo"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_bordaesquerda;
        string hexcor_bordaesquerda;
        public string Hexcor_bordaesquerda
        {
            get { return hexcor_bordaesquerda; }
            set { hexcor_bordaesquerda = value; Add("hexcor_bordaesquerda"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_bordadireita;
        string hexcor_bordadireita;
        public string Hexcor_bordadireita
        {
            get { return hexcor_bordadireita; }
            set { hexcor_bordadireita = value; Add("hexcor_bordadireita"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_bordasuperior;
        string hexcor_bordasuperior;
        public string Hexcor_bordasuperior
        {
            get { return hexcor_bordasuperior; }
            set { hexcor_bordasuperior = value; Add("hexcor_bordasuperior"); _valoresestilostipos.Add(value); }
        }

        static string Ohexcor_bordainfeiror;
        string hexcor_bordainfeiror;
        public string Hexcor_bordainfeiror
        {
            get { return hexcor_bordainfeiror; }
            set { hexcor_bordainfeiror = value; Add("hexcor_bordainfeiror"); _valoresestilostipos.Add(value); }
        }

        static Boolean Oborda_esquerda;
        Boolean borda_esquerda;
        public Boolean Borda_esquerda
        {
            get { return borda_esquerda; }
            set { borda_esquerda = value; Add("borda_esquerda"); _valoresestilostipos.Add(value); }
        }

        static Boolean Oborda_direita;
        Boolean borda_direita;
        public Boolean Borda_direita
        {
            get { return borda_direita; }
            set { borda_direita = value; Add("borda_direita"); _valoresestilostipos.Add(value); }
        }

        static Boolean Oborda_superior;
        Boolean borda_superior;
        public Boolean Borda_superior
        {
            get { return borda_superior; }
            set { borda_superior = value; Add("borda_superior"); _valoresestilostipos.Add(value); }
        }

        static Boolean Oborda_inferior;
        Boolean borda_inferior;
        public Boolean Borda_inferior
        {
            get { return borda_inferior; }
            set { borda_inferior = value; Add("borda_inferior"); _valoresestilostipos.Add(value); }
        }

        static int Oprimeira_celula_linha;
        int primeira_celula_linha;
        public int Primeira_celula_linha
        {
            get { return primeira_celula_linha; }
            set { primeira_celula_linha = value; Add("primeira_celula_linha"); _valoresestilostipos.Add(value); }
        }

        static int Oprimeira_celula_coluna;
        int primeira_celula_coluna;
        public int Primeira_celula_coluna
        {
            get { return primeira_celula_coluna; }
            set { primeira_celula_coluna = value; Add("primeira_celula_coluna"); _valoresestilostipos.Add(value); }
        }

        static int Osegunda_celula_linha;
        int segunda_celula_linha;
        public int Segunda_celula_linha
        {
            get { return segunda_celula_linha; }
            set { segunda_celula_linha = value; Add("segunda_celula_linha"); _valoresestilostipos.Add(value); }
        }

        static int Osegunda_celula_coluna;
        int segunda_celula_coluna;
        public int Segunda_celula_coluna
        {
            get { return segunda_celula_coluna; }
            set { segunda_celula_coluna = value; Add("segunda_celula_coluna"); _valoresestilostipos.Add(value); }
        }

        static string Ocondicaocontem;
        string condicaocontem;
        public string Condicaocontem
        {
            get { return condicaocontem; }
            set { condicaocontem = value; Add("condicaocontem"); _valoresestilostipos.Add(value); }
        }

        static int Ocondicaocoluna;
        int condicaocoluna;
        public int Condicaocoluna
        {
            get { return condicaocoluna; }
            set { condicaocoluna = value; Add("condicaocoluna"); _valoresestilostipos.Add(value); }
        }

        static string Ooriginal;
        string original;
        public string Original
        {
            get { return original; }
            set { original = value; Add("original"); _valoresestilostipos.Add(value); }
        }

        static string Onovo;
        string novo;
        public string Novo
        {
            get { return novo; }
            set { novo = value; Add("novo"); _valoresestilostipos.Add(value); }
        }

        static string Ocodigo;
        string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; Add("codigo"); _valoresestilostipos.Add(value); }
        }

        static int Opos;
        int pos;
        public int Pos
        {
            get { return pos; }
            set { pos = value; Add("pos"); _valoresestilostipos.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("estilostipos", TipoDeOperacao.Tipo.InsertMultiplo, _colunaestilostipos,_valoresestilostipos, _condicoesestilostipos);   
        }
        public int Alterar()
        {
if (_condicoesestilostipos.Count > 0)
{
return ExecuteNonSql.Executar("estilostipos", TipoDeOperacao.Tipo.Update, _colunaestilostipos,_valoresestilostipos, _condicoesestilostipos);
}
else
{
List<string> Nomeestilostipos = new List<string>();
List<dynamic> Valorestilostipos = new List<dynamic>();
_valoresestilostipos.Clear();
if(Id!=null){ Nomeestilostipos.Add("id");
 Valorestilostipos.Add(Oid);
 _valoresestilostipos.Add(Id);
}if(Font!=null){ Nomeestilostipos.Add("font");
 Valorestilostipos.Add(Ofont);
 _valoresestilostipos.Add(Font);
}if(Tamanho!=null){ Nomeestilostipos.Add("tamanho");
 Valorestilostipos.Add(Otamanho);
 _valoresestilostipos.Add(Tamanho);
}if(Negrito!=null){ Nomeestilostipos.Add("negrito");
 Valorestilostipos.Add(Onegrito);
 _valoresestilostipos.Add(Negrito);
}if(Hexcor_texto!=null){ Nomeestilostipos.Add("hexcor_texto");
 Valorestilostipos.Add(Ohexcor_texto);
 _valoresestilostipos.Add(Hexcor_texto);
}if(Hexcor_fundo!=null){ Nomeestilostipos.Add("hexcor_fundo");
 Valorestilostipos.Add(Ohexcor_fundo);
 _valoresestilostipos.Add(Hexcor_fundo);
}if(Hexcor_bordaesquerda!=null){ Nomeestilostipos.Add("hexcor_bordaesquerda");
 Valorestilostipos.Add(Ohexcor_bordaesquerda);
 _valoresestilostipos.Add(Hexcor_bordaesquerda);
}if(Hexcor_bordadireita!=null){ Nomeestilostipos.Add("hexcor_bordadireita");
 Valorestilostipos.Add(Ohexcor_bordadireita);
 _valoresestilostipos.Add(Hexcor_bordadireita);
}if(Hexcor_bordasuperior!=null){ Nomeestilostipos.Add("hexcor_bordasuperior");
 Valorestilostipos.Add(Ohexcor_bordasuperior);
 _valoresestilostipos.Add(Hexcor_bordasuperior);
}if(Hexcor_bordainfeiror!=null){ Nomeestilostipos.Add("hexcor_bordainfeiror");
 Valorestilostipos.Add(Ohexcor_bordainfeiror);
 _valoresestilostipos.Add(Hexcor_bordainfeiror);
}if(Borda_esquerda!=null){ Nomeestilostipos.Add("borda_esquerda");
 Valorestilostipos.Add(Oborda_esquerda);
 _valoresestilostipos.Add(Borda_esquerda);
}if(Borda_direita!=null){ Nomeestilostipos.Add("borda_direita");
 Valorestilostipos.Add(Oborda_direita);
 _valoresestilostipos.Add(Borda_direita);
}if(Borda_superior!=null){ Nomeestilostipos.Add("borda_superior");
 Valorestilostipos.Add(Oborda_superior);
 _valoresestilostipos.Add(Borda_superior);
}if(Borda_inferior!=null){ Nomeestilostipos.Add("borda_inferior");
 Valorestilostipos.Add(Oborda_inferior);
 _valoresestilostipos.Add(Borda_inferior);
}if(Primeira_celula_linha!=null){ Nomeestilostipos.Add("primeira_celula_linha");
 Valorestilostipos.Add(Oprimeira_celula_linha);
 _valoresestilostipos.Add(Primeira_celula_linha);
}if(Primeira_celula_coluna!=null){ Nomeestilostipos.Add("primeira_celula_coluna");
 Valorestilostipos.Add(Oprimeira_celula_coluna);
 _valoresestilostipos.Add(Primeira_celula_coluna);
}if(Segunda_celula_linha!=null){ Nomeestilostipos.Add("segunda_celula_linha");
 Valorestilostipos.Add(Osegunda_celula_linha);
 _valoresestilostipos.Add(Segunda_celula_linha);
}if(Segunda_celula_coluna!=null){ Nomeestilostipos.Add("segunda_celula_coluna");
 Valorestilostipos.Add(Osegunda_celula_coluna);
 _valoresestilostipos.Add(Segunda_celula_coluna);
}if(Condicaocontem!=null){ Nomeestilostipos.Add("condicaocontem");
 Valorestilostipos.Add(Ocondicaocontem);
 _valoresestilostipos.Add(Condicaocontem);
}if(Condicaocoluna!=null){ Nomeestilostipos.Add("condicaocoluna");
 Valorestilostipos.Add(Ocondicaocoluna);
 _valoresestilostipos.Add(Condicaocoluna);
}if(Original!=null){ Nomeestilostipos.Add("original");
 Valorestilostipos.Add(Ooriginal);
 _valoresestilostipos.Add(Original);
}if(Novo!=null){ Nomeestilostipos.Add("novo");
 Valorestilostipos.Add(Onovo);
 _valoresestilostipos.Add(Novo);
}if(Codigo!=null){ Nomeestilostipos.Add("codigo");
 Valorestilostipos.Add(Ocodigo);
 _valoresestilostipos.Add(Codigo);
}if(Pos!=null){ Nomeestilostipos.Add("pos");
 Valorestilostipos.Add(Opos);
 _valoresestilostipos.Add(Pos);
}List<dynamic> Condicaoestilostipos = new List<dynamic>();
Condicaoestilostipos.Add(Nomeestilostipos);
Condicaoestilostipos.Add(Valorestilostipos);
return ExecuteNonSql.Executar("estilostipos", TipoDeOperacao.Tipo.UpdateCondicional, _colunaestilostipos, _valoresestilostipos, Condicaoestilostipos);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("estilostipos", TipoDeOperacao.Tipo.Delete, _colunaestilostipos,_valoresestilostipos, _condicoesestilostipos);
        }
        static public List<estilostipos> Obter()
        {
            List<estilostipos> lista = new List<estilostipos>();
            DataTable tabela = Select.SelectSQL("select * from estilostipos");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilostipos novo = new estilostipos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Font = (string)tabela.Rows[a]["font"]; Ofont = (string)tabela.Rows[a]["font"]; } catch { }
            try {   novo.Tamanho = (int)tabela.Rows[a]["tamanho"]; Otamanho = (int)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Negrito = Convert.ToBoolean(tabela.Rows[a]["negrito"]);  Onegrito= Convert.ToBoolean(tabela.Rows[a]["negrito"]); } catch { }
            try {   novo.Hexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; Ohexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; } catch { }
            try {   novo.Hexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; Ohexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; } catch { }
            try {   novo.Hexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; Ohexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; } catch { }
            try {   novo.Hexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; Ohexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; } catch { }
            try {   novo.Hexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; Ohexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; } catch { }
            try {   novo.Hexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; Ohexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; } catch { }
            try {   novo.Borda_esquerda = Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]);  Oborda_esquerda= Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]); } catch { }
            try {   novo.Borda_direita = Convert.ToBoolean(tabela.Rows[a]["borda_direita"]);  Oborda_direita= Convert.ToBoolean(tabela.Rows[a]["borda_direita"]); } catch { }
            try {   novo.Borda_superior = Convert.ToBoolean(tabela.Rows[a]["borda_superior"]);  Oborda_superior= Convert.ToBoolean(tabela.Rows[a]["borda_superior"]); } catch { }
            try {   novo.Borda_inferior = Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]);  Oborda_inferior= Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]); } catch { }
            try {   novo.Primeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; Oprimeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; } catch { }
            try {   novo.Primeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; Oprimeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; } catch { }
            try {   novo.Segunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; Osegunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; } catch { }
            try {   novo.Segunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; Osegunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; } catch { }
            try {   novo.Condicaocontem = (string)tabela.Rows[a]["condicaocontem"]; Ocondicaocontem = (string)tabela.Rows[a]["condicaocontem"]; } catch { }
            try {   novo.Condicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; Ocondicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; } catch { }
            try {   novo.Original = (string)tabela.Rows[a]["original"]; Ooriginal = (string)tabela.Rows[a]["original"]; } catch { }
            try {   novo.Novo = (string)tabela.Rows[a]["novo"]; Onovo = (string)tabela.Rows[a]["novo"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Pos = (int)tabela.Rows[a]["pos"]; Opos = (int)tabela.Rows[a]["pos"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilostipos> Obter(string where)
        {
            List<estilostipos> lista = new List<estilostipos>();
            DataTable tabela = Select.SelectSQL("select * from estilostipos where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilostipos novo = new estilostipos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Font = (string)tabela.Rows[a]["font"]; Ofont = (string)tabela.Rows[a]["font"]; } catch { }
            try {   novo.Tamanho = (int)tabela.Rows[a]["tamanho"]; Otamanho = (int)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Negrito = Convert.ToBoolean(tabela.Rows[a]["negrito"]);  Onegrito= Convert.ToBoolean(tabela.Rows[a]["negrito"]); } catch { }
            try {   novo.Hexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; Ohexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; } catch { }
            try {   novo.Hexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; Ohexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; } catch { }
            try {   novo.Hexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; Ohexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; } catch { }
            try {   novo.Hexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; Ohexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; } catch { }
            try {   novo.Hexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; Ohexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; } catch { }
            try {   novo.Hexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; Ohexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; } catch { }
            try {   novo.Borda_esquerda = Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]);  Oborda_esquerda= Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]); } catch { }
            try {   novo.Borda_direita = Convert.ToBoolean(tabela.Rows[a]["borda_direita"]);  Oborda_direita= Convert.ToBoolean(tabela.Rows[a]["borda_direita"]); } catch { }
            try {   novo.Borda_superior = Convert.ToBoolean(tabela.Rows[a]["borda_superior"]);  Oborda_superior= Convert.ToBoolean(tabela.Rows[a]["borda_superior"]); } catch { }
            try {   novo.Borda_inferior = Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]);  Oborda_inferior= Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]); } catch { }
            try {   novo.Primeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; Oprimeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; } catch { }
            try {   novo.Primeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; Oprimeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; } catch { }
            try {   novo.Segunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; Osegunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; } catch { }
            try {   novo.Segunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; Osegunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; } catch { }
            try {   novo.Condicaocontem = (string)tabela.Rows[a]["condicaocontem"]; Ocondicaocontem = (string)tabela.Rows[a]["condicaocontem"]; } catch { }
            try {   novo.Condicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; Ocondicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; } catch { }
            try {   novo.Original = (string)tabela.Rows[a]["original"]; Ooriginal = (string)tabela.Rows[a]["original"]; } catch { }
            try {   novo.Novo = (string)tabela.Rows[a]["novo"]; Onovo = (string)tabela.Rows[a]["novo"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Pos = (int)tabela.Rows[a]["pos"]; Opos = (int)tabela.Rows[a]["pos"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<estilostipos> ObterComFiltroAvancado(string sql)
        {
            List<estilostipos> lista = new List<estilostipos>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                estilostipos novo = new estilostipos();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Font = (string)tabela.Rows[a]["font"]; Ofont = (string)tabela.Rows[a]["font"]; } catch { }
            try {   novo.Tamanho = (int)tabela.Rows[a]["tamanho"]; Otamanho = (int)tabela.Rows[a]["tamanho"]; } catch { }
            try {   novo.Negrito = Convert.ToBoolean(tabela.Rows[a]["negrito"]);  Onegrito= Convert.ToBoolean(tabela.Rows[a]["negrito"]); } catch { }
            try {   novo.Hexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; Ohexcor_texto = (string)tabela.Rows[a]["hexcor_texto"]; } catch { }
            try {   novo.Hexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; Ohexcor_fundo = (string)tabela.Rows[a]["hexcor_fundo"]; } catch { }
            try {   novo.Hexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; Ohexcor_bordaesquerda = (string)tabela.Rows[a]["hexcor_bordaesquerda"]; } catch { }
            try {   novo.Hexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; Ohexcor_bordadireita = (string)tabela.Rows[a]["hexcor_bordadireita"]; } catch { }
            try {   novo.Hexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; Ohexcor_bordasuperior = (string)tabela.Rows[a]["hexcor_bordasuperior"]; } catch { }
            try {   novo.Hexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; Ohexcor_bordainfeiror = (string)tabela.Rows[a]["hexcor_bordainfeiror"]; } catch { }
            try {   novo.Borda_esquerda = Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]);  Oborda_esquerda= Convert.ToBoolean(tabela.Rows[a]["borda_esquerda"]); } catch { }
            try {   novo.Borda_direita = Convert.ToBoolean(tabela.Rows[a]["borda_direita"]);  Oborda_direita= Convert.ToBoolean(tabela.Rows[a]["borda_direita"]); } catch { }
            try {   novo.Borda_superior = Convert.ToBoolean(tabela.Rows[a]["borda_superior"]);  Oborda_superior= Convert.ToBoolean(tabela.Rows[a]["borda_superior"]); } catch { }
            try {   novo.Borda_inferior = Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]);  Oborda_inferior= Convert.ToBoolean(tabela.Rows[a]["borda_inferior"]); } catch { }
            try {   novo.Primeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; Oprimeira_celula_linha = (int)tabela.Rows[a]["primeira_celula_linha"]; } catch { }
            try {   novo.Primeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; Oprimeira_celula_coluna = (int)tabela.Rows[a]["primeira_celula_coluna"]; } catch { }
            try {   novo.Segunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; Osegunda_celula_linha = (int)tabela.Rows[a]["segunda_celula_linha"]; } catch { }
            try {   novo.Segunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; Osegunda_celula_coluna = (int)tabela.Rows[a]["segunda_celula_coluna"]; } catch { }
            try {   novo.Condicaocontem = (string)tabela.Rows[a]["condicaocontem"]; Ocondicaocontem = (string)tabela.Rows[a]["condicaocontem"]; } catch { }
            try {   novo.Condicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; Ocondicaocoluna = (int)tabela.Rows[a]["condicaocoluna"]; } catch { }
            try {   novo.Original = (string)tabela.Rows[a]["original"]; Ooriginal = (string)tabela.Rows[a]["original"]; } catch { }
            try {   novo.Novo = (string)tabela.Rows[a]["novo"]; Onovo = (string)tabela.Rows[a]["novo"]; } catch { }
            try {   novo.Codigo = (string)tabela.Rows[a]["codigo"]; Ocodigo = (string)tabela.Rows[a]["codigo"]; } catch { }
            try {   novo.Pos = (int)tabela.Rows[a]["pos"]; Opos = (int)tabela.Rows[a]["pos"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from estilostipos").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from estilostipos where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from estilostipos ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from estilostipos where " + where + "");
}


# endregion
    }
}
