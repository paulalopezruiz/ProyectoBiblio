using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class NuevoPrestamo : Form
    {
        public NuevoPrestamo()
        {
            InitializeComponent();

            Load += NuevoPrestamo_Load;
            btnGuardar.Click += btnGuardar_Click;

            cmbLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void NuevoPrestamo_Load(object sender, EventArgs e)
        {


            var libros = new List<Libro>
            {
                new Libro(1, "Libro 1"),
                new Libro(2, "Libro 2"),
            };

            var usuarios = new List<Usuario>
            {
                new Usuario("Paula", "600111222", "12345678A"),
                new Usuario("Iker",  "600333444", "87654321B"),
            };

            o
            cmbLibro.DataSource = libros;
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "IdLibro";

            // Usuarios: mostrar "Nombre - DNI" usando ToString()
            cmbUsuario.DataSource = usuarios;
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbLibro.SelectedItem == null || cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un libro y un usuario.");
                return;
            }

            int idLibro = (int)cmbLibro.SelectedValue;

            Usuario u = (Usuario)cmbUsuario.SelectedItem;
            string dniUsuario = u.DNI;

            // Fecha: no editable
            DateTime fechaInicio = DateTime.Today;



            Prestamo p = new Prestamo(idLibro, dniUsuario, fechaInicio);

            MessageBox.Show($"Préstamo creado:\nLibro={p.IdLibro}\nUsuario={p.DNIUsuario}\nFecha={p.FechaInicio:dd/MM/yyyy}");
            Close();
        }
    }
}
