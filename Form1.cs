using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace ABM_Productos
{
    public partial class Form1 : Form
    {
        private string SQLString = "Data Source=DESKTOP-UJR9NPC\\SQLEXPRESS;Initial Catalog=Empresa_TP;Integrated Security=False;packet size=4096;UID=Fran;PWD=admin"; // Añadir usuario, deja de usar SA

        public Form1()
        {
            InitializeComponent();
        }

        private bool ValidarIngresos()
        {
            if (!Funciones.ValidezTextBox(txtCode, "El CÓDIGO no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(txtDescription, "La DESCRIPCIÓN no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezTextBox(txtPriceUnit, "El PRECIO UNITARIO no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezComboBox(cbxRubro, "El RUBRO no puede ser <NULO>"))
                return false;

            if (!Funciones.ValidezComboBox(cbxUndMedida, "La UNIDAD DE MEDIDA no puede ser <NULO>"))
                return false;

            return true;
        }

        private void CargarRubroBox()
        {
            try
            {
                string query = "SELECT * FROM dbo.RUBROS";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        using (var reader = LocalCMD.ExecuteReader())
                        {
                            // Llenar un datatable y usarlo para rellenar el combobox
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            cbxRubro.DataSource = dt;

                            // Configuro el display del combobox
                            cbxRubro.DisplayMember = "DESCRIPCION"; // Muestro la descripcion
                            cbxRubro.ValueMember = "ID"; // Uso el ID como valor

                            cbxRubro.SelectedIndex = -1; // Esto es para no seleccionar nada por default
                        }
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar RUBROS: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUnidadMedidaBox()
        {
            try
            {
                string query = "SELECT * FROM dbo.UND_MEDIDA";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        using (var reader = LocalCMD.ExecuteReader())
                        {
                            {
                                // Llenar un datatable y usarlo para rellenar el combobox
                                DataTable dt = new DataTable();
                                dt.Load(reader);

                                cbxUndMedida.DataSource = dt;

                                // Configuro el display del combobox
                                cbxUndMedida.DisplayMember = "DESCRIPCION"; // Muestro la descripcion
                                cbxUndMedida.ValueMember = "CODIGO"; // Uso el CODIGO como valor

                                cbxUndMedida.SelectedIndex = -1; // Esto es para no seleccionar nada por default
                            }
                        }
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar UNIDADES DE MEDIDA: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarRubroBox();
            CargarUnidadMedidaBox();

            string query = "SELECT * FROM dbo.PRODUCTOS";

            try
            {
                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        dataGridView1.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los Clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool MostrarMensajeConfirmacion(string mensaje)
        {
            DialogResult resultado = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (resultado == DialogResult.Yes);
        }

        // Botón de borrado
        private void button2_Click(object sender, EventArgs e)
        {
            // Validar si hay un CÓDIGO
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Debe ingresar un Código.");
                return;
            }

            // Validar el tipo de dato
            if (!Funciones.EsNúmeroValido(txtCode.Text))
            {
                MessageBox.Show("El Código debe ser un número.");
                return;
            }

            // Mostrar mensaje de confirmación
            if (!MostrarMensajeConfirmacion("¿Está seguro de realizar la operación?"))
            {
                return;
            }

            // Ejecutar el comando correspondiente
            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand("UPDATE dbo.PRODUCTOS SET FECHA_BAJA = @FECHA_BAJA WHERE CODIGO = @CODIGO", LocalCNX))
                {
                    // Agregar parámetros
                    LocalCMD.Parameters.AddWithValue("@CODIGO", int.Parse(txtCode.Text));
                    LocalCMD.Parameters.AddWithValue("@FECHA_BAJA", DateTime.Now); // Fecha actual

                    try
                    {
                        MessageBox.Show("Se eliminó el registro correctamente <Filas Afectadas>: " + LocalCMD.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar eliminar el registro: " + ex.Message);
                    }
                }

                LocalCNX.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                // Obtengo los valores de las celdas de la fila donde se hizo doble clic
                string codigo = fila.Cells["CODIGO"].Value.ToString();
                string descripcion = fila.Cells["DESCRIPCION"].Value.ToString();
                string stock = fila.Cells["STOCK"].Value.ToString();
                string precio_unitario = fila.Cells["PRECIO_UNITARIO"].Value.ToString();
                string precio_mayorista = fila.Cells["PRECIO_MAYORISTA"].Value.ToString();
                string precio_distribuidor = fila.Cells["PRECIO_DISTRIBUIDOR"].Value.ToString();
                string id_rubro = fila.Cells["ID_RUBRO"].Value.ToString();
                string id_medida = fila.Cells["ID_MEDIDA"].Value.ToString();
                var fecha_baja = fila.Cells["FECHA_BAJA"].Value;

                // Asigno los valores a los campos correspondientes
                txtCode.Text = codigo;
                txtDescription.Text = descripcion;
                txtUnits.Text = stock;
                txtPriceUnit.Text = precio_unitario;
                txtPriceMay.Text = precio_mayorista;
                txtPriceDist.Text = precio_distribuidor;
                cbxRubro.SelectedValue = id_rubro; // Suponiendo que cbxRubro tiene los valores correspondientes
                cbxUndMedida.SelectedValue = id_medida; // Suponiendo que cbxUndMedida tiene los valores correspondientes

                // Verifico y asigno fecha de baja
                if (fecha_baja != DBNull.Value)
                {
                    lblFechaBaja.Text = "Fecha de baja: " + Convert.ToDateTime(fecha_baja).ToString("dd/MM/yyyy");
                    lblFechaBaja.Visible = true;
                }
                else
                {
                    lblFechaBaja.Text = string.Empty;
                    lblFechaBaja.Visible = false;
                }
            }
        }


        private void CargarDatosEnLaGrilla(string criterio)
        {
            try
            {
                string query = "SELECT * FROM dbo.PRODUCTOS WHERE CAST(CODIGO AS VARCHAR) LIKE @Criterio OR DESCRIPCION LIKE @Criterio";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        LocalCMD.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        dataGridView1.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtCode.Clear();
            txtDescription.Clear();
            txtUnits.Text = "";
            txtPriceUnit.Clear();
            txtPriceMay.Clear();
            txtPriceDist.Clear();
            cbxRubro.SelectedItem = null;
            cbxUndMedida.SelectedItem = null;

            try
            {
                string query = "SELECT * FROM dbo.PRODUCTOS";

                using (var LocalCNX = new SqlConnection(SQLString))
                {
                    LocalCNX.Open();

                    using (var LocalCMD = new SqlCommand(query, LocalCNX))
                    {
                        var LocalDA = new SqlDataAdapter(LocalCMD);
                        var LocalDT = new DataTable();
                        LocalDA.Fill(LocalDT);
                        dataGridView1.DataSource = LocalDT;
                    }

                    LocalCNX.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos en la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                CargarDatosEnLaGrilla(txtCode.Text);
            }
            else if (string.IsNullOrEmpty(txtCode.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                LimpiarCampos();
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDescription.Text))
            {
                CargarDatosEnLaGrilla(txtDescription.Text);
            }
            else if (string.IsNullOrEmpty(txtCode.Text) && string.IsNullOrEmpty(txtDescription.Text))
            {
                LimpiarCampos();
            }
        }

        private int ExisteClave(int COD)
        {
            // Conectar a la BD
            var LocalCNX = new SqlConnection(SQLString);
            LocalCNX.Open();

            var LocalCMD = new SqlCommand("SELECT COUNT(*) FROM dbo.PRODUCTOS WHERE CODIGO = " + COD.ToString(), LocalCNX);

            var LocalDA = new SqlDataAdapter(LocalCMD);

            var LocalDT = new DataTable();

            LocalDA.Fill(LocalDT);

            return int.Parse(LocalDT.Rows[0][0].ToString()); // Convierte el resultado a entero
            // LocalDT.Rows[0] accede a la primera Fila y el segundo [0] a la columna
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            if (!ValidarIngresos())
            {
                return;
            }

            // Convertir los textos a mayúsculas
            txtCode.Text = txtCode.Text.ToUpper();
            txtDescription.Text = txtDescription.Text.ToUpper();

            // Mostrar mensaje de confirmación antes de guardar
            if (!MostrarMensajeConfirmacion("¿Está seguro de realizar la operación?"))
            {
                return;
            }
            string operacion;

            // Valido si existe el PRODUCTO
            if (ExisteClave(int.Parse(txtCode.Text)) == 0)
            {
                operacion = "INSERT INTO dbo.PRODUCTOS (CODIGO, DESCRIPCION, STOCK, PRECIO_UNITARIO, PRECIO_MAYORISTA, PRECIO_DISTRIBUIDOR, FECHA_BAJA, ID_RUBRO, ID_MEDIDA) VALUES (@CODIGO, @DESCRIPCION, @STOCK, @PRECIO_UNITARIO, @PRECIO_MAYORISTA, @PRECIO_DISTRIBUIDOR, @FECHA_BAJA, @ID_RUBRO, @ID_MEDIDA)";
            }
            else
            {
                operacion = "UPDATE dbo.PRODUCTOS SET DESCRIPCION = @DESCRIPCION, STOCK = @STOCK, PRECIO_UNITARIO = @PRECIO_UNITARIO, PRECIO_MAYORISTA = @PRECIO_MAYORISTA, PRECIO_DISTRIBUIDOR = @PRECIO_DISTRIBUIDOR, FECHA_BAJA = @FECHA_BAJA, ID_RUBRO = @ID_RUBRO, ID_MEDIDA = @ID_MEDIDA WHERE CODIGO = @CODIGO";
            }

            // Ejecuto el comando correspondiente
            using (var LocalCNX = new SqlConnection(SQLString))
            {
                LocalCNX.Open();

                using (var LocalCMD = new SqlCommand(operacion, LocalCNX))
                {
                    // Agregar parámetros
                    LocalCMD.Parameters.AddWithValue("@CODIGO", int.Parse(txtCode.Text));
                    LocalCMD.Parameters.AddWithValue("@DESCRIPCION", txtDescription.Text);
                    LocalCMD.Parameters.AddWithValue("@STOCK", int.Parse(txtUnits.Text));
                    LocalCMD.Parameters.AddWithValue("@PRECIO_UNITARIO", decimal.Parse(txtPriceUnit.Text));
                    LocalCMD.Parameters.AddWithValue("@PRECIO_MAYORISTA", decimal.Parse(txtPriceMay.Text));
                    LocalCMD.Parameters.AddWithValue("@PRECIO_DISTRIBUIDOR", decimal.Parse(txtPriceDist.Text));
                    LocalCMD.Parameters.AddWithValue("@FECHA_BAJA", DBNull.Value); // La DB ya lo marca por defecto como null, pero esto es asegurar
                    LocalCMD.Parameters.AddWithValue("@ID_RUBRO", cbxRubro.SelectedValue); // Suponiendo que estás usando un ComboBox con valores.
                    LocalCMD.Parameters.AddWithValue("@ID_MEDIDA", cbxUndMedida.SelectedValue); // Suponiendo que estás usando un ComboBox con valores.

                    try
                    {
                        MessageBox.Show("Operación realizada con exito <Filas afectadas>: " + LocalCMD.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                LocalCNX.Close();
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
