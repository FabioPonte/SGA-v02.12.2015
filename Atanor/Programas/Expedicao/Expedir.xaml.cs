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
namespace Atanor.Programas.Expedicao
{
    /// <summary>
    /// Interaction logic for Expedir.xaml
    /// </summary>
    public partial class Expedir : UserControl
    {
        BancoFileIanez novo = new BancoFileIanez("c:\\notas\\");
        Facilitadores.Transferidor motorista = new Facilitadores.Transferidor();
        Facilitadores.Transferidor caminhao = new Facilitadores.Transferidor();
        Facilitadores.Transferidor produto = new Facilitadores.Transferidor();
        Facilitadores.Verificador vn = new Facilitadores.Verificador();
        Facilitadores.Verificador vt = new Facilitadores.Verificador();
        ObterInformacaoDaNota infornota = new ObterInformacaoDaNota();

        DataTable tabela = new DataTable();

        int idromaneio = 0;

        public int Idromaneio
        {
            get { return idromaneio; }
            set { idromaneio = value; lbl_romaneio.Content = value; }
        }

        List<NotasFiscais> notas = new List<NotasFiscais>();

        private void calcularPeso()
        {
            double liquido = 0;
            double bruto = 0;
            for (int a = 0; a < notas.Count; a++)
            {
                liquido += notas[a].liquido;
                bruto += notas[a].bruto;
            }

            lbl_pesos.Content = "Peso Liquido:"+liquido+"  Peso Bruto:"+bruto+"";
        }


        private void verificandonotaselecionadas()
        {
            //ObterInformacao(txt_nota.Text);
            /*
            cbo_cd.Text = "Resende";
            for(int a = 0; a < Sessao.NotasAtar.Count; a++)
            {
                ObterInformacao(Sessao.NotasAtar[a].Nota + "");
            }*/

        }
        public Expedir()
        {
            InitializeComponent();
            CriarTabela();
            BuscarProximoId();
            vn.Add(txt_nota,"Número da Nota não foi preenchido!",true);
            vn.Add(data_emissao, "Data de emissão não foi preenchido!", true);
            //vn.Add(txt_cliente, "Nome do cliente não foi preenchido!", true);
            vn.Add(cbo_estado, "Estado não foi preenchido!", true);
            vn.Add(txt_cidade, "Cidade não foi preenchido!", true);
            vn.Add(cbo_produto, "Produto não foi preenchido!", true);
            vn.Add(txt_lote, "Lote não foi preenchido!", true);
            vn.Add(txt_liquido, "Peso liquido não foi preenchido!", true);
            vn.Add(txt_bruto, "Peso bruto não foi preenchido!", true);

            vt.Add(cbo_motorista, "Motorista não foi selecionado");
            vt.Add(dt_data, "Data não foi selecionado");
            vt.Add(cbo_transportadora, "Transportadora não foi selecionado");
            vt.Add(cbo_caminhao, "Caminhão não foi selecionado");
            vt.Add(cbo_tipo_caminhao, "Tipo de caminhão não foi selecionado");
            vt.Add(cbo_cd, "CD não foi selecionado");
            listar();

            motorista.Combo = cbo_motorista;
            motorista.controle = this;
            caminhao.Combo = cbo_caminhao;
            caminhao.controle = this;
            produto.Combo = cbo_produto;
            produto.controle = this;


            motorista.Retorno += motorista_Retorno;
            caminhao.Retorno += caminhao_Retorno;
            produto.Retorno += produto_Retorno;

            Facilitadores.ConverteDataParaDataGrid.Converter(ogrid);

            infornota.ErroNota += new ObterInformacaoDaNota.erron(infornota_ErroNota);
            infornota.Retorno += new ObterInformacaoDaNota.retorno(infornota_Retorno);

            verificandonotaselecionadas();

            novo.Retorno += Novo_Retorno;
            novo.Retornado += Novo_Retornado;
            novo.Carregando += Novo_Carregando;
            novo.Msg += Novo_Msg;
            novo.Esperando += Novo_Esperando;
            novo.Erro += Novo_Erro;
        }

        private void Novo_Carregando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Carregando!!!";
        }

        private void Novo_Erro(string msg)
        {
            MsgBox.Show.Error(msg);
            MsgBox.Show.EspereFechar();
        }

        private void Novo_Esperando()
        {
            MsgBox.Show.aguarde.MSG.Content = "Aguarde!!!";
        }

        private void Novo_Msg(string msg)
        {
            MsgBox.Show.aguarde.MSG.Content = msg;
        }

        private void Novo_Retornado()
        {
            MsgBox.Show.EspereFechar();
        }

        

        void motorista_Retorno()
        {
            cbo_motorista.ItemsSource = Select.SelectSQL("select * from motorista order by nome").DefaultView;
            cbo_motorista.SelectedValuePath = "id";
            cbo_motorista.DisplayMemberPath = "nome";
        }

        void caminhao_Retorno()
        {
            cbo_caminhao.ItemsSource = Select.SelectSQL("select * from caminhao order by placa").DefaultView;
            cbo_caminhao.SelectedValuePath = "id";
            cbo_caminhao.DisplayMemberPath = "placa";
        }

        void produto_Retorno()
        {
            prods = Select.SelectSQL("select * from produtos");
            cbo_produto.ItemsSource = prods.DefaultView;
            cbo_produto.SelectedValuePath = "idsap";
            cbo_produto.DisplayMemberPath = "nome";
        }

