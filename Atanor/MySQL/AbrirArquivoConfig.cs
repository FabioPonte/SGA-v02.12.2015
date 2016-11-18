using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace Atanor.MySQL
{
    class AbrirArquivoConfig
    {
        static public DataTable AbrirArquivo()
        {
            System.Windows.Forms.OpenFileDialog novo = new System.Windows.Forms.OpenFileDialog();
            novo.Filter = "SGADB |*.idb";

            if (novo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return ImportDataTableFromFile(novo.FileName, "§", false);
            }
            return null;
        }

        static public DataTable AbrirConteudo(string url)
        {
                return ImportDataTableFromFile(url, "§", false);
        }

        public static DataTable ImportDataTableFromFile(string file, string delimited, bool importcolumnsheader)
        {
            StreamReader strFile1 = new StreamReader(file, System.Text.Encoding.Default);

            string strFile = Crypto.DecryptStringAES(strFile1.ReadLine());
            DataTable datatable = new DataTable();
            datatable.Columns.Add("servidor");
            datatable.Columns.Add("banco");
            datatable.Columns.Add("usuario");
            datatable.Columns.Add("senha");

            datatable.Rows.Add(strFile.Split(delimited.ToCharArray()));

            strFile1.Close();

            return datatable;
        }
    }
}
