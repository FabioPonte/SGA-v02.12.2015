﻿using System;
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

namespace Atanor.MsgBox
{
    /// <summary>
    /// Interaction logic for Aguarde.xaml
    /// </summary>
    public partial class Aguarde : Window
    {
        public Aguarde()
        {
            InitializeComponent();
        }
        public void Fechar()
        {
            MSG.Content = "Aguarde, por favor!";
            this.Close();
        }

        

      
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
