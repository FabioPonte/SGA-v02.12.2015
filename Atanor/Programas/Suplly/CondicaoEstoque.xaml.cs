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
using System.Data;
namespace Atanor.Programas.Suplly
{

    public partial class CondicaoEstoque : UserControl
    {

        BancoFileIanez novo = new BancoFileIanez(@"c:\notas\");
        public CondicaoEstoque()
        {
            InitializeComponent();
            dataGridFiltro1.Odatagrid = ogrid;
            Facilitadores.ConverteDataParaDataGrid.Converter(ogrid);
            Listar();


            novo.Retorno += NovoCadastro;
            novo.Esperando += Novo_Esperando;
            novo.Carregando += Novo_Carregando;
            novo.Retornado += Novo_Retornado;
            novo.Erro += Novo_Erro;
            novo.Msg += Novo_Msg;


        }

        private void Novo_Msg(string msg)
        {
            MsgBox.Show.aguarde.MSG.Content = "Carregando informações.";
        }

        private void Novo_Erro(string msg)
        {
            MsgBox.Show.EspereFechar();
            MsgBox.Show.Error(msg);
        }

        private void Novo_Retornado()
        {
            MsgBox.Show.EspereFechar();
        }

        private void Novo_Carregando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Carregando informações.";
        }

        private void Novo_Esperando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Espere por favor..";
        }

        string NomdeDoArquivo = "";

        public string per = "7";
        public string nome = "Condição do Estoque.";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/factory2.png", UriKind.RelativeOrAbsolute));

        private void ConfiguracaoBotoes()
        {
            Sessao.ApagaBots();
            Sessao.AddExcel(ogrid);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            updia.Valor = DateTime.Now.Day;
            updia.Max = 31;
            upmes.Valor = DateTime.Now.Month;
            upmes.Max = 12;
            upano.Valor = DateTime.Now.Year;
            upano.Max = 2999;
        }

        private void btn_abrir_Click(object sender, RoutedEventArgs e)
        {
            NomdeDoArquivo = Arquivos.Abrir.Excel();
            if (NomdeDoArquivo != "")
            {
                // txt_arquivo.Text = NomdeDoArquivo;
            }
        }

        private void Listar()
        {
            ogrid.ItemsSource = Select.SelectSQL("select data Dia,count(quantidade) Quantidade  from CondicaoEstoque group by dia order by 1 desc").DefaultView;
            ogrid.SelectedValuePath = "Dia";
        }

        private void pacote1_Loaded(object sender, RoutedEventArgs e)
        {
            ConfiguracaoBotoes();
        }

        private void pacote1_Click(ThemaMeritor.TipoEvento.evento tipo)
        {
            if (tipo == ThemaMeritor.TipoEvento.evento.Novo)
            {
                Cadastro();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Editar)
            {
                Editar();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Excluir)
            {
                Excluir();
            }
            if (tipo == ThemaMeritor.TipoEvento.evento.Cancelar)
            {
                btn_detalhar.IsEnabled = false;
                btn_relatorio.IsEnabled = false;
            }
        }

        private void CadastroTemporario(DataTable tabela)
        {

            if (tabela.Rows.Count <= 0)
                return;

            List<string> colunas = new List<string>();
            colunas.Add("data");
            colunas.Add("posicao");
            colunas.Add("numeroitem");
            colunas.Add("descricao");
            colunas.Add("quantidade");
            colunas.Add("custo");
            colunas.Add("valor");

            List<dynamic> valores = new List<dynamic>();

            DateTime adata = DateTime.Parse("30/12/2099 00:00:00");

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                valores.Add(adata);
                valores.Add(tabela.Rows[a]["Alocação"]);
                valores.Add(tabela.Rows[a]["N° do Item"]);
                valores.Add(tabela.Rows[a]["Descrição do item"]);

                string kj = (tabela.Rows[a]["Quantidade"] + "").Replace(".", ",");
                if (kj == "")
                {
                    kj = "0";
                }

                string kk = (tabela.Rows[a]["Custo"] + "").Replace(".", ",");
                if (kk == "")
                {
                    kk = "0";
                }

                valores.Add(double.Parse(kj));
                valores.Add(double.Parse(kk));
                valores.Add(double.Parse(kk) * double.Parse(kj));

            }

