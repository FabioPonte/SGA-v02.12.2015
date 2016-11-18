using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Atanor.Facilitadores
{
    public class ConverterHexaEmBrushes
    {
        public static Brush Color(string hex)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush;
            brush = (Brush)bc.ConvertFrom(hex);
            return brush;
        }
    }
}
