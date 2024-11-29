using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace RazonesFinancieras.Estados_financieros
{
    public partial class Estado_de_resultados : Form
    {
        int idEmpresa = 1;
        public Estado_de_resultados()
        {
            InitializeComponent();
            EnableDoubleBuffering(dgvCuentas);
            int idEmpresa = 1;
            LoadData(idEmpresa);
            dgvCuentas.ForeColor = System.Drawing.Color.Black;
            dgvCuentas.Columns["TipoCuenta"].ReadOnly = true;
            dgvCuentas.Columns["NombreEmpresa"].ReadOnly = true;
            dgvCuentas.Columns["NombreCuenta"].ReadOnly = true;
            dgvCuentas.Columns["Clasificacion"].ReadOnly = true;
            dgvCuentas.Columns["Valor"].ReadOnly = false;
            dgvCuentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;




        }
        string sqlServerConnectionString = ConfigurationManager.ConnectionStrings["connection_S"].ConnectionString;

        private void LoadData(int idEmpresa)
        {
            using (SqlConnection connection = new SqlConnection(sqlServerConnectionString))
            {
                // Llama a la función
                string query = "SELECT * FROM fnCuentasPorEmpresa(@IdEmpresa)";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@IdEmpresa", idEmpresa);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvCuentas.DataSource = dt;
            }
        }


        private void SaveChanges()
        {
            using (SqlConnection connection = new SqlConnection(sqlServerConnectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dgvCuentas.Rows)
                {
                    if (row.IsNewRow) continue; // Ignorar filas nuevas

                    // Extraer datos de la fila
                    string tipoCuenta = row.Cells["TipoCuenta"].Value?.ToString();
                    string nombreCuenta = row.Cells["NombreCuenta"].Value?.ToString();
                    string clasificacion = row.Cells["Clasificacion"].Value?.ToString();
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);

                    // Llama a un procedimiento almacenado para actualizar
                    string procedureName = "spActualizarCuenta"; // Asumimos que existe un procedimiento
                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Añade parámetros para el procedimiento
                        cmd.Parameters.AddWithValue("@TipoCuenta", tipoCuenta);
                        cmd.Parameters.AddWithValue("@NombreCuenta", nombreCuenta);
                        cmd.Parameters.AddWithValue("@Clasificacion", clasificacion);
                        cmd.Parameters.AddWithValue("@Valor", valor);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Los cambios se han guardado correctamente.");
            }
        }

        // Método para limpiar campos
        private void ClearInputFields()
        {
            cbTipoCuenta.SelectedIndex = -1;
            txtNombreCuenta.Clear();
            txtClasificacion.Clear();
            txtValor.Clear();
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void EnviarCambiosButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
            LoadData(idEmpresa); // Recargar los datos después de guardar
        }

        private void ActualizarButton_Click(object sender, EventArgs e)
        {
            LoadData(1);
        }
        private void AddCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlServerConnectionString))
                {
                    connection.Open();

                    // Extraer datos de la interfaz
                    string tipoCuenta = cbTipoCuenta.SelectedItem?.ToString();
                    string nombreCuenta = txtNombreCuenta.Text.Trim();
                    string clasificacion = txtClasificacion.Text.Trim();
                    decimal valor = decimal.Parse(txtValor.Text);
                    idEmpresa = int.Parse(txtEmpId.Text); // ID de la empresa asociada (puedes obtenerlo dinámicamente)

                    // Llama al procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("spAgregarCuenta", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento
                        cmd.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                        cmd.Parameters.AddWithValue("@TipoCuenta", tipoCuenta);
                        cmd.Parameters.AddWithValue("@NombreCuenta", nombreCuenta);
                        cmd.Parameters.AddWithValue("@Clasificacion", clasificacion);
                        cmd.Parameters.AddWithValue("@Valor", valor);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cuenta agregada exitosamente.");
                    ClearInputFields(); // Limpia los campos después de agregar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void DeleteRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCuentas.SelectedRows.Count > 0)
                {
                    // Obtener la fila seleccionada
                    DataGridViewRow selectedRow = dgvCuentas.SelectedRows[0];

                    // Obtener los valores necesarios para eliminar el registro
                    string tipoCuenta = selectedRow.Cells["TipoCuenta"].Value?.ToString();
                    string nombreCuenta = selectedRow.Cells["NombreCuenta"].Value?.ToString();

                    if (!string.IsNullOrEmpty(tipoCuenta) && !string.IsNullOrEmpty(nombreCuenta))
                    {
                        // Confirmar la eliminación
                        DialogResult dialogResult = MessageBox.Show(
                            "¿Estás seguro de que deseas eliminar esta cuenta?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // Eliminar de la base de datos
                            using (SqlConnection connection = new SqlConnection(sqlServerConnectionString))
                            {
                                connection.Open();

                                using (SqlCommand cmd = new SqlCommand("spEliminarCuenta", connection))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@TipoCuenta", tipoCuenta);
                                    cmd.Parameters.AddWithValue("@NombreCuenta", nombreCuenta);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Eliminar de la vista
                            dgvCuentas.Rows.Remove(selectedRow);

                            MessageBox.Show("La cuenta ha sido eliminada exitosamente.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la información de la cuenta seleccionada.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una fila para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar la cuenta: {ex.Message}");
            }
        }
    }
}
