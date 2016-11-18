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
using System.Windows.Shapes;

namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for CheckListFinal.xaml
    /// </summary>
    public partial class CheckListFinal : Window
    {
        public Banco.checklist checklist = new Banco.checklist();
        public Boolean finalizou = false;

        public CheckListFinal()
        {
            InitializeComponent();
        }

        private void Todos(Boolean x)
        {
            M1.IsChecked = x;
            M2.IsChecked = x;
            M3.IsChecked = x;
            M4.IsChecked = x;
            M5.IsChecked = x;

            I1.IsChecked = x;
            I2.IsChecked = x;
            I3.IsChecked = x;
            I4.IsChecked = x;
            I5.IsChecked = x;
            I6.IsChecked = x;

            L1.IsChecked = x;
            L2.IsChecked = x;
            L3.IsChecked = x;
            L4.IsChecked = x;
            L5.IsChecked = x;
            L6.IsChecked = x;
            L7.IsChecked = x;




        }

        private void btn_tudo_Click(object sender, RoutedEventArgs e)
        {
            Todos(true);
        }

        private void btn_nada_Click(object sender, RoutedEventArgs e)
        {
            Todos(false);
        }

        private void btn_gravar_Click(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show.Pergunta("A informação está correta?"))
            {
                checklist.M1 = Convert.ToBoolean(M1.IsChecked);
                checklist.M2 = Convert.ToBoolean(M2.IsChecked);
                checklist.M3 = Convert.ToBoolean(M3.IsChecked);
                checklist.M4 = Convert.ToBoolean(M4.IsChecked);
                checklist.M5 = Convert.ToBoolean(M5.IsChecked);
                checklist.I1 = Convert.ToBoolean(I1.IsChecked);
                checklist.I2 = Convert.ToBoolean(I2.IsChecked);
                checklist.I3 = Convert.ToBoolean(I3.IsChecked);
                checklist.I4 = Convert.ToBoolean(I4.IsChecked);
                checklist.I5 = Convert.ToBoolean(I5.IsChecked);
                checklist.I6 = Convert.ToBoolean(I6.IsChecked);
                checklist.L1 = Convert.ToBoolean(L1.IsChecked);
                checklist.L2 = Convert.ToBoolean(L2.IsChecked);
                checklist.L3 = Convert.ToBoolean(L3.IsChecked);
                checklist.L4 = Convert.ToBoolean(L4.IsChecked);
                checklist.L5 = Convert.ToBoolean(L5.IsChecked);
                checklist.L6 = Convert.ToBoolean(L6.IsChecked);
                checklist.L7 = Convert.ToBoolean(L7.IsChecked);
                finalizou = true;
                this.Close();
            }
        }
    }
}
