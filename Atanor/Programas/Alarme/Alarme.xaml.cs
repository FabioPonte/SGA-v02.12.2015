using Conector;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atanor.Programas.Alarme
{
    /// <summary>
    /// Interaction logic for Alarme.xaml
    /// </summary>
    public partial class Alarme : UserControl
    {
        DataTable tabela;
        public string per = "41";
        public string nome = "Alarme";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));


        List<string> colunas = new List<string>();
        List<dynamic> valores = new List<dynamic>();
        List<dynamic> condicao = new List<dynamic>();

       
        public Alarme()
        {
            InitializeComponent();
            Listar();
            SetarHorario();
            ogrid.AutoGeneratingColumn += ogrid_AutoGeneratingColumn;
            pacote1.GridBase = ogrid;
            pacote1.Janela = this;

        }

       


        private void SetarHorario()
        {
            uphora.Valor = DateTime.Now.Hour;
            upminuto.Valor = DateTime.Now.Minute;
        }
        private Boolean Verificador()
        {
            if (txt_titulo.Text == "")
            {
                MsgBox.Show.Error("Titulo do alerta não foi definido!");
                txt_titulo.Focus();
                return false;
            }
            else
            {
                if (txt_comentario.Text.Trim() == "")
                {
                    MsgBox.Show.Error("Mensagem não foi escrita!");
                    txt_comentario.Focus();
                    return false;
                }
                else
                {
                    if (data.SelectedDate == null)
                    {
                        MsgBox.Show.Error("Data não foi escolhida!");
                        data.Focus();
                        return false;
                    }
                    else
                    {
                        if (data.SelectedDate < DateTime.Now.Date)
                        {
                            MsgBox.Show.Error("Data inválida!");
                            data.Focus();
                            return false;
                        }
                        else
                        {
                                int horaAgora = DateTime.Now.Hour;
                                int minutoAgora = DateTime.Now.Minute;
                                int horaescolhida = (int)uphora.Valor;
                                int minutoescolhida = (int)upminuto.Valor;

                                if (data.SelectedDate == DateTime.Now)
                                {
                                    if (horaAgora == horaescolhida && minutoescolhida > minutoAgora)
                                    {
                                        MsgBox.Show.Error("Horário inválido.");
                                        return false;
                                    }
                                    else
                                    {
                                        if (horaescolhida < horaAgora)
                                        {
                                            MsgBox.Show.Error("Horário inválido.");
                                            return false;
                                        }
                                    }
                                    return true;
                                }
                                else
                                {
                                    return true;
                                }
                        }
                    }
                }
            }
            return true;
        }
        private void Listar()
        {
            tabela = Select.SelectSQL("SELECT id ID,titulo Titulo,msg Msg,dia Dia,mes Mes,ano Ano,hora Hora,minuto Minuto,unico Unico,diario Diario,semanal Semanal,mensal Mensal,ativo Ativo FROM alarme where idusuario=" + Sessao.usuario.Id + "");
           
            ogrid.ItemsSource = tabela.DefaultView;
            ogrid.SelectedValuePath = "ID";
        }
        private void Limpar()
        {
            txt_titulo.Text = "";
            txt_comentario.Text = "";
            SetarHorario();
            rdo_unico.IsChecked = true;
            chk_ativo.IsChecked = true;
            data.SelectedDate = DateTime.Now;
        }

        private void pacote1_Click_1(ThemaMeritor.TipoEvento.evento tipo)
        {
           
        }

        private void Obterinfo()
        {
            colunas.Clear();
            valores.Clear();
            condicao.Clear();

            int unico = 0;
            int diario = 0;
            int semanal = 0;
            int mensal = 0;
            int ativo = 0;

            if (rdo_unico.IsChecked == true) unico = 1;
            if (rdo_diario.IsChecked == true) diario = 1;
            if (rdo_semanal.IsChecked == true) semanal = 1;
            if (rdo_mensal.IsChecked == true) mensal = 1;
            if (chk_ativo.IsChecked == true) ativo = 1;

            colunas.Add("titulo");
            colunas.Add("msg");
            colunas.Add("dia");
            colunas.Add("mes");
            colunas.Add("ano");
            colunas.Add("hora");
            colunas.Add("minuto");
            colunas.Add("unico");
            colunas.Add("diario");
            colunas.Add("semanal");
            colunas.Add("mensal");
            colunas.Add("ativo");
            colunas.Add("idusuario");

            condicao.Add("id=" + ogrid.SelectedValue + "");

            valores.Add(txt_titulo.Text);
            valores.Add(txt_comentario.Text);
            valores.Add(data.SelectedDate.Value.Day);
            valores.Add(data.SelectedDate.Value.Month);
            valores.Add(data.SelectedDate.Value.Year);
            valores.Add((int)uphora.Valor);
            valores.Add((int)upminuto.Valor);
            valores.Add(unico);
            valores.Add(diario);
            valores.Add(semanal);
            valores.Add(mensal);
            valores.Add(ativo);
            valores.Add(Sessao.usuario.Id);
        }

        private void Cadastrar()
        {
            if (Verificador())
            {
                Obterinfo();
                if (ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                {
                    MsgBox.Show.Info("Cadastrado com êxito!");
                    Listar();
                    Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao cadastrar!");
                }
            }
        }

        private void Editar()
        {
            if (Verificador())
            {
                Obterinfo();
                if (ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Update, colunas, valores,condicao) != -1)
                {
                    MsgBox.Show.Info("Editado com êxito!");
                    Listar();
                    Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao editar!");
                }
            }
        }

        private void Excluir()
        {
           
                Obterinfo();
                if (ExecuteNonSql.Executar("alarme", TipoDeOperacao.Tipo.Delete, colunas, valores, condicao) != -1)
                {
                    MsgBox.Show.Info("Deletado com êxito!");
                    Listar();
                    Limpar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao deletar!");
                }
            
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            DataTable info = Select.SelectSQL("select * from alarme where id=" + ogrid.SelectedValue + "");

            if (info.Rows.Count > 0)
            {
                
                pacote1.ModoEdicao = true;
                txt_titulo.Text = info.Rows[0]["titulo"] + "";
                txt_comentario.Text = info.Rows[0]["msg"] + "";
                int dia = int.Parse(info.Rows[0]["dia"] + "");
                int mes = int.Parse(info.Rows[0]["mes"] + "");
                int ano = int.Parse(info.Rows[0]["ano"] + "");
                int hora = int.Parse(info.Rows[0]["hora"] + "");
                int minuto = int.Parse(info.Rows[0]["minuto"] + "");
                int unico = int.Parse(info.Rows[0]["unico"] + "");
                int diario = int.Parse(info.Rows[0]["diario"] + "");
                int semanal = int.Parse(info.Rows[0]["semanal"] + "");
                int mensal = int.Parse(info.Rows[0]["mensal"] + "");
                int ativo = int.Parse(info.Rows[0]["ativo"] + "");

                string datas = "" + dia + "/" + mes + "/" + ano + "";
                data.SelectedDate = DateTime.Parse(datas);
                uphora.Valor = hora;
                upminuto.Valor = minuto;

                if (unico == 1) rdo_unico.IsChecked = true;
                if (diario == 1) rdo_diario.IsChecked = true;
                if (semanal == 1) rdo_semanal.IsChecked = true;
                if (mensal == 1) rdo_mensal.IsChecked = true;
                if (ativo == 1)
                {
                    chk_ativo.IsChecked = true;
                }
                else
                {
                    chk_ativo.IsChecked = false;
                }
            }
        }



        void ogrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
        }

        private void pacote1_Click(TaskMenu.PacoteManutencao.Tipo tipo)
        {
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Cancelar)
            {
                Limpar();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Editar)
            {
                Editar();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Excluir)
            {
                Excluir();
            }
            if (tipo == TaskMenu.PacoteManutencao.Tipo.Novo)
            {
                Cadastrar();
            }
        }
        

       

    }
}
