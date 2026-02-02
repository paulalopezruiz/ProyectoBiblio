namespace Biblioteca.VISTA
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tlpHome = new System.Windows.Forms.TableLayoutPanel();
            this.pPrest = new System.Windows.Forms.Panel();
            this.tlpPrest = new System.Windows.Forms.TableLayoutPanel();
            this.lPrestamos = new System.Windows.Forms.Label();
            this.PrestIcon = new System.Windows.Forms.PictureBox();
            this.pLibros = new System.Windows.Forms.Panel();
            this.tlpLibros = new System.Windows.Forms.TableLayoutPanel();
            this.lLibros = new System.Windows.Forms.Label();
            this.bookIcon = new System.Windows.Forms.PictureBox();
            this.pUser = new System.Windows.Forms.Panel();
            this.tlpUser = new System.Windows.Forms.TableLayoutPanel();
            this.lUSer = new System.Windows.Forms.Label();
            this.userIcon = new System.Windows.Forms.PictureBox();
            this.tlpHome.SuspendLayout();
            this.pPrest.SuspendLayout();
            this.tlpPrest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrestIcon)).BeginInit();
            this.pLibros.SuspendLayout();
            this.tlpLibros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookIcon)).BeginInit();
            this.pUser.SuspendLayout();
            this.tlpUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpHome
            // 
            this.tlpHome.BackColor = System.Drawing.Color.Transparent;
            this.tlpHome.ColumnCount = 3;
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHome.Controls.Add(this.pPrest, 2, 1);
            this.tlpHome.Controls.Add(this.pLibros, 1, 1);
            this.tlpHome.Controls.Add(this.pUser, 0, 1);
            this.tlpHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHome.Location = new System.Drawing.Point(0, 0);
            this.tlpHome.Name = "tlpHome";
            this.tlpHome.RowCount = 3;
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpHome.Size = new System.Drawing.Size(800, 450);
            this.tlpHome.TabIndex = 0;
            this.tlpHome.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpHome_Paint);
            // 
            // pPrest
            // 
            this.pPrest.BackColor = System.Drawing.Color.White;
            this.pPrest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPrest.Controls.Add(this.tlpPrest);
            this.pPrest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrest.Location = new System.Drawing.Point(562, 135);
            this.pPrest.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pPrest.Name = "pPrest";
            this.pPrest.Padding = new System.Windows.Forms.Padding(10);
            this.pPrest.Size = new System.Drawing.Size(208, 180);
            this.pPrest.TabIndex = 2;
            this.pPrest.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTarjeta_Paint);
            // 
            // tlpPrest
            // 
            this.tlpPrest.ColumnCount = 1;
            this.tlpPrest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrest.Controls.Add(this.lPrestamos, 0, 2);
            this.tlpPrest.Controls.Add(this.PrestIcon, 0, 1);
            this.tlpPrest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrest.Location = new System.Drawing.Point(10, 10);
            this.tlpPrest.Name = "tlpPrest";
            this.tlpPrest.RowCount = 4;
            this.tlpPrest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrest.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrest.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrest.Size = new System.Drawing.Size(186, 158);
            this.tlpPrest.TabIndex = 0;
            // 
            // lPrestamos
            // 
            this.lPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPrestamos.ForeColor = System.Drawing.Color.DarkGreen;
            this.lPrestamos.Location = new System.Drawing.Point(3, 111);
            this.lPrestamos.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lPrestamos.Name = "lPrestamos";
            this.lPrestamos.Size = new System.Drawing.Size(180, 23);
            this.lPrestamos.TabIndex = 0;
            this.lPrestamos.Text = "PRESTAMOS";
            this.lPrestamos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrestIcon
            // 
            this.PrestIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrestIcon.Image = ((System.Drawing.Image)(resources.GetObject("PrestIcon.Image")));
            this.PrestIcon.Location = new System.Drawing.Point(43, 27);
            this.PrestIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.PrestIcon.Name = "PrestIcon";
            this.PrestIcon.Size = new System.Drawing.Size(100, 64);
            this.PrestIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PrestIcon.TabIndex = 1;
            this.PrestIcon.TabStop = false;
            // 
            // pLibros
            // 
            this.pLibros.BackColor = System.Drawing.Color.White;
            this.pLibros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLibros.Controls.Add(this.tlpLibros);
            this.pLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLibros.Location = new System.Drawing.Point(296, 135);
            this.pLibros.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pLibros.Name = "pLibros";
            this.pLibros.Padding = new System.Windows.Forms.Padding(10);
            this.pLibros.Size = new System.Drawing.Size(206, 180);
            this.pLibros.TabIndex = 1;
            this.pLibros.Click += new System.EventHandler(this.pLibros_Click);
            this.pLibros.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTarjeta_Paint);
            // 
            // tlpLibros
            // 
            this.tlpLibros.ColumnCount = 1;
            this.tlpLibros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLibros.Controls.Add(this.lLibros, 0, 2);
            this.tlpLibros.Controls.Add(this.bookIcon, 0, 1);
            this.tlpLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLibros.Location = new System.Drawing.Point(10, 10);
            this.tlpLibros.Name = "tlpLibros";
            this.tlpLibros.RowCount = 4;
            this.tlpLibros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLibros.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLibros.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLibros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLibros.Size = new System.Drawing.Size(184, 158);
            this.tlpLibros.TabIndex = 0;
            // 
            // lLibros
            // 
            this.lLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLibros.ForeColor = System.Drawing.Color.DarkGreen;
            this.lLibros.Location = new System.Drawing.Point(3, 111);
            this.lLibros.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lLibros.Name = "lLibros";
            this.lLibros.Size = new System.Drawing.Size(178, 23);
            this.lLibros.TabIndex = 0;
            this.lLibros.Text = "LIBROS";
            this.lLibros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bookIcon
            // 
            this.bookIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bookIcon.Image = ((System.Drawing.Image)(resources.GetObject("bookIcon.Image")));
            this.bookIcon.Location = new System.Drawing.Point(42, 27);
            this.bookIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.bookIcon.Name = "bookIcon";
            this.bookIcon.Size = new System.Drawing.Size(100, 64);
            this.bookIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookIcon.TabIndex = 1;
            this.bookIcon.TabStop = false;
            // 
            // pUser
            // 
            this.pUser.BackColor = System.Drawing.Color.White;
            this.pUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUser.Controls.Add(this.tlpUser);
            this.pUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pUser.Location = new System.Drawing.Point(30, 135);
            this.pUser.Margin = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.pUser.Name = "pUser";
            this.pUser.Padding = new System.Windows.Forms.Padding(10);
            this.pUser.Size = new System.Drawing.Size(206, 180);
            this.pUser.TabIndex = 0;
            this.pUser.Click += new System.EventHandler(this.pUser_Click);
            this.pUser.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTarjeta_Paint);
            // 
            // tlpUser
            // 
            this.tlpUser.ColumnCount = 1;
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.Controls.Add(this.lUSer, 0, 2);
            this.tlpUser.Controls.Add(this.userIcon, 0, 1);
            this.tlpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUser.Location = new System.Drawing.Point(10, 10);
            this.tlpUser.Name = "tlpUser";
            this.tlpUser.RowCount = 4;
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUser.Size = new System.Drawing.Size(184, 158);
            this.tlpUser.TabIndex = 0;
            this.tlpUser.Click += new System.EventHandler(this.pUser_Click);
            // 
            // lUSer
            // 
            this.lUSer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUSer.ForeColor = System.Drawing.Color.DarkGreen;
            this.lUSer.Location = new System.Drawing.Point(3, 111);
            this.lUSer.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lUSer.Name = "lUSer";
            this.lUSer.Size = new System.Drawing.Size(178, 23);
            this.lUSer.TabIndex = 0;
            this.lUSer.Text = "USUARIOS";
            this.lUSer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lUSer.Click += new System.EventHandler(this.pUser_Click);
            // 
            // userIcon
            // 
            this.userIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userIcon.Image = ((System.Drawing.Image)(resources.GetObject("userIcon.Image")));
            this.userIcon.Location = new System.Drawing.Point(42, 27);
            this.userIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.userIcon.Name = "userIcon";
            this.userIcon.Size = new System.Drawing.Size(100, 64);
            this.userIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userIcon.TabIndex = 1;
            this.userIcon.TabStop = false;
            this.userIcon.Click += new System.EventHandler(this.pUser_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.tlpHome.ResumeLayout(false);
            this.pPrest.ResumeLayout(false);
            this.tlpPrest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrestIcon)).EndInit();
            this.pLibros.ResumeLayout(false);
            this.tlpLibros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bookIcon)).EndInit();
            this.pUser.ResumeLayout(false);
            this.tlpUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHome;
        private System.Windows.Forms.Panel pUser;
        private System.Windows.Forms.TableLayoutPanel tlpUser;
        private System.Windows.Forms.Label lUSer;
        private System.Windows.Forms.PictureBox userIcon;
        private System.Windows.Forms.Panel pPrest;
        private System.Windows.Forms.TableLayoutPanel tlpPrest;
        private System.Windows.Forms.Label lPrestamos;
        private System.Windows.Forms.PictureBox PrestIcon;
        private System.Windows.Forms.Panel pLibros;
        private System.Windows.Forms.TableLayoutPanel tlpLibros;
        private System.Windows.Forms.Label lLibros;
        private System.Windows.Forms.PictureBox bookIcon;
    }
}