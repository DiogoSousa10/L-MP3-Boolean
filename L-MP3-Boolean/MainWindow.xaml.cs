using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L_MP3_Boolean
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;

        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            //Métodos 
            app.ya.leituraTerminada += ya_LeituraTerminada;
           
        }

        private void ya_LeituraTerminada()
        {
            {
                //Criar Itens da TreeView
                TreeViewItem vendido = new TreeViewItem();
                vendido.Header = "Vendido";

                TreeViewItem naovendido = new TreeViewItem();
                naovendido.Header = "Nao Vendido";

                //Dados do Model
                foreach (Implementacao sal in app.ya.Dados)
                {
                    //Colocar no Sitio Certo 
                    if (sal.Vendido == true)
                        vendido.Items.Add(sal.Categoria + "-->" + sal.Titulo + "-->" + sal.Autor);
                    else
                        naovendido.Items.Add(sal.Categoria + "-->" + sal.Titulo + "-->" + sal.Autor);
                }

                tvYa.Items.Clear();

                //Adicionar Elementos
                tvYa.Items.Add(vendido);
                tvYa.Items.Add(naovendido);
            }
        }

        private void AbrirXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*-*";

            if (dlg.ShowDialog() == true)
                //invocacao de metodos do model
                app.ya.LeituraXML(dlg.FileName);
        }

        private void GuardarXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*-*";

                if (dlg.ShowDialog() == true)
                //invocacao de metodos do model
                app.ya.EscritaXML(dlg.FileName);
        }

        private void btMaior_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            app.ya.ProcurarMaior(tvYa.ToString());
            }
            catch(OperaçaoInvalidaException ex)
            {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
