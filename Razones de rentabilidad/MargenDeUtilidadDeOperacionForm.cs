﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RazonesFinancieras.Razones_de_rentabilidad
{
    public partial class MargenDeUtilidadDeOperacionForm : Form
    {
        public MargenDeUtilidadDeOperacionForm()
        {
            InitializeComponent();
        }

        private void MargenDeUtilidadDeOperacionForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            // Inicializar las variables
            Double ventas = 0;
            Double utilidadOperativa = 0;

            // Asignar valores iniciales a los TextBox
            VentasTextBox.Text = ventas.ToString();
            UtilidadOperativaTextBox.Text = utilidadOperativa.ToString();

            try
            {
                // Establecer la cadena de conexión
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

                // Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener Ventas, Costos y Gastos
                    string query = @"
            SELECT 
                SUM(CASE WHEN CE.TipoCuenta = 'Ventas' THEN V.Valor ELSE 0 END) AS TotalVentas,
                SUM(CASE WHEN CE.TipoCuenta = 'Costos' THEN C.Valor ELSE 0 END) AS TotalCostos,
                SUM(CASE WHEN CE.TipoCuenta = 'Gastos' THEN G.Valor ELSE 0 END) AS TotalGastos
            FROM CuentaEmpresa CE
            JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
            LEFT JOIN Ventas V ON CE.TipoCuenta = 'Ventas' AND CE.IdCuenta = V.IdVenta
            LEFT JOIN Costos C ON CE.TipoCuenta = 'Costos' AND CE.IdCuenta = C.IdCosto
            LEFT JOIN Gastos G ON CE.TipoCuenta = 'Gastos' AND CE.IdCuenta = G.IdGasto
            WHERE E.IdEmpresa = @IdEmpresa
            GROUP BY E.IdEmpresa;";

                    // Ejecutar la consulta
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Parámetro de la consulta
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1); // Reemplazar con el Id de la empresa deseada

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los valores obtenidos desde la base de datos
                                ventas = reader["TotalVentas"] != DBNull.Value ? Convert.ToDouble(reader["TotalVentas"]) : 0;
                                Double totalCostos = reader["TotalCostos"] != DBNull.Value ? Convert.ToDouble(reader["TotalCostos"]) : 0;
                                Double totalGastos = reader["TotalGastos"] != DBNull.Value ? Convert.ToDouble(reader["TotalGastos"]) : 0;

                                // Calcular la Utilidad Operativa
                                utilidadOperativa = ventas - totalCostos - totalGastos;

                                // Mostrar los valores en los TextBox
                                VentasTextBox.Text = ventas.ToString("N2");
                                UtilidadOperativaTextBox.Text = utilidadOperativa.ToString("N2");

                                // Calcular y mostrar el Margen de Utilidad Operativa
                                if (ventas != 0)
                                {
                                    double margenDeUtilidadOperativa = utilidadOperativa / ventas;
                                    MargenDeUtilidadOperativaTextBox.Text = margenDeUtilidadOperativa.ToString("P2");
                                    // Comparar con el promedio de la industria si está disponible
                                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria
                                    double promedioIndustria;
                                    string conclusion = $"El margen de utilidad operativa es de {margenDeUtilidadOperativa:P2}.\n";

                                    // Evaluar el desempeño
                                    if (margenDeUtilidadOperativa < 0.10)
                                    {
                                        conclusion += "El margen es bajo, indicando un control deficiente de costos y gastos.";
                                    }
                                    else if (margenDeUtilidadOperativa >= 0.10 && margenDeUtilidadOperativa < 0.20)
                                    {
                                        conclusion += "El margen es moderado, indicando una gestión razonable.";
                                    }
                                    else
                                    {
                                        conclusion += "El margen es alto, indicando una excelente gestión de costos y gastos.";
                                    }

                                    // Comparar con el promedio de la industria
                                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                                    {
                                        if (margenDeUtilidadOperativa < promedioIndustria)
                                        {
                                            conclusion += $"\nEste margen es inferior al promedio de la industria ({promedioIndustria:P2}), indicando un desempeño menor al promedio.";
                                        }
                                        else if (margenDeUtilidadOperativa > promedioIndustria)
                                        {
                                            conclusion += $"\nEste margen es superior al promedio de la industria ({promedioIndustria:P2}), indicando un desempeño mejor que el promedio.";
                                        }
                                        else
                                        {
                                            conclusion += $"\nEste margen es igual al promedio de la industria ({promedioIndustria:P2}).";
                                        }
                                    }
                                    else
                                    {
                                        conclusion += "\nNo se pudo comparar con el promedio de la industria.";
                                    }

                                    // Mostrar la conclusión en el TextBox de conclusiones
                                    ConclusionTextBox.Text = conclusion;
                                }
                                else
                                {
                                    MargenDeUtilidadOperativaTextBox.Text = "N/A";
                                    MessageBox.Show("Las ventas no pueden ser cero para este cálculo.", "Advertencia");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para la empresa especificada.", "Sin datos");
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error al acceder a la base de datos: {sqlEx.Message}", "Error SQL");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error");
            }
        }


        private void copyButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ConclusionTextBox.Text))
            {
                Clipboard.SetText(ConclusionTextBox.Text);
                MessageBox.Show("Contenido copiado al portapapeles.", "Copiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay contenido para copiar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén la conclusión del TextBox
                string conclusion = ConclusionTextBox.Text;

                if (!string.IsNullOrWhiteSpace(conclusion))
                {
                    // Agregar la conclusión a la lista en la clase ConclusionesFinancieras
                    ConclusionesFinancieras.AgregarConclusion(this.Text, conclusion);

                    MessageBox.Show("Conclusión guardada exitosamente.", "Éxito");
                }
                else
                {
                    MessageBox.Show("No hay ninguna conclusión para guardar.", "Advertencia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la conclusión: {ex.Message}", "Error");
            }
        }
    }
}
