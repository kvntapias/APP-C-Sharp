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
using DTO;
using CAD;
using System.Data;
using System.Collections.ObjectModel;


namespace APPEventNow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public ObservableCollection<Evento> ListaDeEventos; // Coleccion auxiliar.
        //Load Window
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EventosLoad();
        }

        //Cargar Eventos
        public void EventosLoad()
        {
            try
            {
                Conexion op = new Conexion();
                ListaDeEventos = op.ObtenerEventos();// recupero los eventos el método ObtenerEventos() y la asigno a ListaDeEventos.
                Eventos.ItemsSource = ListaDeEventos; //asigno los datos al listbox en la vista
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Permite mover la ventana
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //Boton para acceder al menu de gestion de eventos
        private void Gestion_Eventos(object sender, RoutedEventArgs e)
        {
            GestionEventos gest = new GestionEventos();
            App.Current.MainWindow = gest;
            this.Close();
            gest.Show();
        }
        //Cerrar Ventana principal
        private void Cerrr_Main(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Boton editar
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            //Caaptura el ID de la tarjeta a editar
            var id = ((Button)sender).DataContext as Evento;
            if (id == null)
                throw new InvalidOperationException("Invalid");
            int x = id.id_e;
            EditarEvento edita = new EditarEvento(x);
            edita.variable = id.id_e;
            edita.Show();
            Console.WriteLine(id.id_e);
        }
        

    } 
}
