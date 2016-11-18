using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atanor.Facilitadores
{
    class ConverterDataSQLemDataTime
    {
        //2015-01-14T00:00:00-02:00

        public static DateTime converter(string data)
        {
            int pos = data.IndexOf("/");
            if (pos == 2)
            {
                return DateTime.Parse(data);
            }
            else
            {
                string ano = data.Substring(0, 4);
                string mes = data.Substring(5, 2);
                string dia = data.Substring(8, 2);
                string hora = data.Substring(11, 2);
                string minuto = data.Substring(14, 2);
                string segundo = data.Substring(17, 2);
                return DateTime.Parse("" + dia + "/" + mes + "/" + ano + " " + hora + ":" + minuto + ":" + segundo + "");
            }
        }
    }
}
