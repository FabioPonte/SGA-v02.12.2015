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

namespace Atanor.Programas.Portaria
{
    /// <summary>
    /// Interaction logic for EntradaSaidaMaterial.xaml
    /// </summary>
    public partial class EntradaSaidaMaterial : UserControl
    {
        public string per = "40";
        public string nome = "Entrada e Saída de Materiais";
        public BitmapImage icone = new BitmapImage(new Uri("../Images/delivery18.png", UriKind.RelativeOrAbsolute));
        Facilitadores.Transferidor pessoa = new Facilitadores.Transferidor();
        Facilitadores.Transferidor empresa = new Facilitadores.Transferidor();
        Facilitadores.Transferidor setor = new Facilitadores.Transferidor();
        Facilitadores.Transferidor item = new Facilitadores.Transferidor();
        Facilitadores.Verificador v = new Facilitadores.Verificador();
        List<PacoteItens> itens = new List<PacoteItens>();
        Boolean modoCadastro = true;

        public bool ModoCadastro
        {
            get
            {
                return modoCadastro;
            }

            set
            {
                modoCadastro = value;
                if (value)
                {
                    btn_cadastrar.IsEnabled = true;
                    btn_cancelar.IsEnabled = false;
                    btn_editar.IsEnabled = false;
                    btn_excluir.IsEnabled = false;
                }
                else
                {
                    btn_cadastrar.IsEnabled = false;
                    btn_cancelar.IsEnabled = true;
                    btn_editar.IsEnabled = true;
                    btn_excluir.IsEnabled = true;
                }
            }
        }

        public EntradaSaidaMaterial()
        {
            InitializeComponent();
            pessoa.Combo = cbo_nome;
            empresa.Combo = cbo_empresa;
            setor.Combo = cbo_destino;
            item.Combo = cbo_itens;

            pessoa.controle = this;
            empresa.controle = this;
            setor.controle = this;
            item.controle = this;

            pessoa.Retorno += Listar_nomes;
            empresa.Retorno += Listar_empresas;
            setor.Retorno += Listar_setores;
            item.Retorno += Listar_item;

            v.Add(cbo_nome, "Nome da pessoa não foi selecionado");
            v.Add(cbo_empresa, "Nome da empresa não foi selecionada");
            v.Add(cbo_destino, "Setor não foi selecionado");

            Listar();
        }

        private void ListarItensCadastrador()
        {
            ogrid.ItemsSource = itens.ToList();
            ogrid.SelectedValuePath = "C";
        }
             
        private void Listar()
        {
            Listar_nomes();
            Listar_empresas();
            Listar_item();
            Listar_setores();
        }

        private void Listar_nomes()
        {
            cbo_nome.ItemsSource = Banco.colaborador.ListarParaDataGrid();
            cbo_nome.DisplayMemberPath = Banco.colaborador.Colunas.nome;
            cbo_nome.SelectedValuePath = "id";
        }

        private void Listar_empresas()
        {
            cbo_empresa.ItemsSource = Banco.empresas.ListarParaDataGrid();
            cbo_empresa.DisplayMemberPath = Banco.empresas.Colunas.nome;
            cbo_empresa.SelectedValuePath = "id";
        }

        private void Listar_setores()
        {
            cbo_destino.ItemsSource = Banco.setor.ListarParaDataGrid();
            cbo_destino.DisplayMemberPath = Banco.setor.Colunas.nome;
            cbo_destino.SelectedValuePath = "id";
        }

        private void Listar_item()
        {
            cbo_itens.ItemsSource = Banco.itens_io.ListarParaDataGrid();
            cbo_itens.DisplayMemberPath = Banco.itens_io.Colunas.nome;
            cbo_itens.SelectedValuePath = "id";
        }

        private void btn_pesquisar_nome_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroColaborador(pessoa), this);
        }

        private void btn_pesquisar_empresa_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroEmpresa(empresa), this);
        }

        private void btn_pesquisa_setor_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroSetor(setor), this);
        }

        private void btn_pesquisa_item_Click(object sender, RoutedEventArgs e)
        {
            Sessao.AbrirPrograma(new Portaria.CadastroItemIO(item), this);
        }

        private void Cadastrar()
        {
            if (cbo_itens.Text.Trim() != "")
            {
               
                    Banco.itens_io n = Banco.itens_io.Obter("id=" + cbo_itens.SelectedValue)[0];
                    PacoteItens pac = new PacoteItens();
                    pac.Id = n.Id;
                    pac.Nome = n.Nome;
                    pac.Fabricante = n.Fabricante;
                    pac.Marca = n.Marca;
                    pac.Obs = txt_obs.Text;
                    pac.C = itens.Count;
                    itens.Add(pac);
                    ListarItensCadastrador();
               
            }

        }

        private void Editar()
        {
            if (cbo_itens.Text.Trim() != "")
            {
                try
                {
                    int posicao = -1;

                    for (int a = 0; a < itens.Count; a++)
                    {
                        if (int.Parse(ogrid.SelectedValue + "") == itens[a].C)
                        {
                            posicao = a;
                            break;
                        }
                    }

                    Banco.itens_io n = Banco.itens_io.Obter("id=" + cbo_itens.SelectedValue)[0];
                    PacoteItens pac = itens[posicao];
                    pac.Id = n.Id;
                    pac.Nome = n.Nome;
                    pac.Fabricante = n.Fabricante;
                    pac.Marca = n.Marca;
                    pac.Obs = txt_obs.Text;
                    ListarItensCadastrador();
                }
                catch { }
            }
        }

        private void btn_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            Editar();
        }

        private void ogrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int valor = int.Parse(ogrid.SelectedValue + "");
                for(int a = 0; a < itens.Count; a++)
                {
                    if (valor == itens[a].C)
                    {
                        txt_obs.Text = itens[a].Obs;
                        cbo_itens.Text = itens[a].Nome;
                        ModoCadastro = false;
                    }
                }

                
            }
            catch { }
        }

        private void btn_excluir_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int posicao = -1;

                for (int a = 0; a < itens.Count; a++)
                {
                    if (int.Parse(ogrid.SelectedValue + "") == itens[a].C)
                    {
                        posicao = a;
                        break;
                    }
                }
                itens.RemoveAt(posicao);
                ReorganizarNumeros();
                ListarItensCadastrador();
            }
            catch { }
        }

        private void ReorganizarNumeros()
        {
            for(int a = 0; a < itens.Count; a++)
            {
                itens[a].C = a;
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ModoCadastro = true;
        }
    }

    class PacoteItens
    {
         int c;
         int id;
         string nome;
         string marca;
         string fabricante;
         string obs;

        public int C
        {
            get
            {
                return c;
            }

            set
            {
                c = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Marca
        {
            get
            {
                return marca;
            }

            set
            {
                marca = value;
            }
        }

        public string Fabricante
        {
            get
            {
                return fabricante;
            }

            set
            {
                fabricante = value;
            }
        }

        public string Obs
        {
            get
            {
                return obs;
            }

            set
            {
                obs = value;
            }
        }
    }

}
