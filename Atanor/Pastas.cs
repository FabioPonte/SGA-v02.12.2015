using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Atanor
{
    public class Pastas
    {
       static public string Relatorios = Environment.CurrentDirectory + "\\Relatorios\\";
       static public string Conexoes = Environment.CurrentDirectory + "\\Conexoes\\";
       static public string Modelos = Environment.CurrentDirectory + "\\Modelos\\";
       static public string Notas = ObterCaminho();

       private static string ObterCaminho()
       {
           string arquivo = Environment.CurrentDirectory + "\\config.ianez";
           if (File.Exists(arquivo))
           {
               StreamReader leitor = new StreamReader(arquivo);
               string enderecp = leitor.ReadLine();
               leitor.Close();
               return enderecp;
           }
           return @"c:\notas\";
       }
    }
}
