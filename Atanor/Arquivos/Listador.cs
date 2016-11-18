using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Atanor.Arquivos
{
    public class Listador
    {
        static public DataTable ListarConectores()
        {
            DirectoryInfo diretorio = new DirectoryInfo(@Environment.CurrentDirectory + "\\Conexoes");
            FileInfo[] Arquivos = diretorio.GetFiles("*.idb");

            DataTable tabela = new DataTable();
            tabela.Columns.Add("nome");
            tabela.Columns.Add("local");

            foreach (FileInfo fileinfo in Arquivos)
            {
                tabela.Rows.Add(fileinfo.Name.Replace(".idb","") + "", fileinfo.FullName);
            }
            return tabela;
        }

    }
}
