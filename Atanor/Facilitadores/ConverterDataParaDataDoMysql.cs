using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atanor.Facilitadores
{
    public class ConverterDataParaDataDoMysql
    {
        static public string Converter(DateTime data)
        {
            return "" + data.Year + "-" + data.Month + "-" + data.Day + " " + data.Hour + ":" + data.Minute + ":" + data.Second + "";
        }
    }
}
