using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Atanor.Arquivos
{
    public class Informacoes
    {
        static public Boolean Existe(string NomeDoArquivo)
        {
            if (File.Exists(NomeDoArquivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
