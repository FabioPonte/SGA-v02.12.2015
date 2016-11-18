using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Atanor.Facilitadores
{
    public class ConverteDataParaDataGrid
    {
        static public void Converter(DataGrid controle)
        {
            controle.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(controle_AutoGeneratingColumn);
        }

        static public void ConverterHora(DataGrid controle)
        {
            controle.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(controle_AutoGeneratingColumn2);
        }

        static void controle_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";

        }

        static void controle_AutoGeneratingColumn2(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy HH:mm:ss";

        }

    }
}
