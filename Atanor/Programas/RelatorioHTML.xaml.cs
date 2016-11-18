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
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Atanor.Programas
{
    /// <summary>
    /// Interaction logic for RelatorioHTML.xaml
    /// </summary>
    public partial class RelatorioHTML : Window
    {
        string ourl;
        public RelatorioHTML(string url,Boolean exportahtml)
        {
            ourl = url;
            InitializeComponent();
            html.IsEnabled = exportahtml;
            webBrowser1.Navigate(url);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Sessao.ApagaBots();
            Sessao.AddPdf(ourl);
            Facilitadores.ExportarParaPDF.Exportar();

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct OLECMDTEXT
        {
            public uint cmdtextf;
            public uint cwActual;
            public uint cwBuf;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
            public char rgwz;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct OLECMD
        {
            public uint cmdID;
            public uint cmdf;
        }

        // Interop definition for IOleCommandTarget. 
        [ComImport,
        Guid("b722bccb-4e68-101b-a2bc-00aa00404770"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleCommandTarget
        {
            //IMPORTANT: The order of the methods is critical here. You
            //perform early binding in most cases, so the order of the methods
            //here MUST match the order of their vtable layout (which is determined
            //by their layout in IDL). The interop calls key off the vtable ordering,
            //not the symbolic names. Therefore, if you switched these method declarations
            //and tried to call the Exec method on an IOleCommandTarget interface from your
            //application, it would translate into a call to the QueryStatus method instead.
            void QueryStatus(ref Guid pguidCmdGroup, UInt32 cCmds,
                [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] 
		OLECMD[] prgCmds, ref OLECMDTEXT CmdText);
            void Exec(ref Guid pguidCmdGroup,
                uint nCmdId, uint nCmdExecOpt, ref object pvaIn, ref object pvaOut);
        }

        Guid CGID_MSHTML = new Guid("DE4BA900-59CA-11CF-9592-444553540000");

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            mshtml.IHTMLDocument2 doc = webBrowser1.Document as mshtml.IHTMLDocument2;
            var v = doc;
            Object o = new object();

            IOleCommandTarget cmdt = (IOleCommandTarget)v;
            cmdt.Exec(ref CGID_MSHTML, 2003, 0, ref o, ref o);
        }

       

        public System.Drawing.Bitmap HTMLToImage(String strHTML)
        {
            System.Drawing.Bitmap myBitmap = null;

            System.Threading.Thread myThread = new System.Threading.Thread(delegate()
            {
               
            });


            myThread.SetApartmentState(System.Threading.ApartmentState.STA);
            myThread.Start();
            myThread.Join();

            return myBitmap;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                File.Delete(ourl);
            }
            catch { }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Salvar Relatório de Estoque.";
            saveFileDialog1.Filter = "Relatório de Estoque|.htm";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = "Relatório_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
            saveFileDialog1.DefaultExt = ".htm";
            saveFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop+"";
            saveFileDialog1.RestoreDirectory = true;

            try
            {
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter escritor = new StreamWriter(saveFileDialog1.FileName,false,Encoding.Default);
                    escritor.Write(Programas.Suplly.RelatorioDeEstadoDeEstoque.MontarHTMLComSenha());
                    escritor.Close();
                }
                MsgBox.Show.Info("Relatório salvo com sucesso!");
            }
            catch { MsgBox.Show.Error("Erro ao gerar relatório."); }
        }
    }
}
