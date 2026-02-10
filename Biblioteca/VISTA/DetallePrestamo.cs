using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

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


        private void DetallePrestamo_Load(object sender, EventArgs e)
        {
            string nombreLibro = BibliotecaBBDD.GetTituloLibro(_prestamo.ID_Libro);
            string nombreUsuario = BibliotecaBBDD.GetNombreUsuario(_prestamo.ID_Usuario);

            lblUsuarioValor.Text = nombreUsuario;
            lblLibroValor.Text = nombreLibro;
            lblFechaInicioValor.Text = _prestamo.Fecha_Inicio.ToShortDateString();

            ConfigurarEstado();
        }


        // CONFIGURAR SEGÚN ESTADO
    
        private void ConfigurarEstado()
        {
            if (_prestamo.Devuelto)
            {
                // Caso: Prestamo devuelto
                lblFechaFinTitulo.Visible = true;
                lblFechaFinValor.Visible = true;
                lblFechaFinTitulo.Text = "Fecha fin:";
                lblFechaFinValor.Text = _prestamo.Fecha_Fin?.ToShortDateString();
                lblFechaFinValor.BackColor = SystemColors.Control;
                lblFechaFinValor.ForeColor = Color.Black;

                // Ocultar fecha límite y botón
                lblFechaLimite.Visible = false;
                btnDevolver.Visible = false;
            }
            else
            {

                // Caso: Prestamo NO devuelto

                // Ocultar fecha fin
                lblFechaFinTitulo.Visible = false;
                lblFechaFinValor.Visible = false;

                // Mostrar fecha límite en un único Label
                lblFechaLimite.Visible = true;
                lblFechaLimite.Text = "FECHA LÍMITE: " + _prestamo.Fecha_Fin?.ToShortDateString();

                bool vencido = _prestamo.Fecha_Fin < DateTime.Today;

                lblFechaLimite.BackColor = vencido ? Color.IndianRed : Color.Orange;
                lblFechaLimite.ForeColor = Color.Black;

                // Mostrar botón de devolución
                btnDevolver.Visible = true;
            }
        }

 
        // DEVOLVER PRÉSTAMO
  
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (_prestamo.Devuelto) return; 

            bool vencido = _prestamo.Fecha_Fin < DateTime.Today;

           
            SQLiteCommand cmd = new SQLiteCommand(@"
                UPDATE Prestamos
                SET Devuelto = 1
                WHERE ID = @id;
            ");
            cmd.Parameters.AddWithValue("@id", _prestamo.ID);
            BibliotecaBBDD.Ejecuta(cmd);

          
            _prestamo.Devuelto = true;

            // Mensaje de devolución
            string mensaje = vencido
                ? "⚠️ Libro devuelto fuera de plazo. Se aplicará penalización."
                : "Libro devuelto correctamente.";

            MessageBox.Show(
                mensaje,
                "Devolución",
                MessageBoxButtons.OK,
                vencido ? MessageBoxIcon.Warning : MessageBoxIcon.Information
            );

            // Cerrar formulario y actualizar tarjeta si es necesario
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
