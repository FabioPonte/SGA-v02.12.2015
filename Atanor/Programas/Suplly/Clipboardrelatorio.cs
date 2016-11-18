using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Atanor.Programas.Suplly
{
    public class Clipboardrelatorio
    {
       static public DataTable ObterRelatorioClipboard()
        {
            try
            {
                DataTable tabela = new DataTable();
                string texto = System.Windows.Forms.Clipboard.GetText();
                texto = texto.Replace("\t\r\n", "@");
                texto = texto.Replace("\t", "#");
                char x = char.Parse("#");
                char y = char.Parse("@");
                string[] linhas = texto.Split(y);
                Boolean coluna = true;
                for (int a = 0; a < linhas.Length; a++)
                {

                    if (coluna)
                    {
                        string[] celula = linhas[a].Split(x);
                        for (int b = 1; b <= celula.Length; b++)
                        {
                            tabela.Columns.Add("F" + b);
                        }
                        coluna = false;
                    }
                    else
                    {
                        string[] celula = linhas[a].Split(x);
                        object[] c = new object[celula.Length];
                        for (int b = 0; b < celula.Length; b++)
                        {
                            c[b] = celula[b].Replace(".", "").Replace(",", ".");
                        }
                        tabela.Rows.Add(c);
                    }
                }
                return tabela;
            }
            catch { return null; }
        }
    }
}