            if (ExecuteNonSql.Executar("CondicaoEstoque", TipoDeOperacao.Tipo.InsertMultiplo, colunas, valores, null) != -1)
            {

                if (checkBox1_Copy.IsChecked == false)
                {
                    DateTime odia = DateTime.Parse("30/12/2099 00:00:00");
                    DateTime adataE = odia;
                    double custoMinimo = 5;
                    if (chk_custos.IsChecked == true)
                    {
                        EscolherData_Estoque data = new EscolherData_Estoque();
                        data.ShowDialog();
                        if (data.Data != null)
                        {
                            adata = data.Data;
                            custoMinimo = data.slider.Value;
                        }
                    }
                  
                        RelatorioDeEstadoDeEstoque novo = new RelatorioDeEstadoDeEstoque();
                        Programas.RelatorioHTML pagina = new RelatorioHTML(novo.MontarHTML(odia, adataE,(Boolean)checkBox1.IsChecked, (Boolean)chk_custos.IsChecked, custoMinimo), true);
                        pagina.ShowDialog();
                    
                }
                else
                {
                    DateTime antes = DateTime.Parse(ObterUltimaData("30/12/2099"));
                    DateTime odia = DateTime.Parse("30/12/2099 00:00:00");
                    RelatorioDeEstadoDeEstoque novo = new RelatorioDeEstadoDeEstoque();
                    Programas.RelatorioHTML pagina = new RelatorioHTML(novo.MontarHTML(odia, antes, (Boolean)checkBox1.IsChecked), false);
                    pagina.ShowDialog();
                }


                List<dynamic> condicao = new List<dynamic>();
                DateTime Adata = DateTime.Parse("30/12/2099 00:00:00");
                condicao.Add("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(Adata) + "'");
                ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.Delete, null, null, condicao);

            }
            else
            {
                MsgBox.Show.Error("Erro ao inserir");
            }

        }
        Boolean temporario = false;

        private void NovoCadastro(DataSet tabelas)
        {

            DataTable tabela = tabelas.Tables[0];
            if (temporario)
            {
                CadastroTemporario(tabela);
                return;
            }
            if (tabela.Rows.Count <= 0)
                return;

            List<string> colunas = new List<string>();
            colunas.Add("data");
            colunas.Add("posicao");
            colunas.Add("numeroitem");
            colunas.Add("descricao");
            colunas.Add("quantidade");
            colunas.Add("custo");
            colunas.Add("valor");

            List<dynamic> valores = new List<dynamic>();

            DateTime adata = DateTime.Parse("" + updia.Valor + "/" + upmes.Valor + "/" + upano.Valor + " 00:00:00");

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                valores.Add(adata);
                valores.Add(tabela.Rows[a]["Alocação"]);
                valores.Add(tabela.Rows[a]["N° do Item"]);
                valores.Add(tabela.Rows[a]["Descrição do item"]);

                string kj = (tabela.Rows[a]["Quantidade"] + "").Replace(".", ",");
                if (kj == "")
                {
                    kj = "0";
                }

                string kk = (tabela.Rows[a]["Custo"] + "").Replace(".", ",");
                if (kk == "")
                {
                    kk = "0";
                }

                valores.Add(double.Parse(kj));
                valores.Add(double.Parse(kk));
                valores.Add(double.Parse(kk) * double.Parse(kj));

            }

            if (ExecuteNonSql.Executar("CondicaoEstoque", TipoDeOperacao.Tipo.InsertMultiplo, colunas, valores, null) != -1)
            {
                MsgBox.Show.Info("Relatório cadastrado!");
                Listar();
            }
            else
            {
                MsgBox.Show.Error("Erro ao cadastrar relatório.");
            }
        }

    

        private void Cadastro()
        {
            temporario = false;
            novo.Select("select 'N° do Item' = T1.ItemCode,'Descrição do item' = T1.ItemName,'NCM' = T2.NcmCode,'Depósito' = T3.WhsCode,'Alocação' = T4.BinCode,'Quantidade' = T3.OnHandQty,'Custo' = T5.AvgPrice from SBO_ATANOR.DBO.OITM T1 inner join SBO_ATANOR.DBO.ONCM T2 on T2.AbsEntry = T1.NCMCode             inner join SBO_ATANOR.DBO.OIBQ T3 on T3.ItemCode = T1.ItemCode			 inner join SBO_ATANOR.DBO.OBIN T4 on T4.AbsEntry = T3.BinAbs			 inner join SBO_ATANOR.DBO.OITW T5 on T5.ItemCode = T1.ItemCode  and T5.WhsCode = T3.WhsCode and T3.OnHandQty>0 union all select 'N° do Item' = T1.ItemCode,'Descrição do item' = T1.ItemName,'NCM' = T2.NcmCode,'Depósito' = T3.WhsCode,'Alocação' = T4.BinCode,'Quantidade' = T3.OnHandQty,'Custo' = T5.AvgPrice from SBO_CONSAGRO.DBO.OITM T1 inner join SBO_CONSAGRO.DBO.ONCM T2 on T2.AbsEntry = T1.NCMCode             inner join SBO_CONSAGRO.DBO.OIBQ T3 on T3.ItemCode = T1.ItemCode			 inner join SBO_CONSAGRO.DBO.OBIN T4 on T4.AbsEntry = T3.BinAbs			 inner join SBO_CONSAGRO.DBO.OITW T5 on T5.ItemCode = T1.ItemCode  and T5.WhsCode = T3.WhsCode and T3.OnHandQty>0");
            MsgBox.Show.EspereAbrir();
            
        }
        private void Editar()
        {
            if (Verificador())
            {
                if ((ogrid.SelectedValue + "") != "")
                {
                    List<string> colunas = new List<string>();
                    List<dynamic> valores = new List<dynamic>();
                    List<dynamic> condicao = new List<dynamic>();

                    colunas.Add("data");
                    colunas.Add("posicao");
                    colunas.Add("numeroitem");
                    colunas.Add("descricao");
                    colunas.Add("quantidade");
                    colunas.Add("custo");
                    colunas.Add("valor");

                    DataTable tabela = Arquivos.Excel.Executar(NomdeDoArquivo, "select * from [plan1$] where f1 not in ('#')", "no");
                    DateTime adata = DateTime.Parse("" + updia.Valor + "/" + upmes.Valor + "/" + upano.Valor + " 00:00:00");
                    for (int a = 0; a < tabela.Rows.Count; a++)
                    {
                        valores.Add(tabela.Rows[a]["f6"]);
                        valores.Add(tabela.Rows[a]["f2"]);
                        valores.Add(tabela.Rows[a]["f3"]);
                        valores.Add(tabela.Rows[a]["f7"]);
                        valores.Add(tabela.Rows[a]["f8"]);
                        valores.Add(double.Parse(tabela.Rows[a]["f8"] + "") * double.Parse(tabela.Rows[a]["f7"] + ""));
                    }
                    DateTime Adata = DateTime.Parse(ogrid.SelectedValue + "");
                    condicao.Add("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(Adata) + "'");

                    if (ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.Delete, null, null, condicao) != -1)
                    {
                        if (ExecuteNonSql.Executar("CondicaoEstoque", TipoDeOperacao.Tipo.InsertMultiplo, colunas, valores, null) != -1)
                        {
                            MsgBox.Show.Info("Alterado com Exito");
                            Listar();
                        }
                        else
                        {
                            MsgBox.Show.Error("Erro ao Alterar");
                        }
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao Alterar");
                    }
                }
            }
        }
        private void Excluir()
        {
            if ((ogrid.SelectedValue + "") != "")
            {
                List<dynamic> condicao = new List<dynamic>();
                DateTime Adata = DateTime.Parse(ogrid.SelectedValue + "");
                condicao.Add("data='" + Facilitadores.ConverterDataParaDataDoMysql.Converter(Adata) + "'");

                if (ExecuteNonSql.Executar("condicaoestoque", TipoDeOperacao.Tipo.Delete, null, null, condicao) != -1)
                {
                   
                        MsgBox.Show.Info("Excluido com Exito");
                        Listar();
                }
                else
                {
                    MsgBox.Show.Error("Erro ao Excluir");
                }
            }
        }


        private Boolean Verificador()
        {
            if (NomdeDoArquivo.Trim() == "")
            {
              //  MsgBox.Show.Error("Arquivo não selecionado",txt_arquivo);
                return false;
            }
            return true;
        }

        private void ogrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ogrid.SelectedValue != "")
                {
                    btn_detalhar.IsEnabled = true;
                    pacote1.ModoEdicao = true;
                    btn_relatorio.IsEnabled = true;
                    try
                    {
                        DateTime selecionado = DateTime.Parse(ogrid.SelectedValue + "");
                        updia.Valor = selecionado.Day;
                        upmes.Valor = selecionado.Month;
                        upano.Valor = selecionado.Year;
                    }
                    catch { }
                }
                else
                {
                    pacote1.ModoEdicao = false;
                    btn_detalhar.IsEnabled = false;
                    btn_relatorio.IsEnabled = false;
                }


            }
            catch { }
        }

        private void btn_detalhar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime odia = DateTime.Parse(ogrid.SelectedValue + "");
                Sessao.AbrirPrograma(new Programas.Suplly.DetalhesDaCondicaoDosEstoques(odia), this);
            }
            catch { }

        }


        private string ObterUltimaData()
        {
            try
            {
                DateTime odia = DateTime.Parse(ogrid.SelectedValue + "");
                string data = Select.SelectSQL("select distinct max(data) from condicaoestoque  where data < '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(odia) + "' order by 1 desc").Rows[0][0] + "";

                return data;
            }
            catch { return null; }
        }


        private string ObterUltimaData(string odata)
        {
            try
            {
                DateTime odia = DateTime.Parse(odata + "");
                string data = Select.SelectSQL("select distinct max(data) from condicaoestoque  where data < '" + Facilitadores.ConverterDataParaDataDoMysql.Converter(odia) + "' order by 1 desc").Rows[0][0] + "";

                return data;
            }
            catch { return null; }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime odia = DateTime.Parse(ogrid.SelectedValue + "");
                DateTime antes = DateTime.Parse(ObterUltimaData() + "");

                RelatorioDeEstadoDeEstoque novo = new RelatorioDeEstadoDeEstoque();
                //novo.MontarHTML(odia,(Boolean)checkBox1.IsChecked);

                if ((Boolean)checkBox1_Copy.IsChecked)
                {
                    Programas.RelatorioHTML pagina = new RelatorioHTML(novo.MontarHTML(odia, antes, (Boolean)checkBox1.IsChecked),false);
                    pagina.Show();
                }
                else
                {
                    DateTime adata = odia;
                    double custoMinimo = 5;
                    if (chk_custos.IsChecked == true)
                    {
                        EscolherData_Estoque data = new EscolherData_Estoque();
                        data.ShowDialog();
                        
                        if (data.Data != null)
                        {
                            adata = data.Data;
                            custoMinimo = data.slider.Value;
                        }
                    }


                        Programas.RelatorioHTML pagina = new RelatorioHTML(novo.MontarHTML(odia,adata, (Boolean)checkBox1.IsChecked, (Boolean)chk_custos.IsChecked, custoMinimo), true);
                        pagina.Show();
                    
                }
                
                
            }
            catch (Exception ex) { MsgBox.Show.Error(ex + ""); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            temporario = true;
            novo.Select("select 'N° do Item' = T1.ItemCode,'Descrição do item' = T1.ItemName,'NCM' = T2.NcmCode,'Depósito' = T3.WhsCode,'Alocação' = T4.BinCode,'Quantidade' = T3.OnHandQty,'Custo' = T5.AvgPrice from SBO_ATANOR.DBO.OITM T1 inner join SBO_ATANOR.DBO.ONCM T2 on T2.AbsEntry = T1.NCMCode             inner join SBO_ATANOR.DBO.OIBQ T3 on T3.ItemCode = T1.ItemCode			 inner join SBO_ATANOR.DBO.OBIN T4 on T4.AbsEntry = T3.BinAbs			 inner join SBO_ATANOR.DBO.OITW T5 on T5.ItemCode = T1.ItemCode  and T5.WhsCode = T3.WhsCode and T3.OnHandQty>0 union all select 'N° do Item' = T1.ItemCode,'Descrição do item' = T1.ItemName,'NCM' = T2.NcmCode,'Depósito' = T3.WhsCode,'Alocação' = T4.BinCode,'Quantidade' = T3.OnHandQty,'Custo' = T5.AvgPrice from SBO_CONSAGRO.DBO.OITM T1 inner join SBO_CONSAGRO.DBO.ONCM T2 on T2.AbsEntry = T1.NCMCode             inner join SBO_CONSAGRO.DBO.OIBQ T3 on T3.ItemCode = T1.ItemCode			 inner join SBO_CONSAGRO.DBO.OBIN T4 on T4.AbsEntry = T3.BinAbs			 inner join SBO_CONSAGRO.DBO.OITW T5 on T5.ItemCode = T1.ItemCode  and T5.WhsCode = T3.WhsCode and T3.OnHandQty>0");
            MsgBox.Show.EspereAbrir();
        }

        private void dataGridFiltro1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
