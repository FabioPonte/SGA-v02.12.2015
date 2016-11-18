using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Atanor.Facilitadores
{
    public class Verificador
    {
        List<Campos> campos = new List<Campos>();

        public void Add(dynamic Controle, string MensagemDeErro)
        {
            Campos novo = new Campos();
            novo.controle = Controle;
            novo.MsgErro = MensagemDeErro;
            novo.verificar = true;
            campos.Add(novo);
        }

        public void Add(dynamic Controle, string MensagemDeErro,Boolean verificar)
        {
            Campos novo = new Campos();
            novo.controle = Controle;
            novo.MsgErro = MensagemDeErro;
            novo.verificar = verificar;
            campos.Add(novo);
        }
        public Boolean Analisar()
        {
            for (int a = 0; a < campos.Count; a++)
            {
                try
                {
                    if (campos[a].verificar)
                    {
                        try
                        {
                            if (campos[a].controle.Text.Trim() == "")
                            {
                                MsgBox.Show.Error(campos[a].MsgErro);
                                campos[a].controle.Focus();
                                return false;
                            }
                        }
                        catch { }

                        try
                        {
                            if (((PasswordBox)campos[a].controle).Password.Trim() == "")
                            {
                                MsgBox.Show.Error(campos[a].MsgErro);
                                campos[a].controle.Focus();
                                return false;
                            }
                        }
                        catch { }

                        try
                        {
                            if ( ((DatePicker)campos[a].controle).SelectedDate == null)
                            {
                                MsgBox.Show.Error(campos[a].MsgErro);
                                campos[a].controle.Focus();
                                return false;
                            }
                        }
                        catch { }

                        try
                        {
                            if (((ListBox)campos[a].controle).SelectedIndex== -1)
                            {
                                MsgBox.Show.Error(campos[a].MsgErro);
                                campos[a].controle.Focus();
                                return false;
                            }
                        }
                        catch { }

                        try
                        {
                            if (((ComboBox)campos[a].controle).SelectedIndex == -1)
                            {
                                MsgBox.Show.Error(campos[a].MsgErro);
                                campos[a].controle.Focus();
                                return false;
                            }
                        }
                        catch { }
                        
                    }
                }
                catch {

                    
                
                }
            }

            return true;
        }

        public void Limpar()
        {
            for (int a = 0; a < campos.Count; a++)
            {
                if (campos[a].controle.GetType() == typeof(TextBox))
                {
                    ((TextBox)campos[a].controle).Text = "";
                }
                if (campos[a].controle.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)campos[a].controle).SelectedIndex = -1;
                }
                if (campos[a].controle.GetType() == typeof(ListBox))
                {
                    ((ListBox)campos[a].controle).SelectedIndex = -1;
                }
                if (campos[a].controle.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)campos[a].controle).IsChecked = false;
                }
                if (campos[a].controle.GetType() == typeof(DataGrid))
                {
                    ((DataGrid)campos[a].controle).SelectedIndex = -1;
                }
                if (campos[a].controle.GetType() == typeof(PasswordBox))
                {
                    ((PasswordBox)campos[a].controle).Password = "";
                }
                if (campos[a].controle.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)campos[a].controle).IsChecked = false;
                }

            }
        }

        
    }
    public class Campos
    {
        public dynamic controle;
        public string MsgErro;
        public Boolean verificar;
    }
}
