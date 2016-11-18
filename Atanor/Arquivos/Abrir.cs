using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Atanor.Arquivos
{
    public class Abrir
    {
        static public string Excel()
        {
            OpenFileDialog of=new OpenFileDialog();
            of.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }
    }
}
