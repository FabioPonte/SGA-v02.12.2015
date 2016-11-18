using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Atanor.MsgBox
{
    public class Show
    {


        public static void Error(string msg,dynamic controle)
        {
            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }
        
            
            new Alerta(msg).ShowDialog();

            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }
            
            
            controle.Focus();
            
        }

        public static void Error(string msg)
        {

            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }
            
            new Erro(msg).ShowDialog();
            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }
            
        }

        public static void Info(string msg)
        {
            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }
            
            new Alerta(msg).ShowDialog();
            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }
            
        }

        public static Boolean Pergunta(string msg)
        {
            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }
            
            Pergunta nova = new Pergunta(msg);
            nova.ShowDialog();
            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }
            
            return nova.retorno;
        }

        public static void Info(string msg, dynamic controle)
        {
            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }

            new Erro(msg).ShowDialog();
            controle.Focus();

            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }

        }

        static public Aguarde aguarde = new Aguarde();

        public static void EspereAbrir()
        {
            try
            {
                Sessao.EfeitoBlur.Height = Sessao.JanelaPrincipal.Height;
            }
            catch { }
            aguarde = new Aguarde();
            aguarde.ShowDialog();
            
        }

        public static void EspereFechar()
        {
            aguarde.Close();
            try
            {
                Sessao.EfeitoBlur.Height = 0;
            }
            catch { }
        }

        public static void Alarme(int id)
        {

            MsgBox.Alarme x = new MsgBox.Alarme(id);
            x.Show();

        }


        public static PacoteMotivo Motivo(string titulo, string msg)
        {
            MsgBox.Motivos x = new Motivos(titulo,msg);
            x.ShowDialog();
            PacoteMotivo m = x.motivo;
            return m;   
        }
    }
    public class PacoteMotivo
    {
        public Boolean Retorno;
        public string Motivo;
    }
}
