using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atanor.Facilitadores
{
    public class Data
    {
        static public string Dia()
        {
            string v = DateTime.Now.Day + "";
            if (v.Length == 1) v = "0" + v;
            return v;
        }
        static public string Mes() 
        {
            string v = DateTime.Now.Month + "";
            if (v.Length == 1) v = "0" + v;
            return v;
        }
        static public int Ano() { return DateTime.Now.Year; }
        static public string Hora()
        {
            string v = DateTime.Now.Hour + "";
            if (v.Length == 1) v = "0" + v;
            return v;
            
        }
        static public string Minuto()
        {
            string v = DateTime.Now.Minute + "";
            if (v.Length == 1) v = "0" + v;
            return v;
        }
        static public string Segundo()
        {

            string v = DateTime.Now.Second + "";
            if (v.Length == 1) v = "0" + v;
            return v;

            
        
        }

        static public string Datas() { return "" + Dia() + "/" + Mes() + "/" + Ano() + ""; }
        static public string DataHora() { return "" + Dia() + "/" + Mes() + "/" + Ano() + " "+Hora()+":"+Minuto()+":"+Segundo()+""; }
        static public string Horas() { return "" + Hora() + ":" + Minuto() + ":" + Segundo() + ""; }
    }
}
