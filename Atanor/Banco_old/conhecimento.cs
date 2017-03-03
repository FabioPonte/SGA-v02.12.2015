using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conector;
using System.Data;
namespace Atanor.Banco
{
    public class conhecimento
    {
        List<dynamic> _valoresconhecimento = new List<dynamic>();
        List<string> _colunaconhecimento = new List<string>();
        List<dynamic> _condicoesconhecimento = new List<dynamic>();
     private void Add(string col)
     {
         for (int a = 0; a < _colunaconhecimento.Count; a++)
         {
             if (col == _colunaconhecimento[a])
                  {
                       return;
                  }
     }
_colunaconhecimento.Add(col);
}
        string condicao;
        public string Condicao
        {
            get { return condicao; }
            set { condicao = value; _condicoesconhecimento.Add(value); }
        }


#region Nome das Colunas
         public class Colunas
         {
        public const string id="id";
        public const string idfaturas="idfaturas";
        public const string chave="chave";
        public const string emissao="emissao";
        public const string oconhecimento="oconhecimento";
        public const string nota_fiscal="nota_fiscal";
        public const string origem="origem";
        public const string r_nome="r_nome";
        public const string r_cnpj="r_cnpj";
        public const string r_incr="r_incr";
        public const string r_cidade="r_cidade";
        public const string r_telefone="r_telefone";
        public const string d_nome="d_nome";
        public const string d_cnpj="d_cnpj";
        public const string d_incr="d_incr";
        public const string d_cidade="d_cidade";
        public const string d_telefone="d_telefone";
        public const string tomador_cnpj="tomador_cnpj";
        public const string produto="produto";
        public const string valor_mercadoria="valor_mercadoria";
        public const string peso="peso";
        public const string volume="volume";
        public const string volume_esperado="volume_esperado";
        public const string icms="icms";
        public const string valor_total="valor_total";
        public const string valor_receber="valor_receber";
        public const string valor_receber_esperado="valor_receber_esperado";
        public const string motorista="motorista";
        public const string placa="placa";
        public const string obs="obs";

         }
# endregion
#region Colunas


        static int Oid;
        int id;
        public int Id
        {
            get { return id; }
            set { id = value; Add("id"); _valoresconhecimento.Add(value); }
        }

        static int Oidfaturas;
        int idfaturas;
        public int Idfaturas
        {
            get { return idfaturas; }
            set { idfaturas = value; Add("idfaturas"); _valoresconhecimento.Add(value); }
        }

        static string Ochave;
        string chave;
        public string Chave
        {
            get { return chave; }
            set { chave = value; Add("chave"); _valoresconhecimento.Add(value); }
        }

        static DateTime Oemissao;
        DateTime emissao;
        public DateTime Emissao
        {
            get { return emissao; }
            set { emissao = value; Add("emissao"); _valoresconhecimento.Add(value); }
        }

        static string Ooconhecimento;
        string oconhecimento;
        public string Oconhecimento
        {
            get { return oconhecimento; }
            set { oconhecimento = value; Add("oconhecimento"); _valoresconhecimento.Add(value); }
        }

        static string Onota_fiscal;
        string nota_fiscal;
        public string Nota_fiscal
        {
            get { return nota_fiscal; }
            set { nota_fiscal = value; Add("nota_fiscal"); _valoresconhecimento.Add(value); }
        }

        static string Oorigem;
        string origem;
        public string Origem
        {
            get { return origem; }
            set { origem = value; Add("origem"); _valoresconhecimento.Add(value); }
        }

        static string Or_nome;
        string r_nome;
        public string R_nome
        {
            get { return r_nome; }
            set { r_nome = value; Add("r_nome"); _valoresconhecimento.Add(value); }
        }

        static string Or_cnpj;
        string r_cnpj;
        public string R_cnpj
        {
            get { return r_cnpj; }
            set { r_cnpj = value; Add("r_cnpj"); _valoresconhecimento.Add(value); }
        }

        static string Or_incr;
        string r_incr;
        public string R_incr
        {
            get { return r_incr; }
            set { r_incr = value; Add("r_incr"); _valoresconhecimento.Add(value); }
        }

