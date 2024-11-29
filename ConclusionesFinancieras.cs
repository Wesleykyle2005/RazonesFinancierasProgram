using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RazonesFinancieras
{
    public static class ConclusionesFinancieras
    {
        // Clase para almacenar una conclusión con su título, fecha y texto
        public class Conclusion
        {
            public string Titulo { get; set; }
            public string Fecha { get; set; }
            public string Texto { get; set; }

            public Conclusion(string titulo, string texto)
            {
                Titulo = titulo;
                Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Texto = texto;
            }
        }

        // Lista estática para almacenar las conclusiones
        public static List<Conclusion> Conclusiones = new List<Conclusion>();

        // Método para agregar una conclusión a la lista
        public static void AgregarConclusion(string titulo, string conclusion)
        {
            // Crear el objeto Conclusion y agregarlo a la lista
            var conclusionObj = new Conclusion(titulo, conclusion);
            Conclusiones.Add(conclusionObj);
        }

        // Método para guardar todas las conclusiones en un archivo CSV
        public static void GuardarConclusionesEnCSV(string rutaArchivo)
        {
            try
            {
                // Crear un StringBuilder para construir las líneas del CSV
                StringBuilder sb = new StringBuilder();

                // Agregar encabezados
                sb.AppendLine("Titulo,Fecha,Conclusion");

                // Agregar cada conclusión de la lista (ahora con objetos de tipo Conclusion)
                foreach (var conclusion in Conclusiones)
                {
                    // Asegúrate de que el título, fecha y conclusión estén correctamente formateados
                    string line = $"{conclusion.Titulo},{conclusion.Fecha},{conclusion.Texto.Replace("\"", "\"\"").Replace("\n", " ").Replace("\r", "")}";
                    sb.AppendLine(line);
                }

                // Escribir en el archivo usando UTF-8 para soportar caracteres especiales
                File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error al guardar el archivo CSV: {ex.Message}");
            }
        }
    }
}
