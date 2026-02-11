using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoPrestamo : Form
    {
        private readonly Controlador controlador;

        // --- ESCALADO ---
        private bool mostrado = false;
        private const float FONT_SIZE = 8.0f;

        public NuevoPrestamo(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            // Si el Load ya está enlazado en el diseñador, NO lo dupliques aquí
            // Load += NuevoPrestamo_Load;

            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            btnGuardar.Click += btnGuardar_Click;

            this.Activated += NuevoPrestamo_Activated;
            this.Resize += NuevoPrestamo_Resize;

            // ✅ Dejar el margen del botón fijo (para que no se corte)
            // Puedes ajustar estos valores si quieres más/menos separación
            btnGuardar.Margin = new Padding(60, 3, 60, 3);
        }

        private void NuevoPrestamo_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
        }

        private void NuevoPrestamo_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            AplicarEscalado();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            if (proporcionAlto > 3f) proporcionAlto = 3f;

            // ✅ Solo escalamos fuentes (como en tus ejemplos)
            cambiarFuentes(tlpPrincipal, proporcionAlto);

            tlpPrincipal.PerformLayout();
        }

        private void cambiarFuentes(Control c, float proporcionAlto)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * proporcionAlto,
                    control.Font.Style
                );

                cambiarFuentes(control, proporcionAlto);
            }
        }

        // Este Load debería estar enlazado desde el diseñador:
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
