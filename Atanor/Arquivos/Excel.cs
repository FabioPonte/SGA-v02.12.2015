using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Atanor.Arquivos
{
    public class Excel
    {
        static public DataTable Executar(string arquivo, string sql, string hdr)
        {
            OleDbConnection conexao = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + arquivo + "';Extended Properties='Excel 12.0 Xml;HDR=" + hdr + ";IMEX=1';");
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conexao);
            DataSet ds = new DataSet();
            try
            {
                conexao.Open();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
               MsgBox.Show.Error(ex.ToString());
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
