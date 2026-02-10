using System;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class DetalleUsuario : Form
    {
        private readonly Usuario _usuario;
        private Controlador controlador;

        public bool HuboCambios { get; private set; } = false;

        public DetalleUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void DetalleUsuario_Load(object sender, EventArgs e)
        {
            if (_usuario == null) return;

            // Obtener controlador desde Gestor
            Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            controlador = gestor?.Controlador;

            // Mostrar datos
            lNombre.Text = _usuario.Nombre;
            lTlf.Text = _usuario.Telefono;
            lDni.Text = _usuario.DNI;

            // Ocultar textboxes
            tbNombre.Visible = false;
            tbTelefono.Visible = false;
            tbDni.Visible = false;

            // Click en labels → activar edición
            lNombre.Click += (s, args) => ActivarEdicion(tbNombre, lNombre.Text);
            lTlf.Click += (s, args) => ActivarEdicion(tbTelefono, lTlf.Text);
            lDni.Click += (s, args) => ActivarEdicion(tbDni, lDni.Text);

            // Enter en textbox → guardar
            tbNombre.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Nombre);
            tbTelefono.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Telefono);
            tbDni.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Dni);

            // Botón Ver Préstamos
            btnVerPrestamos.Click += BtnVerPrestamos_Click;
        }

        private enum Campo
        {
            Nombre,
            Telefono,
            Dni
        }

        private void ActivarEdicion(TextBoxBase tb, string valor)
        {
            tb.Text = valor;
            tb.Visible = true;
            tb.Focus();
            tb.SelectAll();
        }

        private void GuardarConEnter(KeyEventArgs ke, Campo campo)
        {
            if (ke.KeyCode != Keys.Enter) return;

            switch (campo)
            {
                case Campo.Nombre:
                    controlador.ActualizarNombreUsuario(_usuario.ID, tbNombre.Text);
                    _usuario.Nombre = tbNombre.Text;
                    lNombre.Text = tbNombre.Text;
                    tbNombre.Visible = false;
                    break;

                case Campo.Telefono:
                    controlador.ActualizarTelefonoUsuario(_usuario.ID, tbTelefono.Text);
                    _usuario.Telefono = tbTelefono.Text;
                    lTlf.Text = tbTelefono.Text;
                    tbTelefono.Visible = false;
                    break;

                case Campo.Dni:
                    controlador.ActualizarDNIUsuario(_usuario.ID, tbDni.Text);
                    _usuario.DNI = tbDni.Text;
                    lDni.Text = tbDni.Text;
                    tbDni.Visible = false;
                    break;
            }

            HuboCambios = true;
            ke.SuppressKeyPress = true;
        }

        private void BtnVerPrestamos_Click(object sender, EventArgs e)
        {
            // Abrir listado de préstamos filtrado por este usuario
            listadoPrestamos listado = new listadoPrestamos(controlador, _usuario.DNI);

            Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            if (gestor != null)
            {
                gestor.NavegarA(listado); // Se incrusta en MDI sin duplicados
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
