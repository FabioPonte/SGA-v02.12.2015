using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;        
namespace Atanor.Facilitadores
{
   public  class ErroLog
    {
       static public void Registrar(dynamic x)
       {
           try
           {
               if (!Directory.Exists(Environment.CurrentDirectory + "\\Erros"))
               {
                   Directory.CreateDirectory(Environment.CurrentDirectory + "\\Erros");
               }

               string windows = Environment.UserName;
               string pc = Environment.MachineName;
               string usuario = "Não Logado!";
               try
               {
                   usuario = Sessao.usuario.Nome; ;
               }
               catch { }
               string data = "" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Minute + "";
               string arquivo = "("+pc+") ("+usuario+") " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + " " + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + "." + DateTime.Now.Minute + ".txt";

               string resumo = "";
               string erro = x + "";
               char d = char.Parse("§");
               erro = erro.Replace("\n", "§");
               string[] linhas = erro.Split(d);

               resumo += linhas[0] + "" + Environment.NewLine;
               string motivo = "";

               try
               {
                   int p1 = resumo.IndexOf(":");
                   int p2 = resumo.Length;
                   int p3 = p2 - p1;
                   motivo = resumo.Substring(p1, p3);
               }
               catch { }
               




               for (int a = 1; a < linhas.Length; a++)
               {
                   if (linhas[a].IndexOf("linha ") != -1)
                   {
                       resumo += linhas[a] + "" + Environment.NewLine;
                   }
               }

               StreamWriter escritor = new StreamWriter(Environment.CurrentDirectory + "\\Erros\\" + arquivo + "");
               escritor.WriteLine("Usuário SGA: "+usuario);
               escritor.WriteLine("Usuário Windows: "+windows);
               escritor.WriteLine("Nome do Computador: "+pc);
               escritor.WriteLine("Data do Erro: "+data);
               escritor.WriteLine("Motivo do Erro: " + motivo);
               escritor.WriteLine(Environment.NewLine);
               escritor.WriteLine("===================================================================================================");
               escritor.WriteLine("Resumo do Erro. "+motivo+"");
               escritor.WriteLine(Environment.NewLine);
               escritor.WriteLine(resumo);
               escritor.WriteLine(Environment.NewLine);
               escritor.WriteLine("===================================================================================================");
               escritor.WriteLine("Erro detalhado.");
               escritor.WriteLine(Environment.NewLine);
               escritor.WriteLine(x + "");
               escritor.Close();
           }
           catch (Exception ex) { Xceed.Wpf.Toolkit.MessageBox.Show("Erro ao salvar log de erro." + Environment.NewLine + "" + Environment.NewLine + "" + x + ""); }
       }
    }
}
