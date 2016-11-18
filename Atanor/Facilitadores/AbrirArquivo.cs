using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atanor.Facilitadores
{
    public class AbrirArquivo
    {

        static public string Abrir()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }

      
        static public string Abrir(List<FiltrosDeArquivo> filtros)
        {
            OpenFileDialog of = new OpenFileDialog();

            string ofiltro = "";
            for (int a = 0; a < filtros.Count; a++)
            {
                ofiltro += ""+filtros[a].NomeDaExtensao+"|"+filtros[a].Extensao+"|";
            }

            ofiltro = ofiltro.Substring(0, ofiltro.Length - 1);
            of.Filter = ofiltro;

            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }



        static public string Excel()
        {
            OpenFileDialog of = new OpenFileDialog();
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

        static public string Html()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Html |*.html;*.htm;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }

        static public string IDB()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Conexao DGA |*.idb;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }

        static public string Imagens()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Imagens |*.jpg;*.gif;*.png;*.bmp";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }

        static public string Texto()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Texto |*.txt;";
            if (of.ShowDialog() == DialogResult.OK)
            {
                if (of.FileName != "" && Arquivos.Informacoes.Existe(of.FileName))
                {
                    return of.FileName;
                }
            }
            return "";
        }

        static public string Xml()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Xml |*.xml;";
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
    public class FiltrosDeArquivo
    {
        public string NomeDaExtensao = "";
        public string Extensao = "";
    }
}
