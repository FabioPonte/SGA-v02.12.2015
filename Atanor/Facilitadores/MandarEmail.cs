using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Atanor.Facilitadores
{
    public class MandarEmail
    {
        static public Boolean Mandar(PacoteEmails pacote,string msg,string titulo,Boolean html)
        {

            try
            {
                string CorpoEmail = msg;
                MailMessage mailMessage = new MailMessage();
                //Endereço que irá aparecer no e-mail do usuário
                mailMessage.From = new MailAddress("ianez.mathias@atarbrasil.com.br", titulo);
                //destinatarios do e-mail, para incluir mais de um basta separar por ponto e virgula 
                for (int a = 0; a < pacote.emails.Count; a++)
                {
                    mailMessage.To.Add(pacote.emails[a]+"");
                }
                
                mailMessage.Subject = titulo;
                mailMessage.IsBodyHtml = html;
                //conteudo do corpo do e-mail
                mailMessage.Body = CorpoEmail.ToString();
                mailMessage.Priority = MailPriority.High;
                //smtp do e-mail que irá enviar
                SmtpClient smtpClient = new SmtpClient("smtp.terra.com.br", 587);
                smtpClient.EnableSsl = false;
                //credenciais da conta que utilizará para enviar o e-mail
                smtpClient.Credentials = new NetworkCredential("ianez.mathias@atarbrasil.com.br", "mudar123");
                smtpClient.Send(mailMessage);
                return true;
            }
            catch(Exception ex)
            {
                MsgBox.Show.Error(ex + "");
                return false;
            }
        }
    }
    public class PacoteEmails
    {
        public List<string> emails = new List<string>();
    }
}
