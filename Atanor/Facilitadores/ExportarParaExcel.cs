using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel;
using System.Data;
namespace Atanor.Facilitadores
{
    public class ExportarParaExcel
    {
        
        static public void Exportar()
        {
            
            List<DataView> lista = new List<DataView>();

            for (int a = 0; a < Sessao.ExportaExcel.Count; a++)
            {
                lista.Add(Sessao.ExportaExcel[a].ItemsSource);
            }

            List<Pacotes> pacotes = new List<Pacotes>();

            for (int a = 0; a < lista.Count; a++)
            {
                Pacotes novo = new Pacotes();
                novo.NomeDaAaba = "Relatorio " + (a + 1) + "";
                novo.TituloNomeDoRelatorio = "Relatorio " + (a + 1) + "";
                novo.tabela = lista[a].Table;
                pacotes.Add(novo);
            }
            int tt = 0;

            Gerador.GerarExcel(true, pacotes, Environment.CurrentDirectory + "\\Relatorios\\", ""+DateTime.Now.Day+"."+DateTime.Now.Month+"."+DateTime.Now.Year+"."+DateTime.Now.Hour+"."+DateTime.Now.Minute+"."+DateTime.Now.Second+"."+DateTime.Now.Millisecond+"");

           // Gerador.GerarExcel(true, pacotes, Environment.CurrentDirectory + "\\Relatorios\\", "relatorio");
        }
    }
}
