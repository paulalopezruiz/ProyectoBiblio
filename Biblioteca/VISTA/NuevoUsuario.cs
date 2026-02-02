using System;
using System.Windows.Forms;
using System.Data.SQLite;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoUsuario : Form
    {
        private const string BBDD = "BibliotecaBD";   // <-- mismo nombre que en listadoUsuarios

        public Usuario UsuarioCreado { get; private set; }

        public NuevoUsuario()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
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

            if (nombre.Length == 0 || telefono.Length == 0 || dni.Length == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            try
            {
                // INSERT (si DNI es PK, evita duplicados)
                SQLiteCommand cmd = new SQLiteCommand(
                    "INSERT INTO Usuarios (Nombre, Telefono, DNI) VALUES (@nombre, @telefono, @dni);"
                );
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@dni", dni);

                BibliotecaBBDD.Ejecuta(BBDD, cmd);

                UsuarioCreado = new Usuario(nombre, telefono, dni);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Si el DNI ya existe, SQLite suele lanzar error de constraint
                MessageBox.Show(ex.Message, "Error guardando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
