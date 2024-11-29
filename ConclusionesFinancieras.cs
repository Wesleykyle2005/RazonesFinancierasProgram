using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace RazonesFinancieras
{
    public static class ConclusionesFinancieras
    {
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

        public static List<Conclusion> Conclusiones = new List<Conclusion>();

        public static void AgregarConclusion(string titulo, string conclusion)
        {
            // Eliminar la parte final "Form" si está presente en el título
            if (titulo.EndsWith("Form"))
            {
                titulo = titulo.Substring(0, titulo.Length - 4); // Elimina los últimos 4 caracteres ("Form")
            }

            var conclusionObj = new Conclusion(titulo, conclusion);
            Conclusiones.Add(conclusionObj);
        }


        // Método para guardar todas las conclusiones en un archivo Excel usando ClosedXML
        public static void GuardarConclusionesEnExcel(string rutaArchivoExcel)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaArchivoExcel))
                {
                    MessageBox.Show("La ruta del archivo es inválida.", "Error");
                    return;
                }

                // Crear un archivo Excel con ClosedXML
                using (var workbook = new XLWorkbook())
                {
                    // Crear una hoja de trabajo
                    var worksheet = workbook.Worksheets.Add("Conclusiones");

                    // Agregar encabezados
                    var encabezadoTitulo = worksheet.Cell(1, 1);
                    var encabezadoFecha = worksheet.Cell(1, 2);
                    var encabezadoConclusion = worksheet.Cell(1, 3);

                    encabezadoTitulo.Value = "Titulo";
                    encabezadoFecha.Value = "Fecha";
                    encabezadoConclusion.Value = "Conclusion";

                    // Formatear encabezados
                    encabezadoTitulo.Style.Fill.BackgroundColor = XLColor.LightGreen;  // Fondo verde
                    encabezadoFecha.Style.Fill.BackgroundColor = XLColor.LightGreen;    // Fondo verde
                    encabezadoConclusion.Style.Fill.BackgroundColor = XLColor.LightGreen;  // Fondo verde

                    encabezadoTitulo.Style.Font.FontColor = XLColor.Black;  // Texto negro
                    encabezadoFecha.Style.Font.FontColor = XLColor.Black;   // Texto negro
                    encabezadoConclusion.Style.Font.FontColor = XLColor.Black;  // Texto negro

                    encabezadoTitulo.Style.Font.Bold = true;  // Texto en negrita
                    encabezadoFecha.Style.Font.Bold = true;   // Texto en negrita
                    encabezadoConclusion.Style.Font.Bold = true;  // Texto en negrita

                    encabezadoTitulo.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;  // Borde exterior
                    encabezadoFecha.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;   // Borde exterior
                    encabezadoConclusion.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;  // Borde exterior

                    encabezadoTitulo.Style.Border.InsideBorder = XLBorderStyleValues.Thin; // Borde interior
                    encabezadoFecha.Style.Border.InsideBorder = XLBorderStyleValues.Thin;  // Borde interior
                    encabezadoConclusion.Style.Border.InsideBorder = XLBorderStyleValues.Thin; // Borde interior

                    // Ajustar ancho de todas las columnas a 50
                    worksheet.Column(1).Width = 50;  // Columna Titulo
                    worksheet.Column(2).Width = 50;  // Columna Fecha
                    worksheet.Column(3).Width = 50;  // Columna Conclusion

                    // Establecer alineación vertical centrada para todas las columnas
                    worksheet.Column(1).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);  // Alineación vertical centrada para la columna Titulo
                    worksheet.Column(2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);  // Alineación vertical centrada para la columna Fecha
                    worksheet.Column(3).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);  // Alineación vertical centrada para la columna Conclusion

                    // Asegurarse de que el texto no se corte
                    worksheet.Column(1).Style.Alignment.WrapText = true;
                    worksheet.Column(2).Style.Alignment.WrapText = true;
                    worksheet.Column(3).Style.Alignment.WrapText = true;

                    // Agregar cada conclusión de la lista
                    for (int i = 0; i < Conclusiones.Count; i++)
                    {
                        var conclusion = Conclusiones[i];

                        // Escribir los valores en la fila correspondiente
                        worksheet.Cell(i + 2, 1).Value = conclusion.Titulo;
                        worksheet.Cell(i + 2, 2).Value = conclusion.Fecha;
                        worksheet.Cell(i + 2, 3).Value = conclusion.Texto.Replace("\n", " ").Replace("\r", "");
                    }

                    // Aplicar bordes a todas las celdas
                    worksheet.Range(1, 1, Conclusiones.Count + 1, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;  // Bordes exteriores
                    worksheet.Range(1, 1, Conclusiones.Count + 1, 3).Style.Border.InsideBorder = XLBorderStyleValues.Thin;   // Bordes interiores

                    // Guardar el archivo Excel
                    workbook.SaveAs(rutaArchivoExcel);
                }
                MessageBox.Show("Todas las conclusiones han sido guardadas exitosamente en formato Excel.", "Éxito");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo Excel: {ex.Message}");
                MessageBox.Show($"Error al guardar el archivo Excel: {ex.Message}", "Error");
            }
        }




    }
}
