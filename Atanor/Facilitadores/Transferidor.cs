using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Data;
using System.Windows;

namespace Atanor.Facilitadores
{
    public class Transferidor
    {
        string valor = "";
        int ex = 0;
        private ComboBox comb;
        private Boolean externo = false;

        public ComboBox Combo
        {
            get { return comb; }
            set { comb = value;}
        }


        public delegate void retorno();
        public event retorno Retorno;
             
        public UserControl controle;
        public void add(string v)
        {

            try
            {
                Retorno();
            }
            catch { }

            valor = v;
            for (int a = 0; a < Combo.Items.Count; a++)
            {
                DataRowView c = (DataRowView)Combo.Items[a];
                dynamic b = c[0];
                if ((b + "") == valor)
                {
                    Combo.SelectedIndex = ex;
                    ex = a;
                    break;
                }
            }
           

            foreach (dynamic tb in FindVisualChildren<Control>(controle))
            {
                if (tb.Name == Combo.Name)
                {
                    tb.SelectedIndex = ex;
                }
            }


           Window janela = Window.GetWindow(controle);
            dynamic d = janela;
            try
            {
                externo = d.externamente;
            }
            catch { }

            if (externo)
            {
                janela.Focus();
            }
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        

     

       

    }
}
