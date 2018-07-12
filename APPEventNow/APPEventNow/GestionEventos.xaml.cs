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
using System.Windows.Shapes;

namespace APPEventNow
{
    /// <summary>
    /// Lógica de interacción para GestionEventos.xaml
    /// </summary>
    public partial class GestionEventos : Window
    {
        public GestionEventos()
        {
            InitializeComponent();
        }

        //Eventos en los botones
        private void Actualizar(object sender, RoutedEventArgs e)
        {

        }

        private void Publicar(object sender, RoutedEventArgs e)
        {
            registrarEvento reg = new registrarEvento();
            App.Current.MainWindow = reg;
            this.Close();
            reg.Show();
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            Busqueda_Eliminar open = new Busqueda_Eliminar();
            App.Current.MainWindow = open;
            this.Close();
            open.Show();
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        { 
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            MainWindow back = new MainWindow();
            App.Current.MainWindow = back;
            this.Close();
            back.Show();
        }
    }
}
