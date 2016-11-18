using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;

namespace Atanor
{
    class BancoFileIanez
    {
        DispatcherTimer temp = new DispatcherTimer();
        DispatcherTimer timeout = new DispatcherTimer();
        public delegate void retorno(DataSet tabelas);
        public event retorno Retorno;

        public delegate void info();
        public delegate void info2(string msg);
        public event info Esperando;
        public event info Carregando;
        public event info Retornado;
        public event info2 Erro;
        public event info2 Msg;

        public string Local = "";
        public string Localizar = "";

        List<string> localizados = new List<string>();

        public BancoFileIanez(string pastaLocal)
        {
            Local = pastaLocal;
            temp.Interval = new TimeSpan(0, 0, 0, 0, 50);
            temp.Tick += Temp_Tick;
            timeout.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timeout.Tick += Timeout_Tick;
            
        }

        private void PararTempo()
        {
            temp.Stop();
            for(int a = 0; a < localizados.Count; a++)
            {
                try
                {
                    if (File.Exists(Local + "" + localizados[a] + ".consulta.esp"))
                    {
                        File.Delete(Local + "" + localizados[a] + ".consulta.esp");
                    }

                    if (File.Exists(Local + "" + localizados[a] + ".consulta"))
                    {
                        File.Delete(Local + "" + localizados[a] + ".consulta");
                    }

                    if (File.Exists(Local + "" + localizados[a] + ".consulta.esp"))
                    {
                        File.Delete(Local + "" + localizados[a] + ".consulta.esp");
                    }

                    if (File.Exists(Local + "" + localizados[a] + ".consulta.retorno"))
                    {
                        File.Delete(Local + "" + localizados[a] + ".consulta.retorno");
                    }

                    if (File.Exists(Local + "" + localizados[a] + ".consulta.erro"))
                    {
                        File.Delete(Local + "" + localizados[a] + ".consulta.erro");
                    }
                }
                catch { }
            }
        }

        int contador = 0;
        private void Timeout_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(Local + "" + Localizar + ".consulta.esp"))
            {
                contador++;
            }
            if (contador >= 30)
            {
                try
                {
                    File.Delete(Local + "" + Localizar + ".consulta");
                }
                catch { }

                PararTempo();
                timeout.Stop();
                Erro("Sistema remoto não respondeu!");
            }
        }

        public void Select(string osql)
        {
            DataTable nova = new DataTable();
            nova.Columns.Add("osql");
            nova.Rows.Add(osql);

            DataTable novo = new DataTable();
            novo.Columns.Add("info");
            novo.Rows.Add("info");

            DataSet pacote = new DataSet();
            pacote.Tables.Add(nova);
            pacote.Tables.Add(novo);

            string nome = Guid.NewGuid().ToString();

            pacote.WriteXml(Local + "" + nome + ".consulta");

            Localizar = nome;
            localizados.Add(nome);
            temp.Start();
            timeout.Start();
        }


        private void Temp_Tick(object sender, EventArgs e)
        {
            if (File.Exists(Local + "" + Localizar + ".consulta.esp"))
            {
                try
                {
                    Carregando();
                }
                catch { }
                timeout.Stop();
                if (File.Exists(Local + "" + Localizar + ".consulta.retorno"))
                {
                    try
                    {
                        DataSet ret = new DataSet();
                        try {
                            ret.ReadXml(Local + "" + Localizar + ".consulta.retorno");
                        }
                        catch {  return; }
                        Retorno(ret);
                        try
                        {
                            File.Delete(Local + "" + Localizar + ".consulta.retorno");
                            File.Delete(Local + "" + Localizar + ".consulta.esp");
                        }
                        catch { }

                        try
                        {
                            Retornado();
                        }
                        catch { }
                        temp.Interval = new TimeSpan(0, 0, 0, 0, 50);
                        PararTempo();
                        timeout.Stop();
                    }
                    catch (IOException ex) { Msg("Tentando abrir o arquivo"); temp.Interval = new TimeSpan(0, 0, 0, 1, 50); }
                }

                if (File.Exists(Local + "" + Localizar + ".consulta.erro"))
                {
                    Thread.Sleep(500);
                    try
                    {
                        StreamReader leitor = new StreamReader(Local + "" + Localizar + ".consulta.erro");
                        string msg = leitor.ReadToEnd();
                        leitor.Close();
                        Erro(msg);

                        try
                        {
                            File.Delete(Local + "" + Localizar + ".consulta.erro");
                            File.Delete(Local + "" + Localizar + ".consulta.esp");
                        }
                        catch { }
                        PararTempo();
                        timeout.Stop();

                    }
                    catch { Erro("Um arquivo erro foi gerado, mas o sistema não conseguiu ler."); temp.Stop(); }
                }
            }
            else
            {
                try
                {
                    Esperando();
                }
                catch { }
            }
        }

    }
}
