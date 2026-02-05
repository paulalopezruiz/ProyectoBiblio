using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        public listadoUsuarios()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            // --- DIAGNÓSTICO (temporal) ---
            //DebugBaseDeDatos();

            // --- CARGA NORMAL ---
            CargarTarjetas(ObtenerUsuarios());
        }

        // =========================================
        // Diagnóstico: ver si la BD existe y tablas
        // =========================================
        private void DebugBaseDeDatos()
        {
            try
            {
                using (var con = BibliotecaBBDD.Conectar())
                {
                    using (var cmd = new SQLiteCommand("PRAGMA database_list;", con))
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            string file = rd["file"]?.ToString() ?? "(null)";
                            MessageBox.Show("DB FILE:\n" + file +
                                            "\n\nEXISTE?: " + (File.Exists(file) ? "SI" : "NO"));
                        }
                    }

                    using (var cmd2 = new SQLiteCommand(
                        "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;", con))
                    using (var rd2 = cmd2.ExecuteReader())
                    {
                        string tablas = "";
                        while (rd2.Read()) tablas += rd2["name"].ToString() + "\n";

                        if (string.IsNullOrWhiteSpace(tablas))
                            tablas = "(NO HAY TABLAS)";

                        MessageBox.Show("TABLAS EN LA BD:\n" + tablas);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DebugBaseDeDatos:\n" + ex.Message);
            }
        }

        // =========================================
        // Obtener usuarios
        // =========================================
        private List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT ID, Nombre, Telefono, DNI FROM Usuarios ORDER BY Nombre;"
            );

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                string id = row["ID"].ToString();
                string nombre = row["Nombre"].ToString();
                string telefono = row["Telefono"].ToString();
                string dni = row["DNI"].ToString();

                usuarios.Add(new Usuario(id, nombre, telefono, dni));
            }

            return usuarios;
        }

        // =========================================
        // Pintar tarjetas
        // =========================================
        private void CargarTarjetas(List<Usuario> usuarios)
        {
            // Desuscribir y liberar tarjetas viejas
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is TarjetaUsuario tu)
                {
                    tu.UsuarioBorrado -= Tarjeta_UsuarioBorrado;
                    tu.Dispose();
                }
            }
            flowLayoutPanel1.Controls.Clear();

            // Crear nuevas tarjetas y suscribir evento
            foreach (var u in usuarios)
            {
                TarjetaUsuario tarjeta = new TarjetaUsuario
                {
                    Usuario = u,
                    Width = flowLayoutPanel1.ClientSize.Width - 20
                };

                tarjeta.UsuarioBorrado += Tarjeta_UsuarioBorrado; // SUSCRIBIMOS AQUÍ
                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }

        // =========================================
        // Evento al pulsar BORRAR en la tarjeta
        // =========================================
        private void Tarjeta_UsuarioBorrado(object sender, Usuario usuario)
        {
            if (usuario == null) return;

            // Preguntar al usuario antes de borrar
            var resp = MessageBox.Show(
                $"¿Estás seguro de que quieres borrar a {usuario.Nombre} permanentemente?",
                "Confirmar borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resp != DialogResult.Yes) return;

            try
            {
                // Borra de la base de datos
                SQLiteCommand cmd = new SQLiteCommand(
                    "DELETE FROM Usuarios WHERE DNI = @dni;"
                );
                cmd.Parameters.AddWithValue("@dni", usuario.DNI);
                BibliotecaBBDD.Ejecuta(cmd);

                // Recargar tarjetas
                CargarTarjetas(ObtenerUsuarios());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error borrando usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================
        // Nuevo usuario
        // =========================================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario frm = new NuevoUsuario();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarTarjetas(ObtenerUsuarios());
            }
        }

        // =========================================
        // Buscador por nombre
        // =========================================
        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            string texto = tbNombre.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                CargarTarjetas(ObtenerUsuarios());
                return;
            }

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT ID, Nombre, Telefono, DNI FROM Usuarios WHERE Nombre LIKE @patron ORDER BY Nombre;"
                );
                cmd.Parameters.AddWithValue("@patron", texto + "%");

                DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

                List<Usuario> filtrados = new List<Usuario>();
                foreach (DataRow row in dt.Rows)
                {
                    filtrados.Add(new Usuario(
                        row["ID"].ToString(),
                        row["Nombre"].ToString(),
                        row["Telefono"].ToString(),
                        row["DNI"].ToString()
                    ));
                }

                CargarTarjetas(filtrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error buscando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
