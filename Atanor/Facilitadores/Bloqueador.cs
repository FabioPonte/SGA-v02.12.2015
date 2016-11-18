using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Conector;
using System.Data;
namespace Atanor.Facilitadores
{
    public class Bloqueador
    {
        
        static public Boolean VerificarPermissao(UserControl controle)
        {
            string ok = "";
            dynamic dy = controle;
            try
            {
                string aid = dy.per + "";
                try
                {
                    ok = Select.SelectSQL("select id from  permissao_usuario x where x.idusuario=" + Sessao.usuario.Id + " and x.idpermissao="+aid+"").Rows[0][0] + "";
                    if (ok == "")
                    {
                        Sessao.FecharPrograma(controle);
                        MsgBox.Show.Error("Sem acesso!");
                        return false;
                    }
                    return true;
                }
                catch
                {
                    Sessao.FecharPrograma(controle);
                    MsgBox.Show.Error("Sem acesso!");
                    return false;
                }
            }
            catch {
                Sessao.FecharPrograma(controle);
                MsgBox.Show.Error("Código de permissão não foi encontrado!");
                return false;
            }
        }
            
    }
}
