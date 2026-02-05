using System;
using System.Drawing;
using System.Data.SQLite;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class DetallePrestamo : Form
    {
        private Prestamo _prestamo;

        public DetallePrestamo(Prestamo prestamo)
        {
            InitializeComponent();
            _prestamo = prestamo;

            Load += DetallePrestamo_Load;
            btnDevolver.Click += btnDevolver_Click;
        }

        // =========================
        // LOAD
        // =========================
        private void DetallePrestamo_Load(object sender, EventArgs e)
        {
            lblLibro.Text = _prestamo.Libro;
            lblUsuario.Text = _prestamo.Usuario;
            lblFechaInicio.Text = _prestamo.Fecha_Inicio.ToShortDateString();

            ConfigurarEstado();
        }

        // =========================
        // CONFIGURAR SEGÚN ESTADO
        // =========================
        private void ConfigurarEstado()
        {
            if (_prestamo.Devuelto)
            {
                // DEVUELTO
                lblFechaFinTitulo.Text = "Fecha fin:";
                lblFechaFinValor.Text = _prestamo.Fecha_Fin?.ToShortDateString();
                lblFechaFinValor.BackColor = SystemColors.Control;

                btnDevolver.Visible = false;
            }
            else
            {
                // NO DEVUELTO
                lblFechaFinTitulo.Text = "Fecha límite:";
                lblFechaFinValor.Text = _prestamo.Fecha_Fin?.ToShortDateString();

                bool vencido = _prestamo.Fecha_Fin < DateTime.Today;

                lblFechaFinValor.BackColor = vencido
                    ? Color.IndianRed
                    : Color.Orange;

                lblFechaFinValor.ForeColor = Color.White;
                btnDevolver.Visible = true;
            }
        }

        // =========================
        // DEVOLVER PRÉSTAMO
        // =========================
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            bool vencido = _prestamo.Fecha_Fin < DateTime.Today;

            SQLiteCommand cmd = new SQLiteCommand(@"
                UPDATE Prestamos
                SET Devuelto = 1
                WHERE ID = @id;
            ");

            cmd.Parameters.AddWithValue("@id", _prestamo.ID);

            BibliotecaBBDD.Ejecuta(cmd);

            string mensaje = vencido
                ? "⚠️ Libro devuelto fuera de plazo."
                : "Libro devuelto correctamente.";

            MessageBox.Show(
                mensaje,
                "Devolución",
                MessageBoxButtons.OK,
                vencido ? MessageBoxIcon.Warning : MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}