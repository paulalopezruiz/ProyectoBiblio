namespace Biblioteca
{
    partial class Gestor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestor));
            this.NavBar = new System.Windows.Forms.TableLayoutPanel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.bCerrarSesion = new System.Windows.Forms.Button();
            this.tbMenu = new System.Windows.Forms.TableLayoutPanel();
            this.lUsuario = new System.Windows.Forms.Label();
            this.lLibros = new System.Windows.Forms.Label();
            this.lPrestamos = new System.Windows.Forms.Label();
            this.NavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.tbMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavBar
            // 
            this.NavBar.ColumnCount = 3;
            this.NavBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NavBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.NavBar.Controls.Add(this.logo, 0, 0);
            this.NavBar.Controls.Add(this.bCerrarSesion, 2, 0);
            this.NavBar.Controls.Add(this.tbMenu, 1, 0);
            this.NavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavBar.Location = new System.Drawing.Point(0, 0);
            this.NavBar.Name = "NavBar";
            this.NavBar.RowCount = 1;
            this.NavBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavBar.Size = new System.Drawing.Size(975, 100);
            this.NavBar.TabIndex = 0;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(3, 3);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(260, 94);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // bCerrarSesion
            // 
            this.bCerrarSesion.Dock = System.Windows.Forms.DockStyle.Right;
            this.bCerrarSesion.Location = new System.Drawing.Point(767, 20);
            this.bCerrarSesion.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.bCerrarSesion.Name = "bCerrarSesion";
            this.bCerrarSesion.Size = new System.Drawing.Size(188, 60);
            this.bCerrarSesion.TabIndex = 1;
            this.bCerrarSesion.Text = "Cerrar sesion";
            this.bCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // tbMenu
            // 
            this.tbMenu.AutoSize = true;
            this.tbMenu.ColumnCount = 5;
            this.tbMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.140351F));
            this.tbMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.94737F));
            this.tbMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.82456F));
            this.tbMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.94737F));
            this.tbMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.140351F));
            this.tbMenu.Controls.Add(this.lUsuario, 1, 0);
            this.tbMenu.Controls.Add(this.lLibros, 2, 0);
            this.tbMenu.Controls.Add(this.lPrestamos, 3, 0);
            this.tbMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMenu.Location = new System.Drawing.Point(269, 3);
            this.tbMenu.Name = "tbMenu";
            this.tbMenu.RowCount = 1;
            this.tbMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbMenu.Size = new System.Drawing.Size(475, 94);
            this.tbMenu.TabIndex = 2;
            this.tbMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.tbMenu_Paint);
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUsuario.Location = new System.Drawing.Point(32, 0);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(131, 94);
            this.lUsuario.TabIndex = 0;
            this.lUsuario.Text = "Usuarios";
            this.lUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lUsuario.Click += new System.EventHandler(this.lUsuario_Click);
            // 
            // lLibros
            // 
            this.lLibros.AutoSize = true;
            this.lLibros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibros.Location = new System.Drawing.Point(169, 0);
            this.lLibros.Name = "lLibros";
            this.lLibros.Size = new System.Drawing.Size(135, 94);
            this.lLibros.TabIndex = 1;
            this.lLibros.Text = "Libros";
            this.lLibros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPrestamos
            // 
            this.lPrestamos.AutoSize = true;
            this.lPrestamos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPrestamos.Location = new System.Drawing.Point(310, 0);
            this.lPrestamos.Name = "lPrestamos";
            this.lPrestamos.Size = new System.Drawing.Size(131, 94);
            this.lPrestamos.TabIndex = 2;
            this.lPrestamos.Text = "Prestamos";
            this.lPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lPrestamos.Click += new System.EventHandler(this.lPrestamos_Click_1);
            // 
            // Gestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 569);
            this.Controls.Add(this.NavBar);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(989, 602);
            this.Name = "Gestor";
            this.Text = "Gestor";
            this.Load += new System.EventHandler(this.Gestor_Load);
            this.NavBar.ResumeLayout(false);
            this.NavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.tbMenu.ResumeLayout(false);
            this.tbMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel NavBar;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button bCerrarSesion;
        private System.Windows.Forms.TableLayoutPanel tbMenu;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.Label lLibros;
        private System.Windows.Forms.Label lPrestamos;
    }
}

