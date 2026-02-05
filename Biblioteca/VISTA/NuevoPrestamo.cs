using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoPrestamo : Form
    {
        public NuevoPrestamo()
        {
            InitializeComponent();

            Load += NuevoPrestamo_Load;

            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // =========================
        // LOAD
        // =========================
        private void NuevoPrestamo_Load(object sender, EventArgs e)
        {
            ConfigurarFecha();
            CargarLibros();
            CargarUsuarios();
        }

        // =========================
        // FECHA
        // =========================
        private void ConfigurarFecha()
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaInicio.MinDate = DateTime.Today; // ❌ no fechas anteriores
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
        }

        // =========================
        // CARGAR LIBROS
        // =========================
        private void CargarLibros()
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT ID, Titulo FROM Libros ORDER BY Titulo;"
            );

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            cmbLibro.DataSource = dt;
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "ID";
        }

        // =========================
        // CARGAR USUARIOS
        // =========================
        private void CargarUsuarios()
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT ID, Nombre FROM Usuarios ORDER BY Nombre;"
            );

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            cmbUsuario.DataSource = dt;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }

        // =========================
        // GUARDAR
        // =========================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedIndex == -1 || cmbUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un libro y un usuario.");
                return;
            }

            btnGuardar.Enabled = false; // 🛑 evita doble click

            int idLibro = Convert.ToInt32(cmbLibro.SelectedValue);
            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);

            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = fechaInicio.AddDays(15);

            SQLiteCommand cmd = new SQLiteCommand(@"
                INSERT INTO Prestamos (ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin)
                VALUES (@libro, @usuario, @inicio, @fin);
            ");

            cmd.Parameters.AddWithValue("@libro", idLibro);
            cmd.Parameters.AddWithValue("@usuario", idUsuario);
            cmd.Parameters.AddWithValue("@inicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fin", fechaFin);

            try
            {
                BibliotecaBBDD.Ejecuta(cmd);

                MessageBox.Show(
                    "Préstamo registrado correctamente.\n\n" +
                    "📅 Recuerda que tienes un plazo de 15 días para devolver el libro.",
                    "Préstamo correcto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                btnGuardar.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoPrestamo_Load_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


