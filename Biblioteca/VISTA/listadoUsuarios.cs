using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.IO; // <-- AÑADIR ESTO
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        private const string BBDD = "BibliotecaBD";   // nombre de tu connectionString

        public listadoUsuarios()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            // --- DIAGNÓSTICO (temporal) ---
            DebugBaseDeDatos(); // <-- AÑADIR ESTO AQUÍ

            // --- CARGA NORMAL ---
            CargarTarjetas(ObtenerUsuarios());
        }

        // ========= DIAGNÓSTICO =========
        private void DebugBaseDeDatos()
        {
            try
            {
                using (var con = BibliotecaBBDD.Conectar(BBDD))
                {
                    // 1) Ruta REAL del archivo que se está abriendo
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

                    // 2) Tablas existentes en ESA base
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
        // ===============================

        // ---------- BBDD: SELECT ----------
        private List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT Nombre, Telefono, DNI FROM Usuarios ORDER BY Nombre;"
            );

            DataTable dt = BibliotecaBBDD.GetDataTable(BBDD, cmd);

            foreach (DataRow row in dt.Rows)
            {
                string nombre = row["Nombre"].ToString();
                string telefono = row["Telefono"].ToString();
                string dni = row["DNI"].ToString();

                usuarios.Add(new Usuario(nombre, telefono, dni));
            }

            return usuarios;
        }

        // ---------- UI: pintar tarjetas ----------
        private void CargarTarjetas(List<Usuario> usuarios)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var u in usuarios)
            {
                TarjetaUsuario tarjeta = new TarjetaUsuario();

                tarjeta.Usuario = u;
                tarjeta.Width = flowLayoutPanel1.ClientSize.Width - 20;

                // escuchar evento borrar
                tarjeta.UsuarioBorrado += Tarjeta_UsuarioBorrado;

                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }

        // ---------- BBDD: DELETE ----------
        private void Tarjeta_UsuarioBorrado(object sender, Usuario usuario)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(
                    "DELETE FROM Usuarios WHERE DNI = @dni;"
                );
                cmd.Parameters.AddWithValue("@dni", usuario.DNI);

                BibliotecaBBDD.Ejecuta(BBDD, cmd);

                // recargar desde BBDD
                CargarTarjetas(ObtenerUsuarios());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error borrando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Nuevo Usuario ----------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario frm = new NuevoUsuario();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // ya se insertó en BBDD dentro de NuevoUsuario
                CargarTarjetas(ObtenerUsuarios());
            }
        }

        // ---------- Buscador por nombre ----------
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
                    "SELECT Nombre, Telefono, DNI FROM Usuarios WHERE Nombre LIKE @patron ORDER BY Nombre;"
                );
                cmd.Parameters.AddWithValue("@patron", texto + "%");

                DataTable dt = BibliotecaBBDD.GetDataTable(BBDD, cmd);

                List<Usuario> filtrados = new List<Usuario>();
                foreach (DataRow row in dt.Rows)
                {
                    filtrados.Add(new Usuario(
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
