using Npgsql;
using System;
using System.Data;

namespace BBDDVisualStudio
{
    class Conexion
    {
        // Crea una instancia de NpgsqlConnection para la conexión a la base de datos.
        NpgsqlConnection conex = new NpgsqlConnection();

        static String host = "localhost";
        static String bd = "gestorBibliotecaPersonal";
        static String nombre = "postgres";
        static String pass = "#";
        static String puerto = "5432";
        // Contiene la información de conexión.
        String connString = "server=" + host + ";" + "port=" + puerto + ";" + "user id=" + nombre + ";" + "password=" + pass + ";" + "database=" + bd + ";";
        public NpgsqlConnection conectarBBDD()
        {
            try
            {
                conex.ConnectionString = connString;
                conex.Open();
                if(conex != null)
                {
                    Console.WriteLine("Conexion establecida con éxito");
                }
            }
            catch(NpgsqlException e)
            {
                Console.WriteLine("No se pudo conectar con la base de datos, " + e.ToString());
            }
            return conex;

              
        }
        // Método para realizar una consulta a la base de datos.
        public DataTable consulta(NpgsqlConnection conex)
        {
            string query = "SELECT * FROM gbp_almacen.gbp_alm_cat_libros";  // Consulta SQL para seleccionar todos los registros de una tabla.

            NpgsqlCommand conector = new NpgsqlCommand(query, conex);  // Crea un comando Npgsql para ejecutar la consulta.
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);  // Crea un adaptador NpgsqlDataAdapter para obtener los datos.
            DataTable tabla = new DataTable();  // Crea una tabla DataTable para almacenar los resultados de la consulta.

            datos.Fill(tabla);  // Llena la tabla con los resultados de la consulta.

            // Recorre las filas del elemento
            foreach (DataRow filas in tabla.Rows)
            {
                // Recorre las columnas del elemento
                foreach (DataColumn columnas in tabla.Columns)
                {
                    Console.WriteLine(columnas.ColumnName + ": " + filas[columnas].ToString() + "\t");  // Imprime el nombre de la columna y el valor de la celda.
                }
                Console.WriteLine();
            }
            return tabla;
        }
      


    }
}
