using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Threading;

namespace Atanor.Programas.Expedicao
{
    public class ObterInformacaoDaNota
    {

        public delegate void retorno(DadosNota nota);
        public delegate void erron(string nota);
        public event retorno Retorno;
        public event erron ErroNota;
        DispatcherTimer timer = new DispatcherTimer();
        string Nota = "";
        public ObterInformacaoDaNota()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
        }

        int tempo = 0;

        void timer_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Config.local + "" + Nota + ".retorno"))
            {
                if (!IsFileInUse(Config.local + "" + Nota + ".retorno"))
                {
                    try
                    {
                        Retorno(RetornarInformacao(Config.local + "" + Nota + ".retorno"));
                    }
                    catch (Exception ex)
                    {
                        Facilitadores.ErroLog.Registrar(ex);
                        MsgBox.Show.Error(ex + "");
                        try
                        {
                            ErroNota(Nota);
                        }
                        catch { }
                        tempo = 0;
                        timer.Stop();
                    }
                    tempo = 0;
                    timer.Stop();
                }

            }

            if (tempo == 10)
            {
                try
                {
                    ErroNota(Nota);

                }
                catch { }
                tempo = 0;
                timer.Stop();
            }
            tempo++;
        }

        public Boolean SolicitarNota(string nota, string cd)
        {
            try
            {
                Nota = nota;
                Config.Obterlocal();
                StreamWriter escritor = new StreamWriter(Config.local + "" + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".mathias");
                escritor.WriteLine(cd);
                escritor.WriteLine(nota);
                escritor.Close();
                timer.Start();
                return true;
            }
            catch { return false; }
        }

        public DadosNota RetornarInformacao(string arquivo)
        {

            StreamReader leitor = new StreamReader(arquivo);
            string x = leitor.ReadToEnd();
            leitor.Close();
            if (x.IndexOf("infEvento") != -1)
                return null;
            int p1 = x.IndexOf("Id=") + 4;
            string nfe = x.Substring(p1, 47);
            string nota = sub(x, "<nNF>", "</nNF>");
            string cfaz = sub(x, "<xMotivo>", "</xMotivo>");
            double valor = 0;
            try
            {
                valor = double.Parse(sub(x, "</vST><vProd>", "</vProd><vFrete>"));
            }
            catch { }
            string data = sub(x, "Emi>", "</d");
            string dia = "";
            dia = data.Substring(8, 2);
            string mes = "";
            mes = data.Substring(5, 2);
            string ano = "";
            ano = data.Substring(0, 4);
            data = "" + dia + "/" + mes + "/" + ano + "";
            string xcliente = sub(x, "<dest>", "</dest>");
            string cliente = sub(xcliente, "<xNome>", "</xNome>");
            string UF = sub(xcliente, "<UF>", "</UF>");
            string cidade = sub(xcliente, "<xMun>", "</xMun>");
            string bairro = sub(xcliente, "<xBairro>", "</xBairro>");
            string rua = sub(xcliente, "<xLgr>", "</xLgr>");
            string numero = sub(xcliente, "<nro>", "</nro>");
            string pais = sub(xcliente, "<xPais>", "</xPais>");
            string cep = sub(xcliente, "<CEP>", "</CEP>");
            string fone = sub(xcliente, "<fone>", "</fone>");
            string email = sub(xcliente, "<email>", "</email>");
            string cnpj_cliente = sub(xcliente, "<CNPJ>", "</CNPJ>");
            string cfop = sub(x, "<natOp>", "</natOp>");
            string xtraps = sub(x, "<transp>", "</transp>");
            string cnpj_trasportadora = sub(xtraps, "<CNPJ>", "</CNPJ>");
            string transportadora = sub(xtraps, "<xNome>", "</xNome>");
            string embalegem = sub(xtraps, "<esp>", "</esp>");
            string qtd_embalagem = sub(xtraps, "<qVol>", "</qVol>");
            double peso_liquido = 0;
            double peso_bruto = 0;
            try
            {
                peso_liquido = double.Parse(sub(xtraps, "<pesoL>", "</pesoL>")) / 1000;
            }
            catch { }
            try
            {
                peso_bruto = double.Parse(sub(xtraps, "<pesoB>", "</pesoB>")) / 1000;
            }
            catch { }




            List<Produto> n = new List<Produto>();

            string y = sub(x, "<det ", "<total>");

            for (int p = 0; p <= 1000; p++)
            {
                if (y.IndexOf("<cProd>") == -1)
                    break;

                Produto po = new Produto();
                List<string> lotes = new List<string>();
                List<double> volume = new List<double>();

                po.produto = sub(y, "<cProd>", "</cProd>");
                po.valor = 0;
                try
                {
                    po.valor = double.Parse(sub(y, "<vProd>", "</vProd>")) / 100;
                }
                catch { }




                p1 = y.IndexOf("<infAdProd>") + 11;
                int p2 = y.IndexOf("</infAdProd>");
                if (p2 < 0) p2 = 0;
                int p3 = p2 - p1;
                int pf = p2 + 12;

                if (p3 > 0)
                {

                    string w = y.Substring(p1, p3);



                    for (int b1 = 0; b1 < 1000; b1++)
                    {

                        if (w.IndexOf("Lote") == -1) break;

                        p1 = w.IndexOf("Lote");
                        p2 = w.Length;
                        if (p2 < 0) p2 = 0;
                        p3 = p2 - p1;

                        w = w.Substring(p1, p3);

                        p1 = w.IndexOf("Lote:") + 5;
                        p2 = w.IndexOf(",");
                        if (p2 < 0) p2 = 0;
                        p3 = p2 - p1;

                        string p1l = w.Substring(p1, p3);


                        p1 = 0;
                        p2 = p1l.IndexOf("Qtde:");
                        if (p2 < 0) p2 = 0;
                        p3 = p2 - p1;

                        string lot = p1l.Substring(p1, p3).Trim();

                        p1 = p1l.IndexOf("Qtde:") + 5;
                        p2 = p1l.Length;
                        if (p2 < 0) p2 = 0;
                        p3 = p2 - p1;

                        string vol = p1l.Substring(p1, p3).Trim();

                        lotes.Add(lot);
                        volume.Add(double.Parse(vol));


                        p1 = w.IndexOf(",");
                        p2 = w.Length;
                        if (p2 < 0) p2 = 0;
                        p3 = p2 - p1;

                        w = w.Substring(p1, p3);
                    }

                }
                po.lote = lotes;
                po.volume = volume;
                n.Add(po);


                p1 = pf;
                p2 = y.Length;
                p3 = p2 - p1;

                y = y.Substring(p1, p3);
            }

            DadosNota novo = new DadosNota();
            novo.cfop = cfop;
            novo.cidade = cidade;
            novo.cliente = cliente;
            novo.data = data;
            novo.estado = UF;
            novo.nota = nota;
            novo.Valor = valor / 100;
            novo.produto = n;
            novo.cfaz = cfaz;
            novo.bairro = bairro;
            novo.rua = rua;
            novo.numero = numero;
            novo.cep = cep;
            novo.pais = pais;
            novo.fone = fone;
            novo.email = email;
            novo.cnpj_cliente = cnpj_cliente;
            novo.cnpj_transportadora = cnpj_trasportadora;
            novo.transportadora = transportadora;
            novo.embalegem = embalegem;
            novo.qtd_embalagem = qtd_embalagem;
            novo.peso_liquido = peso_liquido;
            novo.peso_bruto = peso_bruto;


            double con = 0;
            for (int a = 0; a < n.Count; a++)
            {
                con += n[a].valor;
            }

            novo.dif_valor = novo.Valor - con;

            try
            {
                File.Delete(Config.local + "" + Nota + ".retorno");
            }
            catch { }
            return novo;
        }

        public bool IsFileInUse(string path)
        {

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }

        public string sub(string valor, string inicio, string fim)
        {

            int p1 = valor.IndexOf(inicio) + inicio.Length;
            int p2 = valor.IndexOf(fim);
            int p3 = p2 - p1;

            if (p1 <= 0) return "";
            if (p2 <= 0) return "";

            return valor.Substring(p1, p3);
        }
    }

    public class DadosNota
    {
        public string nota;
        public string data;
        public string cliente;
        public string estado;
        public string cidade;
        public string cfop;
        public double Valor;
        public double dif_valor;
        public string cfaz;
        public string bairro;
        public string rua;
        public string numero;
        public string cep;
        public string pais;
        public string fone;
        public string email;
        public string cnpj_cliente;
        public string cnpj_transportadora;
        public string transportadora;
        public string embalegem;
        public string qtd_embalagem;
        public double peso_liquido;
        public double peso_bruto;
        public List<Produto> produto = new List<Produto>();
    }
    public class Produto
    {
        public string produto;
        public double valor;
        public List<string> lote = new List<string>();
        public List<double> volume = new List<double>();
    }
    public class Config
    {
        static public string local = "";

        static public void Obterlocal()
        {
            string l = Environment.CurrentDirectory + "\\";
            if (File.Exists(l + "config.ianez"))
            {
                StreamReader leitor = new StreamReader(l + "config.ianez");
                local = leitor.ReadLine();
                leitor.Close();
            }

        }
    }
}
