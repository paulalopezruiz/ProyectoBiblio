using System;
using System.Data;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoPrestamo : Form
    {
        private readonly Controlador controlador;

        public NuevoPrestamo(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            Load += NuevoPrestamo_Load;
            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            btnGuardar.Click += btnGuardar_Click;  
        }

        private void NuevoPrestamo_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaInicio.MinDate = DateTime.Today;
            dtpFechaInicio.Format = DateTimePickerFormat.Short;

            CargarLibros();
            CargarUsuarios();
        }

        private void CargarLibros()
        {
            var dt = controlador.GetDataTable(new System.Data.SQLite.SQLiteCommand(
                "SELECT ID, Titulo FROM Libros ORDER BY Titulo;"
            ));
            cmbLibro.DataSource = dt;
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "ID";
        }

        private void CargarUsuarios()
        {
            var dt = controlador.GetDataTable(new System.Data.SQLite.SQLiteCommand(
                "SELECT ID, Nombre FROM Usuarios ORDER BY Nombre;"
            ));
            cmbUsuario.DataSource = dt;
            cmbUsuario.DisplayMember = "Nombre";
            cmbUsuario.ValueMember = "ID";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedIndex == -1 || cmbUsuario.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar un libro y un usuario.");
                return;
            }

            btnGuardar.Enabled = false;

            int idLibro = Convert.ToInt32(cmbLibro.SelectedValue);
            int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = fechaInicio.AddDays(15);

            try
            {
                // Usa la comprobación de ejemplares disponibles en el controlador
                controlador.InsertarPrestamo(idLibro, idUsuario, fechaInicio, fechaFin);

                MessageBox.Show(
                    "Préstamo registrado correctamente.\n📅 Plazo de 15 días.",
                    "Éxito",
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

    }
}
