using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;
using Conector;

namespace Atanor.Facilitadores
{
    public class TrocarFotodeUsuario
    {
        
        static public void Mudar()
        {
            ExecuteNonSql.Retorno += new ExecuteNonSql.retorno(ExecuteNonSql_Retorno);

            string url = Facilitadores.AbrirArquivo.Imagens();
            if (url != "")
            {
                if (File.Exists(url))
                {
                    BitmapImage foto=new BitmapImage(new Uri(url,UriKind.RelativeOrAbsolute));

                    List<string> colunas = new List<string>();
                    colunas.Add("foto");

                    List<dynamic> valores = new List<dynamic>();
                    valores.Add(Facilitadores.ConverterImagemEmByte.Converter(foto));

                    List<dynamic> condicao = new List<dynamic>();
                    condicao.Add("id="+Sessao.usuario.Id+"");
                    ExecuteNonSql.ExecutarThread("usuarios", TipoDeOperacao.Tipo.Update, colunas, valores, condicao,true);
                }
            }
        }

        static void ExecuteNonSql_Retorno(int retorno)
        {
            if (retorno!=-1)
            {
                dynamic afoto = ((dynamic)Select.SelectSQL("select * from usuarios x where x.id=" + Sessao.usuario.Id + "").Rows[0]["foto"]);
                Sessao.usuario.Foto = Facilitadores.ConverterBytsEmImagens.Converter(afoto);

            }
        }
    }
}