        static string Or_cidade;
        string r_cidade;
        public string R_cidade
        {
            get { return r_cidade; }
            set { r_cidade = value; Add("r_cidade"); _valoresconhecimento.Add(value); }
        }

        static string Or_telefone;
        string r_telefone;
        public string R_telefone
        {
            get { return r_telefone; }
            set { r_telefone = value; Add("r_telefone"); _valoresconhecimento.Add(value); }
        }

        static string Od_nome;
        string d_nome;
        public string D_nome
        {
            get { return d_nome; }
            set { d_nome = value; Add("d_nome"); _valoresconhecimento.Add(value); }
        }

        static string Od_cnpj;
        string d_cnpj;
        public string D_cnpj
        {
            get { return d_cnpj; }
            set { d_cnpj = value; Add("d_cnpj"); _valoresconhecimento.Add(value); }
        }

        static string Od_incr;
        string d_incr;
        public string D_incr
        {
            get { return d_incr; }
            set { d_incr = value; Add("d_incr"); _valoresconhecimento.Add(value); }
        }

        static string Od_cidade;
        string d_cidade;
        public string D_cidade
        {
            get { return d_cidade; }
            set { d_cidade = value; Add("d_cidade"); _valoresconhecimento.Add(value); }
        }

        static string Od_telefone;
        string d_telefone;
        public string D_telefone
        {
            get { return d_telefone; }
            set { d_telefone = value; Add("d_telefone"); _valoresconhecimento.Add(value); }
        }

        static string Otomador_cnpj;
        string tomador_cnpj;
        public string Tomador_cnpj
        {
            get { return tomador_cnpj; }
            set { tomador_cnpj = value; Add("tomador_cnpj"); _valoresconhecimento.Add(value); }
        }

        static string Oproduto;
        string produto;
        public string Produto
        {
            get { return produto; }
            set { produto = value; Add("produto"); _valoresconhecimento.Add(value); }
        }

        static double Ovalor_mercadoria;
        double valor_mercadoria;
        public double Valor_mercadoria
        {
            get { return valor_mercadoria; }
            set { valor_mercadoria = value; Add("valor_mercadoria"); _valoresconhecimento.Add(value); }
        }

        static double Opeso;
        double peso;
        public double Peso
        {
            get { return peso; }
            set { peso = value; Add("peso"); _valoresconhecimento.Add(value); }
        }

        static double Ovolume;
        double volume;
        public double Volume
        {
            get { return volume; }
            set { volume = value; Add("volume"); _valoresconhecimento.Add(value); }
        }

        static double Ovolume_esperado;
        double volume_esperado;
        public double Volume_esperado
        {
            get { return volume_esperado; }
            set { volume_esperado = value; Add("volume_esperado"); _valoresconhecimento.Add(value); }
        }

        static double Oicms;
        double icms;
        public double Icms
        {
            get { return icms; }
            set { icms = value; Add("icms"); _valoresconhecimento.Add(value); }
        }

        static double Ovalor_total;
        double valor_total;
        public double Valor_total
        {
            get { return valor_total; }
            set { valor_total = value; Add("valor_total"); _valoresconhecimento.Add(value); }
        }

        static double Ovalor_receber;
        double valor_receber;
        public double Valor_receber
        {
            get { return valor_receber; }
            set { valor_receber = value; Add("valor_receber"); _valoresconhecimento.Add(value); }
        }

        static double Ovalor_receber_esperado;
        double valor_receber_esperado;
        public double Valor_receber_esperado
        {
            get { return valor_receber_esperado; }
            set { valor_receber_esperado = value; Add("valor_receber_esperado"); _valoresconhecimento.Add(value); }
        }

        static string Omotorista;
        string motorista;
        public string Motorista
        {
            get { return motorista; }
            set { motorista = value; Add("motorista"); _valoresconhecimento.Add(value); }
        }

        static string Oplaca;
        string placa;
        public string Placa
        {
            get { return placa; }
            set { placa = value; Add("placa"); _valoresconhecimento.Add(value); }
        }