        void infornota_Retorno(DadosNota nota)
        {
            MsgBox.Show.EspereFechar();

            Boolean semlote = false;
            for (int a = 0; a < nota.produto.Count; a++)
            {
                if (nota.produto[a].lote.Count > 0)
                {
                    semlote = true;
                }
            }

            if (!semlote)
            {
                MsgBox.Show.Error("A nota fiscal " + nota.nota + " que você quer adicionar não existe lotes segregados para ela." + Environment.NewLine + "" + Environment.NewLine + "Cfop:" + nota.cfop + "");

            }
            else
            {
                if (MsgBox.Show.Pergunta("Voce quer mesmo adicionar." + Environment.NewLine + "Nota Fiscal:" + nota.nota + "" + Environment.NewLine + "" + Environment.NewLine + "Cliente :" + nota.cliente + "" + Environment.NewLine + "" + Environment.NewLine + "Cfop:" + nota.cfop + "" + Environment.NewLine + "" + Environment.NewLine + "Cfaz:" + nota.cfaz + ""))
                {
                    Injetar(nota);
                }
            }
        }

        private void Injetar(DadosNota nota)
        {
            DateTime emissao = DateTime.Parse(nota.data);
            data_emissao.SelectedDate = emissao;
            txt_cliente.Text = nota.cliente;
            cbo_estado.Text = nota.estado;
            txt_cidade.Text = nota.cidade;
            txt_nota.Text = nota.nota;

            


            for (int a = 0; a < nota.produto.Count; a++)
            {

                double liquido = 0;
            double bruto = 0;

            for (int c = 0; c < produtos.Rows.Count; c++)
            {
                if (produtos.Rows[c]["idsap"].ToString() == nota.produto[a].produto.ToString())
                {
                    try
                    {
                        liquido = double.Parse(produtos.Rows[c]["peso"].ToString() + "");
                    }
                    catch { }

                    string bbb = produtos.Rows[c]["conversao"] + "";
                    try
                    {
                        bruto = double.Parse(bbb);
                    }
                    catch { }
                }
            }

                InjectarPorIdSap(nota.produto[a].produto);
                for (int b = 0; b < nota.produto[a].lote.Count; b++)
                {

                    double qtd_pallet = double.Parse(nota.produto[a].volume[b] + "") / liquido;

                    double brutal = qtd_pallet * bruto;

                    txt_lote.Text = nota.produto[a].lote[b];
                    txt_liquido.Text = nota.produto[a].volume[b]+"";
                    txt_bruto.Text = brutal + "";
                    btn_add_Click(null, null);
                }
                
            }
        }
        DataTable prods = new DataTable();

        private void InjectarPorIdSap(string produto)
        {
            for (int a = 0; a < prods.Rows.Count; a++)
            {
                
                if (produto == (prods.Rows[a]["idsap"] + ""))
                {
                    cbo_produto.SelectedIndex = a;
                    break;
                }
            }
        }

        private void InjectarPorNomeSap(string produto)
        {
            for (int a = 0; a < prods.Rows.Count; a++)
            {

                if (produto == (prods.Rows[a]["nome"] + ""))
                {
                    cbo_produto.SelectedIndex = a;
                    break;
                }
            }
        }
        void infornota_ErroNota(string nota)
        {
            MsgBox.Show.EspereFechar();
            MsgBox.Show.Error("Nota Fiscal "+nota+" não foi encontrada!");
        }

        private void ObterInformacao(string nota)
        {
            infornota.SolicitarNota(nota, cbo_cd.Text.ToUpper());
            MsgBox.Show.EspereAbrir();
        }

        private void BuscarProximoId()
        {
            int valor = 0;
            try
            {
                valor = int.Parse(Select.SelectSQL("SELECT max(id) FROM romaneio").Rows[0][0] + "");
                valor++;
                Idromaneio = valor;
            }
            catch { Idromaneio = 1; }
        }

        private void CriarTabela()
        {
            tabela.Columns.Add("id", typeof(int));
            tabela.Columns.Add("Nota Fiscal",typeof(double));
            tabela.Columns.Add("Emissão", typeof(DateTime));
            tabela.Columns.Add("Cliente", typeof(string));
            tabela.Columns.Add("Cidade", typeof(string));
            tabela.Columns.Add("UF", typeof(string));
            tabela.Columns.Add("Código", typeof(string));
            tabela.Columns.Add("Produto", typeof(string));
            tabela.Columns.Add("Lote", typeof(string));
            tabela.Columns.Add("Peso Liquido", typeof(double));
            tabela.Columns.Add("Peso Bruto", typeof(double));
            tabela.Columns.Add("Vendedor", typeof(string));
            tabela.Columns.Add("Posição", typeof(string));
            tabela.Columns.Add("Utilização", typeof(string));
            ogrid.ItemsSource = tabela.DefaultView;
            ogrid.SelectedValuePath = "id";
        }

        int contador = 1;

        double liquido, bruto;

        private void MontarConteudoDaTable()
        {
            liquido = 0;
            bruto = 0;
            try
            {
                tabela.Rows.Clear();
            }
            catch { }
            for (int a = 0; a < notas.Count; a++)
            {
                NotasFiscais nova = notas[a];
                tabela.Rows.Add(nova.id,nova.notaFiscal, nova.emissao, nova.cliente, nova.cidade, nova.uf, nova.codigo, nova.produto, nova.lote, nova.liquido, nova.bruto,nova.vendedor,nova.local,nova.utilizacao);
                bruto += nova.bruto;
                liquido += nova.liquido;
            }
        }

