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
using System.Configuration;

namespace RazonesFinancieras.Razones_de_endeudamiento
{
    public partial class RazonDePasivoACapitalForm : Form
    {
        public RazonDePasivoACapitalForm()
        {
            InitializeComponent();
        }

        private void RazonDePasivoACapitalForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void EvaluarButton_Click(object sender, EventArgs e)
        {
            Double pasivoALargoPlazo = 0;
            Double capitalSocial = 0;

            // Conexión a la base de datos
            string SqlServerConnection = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString; // Reemplaza con tu cadena de conexión
            string query = @"
    SELECT 
    SUM(CASE WHEN CE.TipoCuenta = 'Pasivos' AND P.Clasificacion = 'Pasivo Largo Plazo' THEN P.Valor ELSE 0 END) AS TotalPasivoLargoPlazo,
    SUM(CASE WHEN CE.TipoCuenta = 'Capital' THEN C.Valor ELSE 0 END) AS TotalCapitalSocial
FROM CuentaEmpresa CE
JOIN Empresa E ON CE.IdEmpresa = E.IdEmpresa
LEFT JOIN Pasivos P ON CE.TipoCuenta = 'Pasivos' AND CE.IdCuenta = P.IdPasivo
LEFT JOIN Capital C ON C.NombreCuenta = 'Capital Social' AND CE.IdCuenta = C.IdCapital
WHERE E.IdEmpresa = 1
GROUP BY E.IdEmpresa";
            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection conn = new SqlConnection(SqlServerConnection))
                {
                    conn.Open();

                    // Crear el comando SQL con el parámetro de la empresa
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEmpresa", 1); // Reemplaza con el ID de la empresa adecuada

                        // Ejecutar la consulta y leer los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Leer el primer registro
                            if (reader.Read())
                            {
                                // Asignar valores a las variables de pasivo largo plazo y capital social
                                pasivoALargoPlazo = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader.GetDecimal(0)); // Total Pasivo Largo Plazo
                                capitalSocial = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader.GetDecimal(1)); // Total Capital Social
                            }
                        }
                    }
                }

                // Asignar los valores de los pasivos y el capital social a los TextBox
                PasivoALargoPlazotextBox.Text = pasivoALargoPlazo.ToString("F2");
                CapitalSocialTextBox.Text = capitalSocial.ToString("F2");

                // Calcular la razón de pasivo a capital
                Double razonDePasivoACapital = 0;

                if (capitalSocial != 0)
                {
                    razonDePasivoACapital = pasivoALargoPlazo / capitalSocial;
                    RazonDePasivoACapitalTextBox.Text = razonDePasivoACapital.ToString("F2");
                    string conclusion = $"La razón pasivo a capital es de {razonDePasivoACapital:F2}.\n";

                    // Promedio de la industria (ejemplo fijo)
                    string promedioIndustriaText = txtPromedioDeLaIndustria.Text; // Obtener el valor del promedio de la industria
                    double promedioIndustria;

                    // Evaluar la razón de pasivo a capital
                    if (razonDePasivoACapital < 1.0)
                    {
                        conclusion += "La empresa tiene una razón pasivo a capital baja, lo que indica que depende en menor medida de los acreedores para financiar sus operaciones.";
                    }
                    else if (razonDePasivoACapital >= 1.0 && razonDePasivoACapital <= 2.0)
                    {
                        conclusion += "La empresa tiene una razón pasivo a capital moderada, lo que indica que tiene un grado de apalancamiento balanceado.";
                    }
                    else
                    {
                        conclusion += "La empresa tiene una alta razón pasivo a capital, lo que sugiere un grado de apalancamiento elevado y una mayor dependencia de los acreedores para financiar sus operaciones.";
                    }

                    // Comparación con el promedio de la industria


                    if (double.TryParse(promedioIndustriaText, out promedioIndustria))
                    {

                        if (razonDePasivoACapital > promedioIndustria)
                        {
                            conclusion += $"\nLa razón pasivo a capital de la empresa es superior al promedio de la industria ({promedioIndustria * 100}%), lo que indica que la empresa podría estar más apalancada que sus competidores en el sector.";
                        }
                        else if (razonDePasivoACapital < promedioIndustria)
                        {
                            conclusion += $"\nLa razón pasivo a capital de la empresa es inferior al promedio de la industria ({promedioIndustria * 100}%), lo que sugiere que la empresa tiene un apalancamiento financiero más bajo que sus competidores.";
                        }
                        else
                        {
                            conclusion += $"\nLa razón pasivo a capital de la empresa es igual al promedio de la industria ({promedioIndustria * 100}%), lo que indica que la empresa tiene un grado de apalancamiento comparable con el sector.";
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
                    MessageBox.Show("El capital social no puede ser cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.", "Error de Formato");
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error de base de datos: {sqlEx.Message}", "Error de Base de Datos");
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