        static string Oobs;
        string obs;
        public string Obs
        {
            get { return obs; }
            set { obs = value; Add("obs"); _valoresconhecimento.Add(value); }
        }



# endregion


#region Ações


	public int Inserir()
	{
            return ExecuteNonSql.Executar("conhecimento", TipoDeOperacao.Tipo.InsertMultiplo, _colunaconhecimento,_valoresconhecimento, _condicoesconhecimento);   
        }
        public int Alterar()
        {
if (_condicoesconhecimento.Count > 0)
{
return ExecuteNonSql.Executar("conhecimento", TipoDeOperacao.Tipo.Update, _colunaconhecimento,_valoresconhecimento, _condicoesconhecimento);
}
else
{
List<string> Nomeconhecimento = new List<string>();
List<dynamic> Valorconhecimento = new List<dynamic>();
_valoresconhecimento.Clear();
if(Id!=null){ Nomeconhecimento.Add("id");
 Valorconhecimento.Add(Oid);
 _valoresconhecimento.Add(Id);
}if(Idfaturas!=null){ Nomeconhecimento.Add("idfaturas");
 Valorconhecimento.Add(Oidfaturas);
 _valoresconhecimento.Add(Idfaturas);
}if(Chave!=null){ Nomeconhecimento.Add("chave");
 Valorconhecimento.Add(Ochave);
 _valoresconhecimento.Add(Chave);
}if(Emissao!=null){ Nomeconhecimento.Add("emissao");
 Valorconhecimento.Add(Oemissao);
 _valoresconhecimento.Add(Emissao);
}if(Oconhecimento!=null){ Nomeconhecimento.Add("oconhecimento");
 Valorconhecimento.Add(Ooconhecimento);
 _valoresconhecimento.Add(Oconhecimento);
}if(Nota_fiscal!=null){ Nomeconhecimento.Add("nota_fiscal");
 Valorconhecimento.Add(Onota_fiscal);
 _valoresconhecimento.Add(Nota_fiscal);
}if(Origem!=null){ Nomeconhecimento.Add("origem");
 Valorconhecimento.Add(Oorigem);
 _valoresconhecimento.Add(Origem);
}if(R_nome!=null){ Nomeconhecimento.Add("r_nome");
 Valorconhecimento.Add(Or_nome);
 _valoresconhecimento.Add(R_nome);
}if(R_cnpj!=null){ Nomeconhecimento.Add("r_cnpj");
 Valorconhecimento.Add(Or_cnpj);
 _valoresconhecimento.Add(R_cnpj);
}if(R_incr!=null){ Nomeconhecimento.Add("r_incr");
 Valorconhecimento.Add(Or_incr);
 _valoresconhecimento.Add(R_incr);
}if(R_cidade!=null){ Nomeconhecimento.Add("r_cidade");
 Valorconhecimento.Add(Or_cidade);
 _valoresconhecimento.Add(R_cidade);
}if(R_telefone!=null){ Nomeconhecimento.Add("r_telefone");
 Valorconhecimento.Add(Or_telefone);
 _valoresconhecimento.Add(R_telefone);
}if(D_nome!=null){ Nomeconhecimento.Add("d_nome");
 Valorconhecimento.Add(Od_nome);
 _valoresconhecimento.Add(D_nome);
}if(D_cnpj!=null){ Nomeconhecimento.Add("d_cnpj");
 Valorconhecimento.Add(Od_cnpj);
 _valoresconhecimento.Add(D_cnpj);
}if(D_incr!=null){ Nomeconhecimento.Add("d_incr");
 Valorconhecimento.Add(Od_incr);
 _valoresconhecimento.Add(D_incr);
}if(D_cidade!=null){ Nomeconhecimento.Add("d_cidade");
 Valorconhecimento.Add(Od_cidade);
 _valoresconhecimento.Add(D_cidade);
}if(D_telefone!=null){ Nomeconhecimento.Add("d_telefone");
 Valorconhecimento.Add(Od_telefone);
 _valoresconhecimento.Add(D_telefone);
}if(Tomador_cnpj!=null){ Nomeconhecimento.Add("tomador_cnpj");
 Valorconhecimento.Add(Otomador_cnpj);
 _valoresconhecimento.Add(Tomador_cnpj);
}if(Produto!=null){ Nomeconhecimento.Add("produto");
 Valorconhecimento.Add(Oproduto);
 _valoresconhecimento.Add(Produto);
}if(Valor_mercadoria!=null){ Nomeconhecimento.Add("valor_mercadoria");
 Valorconhecimento.Add(Ovalor_mercadoria);
 _valoresconhecimento.Add(Valor_mercadoria);
}if(Peso!=null){ Nomeconhecimento.Add("peso");
 Valorconhecimento.Add(Opeso);
 _valoresconhecimento.Add(Peso);
}if(Volume!=null){ Nomeconhecimento.Add("volume");
 Valorconhecimento.Add(Ovolume);
 _valoresconhecimento.Add(Volume);
}if(Volume_esperado!=null){ Nomeconhecimento.Add("volume_esperado");
 Valorconhecimento.Add(Ovolume_esperado);
 _valoresconhecimento.Add(Volume_esperado);
}if(Icms!=null){ Nomeconhecimento.Add("icms");
 Valorconhecimento.Add(Oicms);
 _valoresconhecimento.Add(Icms);
}if(Valor_total!=null){ Nomeconhecimento.Add("valor_total");
 Valorconhecimento.Add(Ovalor_total);
 _valoresconhecimento.Add(Valor_total);
}if(Valor_receber!=null){ Nomeconhecimento.Add("valor_receber");
 Valorconhecimento.Add(Ovalor_receber);
 _valoresconhecimento.Add(Valor_receber);
}if(Valor_receber_esperado!=null){ Nomeconhecimento.Add("valor_receber_esperado");
 Valorconhecimento.Add(Ovalor_receber_esperado);
 _valoresconhecimento.Add(Valor_receber_esperado);
}if(Motorista!=null){ Nomeconhecimento.Add("motorista");
 Valorconhecimento.Add(Omotorista);
 _valoresconhecimento.Add(Motorista);
}if(Placa!=null){ Nomeconhecimento.Add("placa");
 Valorconhecimento.Add(Oplaca);
 _valoresconhecimento.Add(Placa);
}if(Obs!=null){ Nomeconhecimento.Add("obs");
 Valorconhecimento.Add(Oobs);
 _valoresconhecimento.Add(Obs);
}List<dynamic> Condicaoconhecimento = new List<dynamic>();
Condicaoconhecimento.Add(Nomeconhecimento);
Condicaoconhecimento.Add(Valorconhecimento);
return ExecuteNonSql.Executar("conhecimento", TipoDeOperacao.Tipo.UpdateCondicional, _colunaconhecimento, _valoresconhecimento, Condicaoconhecimento);
 }
        }
        public int Excluir()
        {
            return ExecuteNonSql.Executar("conhecimento", TipoDeOperacao.Tipo.Delete, _colunaconhecimento,_valoresconhecimento, _condicoesconhecimento);
        }
        static public List<conhecimento> Obter()
        {
            List<conhecimento> lista = new List<conhecimento>();
            DataTable tabela = Select.SelectSQL("select * from conhecimento");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conhecimento novo = new conhecimento();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfaturas = (int)tabela.Rows[a]["idfaturas"]; Oidfaturas = (int)tabela.Rows[a]["idfaturas"]; } catch { }
            try {   novo.Chave = (string)tabela.Rows[a]["chave"]; Ochave = (string)tabela.Rows[a]["chave"]; } catch { }
            try {   novo.Emissao = (DateTime)tabela.Rows[a]["emissao"]; Oemissao = (DateTime)tabela.Rows[a]["emissao"]; } catch { }
            try {   novo.Oconhecimento = (string)tabela.Rows[a]["oconhecimento"]; Ooconhecimento = (string)tabela.Rows[a]["oconhecimento"]; } catch { }
            try {   novo.Nota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; Onota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; } catch { }
            try {   novo.Origem = (string)tabela.Rows[a]["origem"]; Oorigem = (string)tabela.Rows[a]["origem"]; } catch { }
            try {   novo.R_nome = (string)tabela.Rows[a]["r_nome"]; Or_nome = (string)tabela.Rows[a]["r_nome"]; } catch { }
            try {   novo.R_cnpj = (string)tabela.Rows[a]["r_cnpj"]; Or_cnpj = (string)tabela.Rows[a]["r_cnpj"]; } catch { }
            try {   novo.R_incr = (string)tabela.Rows[a]["r_incr"]; Or_incr = (string)tabela.Rows[a]["r_incr"]; } catch { }
            try {   novo.R_cidade = (string)tabela.Rows[a]["r_cidade"]; Or_cidade = (string)tabela.Rows[a]["r_cidade"]; } catch { }
            try {   novo.R_telefone = (string)tabela.Rows[a]["r_telefone"]; Or_telefone = (string)tabela.Rows[a]["r_telefone"]; } catch { }
            try {   novo.D_nome = (string)tabela.Rows[a]["d_nome"]; Od_nome = (string)tabela.Rows[a]["d_nome"]; } catch { }
            try {   novo.D_cnpj = (string)tabela.Rows[a]["d_cnpj"]; Od_cnpj = (string)tabela.Rows[a]["d_cnpj"]; } catch { }
            try {   novo.D_incr = (string)tabela.Rows[a]["d_incr"]; Od_incr = (string)tabela.Rows[a]["d_incr"]; } catch { }
            try {   novo.D_cidade = (string)tabela.Rows[a]["d_cidade"]; Od_cidade = (string)tabela.Rows[a]["d_cidade"]; } catch { }
            try {   novo.D_telefone = (string)tabela.Rows[a]["d_telefone"]; Od_telefone = (string)tabela.Rows[a]["d_telefone"]; } catch { }
            try {   novo.Tomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; Otomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Valor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; Ovalor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Volume_esperado = (double)tabela.Rows[a]["volume_esperado"]; Ovolume_esperado = (double)tabela.Rows[a]["volume_esperado"]; } catch { }
            try {   novo.Icms = (double)tabela.Rows[a]["icms"]; Oicms = (double)tabela.Rows[a]["icms"]; } catch { }
            try {   novo.Valor_total = (double)tabela.Rows[a]["valor_total"]; Ovalor_total = (double)tabela.Rows[a]["valor_total"]; } catch { }
            try {   novo.Valor_receber = (double)tabela.Rows[a]["valor_receber"]; Ovalor_receber = (double)tabela.Rows[a]["valor_receber"]; } catch { }
            try {   novo.Valor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; Ovalor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<conhecimento> Obter(string where)
        {
            List<conhecimento> lista = new List<conhecimento>();
            DataTable tabela = Select.SelectSQL("select * from conhecimento where " + where + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conhecimento novo = new conhecimento();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfaturas = (int)tabela.Rows[a]["idfaturas"]; Oidfaturas = (int)tabela.Rows[a]["idfaturas"]; } catch { }
            try {   novo.Chave = (string)tabela.Rows[a]["chave"]; Ochave = (string)tabela.Rows[a]["chave"]; } catch { }
            try {   novo.Emissao = (DateTime)tabela.Rows[a]["emissao"]; Oemissao = (DateTime)tabela.Rows[a]["emissao"]; } catch { }
            try {   novo.Oconhecimento = (string)tabela.Rows[a]["oconhecimento"]; Ooconhecimento = (string)tabela.Rows[a]["oconhecimento"]; } catch { }
            try {   novo.Nota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; Onota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; } catch { }
            try {   novo.Origem = (string)tabela.Rows[a]["origem"]; Oorigem = (string)tabela.Rows[a]["origem"]; } catch { }
            try {   novo.R_nome = (string)tabela.Rows[a]["r_nome"]; Or_nome = (string)tabela.Rows[a]["r_nome"]; } catch { }
            try {   novo.R_cnpj = (string)tabela.Rows[a]["r_cnpj"]; Or_cnpj = (string)tabela.Rows[a]["r_cnpj"]; } catch { }
            try {   novo.R_incr = (string)tabela.Rows[a]["r_incr"]; Or_incr = (string)tabela.Rows[a]["r_incr"]; } catch { }
            try {   novo.R_cidade = (string)tabela.Rows[a]["r_cidade"]; Or_cidade = (string)tabela.Rows[a]["r_cidade"]; } catch { }
            try {   novo.R_telefone = (string)tabela.Rows[a]["r_telefone"]; Or_telefone = (string)tabela.Rows[a]["r_telefone"]; } catch { }
            try {   novo.D_nome = (string)tabela.Rows[a]["d_nome"]; Od_nome = (string)tabela.Rows[a]["d_nome"]; } catch { }
            try {   novo.D_cnpj = (string)tabela.Rows[a]["d_cnpj"]; Od_cnpj = (string)tabela.Rows[a]["d_cnpj"]; } catch { }
            try {   novo.D_incr = (string)tabela.Rows[a]["d_incr"]; Od_incr = (string)tabela.Rows[a]["d_incr"]; } catch { }
            try {   novo.D_cidade = (string)tabela.Rows[a]["d_cidade"]; Od_cidade = (string)tabela.Rows[a]["d_cidade"]; } catch { }
            try {   novo.D_telefone = (string)tabela.Rows[a]["d_telefone"]; Od_telefone = (string)tabela.Rows[a]["d_telefone"]; } catch { }
            try {   novo.Tomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; Otomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Valor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; Ovalor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Volume_esperado = (double)tabela.Rows[a]["volume_esperado"]; Ovolume_esperado = (double)tabela.Rows[a]["volume_esperado"]; } catch { }
            try {   novo.Icms = (double)tabela.Rows[a]["icms"]; Oicms = (double)tabela.Rows[a]["icms"]; } catch { }
            try {   novo.Valor_total = (double)tabela.Rows[a]["valor_total"]; Ovalor_total = (double)tabela.Rows[a]["valor_total"]; } catch { }
            try {   novo.Valor_receber = (double)tabela.Rows[a]["valor_receber"]; Ovalor_receber = (double)tabela.Rows[a]["valor_receber"]; } catch { }
            try {   novo.Valor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; Ovalor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
        static public List<conhecimento> ObterComFiltroAvancado(string sql)
        {
            List<conhecimento> lista = new List<conhecimento>();
            DataTable tabela = Select.SelectSQL("" + sql + "");
            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                conhecimento novo = new conhecimento();
            try {   novo.Id = (int)tabela.Rows[a]["id"]; Oid = (int)tabela.Rows[a]["id"]; } catch { }
            try {   novo.Idfaturas = (int)tabela.Rows[a]["idfaturas"]; Oidfaturas = (int)tabela.Rows[a]["idfaturas"]; } catch { }
            try {   novo.Chave = (string)tabela.Rows[a]["chave"]; Ochave = (string)tabela.Rows[a]["chave"]; } catch { }
            try {   novo.Emissao = (DateTime)tabela.Rows[a]["emissao"]; Oemissao = (DateTime)tabela.Rows[a]["emissao"]; } catch { }
            try {   novo.Oconhecimento = (string)tabela.Rows[a]["oconhecimento"]; Ooconhecimento = (string)tabela.Rows[a]["oconhecimento"]; } catch { }
            try {   novo.Nota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; Onota_fiscal = (string)tabela.Rows[a]["nota_fiscal"]; } catch { }
            try {   novo.Origem = (string)tabela.Rows[a]["origem"]; Oorigem = (string)tabela.Rows[a]["origem"]; } catch { }
            try {   novo.R_nome = (string)tabela.Rows[a]["r_nome"]; Or_nome = (string)tabela.Rows[a]["r_nome"]; } catch { }
            try {   novo.R_cnpj = (string)tabela.Rows[a]["r_cnpj"]; Or_cnpj = (string)tabela.Rows[a]["r_cnpj"]; } catch { }
            try {   novo.R_incr = (string)tabela.Rows[a]["r_incr"]; Or_incr = (string)tabela.Rows[a]["r_incr"]; } catch { }
            try {   novo.R_cidade = (string)tabela.Rows[a]["r_cidade"]; Or_cidade = (string)tabela.Rows[a]["r_cidade"]; } catch { }
            try {   novo.R_telefone = (string)tabela.Rows[a]["r_telefone"]; Or_telefone = (string)tabela.Rows[a]["r_telefone"]; } catch { }
            try {   novo.D_nome = (string)tabela.Rows[a]["d_nome"]; Od_nome = (string)tabela.Rows[a]["d_nome"]; } catch { }
            try {   novo.D_cnpj = (string)tabela.Rows[a]["d_cnpj"]; Od_cnpj = (string)tabela.Rows[a]["d_cnpj"]; } catch { }
            try {   novo.D_incr = (string)tabela.Rows[a]["d_incr"]; Od_incr = (string)tabela.Rows[a]["d_incr"]; } catch { }
            try {   novo.D_cidade = (string)tabela.Rows[a]["d_cidade"]; Od_cidade = (string)tabela.Rows[a]["d_cidade"]; } catch { }
            try {   novo.D_telefone = (string)tabela.Rows[a]["d_telefone"]; Od_telefone = (string)tabela.Rows[a]["d_telefone"]; } catch { }
            try {   novo.Tomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; Otomador_cnpj = (string)tabela.Rows[a]["tomador_cnpj"]; } catch { }
            try {   novo.Produto = (string)tabela.Rows[a]["produto"]; Oproduto = (string)tabela.Rows[a]["produto"]; } catch { }
            try {   novo.Valor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; Ovalor_mercadoria = (double)tabela.Rows[a]["valor_mercadoria"]; } catch { }
            try {   novo.Peso = (double)tabela.Rows[a]["peso"]; Opeso = (double)tabela.Rows[a]["peso"]; } catch { }
            try {   novo.Volume = (double)tabela.Rows[a]["volume"]; Ovolume = (double)tabela.Rows[a]["volume"]; } catch { }
            try {   novo.Volume_esperado = (double)tabela.Rows[a]["volume_esperado"]; Ovolume_esperado = (double)tabela.Rows[a]["volume_esperado"]; } catch { }
            try {   novo.Icms = (double)tabela.Rows[a]["icms"]; Oicms = (double)tabela.Rows[a]["icms"]; } catch { }
            try {   novo.Valor_total = (double)tabela.Rows[a]["valor_total"]; Ovalor_total = (double)tabela.Rows[a]["valor_total"]; } catch { }
            try {   novo.Valor_receber = (double)tabela.Rows[a]["valor_receber"]; Ovalor_receber = (double)tabela.Rows[a]["valor_receber"]; } catch { }
            try {   novo.Valor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; Ovalor_receber_esperado = (double)tabela.Rows[a]["valor_receber_esperado"]; } catch { }
            try {   novo.Motorista = (string)tabela.Rows[a]["motorista"]; Omotorista = (string)tabela.Rows[a]["motorista"]; } catch { }
            try {   novo.Placa = (string)tabela.Rows[a]["placa"]; Oplaca = (string)tabela.Rows[a]["placa"]; } catch { }
            try {   novo.Obs = (string)tabela.Rows[a]["obs"]; Oobs = (string)tabela.Rows[a]["obs"]; } catch { }
                lista.Add(novo);
            }
            return lista;
        }
static public DataView ListarParaDataGrid()
{
return Select.SelectSQL("select * from conhecimento").DefaultView;
}
static public DataView ListarParaDataGrid(string where)
{
return Select.SelectSQL("select * from conhecimento where " + where).DefaultView;
}
static public DataTable ObterTabela()
{
    return Select.SelectSQL("select * from conhecimento ");
}
static public DataTable ObterTabela(string where)
{
return Select.SelectSQL("select * from conhecimento where " + where + "");
}


# endregion
    }
}