        private void add()
        {
            if (VerificarNotasFiscais(txt_nota.Text))
            {
                if (vn.Analisar())
                {

                    NotasFiscais nova = new NotasFiscais();
                    nova.id = contador;
                    try
                    {
                        nova.bruto = double.Parse(txt_bruto.Text);
                    }
                    catch { MsgBox.Show.Error("Peso Bruto inválido!"); return; }
                    nova.cidade = txt_cidade.Text;
                    nova.cliente = txt_cliente.Text;
                    nova.codigo = cbo_produto.SelectedValue + "";
                    nova.idproduto = Select.SelectSQL("select * from produtos where idsap='" + cbo_produto.SelectedValue + "'").Rows[0]["id"] + "";
                    nova.emissao = (DateTime)data_emissao.SelectedDate;
                    try
                    {
                        nova.liquido = double.Parse(txt_liquido.Text);
                    }
                    catch { MsgBox.Show.Error("Peso liquido inválido!"); return; }

                    nova.lote = txt_lote.Text;
                    nova.notaFiscal = txt_nota.Text;
                    nova.produto = cbo_produto.Text;
                    nova.uf = cbo_estado.Text;
                    nova.utilizacao = txt_utilizacao.Text;
                    nova.vendedor = txt_vendedor.Text;
                    nova.local = txt_posicao.Text;

                    notas.Add(nova);

                    contador++;
                    MontarConteudoDaTable();
                }

                calcularPeso();
            }
        }

        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dt_data.SelectedDate = DateTime.Now;
            
        }
        public string per = "24";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/packages2.png", UriKind.RelativeOrAbsolute));
        public string nome = "Expedição";



        DataTable produtos = new DataTable();

        private void listar()
        {
            dt_data.DisplayDate = DateTime.Now;

            produtos = Select.SelectSQL("select * from produtos where peso is not null");

            cbo_transportadora.ItemsSource = Select.SelectSQL("select * from transportadoras order by Apelido").DefaultView;
            cbo_transportadora.SelectedValuePath = "id";
            cbo_transportadora.DisplayMemberPath = "Apelido";

            cbo_tipo_caminhao.ItemsSource = Select.SelectSQL("select * from tipo_caminhao order by nome").DefaultView;
            cbo_tipo_caminhao.SelectedValuePath = "id";
            cbo_tipo_caminhao.DisplayMemberPath = "nome";

            prods = Select.SelectSQL("select * from produtos");
            cbo_produto.ItemsSource = prods.DefaultView;
            cbo_produto.SelectedValuePath = "idsap";
            cbo_produto.DisplayMemberPath = "nome";

            cbo_estado.ItemsSource = Select.SelectSQL("select * from estados").DefaultView;
            cbo_estado.SelectedValuePath = "uf";
            cbo_estado.DisplayMemberPath = "uf";

            cbo_motorista.ItemsSource = Select.SelectSQL("select * from motorista order by nome").DefaultView;
            cbo_motorista.SelectedValuePath = "id";
            cbo_motorista.DisplayMemberPath = "nome";

            cbo_caminhao.ItemsSource = Select.SelectSQL("select * from caminhao order by placa").DefaultView;
            cbo_caminhao.SelectedValuePath = "id";
            cbo_caminhao.DisplayMemberPath = "placa";

            cbo_cd.ItemsSource = Select.SelectSQL("select * from centrodistribuicao").DefaultView;
            cbo_cd.SelectedValuePath = "id";
            cbo_cd.DisplayMemberPath = "nome";

            cbo_idRomaneio.ItemsSource = Select.SelectSQL("select * from romaneio").DefaultView;
            cbo_idRomaneio.SelectedValuePath = "id";
            cbo_idRomaneio.DisplayMemberPath = "id";

            txt_cliente.ItemsSource = Select.SelectSQL("SELECT distinct cliente FROM expedicao order by 1").DefaultView;
            txt_cliente.DisplayMemberPath = "cliente";
        }

        private void txt_placa_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbo_tipo_caminhao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                dynamic afoto = ((dynamic)Conector.Select.SelectSQL("SELECT * FROM tipo_caminhao y where y.id=" + cbo_tipo_caminhao.SelectedValue + "").Rows[0]["foto"]);
                img_foto.Source = Facilitadores.ConverterBytsEmImagens.Converter(afoto);
            }
            catch { }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroMotorista(motorista), this);
        }

        private void cbo_motorista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                lbl_cnh.Content = Select.SelectSQL("select * from motorista where id=" + cbo_motorista.SelectedValue + "").Rows[0]["cnh"] + "";
            }
            catch { }
        }

        private void cbo_caminhao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string id = Select.SelectSQL("select idtipo_caminhao from caminhao where id='" + cbo_caminhao.SelectedValue + "'").Rows[0][0] + "";

                for (int a = 0; a < cbo_tipo_caminhao.Items.Count; a++)
                {
                    DataRowView c = (DataRowView)cbo_tipo_caminhao.Items[a];
                    dynamic b = c[0];
                    if ((b + "") == id)
                    {
                        cbo_tipo_caminhao.SelectedIndex = a;
                        break;
                    }
                }

            }
            catch { }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroCaminhao(caminhao), this);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            BuscarProximoId();
            add();

        }

        int IndexSelecionado = -1;

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Modos(true);

                for (int a = 0; a < notas.Count; a++)
                {
                    int oid = int.Parse(ogrid.SelectedValue + "");
                    if (oid == notas[a].id)
                    {

                        txt_bruto.Text = notas[a].bruto + "";
                        txt_cidade.Text = notas[a].cidade;
                        txt_cliente.Text = notas[a].cliente;

                        InjectarPorIdSap(notas[a].codigo);


                        data_emissao.DisplayDate = notas[a].emissao;
                        txt_liquido.Text = notas[a].liquido + "";
                        txt_lote.Text = notas[a].lote;
                        txt_nota.Text = notas[a].notaFiscal;

                   
                        cbo_estado.Text = notas[a].uf;
                             
                        IndexSelecionado = a;
                        break;
                    }
                }

            }
            catch { }
        }

        
        private void Modos(Boolean edicao)
        {
            if (edicao == true)
            {
                btn_add.IsEnabled = false;
                btn_editar.IsEnabled = true;
                btn_excluir.IsEnabled = true;
                btn_cadastro.IsEnabled = true;
            }
            else
            {
                IndexSelecionado = -1;
                btn_add.IsEnabled = true;
                btn_editar.IsEnabled = false;
                btn_excluir.IsEnabled = false;
                btn_cadastro.IsEnabled = false;
            }

        }

        private void btn_cadastro_Click(object sender, RoutedEventArgs e)
        {
            Modos(false);
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            if (vn.Analisar())
            {
                NotasFiscais nova = notas[IndexSelecionado];
                nova.bruto = double.Parse(txt_bruto.Text);
                nova.cidade = txt_cidade.Text;
                nova.cliente = txt_cliente.Text;
                nova.codigo = cbo_produto.SelectedValue + "";
                nova.idproduto = Select.SelectSQL("select * from produtos where idsap='" + cbo_produto.SelectedValue + "'").Rows[0]["id"] + "";
                nova.emissao = data_emissao.DisplayDate;
                nova.liquido = double.Parse(txt_liquido.Text);
                nova.lote = txt_lote.Text;
                nova.notaFiscal = txt_nota.Text;
                nova.produto = cbo_produto.Text;
                nova.uf = cbo_estado.Text;
                Modos(false);
                MontarConteudoDaTable();
                calcularPeso();
            }
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {
            if (IndexSelecionado != -1)
            {
                notas.Remove(notas[IndexSelecionado]);
                MontarConteudoDaTable();
                Modos(false);
                calcularPeso();
            }
        }

        

        private void button5_Click(object sender, RoutedEventArgs e)
        {

            if (verificador())
            {
                if (MsgBox.Show.Pergunta("Quer mesmo realizar essa expedição?"))
                {
                    Banco.checklist chk = new Banco.checklist();
                    CheckListFinal final = new CheckListFinal();
                    final.ShowDialog();
                    if (final.finalizou)
                        chk = final.checklist;
                    else
                    {
                        MsgBox.Show.Error("Não foi possível realizar esta expedição por que o checkList não foi preenchido!");
                        return;
                    }
                    

                    BuscarProximoId();

                    List<string> colunas = new List<string>();
                    colunas.Add("idmotorista");
                    colunas.Add("idtransportadoras");
                    colunas.Add("idcaminhao");
                    colunas.Add("data");
                    colunas.Add("liquido");
                    colunas.Add("bruto");
                    colunas.Add("idcd");
                    colunas.Add("criador");

                    List<dynamic> valores = new List<dynamic>();
                    valores.Add(cbo_motorista.SelectedValue);
                    valores.Add(cbo_transportadora.SelectedValue);
                    valores.Add(cbo_caminhao.SelectedValue);
                    valores.Add(dt_data.DisplayDate);
                    valores.Add(liquido);
                    valores.Add(bruto);
                    valores.Add(cbo_cd.SelectedValue);
                    valores.Add(Sessao.usuario.Nome);

                    if (ExecuteNonSql.Executar("romaneio", TipoDeOperacao.Tipo.Insert, colunas, valores, null) != -1)
                    {
                        colunas.Clear();
                        valores.Clear();

                        colunas.Add("idromaneio");
                        colunas.Add("idprodutos");
                        colunas.Add("nota");
                        colunas.Add("data");
                        colunas.Add("cidade");
                        colunas.Add("estado");
                        colunas.Add("lote");
                        colunas.Add("liquido");
                        colunas.Add("bruto");
                        colunas.Add("cliente");

                        List<string> coluna1 = new List<string>();
                        coluna1.Add("nota");
                        List<dynamic> valores1 = new List<dynamic>();


                        for (int a = 0; a < notas.Count; a++)
                        {
                            valores.Add(idromaneio);
                            valores.Add(notas[a].idproduto);
                            valores.Add(notas[a].notaFiscal);
                            valores.Add(notas[a].emissao);
                            valores.Add(notas[a].cidade);
                            valores.Add(notas[a].uf);
                            valores.Add(notas[a].lote);
                            valores.Add(notas[a].liquido);
                            valores.Add(notas[a].bruto);
                            valores.Add(notas[a].cliente);
                        }

                        if (ExecuteNonSql.Executar("expedicao", TipoDeOperacao.Tipo.InsertMultiplo, colunas, valores, null) != -1)
                        {

                            DataTable nots = Select.SelectSQL("select distinct nota from expedicao where idromaneio=" + idromaneio + "");

                            for(int a = 0; a < nots.Rows.Count; a++)
                            {
                                valores1.Add(nots.Rows[a][0] + "");
                            }

                            if (ExecuteNonSql.Executar("entrega", TipoDeOperacao.Tipo.InsertMultiplo, coluna1, valores1, null) != -1)
                            {

                                chk.Idromaneio = idromaneio;
                                if (chk.Inserir() == -1){ MsgBox.Show.Error("Erro ao inserir checklist"); }

                                MsgBox.Show.Info("Expedido com Sucesso!");
                                Sessao.FecharPrograma(this);
                                Programas.RelatorioHTML novo = new RelatorioHTML(GerarHtmlRomaneio.Gerar(idromaneio + ""),false);
                                Programas.RelatorioHTML nova = new RelatorioHTML(GerarChecklist.Gerar(idromaneio + ""), false);
                                novo.Show();
                                nova.Show();
                            }
                            else
                            {
                                MsgBox.Show.Error("Erro ao ingressar novas notas para entrega!");
                                Programas.RelatorioHTML novo = new RelatorioHTML(GerarHtmlRomaneio.Gerar(idromaneio + ""), false);
                                Programas.RelatorioHTML nova = new RelatorioHTML(GerarChecklist.Gerar(idromaneio + ""), false);
                                novo.Show();
                                nova.Show();
                            }
                        }
                        else
                        {
                            MsgBox.Show.Error("Erro ao Fazer Expedição");
                        }
                    }
                    else
                    {
                        MsgBox.Show.Error("Erro ao Fazer Româneio!");
                    }
                }
            }
        }

        private Boolean verificador()
        {
            if (vt.Analisar())
            {
                if (notas.Count <= 0)
                {
                    MsgBox.Show.Error("Não foi cadastrado nenhuma nota fiscal!");
                    return false;
                }
                else
                {
                    return VerificarNotasFiscais();
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        private Boolean VerificarNotasFiscais()
        {
            DataTable tabela = Select.SelectSQL("select distinct y.nota nota,x.data data,x.id romaneio from expedicao y , romaneio x where y.idromaneio=x.id and x.idcd=" + cbo_cd.SelectedValue + "");
            IEnumerable<string> g = notas.Select(i => i.notaFiscal).Distinct();

            for (int a = 0; a < tabela.Rows.Count; a++)
            {
                for (int b = 0; b < g.Count(); b++)
                {
                    if ((tabela.Rows[a]["nota"] + "") == (g.ElementAt(b) + ""))
                    {
                        MsgBox.Show.Error("Nota Fiscal " + tabela.Rows[a]["nota"] + " já foi expedida no romaneio " + tabela.Rows[a]["romaneio"] + " em " + tabela.Rows[a]["data"] + "!");
                        return false;
                    }
                }
            }
            return true;
        }

        private Boolean VerificarNotasFiscais(string nota)
        {
            if (nota == "")
            {
                MsgBox.Show.Error("Nota Fiscal inválida.");
                return false;
            }
            else
            {
                if (("" + cbo_cd.SelectedValue + "") == "")
                {
                    MsgBox.Show.Error("Centro de distribuição não foi escolhido.");
                    return false;
                }
                else
                {
                    DataTable tabela = Select.SelectSQL("select distinct y.nota nota,x.data data,x.id romaneio from expedicao y , romaneio x where y.idromaneio=x.id and x.idcd=" + cbo_cd.SelectedValue + "");
                    for (int a = 0; a < tabela.Rows.Count; a++)
                    {
                        if ((tabela.Rows[a]["nota"] + "") == nota)
                        {
                            MsgBox.Show.Error("Nota Fiscal " + tabela.Rows[a]["nota"] + " já foi expedida no romaneio " + tabela.Rows[a]["romaneio"] + " em " + tabela.Rows[a]["data"] + "!");
                            return false;
                        }
                    }
                    return true;
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Programas.Logistica.Produtos(produto), this);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbo_idRomaneio.SelectedIndex != -1)
                {
                    Programas.RelatorioHTML novo = new RelatorioHTML(GerarHtmlRomaneio.Gerar(cbo_idRomaneio.SelectedValue + ""), false);
                    novo.Show();
                }
            }
            catch(Exception ex)
            {
                Facilitadores.ErroLog.Registrar(ex);
                MsgBox.Show.Error(ex + "");
            }
        }

        private void buttonq_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbo_idRomaneio.SelectedIndex != -1)
                {
                    string url = GerarChecklist.Gerar(cbo_idRomaneio.SelectedValue + "");
                    if (url != "")
                    {
                        Programas.RelatorioHTML novo = new RelatorioHTML(url, false);
                        novo.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Facilitadores.ErroLog.Registrar(ex);
                MsgBox.Show.Error(ex + "");
            }
        }



        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (cbo_cd.Text.Trim() == "")
            {
                MsgBox.Show.Error("O Centro de Distribuição ainda não foi informado",cbo_cd);
            }
            else
            {
                //1   Atanor do Brasil LTDA -POA
                //2   Atanor do Brasil LTDA -CWB
                //3   Atanor do Brasil LTDA -XAN
                //5   Atanor do Brasil LTDA -RES
                //ObterInformacao(txt_nota.Text);
                string meuidcd = "-1";
                if (cbo_cd.Text == "Passo Fundo") meuidcd = "1";
                if (cbo_cd.Text == "Pato Branco") meuidcd = "2";
                if (cbo_cd.Text == "Xanxerê") meuidcd = "3";
                if (cbo_cd.Text == "Consagro") meuidcd = "4";
                if (cbo_cd.Text == "Resende") meuidcd = "5";

                string nota = txt_nota.Text;

                // string sql = "select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, T0.FILIAL, T0.[Cód. PN], T0.CLIENTE, T0.PAIS, T0.ESTADO, T0.CIDADE, T0.VENDEDOR, T0.[DATA DO LANÇAMENTO], T0.[CÓDIGO DO PRODUTO], T0.PRODUTO, T0.UTILIZAÇÃO, T0.LOTE, T0.[QUANTIDADE DO LOTE], T0.[QUANTIDADE TOTAL], T0.LOCAL, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod,CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo  from (select  DISTINCT ENTREGA.DocEntry AS 'DOCENTRY', ENTREGA.TrgetEntry AS 'DOCENTRYF', nfe.BPLId as 'idfilial', NFE.[BPLName] AS 'FILIAL',   NFE.[CardCode] as 'Cód. PN',  NFE.[CardName] AS 'CLIENTE', (SELECT MAX(countrys) FROM INV12 X WHERE X.docentry=ENTREGA.TrgetEntry) AS 'PAIS', (SELECT MAX(states) FROM INV12 X WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM INV12 X WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE NFE.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', NFE.DocDate  AS 'DATA DO LANÇAMENTO', ENTREGA.[ItemCode]  AS 'CÓDIGO DO PRODUTO',  ENTREGA.[Dscription]  AS 'PRODUTO', (SELECT T3.Usage FROM OUSG T3 WHERE ENTREGA.[Usage] = T3.[ID] )  AS 'UTILIZAÇÃO', ENTREGA.[Quantity]  AS 'QUANTIDADE TOTAL',   t2.DistNumber  AS 'LOTE', t1.Quantity  AS 'QUANTIDADE DO LOTE', t3.BinCode  AS 'LOCAL' from  dln1 ENTREGA, ODLN NFE,  OITL T0, ITL1 T1, OBTN T2, B1_SnBTransRptFirstBinView T3  WHERE t0.LogEntry=t1.LogEntry and t2.AbsEntry=t1.MdAbsEntry and t3.ITLEntry=t0.LogEntry and t3.SnBMDAbs=t1.MdAbsEntry and t0.DOCTYPE=ENTREGA.ObjType and t0.DocEntry=ENTREGA.DocEntry and t0.ItemCode=ENTREGA.ItemCode and ENTREGA.DocEntry=NFE.DocEntry ) t0, oinv t1, inv1 t2 where t1.docentry=t2.docentry and t2.BaseEntry=t0.DOCENTRY and t1.BPLId=t0.idfilial and t1.BPLId=§§id§§ and t1.Serial=§§nota§§  union all  select  T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, T0.FILIAL, T0.[Cód. PN], T0.CLIENTE, T0.PAIS, T0.ESTADO, T0.CIDADE, T0.VENDEDOR, T0.[DATA DO LANÇAMENTO], T0.[CÓDIGO DO PRODUTO], T0.PRODUTO, T0.UTILIZAÇÃO, T0.LOTE, T0.[QUANTIDADE DO LOTE], T0.[QUANTIDADE TOTAL], T0.LOCAL, (select TrnspName from oshp T99 WHERE T99.TrnspCode=t1.TrnspCode) frete, CONVERT(int , t1.U_nfe_STU) cod,CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo  from (select  DISTINCT ENTREGA.DocEntry AS 'DOCENTRY', ENTREGA.TrgetEntry AS 'DOCENTRYF', nfe.BPLId as 'idfilial', NFE.[BPLName] AS 'FILIAL',   NFE.[CardCode] as 'Cód. PN',  NFE.[CardName] AS 'CLIENTE', (SELECT MAX(countrys) FROM dln12 X WHERE X.docentry=ENTREGA.TrgetEntry) AS 'PAIS', (SELECT MAX(states) FROM dln12 X WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT WHERE ABSID=X.countys) FROM dln12 X WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 WHERE NFE.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', NFE.DocDate  AS 'DATA DO LANÇAMENTO', ENTREGA.[ItemCode]  AS 'CÓDIGO DO PRODUTO',  ENTREGA.[Dscription]  AS 'PRODUTO', (SELECT T3.Usage FROM OUSG T3 WHERE ENTREGA.[Usage] = T3.[ID] )  AS 'UTILIZAÇÃO', ENTREGA.[Quantity]  AS 'QUANTIDADE TOTAL',   t2.DistNumber  AS 'LOTE', t1.Quantity  AS 'QUANTIDADE DO LOTE', t3.BinCode  AS 'LOCAL' from  dln1 ENTREGA, ODLN NFE,  OITL T0, ITL1 T1, OBTN T2, B1_SnBTransRptFirstBinView T3  WHERE t0.LogEntry=t1.LogEntry and t2.AbsEntry=t1.MdAbsEntry and t3.ITLEntry=t0.LogEntry and t3.SnBMDAbs=t1.MdAbsEntry and t0.DOCTYPE=ENTREGA.ObjType and t0.DocEntry=ENTREGA.DocEntry and t0.ItemCode=ENTREGA.ItemCode and ENTREGA.DocEntry=NFE.DocEntry ) t0, odln t1, dln1 t2 where t1.docentry=t2.docentry and t2.DocEntry=t0.DOCENTRY and t1.BPLId=t0.idfilial and t1.BPLId=§§id§§ and t2.BaseType=13 and t1.Serial=§§nota§§";
                 string sql = "select  distinct T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, T0.FILIAL, T0.[Cód. PN], T0.CLIENTE, T0.PAIS, T0.ESTADO, T0.CIDADE, T0.VENDEDOR, T0.[DATA DO LANÇAMENTO], T0.[CÓDIGO DO PRODUTO], T0.PRODUTO, T0.UTILIZAÇÃO, T0.LOTE, T0.[QUANTIDADE DO LOTE], T0.[QUANTIDADE TOTAL], T0.LOCAL, (select TrnspName from oshp T99 with(nolock) WHERE T99.TrnspCode=t1.TrnspCode) frete, case when  CONVERT(int ,  t1.U_nfe_STU)  = -1 then (select U_inStatus from [@SKL25NFE] with(nolock) where U_DocEntry = T1.DocEntry ) else  CONVERT(int ,  t1.U_nfe_STU)  end cod,CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo  from (select  DISTINCT ENTREGA.DocEntry AS 'DOCENTRY', ENTREGA.TrgetEntry AS 'DOCENTRYF', nfe.BPLId as 'idfilial', NFE.[BPLName] AS 'FILIAL',   NFE.[CardCode] as 'Cód. PN',  NFE.[CardName] AS 'CLIENTE', (SELECT MAX(countrys) FROM INV12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry) AS 'PAIS', (SELECT MAX(states) FROM INV12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT with(nolock) WHERE ABSID=X.countys) FROM INV12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 with(nolock) WHERE NFE.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', NFE.DocDate  AS 'DATA DO LANÇAMENTO', ENTREGA.[ItemCode]  AS 'CÓDIGO DO PRODUTO',  ENTREGA.[Dscription]  AS 'PRODUTO', (SELECT T3.Usage FROM OUSG T3 with(nolock) WHERE ENTREGA.[Usage] = T3.[ID] )  AS 'UTILIZAÇÃO', ENTREGA.[Quantity]  AS 'QUANTIDADE TOTAL',   t2.DistNumber  AS 'LOTE', t1.Quantity  AS 'QUANTIDADE DO LOTE', t3.BinCode  AS 'LOCAL' from  dln1 ENTREGA with(nolock), ODLN NFE with(nolock),  OITL T0 with(nolock), ITL1 T1 with(nolock), OBTN T2 with(nolock) , B1_SnBTransRptFirstBinView T3  WHERE t0.LogEntry=t1.LogEntry and t2.AbsEntry=t1.MdAbsEntry and t3.ITLEntry=t0.LogEntry and t3.SnBMDAbs=t1.MdAbsEntry and t0.DOCTYPE=ENTREGA.ObjType and t0.DocEntry=ENTREGA.DocEntry and t0.ItemCode=ENTREGA.ItemCode and ENTREGA.DocEntry=NFE.DocEntry ) t0, oinv t1 with(nolock), inv1 t2 with(nolock) where t1.docentry=t2.docentry and t2.BaseEntry=t0.DOCENTRY and t1.BPLId=t0.idfilial and t1.BPLId=§§id§§ and t1.Serial=§§nota§§  union all  select  T1.DocEntry, T1.Serial, t2.TargetType, t1.CANCELED, t1.DocStatus, t1.BPLId, T0.FILIAL, T0.[Cód. PN], T0.CLIENTE, T0.PAIS, T0.ESTADO, T0.CIDADE, T0.VENDEDOR, T0.[DATA DO LANÇAMENTO], T0.[CÓDIGO DO PRODUTO], T0.PRODUTO, T0.UTILIZAÇÃO, T0.LOTE, T0.[QUANTIDADE DO LOTE], T0.[QUANTIDADE TOTAL], T0.LOCAL, (select TrnspName from oshp T99 with(nolock) WHERE T99.TrnspCode=t1.TrnspCode) frete, case when  CONVERT(int ,  t1.U_nfe_STU)  = -1 then (select U_inStatus from [@SKL25NFE] with(nolock) where U_DocEntry = T1.DocEntry ) else  CONVERT(int ,  t1.U_nfe_STU)  end cod,CONVERT(varchar(200), t1.U_nfe_STU_Motivo) motivo  from (select  DISTINCT ENTREGA.DocEntry AS 'DOCENTRY', ENTREGA.TrgetEntry AS 'DOCENTRYF', nfe.BPLId as 'idfilial', NFE.[BPLName] AS 'FILIAL',   NFE.[CardCode] as 'Cód. PN',  NFE.[CardName] AS 'CLIENTE', (SELECT MAX(countrys) FROM dln12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry) AS 'PAIS', (SELECT MAX(states) FROM dln12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'ESTADO', (SELECT (SELECT NAME FROM OCNT with(nolock) WHERE ABSID=X.countys) FROM dln12 X with(nolock) WHERE X.docentry=ENTREGA.TrgetEntry)  AS 'CIDADE', (SELECT T2.SlpName FROM OSLP T2 with(nolock) WHERE NFE.[SlpCode] = T2.[SlpCode] )  AS 'VENDEDOR', NFE.DocDate  AS 'DATA DO LANÇAMENTO', ENTREGA.[ItemCode]  AS 'CÓDIGO DO PRODUTO',  ENTREGA.[Dscription]  AS 'PRODUTO', (SELECT T3.Usage FROM OUSG T3 with(nolock) WHERE ENTREGA.[Usage] = T3.[ID] )  AS 'UTILIZAÇÃO', ENTREGA.[Quantity]  AS 'QUANTIDADE TOTAL',   t2.DistNumber  AS 'LOTE', t1.Quantity  AS 'QUANTIDADE DO LOTE', t3.BinCode  AS 'LOCAL' from  dln1 ENTREGA with(nolock), ODLN NFE with(nolock),  OITL T0 with(nolock), ITL1 T1 with(nolock), OBTN T2 with(nolock), B1_SnBTransRptFirstBinView T3  WHERE t0.LogEntry=t1.LogEntry and t2.AbsEntry=t1.MdAbsEntry and t3.ITLEntry=t0.LogEntry and t3.SnBMDAbs=t1.MdAbsEntry and t0.DOCTYPE=ENTREGA.ObjType and t0.DocEntry=ENTREGA.DocEntry and t0.ItemCode=ENTREGA.ItemCode and ENTREGA.DocEntry=NFE.DocEntry ) t0, odln t1, dln1 t2 where t1.docentry=t2.docentry and t2.DocEntry=t0.DOCENTRY and t1.BPLId=t0.idfilial and t1.BPLId=§§id§§ and t2.BaseType=13 and t1.Serial=§§nota§§";
                sql = sql.Replace("§§id§§", meuidcd);
                sql = sql.Replace("§§nota§§", nota);

                
                novo.Select(sql);
                MsgBox.Show.EspereAbrir();

            }
        }

        private void txt_liquido_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double p = double.Parse(txt_liquido.Text);
                string idsap = cbo_produto.SelectedValue + "";

                double liquido = 0;
                double conversao = 0;

                for(int a = 0; a < prod.Count; a++)
                {
                    if (idsap == prod[a].Idsap)
                    {
                        liquido = prod[a].Peso;
                        conversao = prod[a].Conversao;
                        break;
                    }
                }

                if (conversao > 0)
                {
                    double fator = conversao / liquido;

                    txt_bruto.Text = "" + (p * fator) + "";
                }
                else
                {
                    txt_bruto.Text = txt_liquido.Text;
                }
            }
            catch { txt_bruto.Text = txt_liquido.Text; }
        }

        List<Banco.produtos> prod = Banco.produtos.Obter();
        

        private void Novo_Retorno(DataSet tabelas)
        {
            DataTable tabela = tabelas.Tables[0];
            

            if (tabela.Rows.Count > 0)
            {
                if (tabela.Columns[0].ColumnName == "arq")
                {
                    MsgBox.Show.Error("Nota fiscal não foi encontrada!");
                    return;
                }
                string documentoapos = tabela.Rows[0][2] + "";
                string cancelado = tabela.Rows[0][3] + "";

                string cfaz = "";
                string cfazmotivo = "";

                try
                {
                     cfaz = tabela.Rows[0][22] + "";
                     cfazmotivo = tabela.Rows[0][23] + "";
                    cfaz = cfaz.Trim();
                }
                catch { }

                if (documentoapos.Trim() == "14")
                {
                    MsgBox.Show.Error("A nota fiscal " + tabela.Rows[0][1] + " teve uma devolução. só é possível fazer essa operação manualmente.");
                    return;
                }

                if (documentoapos.Trim() == "13" || cancelado == "Y")
                {
                    MsgBox.Show.Error("A nota fiscal " + tabela.Rows[0][1] + " foi cancelado. por favor veja essa nota no mapa de relaçãop do SAP. só é possível fazer essa operação manualmente.");
                    return;
                }

                if (cfaz != "100" && cfaz != "3")
                {
                    if (cfaz != "Autorizado o uso da NF-e")
                    {
                        if (cfazmotivo.Trim() == "")
                        {
                            MsgBox.Show.Error("Não é possível fazer esta expedição pois esta nota não foi enviada para o Sefaz.");
                            return;
                        }
                        else
                        {
                            MsgBox.Show.Error("Não é possível fazer esta expedição." + cfazmotivo);
                            return;
                        }
                    }
                }

                if (documentoapos == "" || documentoapos == "-1")
                {
                    if (MsgBox.Show.Pergunta("Quer mesmo adicionar a nota " + tabela.Rows[0][1] + " do cliente " + tabela.Rows[0][8] + "  Frete:" + tabela.Rows[0][21] + ""))
                    {
                        string local = "";
                        for (int a = 0; a < tabela.Rows.Count; a++)
                        {
                             local = tabela.Rows[a][20] + "";
                            local = local.Replace("-", "");
                            if (local.IndexOf("BINLOCATION") == -1)
                            {
                                if(MsgBox.Show.Pergunta("O lote " + tabela.Rows[a][17] + " foi consumido do local " + tabela.Rows[a][20] + " quer adicionar esse lote?"))
                                {
                                    data_emissao.SelectedDate = Facilitadores.ConverterDataSQLemDataTime.converter(tabela.Rows[a][13] + "");
                                    txt_cliente.Text = tabela.Rows[a][8] + "";
                                    cbo_estado.Text = tabela.Rows[a][10] + "";
                                    txt_cidade.Text = tabela.Rows[a][11] + "";
                                    cbo_produto.Text = tabela.Rows[a][15] + "";
                                    txt_lote.Text = tabela.Rows[a][17] + "";
                                    txt_liquido.Text = "" + double.Parse((tabela.Rows[a][18] + "").Replace("-", ""));
                                   // txt_bruto.Text = "" + double.Parse((tabela.Rows[a][18] + "").Replace("-", ""));
                                   txt_vendedor.Text= tabela.Rows[a][12] + "";
                                    txt_posicao.Text = tabela.Rows[a][20] + "";
                                    txt_utilizacao.Text = tabela.Rows[a][16] + "";


                                    btn_add_Click(null, null);
                                }
                            }
                            else
                            {

                                data_emissao.SelectedDate = Facilitadores.ConverterDataSQLemDataTime.converter(tabela.Rows[a][13] + "");
                                txt_cliente.Text = tabela.Rows[a][8] + "";
                                cbo_estado.Text = tabela.Rows[a][10] + "";
                                txt_cidade.Text = tabela.Rows[a][11] + "";
                                string pr= tabela.Rows[a][14] + "";
                                cbo_produto.SelectedValue = pr;
                                
                                txt_lote.Text = tabela.Rows[a][17] + "";
                                string liquido = tabela.Rows[a][18] + "";
                                if (liquido.IndexOf(".") != -1)
                                {
                                    liquido = liquido.Substring(0, liquido.IndexOf(".")).Replace("-", "");
                                }
                                txt_liquido.Text =""+ double.Parse(liquido);
                                //txt_bruto.Text = "" + double.Parse(liquido);
                                txt_vendedor.Text = tabela.Rows[a][12] + "";
                                txt_posicao.Text = tabela.Rows[a][20] + "";
                                txt_utilizacao.Text = tabela.Rows[a][16] + "";
                                btn_add_Click(null, null);
                                
                            }
                        }
                    }
                }
            }
            else
            {
                MsgBox.Show.Error("Nota fiscal não foi encontrada.");
                return;
            }
        }


    }
}
