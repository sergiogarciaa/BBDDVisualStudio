using BBDDVisualStudio;
using Npgsql;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        

        static void Main(string[] args)
        {

            // Crear una instancia de la clase Conexion.
            Conexion conexion = new Conexion();

            // Establecer una conexión a la base de datos y almacenarla en la variable 'conect'.
            var conect = conexion.conectarBBDD();

            // Ejecutar una consulta en la conexión establecida.
            conexion.consulta(conect);
        }
    }
}