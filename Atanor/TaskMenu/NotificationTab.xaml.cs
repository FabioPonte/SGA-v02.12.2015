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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Conector;

namespace Atanor.TaskMenu
{
    /// <summary>
    /// Interaction logic for NotificationTab.xaml
    /// </summary>
    public partial class NotificationTab : UserControl
    {
        public NotificationTab()
        {
            InitializeComponent();
        }

        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; lbl_empresa.Content = value; }
        }
        string servico;

        public string Servico
        {
            get { return servico; }
            set { servico = value; lbl_servico.Content = value; }
        }
        string placa;

        public string Placa
        {
            get { return placa; }
            set { placa = value; lbl_placa.Content = value; }
        }
        string motorista;

        public string Motorista
        {
            get { return motorista; }
            set { motorista = value; lbl_motorista.Content = value; }
        }
        string nota;

        public string Nota
        {
            get { return nota; }
            set { nota = value; lbl_nota.Content = value; }
        }
        string data;

        public string Data
        {
            get { return data; }
            set { data = value; lbl_data.Content = value; }
        }

        string espera;

        public string Espera
        {
            get { return espera; }
            set { espera = value; lbl_espera.Content = value; }
        }

        public string Container
        {
            get
            {
                return container;
            }

            set
            {
                container = value;
                lbl_container.Content = value;
            }
        }

        string container;

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ogrid.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FFE1ECF4");
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ogrid.Background = Facilitadores.ConverterHexaEmBrushes.Color("#FFFFFFFF");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btn_avisado_Click(object sender, RoutedEventArgs e)
        {
            List<string> colunas = new List<string>();
            colunas.Add("idaviso");
            colunas.Add("usuario");
            colunas.Add("data");

            List<dynamic> valores = new List<dynamic>();
            valores.Add(id);
            valores.Add(Sessao.usuario.Nome);
            valores.Add(Facilitadores.ConverterDataParaDataDoMysql.Converter(DateTime.Now));

            ExecuteNonSql.Executar("aviso_recebido", TipoDeOperacao.Tipo.Insert, colunas, valores, null);
            Sessao.AtualizarNotificador();
        }
    }
}
