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
using System.Data;
using Microsoft.Win32;

namespace APPEventNow
{
    /// <summary>
    /// Lógica de interacción para EditarEvento.xaml
    /// </summary>
    /// 

    public partial class EditarEvento : Window
    {
        string rutaimg;
        public int variable;
        //Abrir ventana de edicion y recibe el ID del evento respectivo
        public EditarEvento(int parametro)
        {
            InitializeComponent();
            int idevento = parametro;
            DataTable dt = new DataTable();
            Conexion op = new Conexion();
            Evento upd = new Evento
            {
                id_e = idevento
        };
            dt = op.consultaEventos(upd);
            txtTitulo.Text = dt.Rows[0][2].ToString();
            txtDescripcion.Text = dt.Rows[0][3].ToString();
            txtCategoria.Text = dt.Rows[0][1].ToString();
            rutaimg = dt.Rows[0][4].ToString();
            preview.Source = new BitmapImage(new Uri(rutaimg));
            btnFoto.Content = "Cambiar";
            txtUbicacion.Text = dt.Rows[0][5].ToString();
            txtFecha.Text = dt.Rows[0][6].ToString();
            txtHoraI.Text = dt.Rows[0][7].ToString();
            txtHoraF.Text = dt.Rows[0][8].ToString();
            txtEntidad.Text = dt.Rows[0][9].ToString();
            txtTipo.Text = dt.Rows[0][10].ToString();

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
        //Click actualizar evento
        private void Actualizar_Evento(object sender, RoutedEventArgs e)
        {
            int filas = 0;
            Evento registro = new Evento {
                id_e = variable
            };
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
            Conexion op = new Conexion();
            filas = op.ActualizarEvento(registro);
            if (filas>0)
            {
                MessageBox.Show("Actualizado");
                this.Close();                
            }
            else
            {
                MessageBox.Show("no Actualizado");
            }
        }
        //Close
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
}
}
