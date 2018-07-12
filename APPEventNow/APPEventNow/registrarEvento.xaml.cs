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
using DTO;
using CAD;
using Microsoft.Win32;

namespace APPEventNow
{
    /// <summary>
    /// Lógica de interacción para registrarEvento.xaml
    /// </summary>
    public partial class registrarEvento : Window
    {
        string rutaimg;
        public registrarEvento()
        {
            InitializeComponent();
            txtTitulo.Focus();
        }

        //Metodo para Agregar foto
        private void btnFoto_Click(object sender, RoutedEventArgs e)
        {
            if (imgFoto.Source == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                string msj = "Seleccione Imagen del Evento";
                openFile.Title = msj;
                openFile.Filter = "Todos(*.*)Imagenes .jpg .png | *.jpg;*.gif;*.png;*.bmp";
                if (openFile.ShowDialog() == true)
                {
                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    rutaimg = openFile.FileName;
                    preview.Source = new BitmapImage(new Uri(rutaimg));
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;
                    btnFoto.Content = "Cancelar";
                }
            }
            else
            {
                btnFoto.Content = "Añadir foto";
                imgFoto.Source = null;
                rutaimg = null;
                preview.Source = null;
            }
        }
        //Boton Registrar evento
        private void Registrar_Evento(object sender, RoutedEventArgs e)
        {
            int filas = 0;
            Evento registro = new Evento();
            //Capturar de datos del Form en variables
           
            registro.titulo_e = txtTitulo.Text;
            registro.descripcion_e = txtDescripcion.Text;
            registro.fecha_e = txtFecha.Text;
            registro.hora_i = txtHoraI.Text;
            registro.hora_f = txtHoraF.Text;
            registro.imagen_e = rutaimg;
            registro.ubicacion_e = txtUbicacion.Text;
            registro.entidad_e = txtEntidad.Text;
            registro.tipo_e = txtTipo.Text;
            registro.categoria_e = txtCategoria.Text;

            //Validar campos vacíos en formulario de registro de libros
            if (String.IsNullOrEmpty(registro.titulo_e) ||
                String.IsNullOrEmpty(registro.descripcion_e) ||
                String.IsNullOrEmpty(registro.fecha_e) ||
                String.IsNullOrEmpty(registro.ubicacion_e) ||
                String.IsNullOrEmpty(registro.imagen_e) ||
                String.IsNullOrEmpty(registro.hora_f) ||
                String.IsNullOrEmpty(registro.hora_i) ||
                String.IsNullOrEmpty(registro.entidad_e) ||
                String.IsNullOrEmpty(registro.tipo_e) ||
                String.IsNullOrEmpty(registro.categoria_e)
                 )
            {
                MessageBox.Show("Verifique los campos");
            }
            else
            //envio de parametros al metodo
            {
                Conexion op = new Conexion();
                filas = op.CrearEvento(registro);
                if (filas > 0)
                {
                    MessageBox.Show("Evento registrado");
                    MainWindow main = new MainWindow();
                    App.Current.MainWindow = main;
                    main.Show();
                    this.Close();
                    limpiarCampos();
                }
                else
                { 
                    MessageBox.Show("Evento no registrado");

                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GestionEventos back = new GestionEventos();
            App.Current.MainWindow = back;
            back.Show();
            this.Close();
        }

        //limpiar textbox
        public void limpiarCampos()
        {
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtHoraI.Text = "";
            txtHoraF.Text = "";
            txtEntidad.Text = "";
            txtUbicacion.Text = "";
            txtTipo.SelectedIndex = 1;
            txtCategoria.Text = txtCategoria.Text;
            imgFoto.Source = null;
            preview.Source = null;
        }

        //Clear data
        private void clearData()
        {
            
        }
    }
}