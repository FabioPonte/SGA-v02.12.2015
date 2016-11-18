using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;
using System.Drawing;
using PdfSharp.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Atanor.Facilitadores
{
    class ExportarParaPDF
    {
        static public void Exportar()
        {
            try
            {
                string subPath = @"C:\Documentos\"; // your code goes here

                bool exists = System.IO.Directory.Exists(subPath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);

                string ur = Sessao.ExportaPdf[0] + "";
                string nome = @"C:\Documentos\DOCUMENTO" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "." + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + "" + DateTime.Now.Millisecond + ".pdf";
                Process.Start("wkhtmltopdf.exe", @"--margin-top 0 --margin-bottom 0 --margin-left 0 --margin-right 0  " + ur + " " + nome + "");
                Process.Start("EXPLORER.EXE", @"C:\documentos");
            }
            catch { }
        }

    }
}
