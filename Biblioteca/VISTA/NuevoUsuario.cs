using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoUsuario : Form
    {
        private readonly Controlador controlador;

        public Usuario UsuarioCreado { get; private set; }

        // --- ESCALADO ---
        private bool mostrado = false;
        private const float FONT_SIZE = 9.0f;

        public NuevoUsuario(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador ?? throw new ArgumentNullException(nameof(controlador));

            btnGuardar.Click += btnGuardar_Click;

            // Escalado
            this.Activated += NuevoUsuario_Activated;
            this.Resize += NuevoUsuario_Resize;

            // ✅ Dejar margen fijo para que no se recorte el texto del botón
            // (tu diseñador tenía 100,3,100,3 y a veces se come el ancho)
            btnGuardar.Margin = new Padding(60, 3, 60, 3);
        }

        private void NuevoUsuario_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
        }

        private void NuevoUsuario_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            AplicarEscalado();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            if (proporcionAlto > 3f) proporcionAlto = 3f;

            // ✅ Solo fuentes (lo más estable en estos forms pequeños)
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

        public void CargarDatos()
        {
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbDNI.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string dni = tbDNI.Text.Trim();

            try
            {
                controlador.InsertarUsuario(nombre, telefono, dni);

                UsuarioCreado = new Usuario(nombre, telefono, dni);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error guardando usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
