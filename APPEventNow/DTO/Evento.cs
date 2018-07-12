using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DTO
{
    public class Evento : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        private string _titulo;
        private string _descripcion;
        public string _imagen;


        public int id_e
        { get { return _id; } set { _id = value; } }
        public string titulo_e
        { get { return _titulo; } set { _titulo = value;  } }
        public string descripcion_e
        { get { return _descripcion; } set { _descripcion = value; } }
        public string imagen_e
        { get { return _imagen; } set { _imagen = value;  } }

        public string entidad_e { get; set; }
        public string ubicacion_e { get; set; }
        public string fecha_e { get; set; }
        public string hora_i { get; set; }
        public string hora_f { get; set; }
        public string tipo_e { get; set; }
        public string categoria_e { get; set; }

        // Constructor de cardView.
        public Evento(int id, string titulo, string descripcion, string imagen)
        {
            this.id_e = id;
            this.titulo_e = titulo ;
            this.descripcion_e = descripcion;
            this.imagen_e = imagen;
            
        }
        public Evento()
        {
        }

        private void OnPropertyChanged(string titulo_e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(titulo_e));
            }
        }
    }
}
