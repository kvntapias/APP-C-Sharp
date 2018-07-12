using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections.ObjectModel;

//Nombre del paquete
namespace CAD
{
    //Conexion a la base de datos
    public class Conexion
    {
        private static string cadenaConexion = ConfigurationManager.ConnectionStrings["conSQLServer"].ConnectionString;
        private static SqlConnection con = new SqlConnection(cadenaConexion);
        private static SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter sda = new SqlDataAdapter();
        private SqlDataReader rdr;
        public Conexion() {

            con.ConnectionString = cadenaConexion;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

        }
        //Metodo para Insertar  un evento 
        public int CrearEvento(Evento evento)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.CommandText = "insertar_evento";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@titulo_", evento.titulo_e);
                cmd.Parameters.AddWithValue("@id_c", evento.categoria_e);
                cmd.Parameters.AddWithValue("@descripcion_", evento.descripcion_e);
                cmd.Parameters.AddWithValue("@foto_", evento.imagen_e);
                cmd.Parameters.AddWithValue("@ubicacion_", evento.ubicacion_e);
                cmd.Parameters.AddWithValue("@fecha_", evento.fecha_e);
                cmd.Parameters.AddWithValue("@horainicio_", evento.hora_i);
                cmd.Parameters.AddWithValue("@horafin_", evento.hora_f);
                cmd.Parameters.AddWithValue("@entidad_", evento.entidad_e);
                cmd.Parameters.AddWithValue("@tipo_", evento.tipo_e);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return filas;
        }
        //Metodo para Eliminar evento
        public int EliminarEvento(Evento evento) {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "eliminar_evento";
                cmd.Parameters.AddWithValue("@id_", evento.id_e);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return filas;
        }
        //Consulta eventos
        public DataTable consultaEventos(Evento evento)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "select_eventos";
                cmd.Parameters.AddWithValue("@id", evento.id_e);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return dt;
            }
        //Buscar por titullo y categoria
        public DataTable Buscar_titulo_categoria(Evento evento)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "buscar_titulo_categoria";
                cmd.Parameters.AddWithValue("@titulo", evento.titulo_e);
                cmd.Parameters.AddWithValue("@categoria", evento.categoria_e);
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return dt;
        }
        //Metodo para Actualizar Eventos
        public int ActualizarEvento(Evento evento)
        {
            int filas = 0;
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "actualizar_evento";
                cmd.Parameters.AddWithValue("@id_", evento.id_e);
                cmd.Parameters.AddWithValue("@titulo_", evento.titulo_e);
                cmd.Parameters.AddWithValue("@idc", evento.categoria_e);
                cmd.Parameters.AddWithValue("@descripcion_", evento.descripcion_e );
                cmd.Parameters.AddWithValue("@foto_", evento.imagen_e);
                cmd.Parameters.AddWithValue("@ubicacion_", evento.ubicacion_e);
                cmd.Parameters.AddWithValue("@fecha_", evento.fecha_e);
                cmd.Parameters.AddWithValue("@horainicio_", evento.hora_i);
                cmd.Parameters.AddWithValue("@horafin_", evento.hora_f);
                cmd.Parameters.AddWithValue("@entidad_", evento.entidad_e);
                cmd.Parameters.AddWithValue("@tipo_", evento.tipo_e);
                filas = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

                string error = e.Message;
                Console.WriteLine(error);
            }
            return filas;
        }
        //Consultar todos los eventos
        public DataTable Consulta()
        {
            DataTable dt = new DataTable();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "select_eventos2";
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {

                string error = e.Message;
            }
            return dt;
        }
        //Consultar Eventos y almacenarlos en una Coleccion
        public ObservableCollection<Evento> ObtenerEventos()
        {
            ObservableCollection<Evento> ListaDeEventos =
                new ObservableCollection<Evento>();
            try
            {
                if (!(cmd.Connection.State == ConnectionState.Open)) { con.Open(); }
                cmd.Parameters.Clear();
                cmd.CommandText = "select_eventos2";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Evento Datos = new Evento(
                        (int)rdr["id_e"],
                        (string)rdr["titulo_e"],
                        (string)rdr["descripcion_e"],
                        (string)rdr["foto_e"]
                        );
                    // Agregar el objeto a la coleccion.
                    ListaDeEventos.Add(Datos);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message; // Lanzamos excepción.
            }
            finally
            {
                con.Close(); // Cerramos la conexión.
            }
            return ListaDeEventos; // Regreso datos.
        }
    } 
 }
