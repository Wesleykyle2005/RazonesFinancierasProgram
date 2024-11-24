using Microsoft.Data.SqlClient;
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
using RazonesFinancieras.Models;

namespace RazonesFinancieras.Estados_financieros
{
    public partial class Estado_de_resultados : Form
    {
        public Estado_de_resultados()
        {
            InitializeComponent();
        }

        private void Estado_de_resultados_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }



        string sqlServerConnectionString = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;
        public IEnumerable<Venta> GetAll()
        {
            var ventas = new List<Venta>(); // Usamos var para simplificar

            try
            {
                using (var connection = new SqlConnection(sqlServerConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT * FROM Ventas", connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Validamos columnas para evitar errores con valores nulos.
                            var venta = new Venta
                            {
                                NombreCuenta = reader["NombreCuenta"]?.ToString() ?? "Sin nombre", // Valor por defecto si es nulo
                                Clasificacion = reader["Clasificacion"]?.ToString() ?? "Sin clasificacion", // Valor por defecto si es nulo
                                Valor = reader["Valor"] != DBNull.Value
                                    ? Convert.ToDecimal(reader["Valor"])
                                    : 0m // Valor por defecto si es nulo
                            };
                            ventas.Add(venta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra el error en consola o MessageBox según el contexto
                Console.WriteLine($"Error al obtener las ventas: {ex.Message}");
                MessageBox.Show($"Error al obtener las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ventas;
        }


        private void LoadDataToDataGridView()
        {
            try
            {
                var ventas = GetAll();
                
                dgvER.DataSource = ventas.ToList();
                dgvER.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvER.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvER.Dock= DockStyle.Bottom;
                dgvER.ForeColor= Color.Black;
                int Hdgv = (int)(MdiParent.Height / 1.4); 
                dgvER.Height = Hdgv;
                dgvER.Columns["Valor"].DefaultCellStyle.Format = "C2";


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos en el DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }
    }
}
