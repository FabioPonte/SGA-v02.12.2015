using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace Atanor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                MainWindow x = new MainWindow();
                x.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO SEM TRATAMENTO!!! "+Environment.NewLine+""+ex + "", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Facilitadores.ErroLog.Registrar(ex);
            }
        }
    }
}
