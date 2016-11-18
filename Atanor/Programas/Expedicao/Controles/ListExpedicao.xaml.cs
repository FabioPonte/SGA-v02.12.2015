using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atanor.Programas.Expedicao.Controles
{
    /// <summary>
    /// Interaction logic for ListExpedicao.xaml
    /// </summary>
    public partial class ListExpedicao : UserControl
    {
        Storyboard on = new Storyboard();
        Storyboard off = new Storyboard();
        public ListExpedicao()
        {
            InitializeComponent();
            on = FindResource("on") as Storyboard;
            off = FindResource("off") as Storyboard;
        }

        List<ListExpedicaoItem> Itens = new List<ListExpedicaoItem>();

        public void Add(Programas.Expedicao.Controles.ListExpedicaoItem itens)
        {
            Painel.Children.Add(itens);
            itens.Excluido += itens_Excluido;
            itens.ChangeCheck += Itens_ChangeCheck;
            Itens.Add(itens);
        }

        Boolean efeito = false;

        private string notas()
        {
            List<ListExpedicaoItem> lista = ObterItensAtivo();

            string msg = "";

            for(int a = 0; a < lista.Count; a++)
            {
                if (a == 0)
                {
                    msg += "" + lista[a].Nota + "";
                }
                else
                {
                    msg += "," + lista[a].Nota + "";
                }
                
            }
            return msg;
        }
             
        private void Itens_ChangeCheck(ListExpedicaoItem index)
        {
            int c = ObterItensAtivo().Count;

            if (c > 0 && efeito == false)
            {
                on.Begin();
                efeito = true;
            }
            if (c == 0 && efeito==true)
            {
                efeito = false;
                off.Begin();
            }
            if (c == 1)
            {
                lbl_info.Content = "" + c + " Nota Selecionada "+notas()+"";
            }

            if (c > 1)
            {
                lbl_info.Content = "" + c + " Notas Selecionadas " + notas() + "";
            }


        }

        void itens_Excluido(ListExpedicaoItem item)
        {
            try
            {
                Painel.Children.Remove(item);
            }
            catch { }

            try
            {
                Itens.Remove(item);
            }
            catch { }
        }

        public List<ListExpedicaoItem> ObterItensAtivo()
        {
            List<ListExpedicaoItem> i = new List<ListExpedicaoItem>();
            for (int a = 0; a < Itens.Count; a++)
            {
                if (Itens[a].Expedir == true)
                    i.Add(Itens[a]);
            }
            return i;
        }
        public List<ListExpedicaoItem> ObterItensInativo()
        {
            List<ListExpedicaoItem> i = new List<ListExpedicaoItem>();
            for (int a = 0; a < Itens.Count; a++)
            {
                if (Itens[a].Expedir == false)
                    i.Add(Itens[a]);
            }
            return i;
        }

        public ListExpedicaoItem ObterItem(int index)
        {
            try
            {
                return Itens[index];
            }
            catch { return null; }
        }
        public Boolean? ObterExpedicao(ListExpedicaoItem index)
        {
            try
            {
                for (int a = 0; a < Itens.Count; a++)
                {
                    if (index == Itens[a]) return Itens[a].Expedir;
                }
                return null;
            }
            catch { return null; }
        }
        public String ObterNota(ListExpedicaoItem index)
        {
            try
            {
                for (int a = 0; a < Itens.Count; a++)
                {
                    if (index == Itens[a]) return Itens[a].Nota;
                }
                return null;
            }
            catch { return null; }
        }
        public String ObterID(ListExpedicaoItem index)
        {
            try
            {
                for (int a = 0; a < Itens.Count; a++)
                {
                    if (index == Itens[a]) return Itens[a].Id;
                }
                return null;
            }
            catch { return null; }
        }


        DataTable itemSource;

        public DataTable ItemSource
        {
            get { return itemSource; }
            set { itemSource = value; Popular(); }
        }

        public void DesmarcarTudo()
        {
            for (int a = 0; a < Itens.Count; a++)
            {
                Itens[a].Desmarcar();
            }
        }
        public void MarcarTudo()
        {
            for (int a = 0; a < Itens.Count; a++)
            {
                Itens[a].Marcar();
            }
        }

        private void Popular()
        {
            string id = "";
            string data = "";
            string nota = "";
            string cfop = "";
            string cliente = "";
            string cd = "";
            string estado = "";

            for (int a = 0; a < itemSource.Rows.Count; a++)
            {
                id = itemSource.Rows[a]["id"] + "";
                data = itemSource.Rows[a]["data"] + "";
                nota = itemSource.Rows[a]["nota"] + "";
                cfop = itemSource.Rows[a]["cfop"] + "";
                cliente = itemSource.Rows[a]["cliente"] + "";
                cd = itemSource.Rows[a]["cd"] + "";
                estado = itemSource.Rows[a]["uf"] + "";
                ListExpedicaoItem nova = new ListExpedicaoItem();
                nova.Id = id;
                nova.Data = data;
                nova.Nota = nota;
                nova.Cfop = cfop;
                nova.Cliente = cliente;
                nova.Cd = cd;
                nova.Estado = estado;
                Add(nova);
            }
        }

    }
}
