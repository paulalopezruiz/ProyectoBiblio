namespace Biblioteca.VISTA
{
    partial class NuevoLibro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.numericEjemplares = new System.Windows.Forms.NumericUpDown();
            this.tlpImagen = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubirImagen = new System.Windows.Forms.Button();
            this.pictureBoxImagen = new System.Windows.Forms.PictureBox();
            this.tlpPrincipal.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEjemplares)).BeginInit();
            this.tlpImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.Controls.Add(this.tlpInfo, 1, 1);
            this.tlpPrincipal.Controls.Add(this.tlpImagen, 1, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPrincipal.MinimumSize = new System.Drawing.Size(988, 602);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.2219F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.10526F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.530583F));
            this.tlpPrincipal.Size = new System.Drawing.Size(988, 703);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpInfo.Controls.Add(this.lblAutor, 0, 1);
            this.tlpInfo.Controls.Add(this.lblISBN, 0, 2);
            this.tlpInfo.Controls.Add(this.tbTitulo, 1, 0);
            this.tlpInfo.Controls.Add(this.tbAutor, 1, 1);
            this.tlpInfo.Controls.Add(this.btnGuardar, 0, 3);
            this.tlpInfo.Controls.Add(this.numericEjemplares, 1, 2);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(251, 344);
            this.tlpInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 4;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.Size = new System.Drawing.Size(486, 286);
            this.tlpInfo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(4, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(65, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(4, 71);
            this.lblAutor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(63, 25);
            this.lblAutor.TabIndex = 1;
            this.lblAutor.Text = "Autor";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(4, 142);
            this.lblISBN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(148, 25);
            this.lblISBN.TabIndex = 2;
            this.lblISBN.Text = "Nº Ejemplares";
            // 
            // tbTitulo
            // 
            this.tbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTitulo.Location = new System.Drawing.Point(160, 5);
            this.tbTitulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(322, 31);
            this.tbTitulo.TabIndex = 3;
            // 
            // tbAutor
            // 
            this.tbAutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAutor.Location = new System.Drawing.Point(160, 76);
            this.tbAutor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(322, 31);
            this.tbAutor.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tlpInfo.SetColumnSpan(this.btnGuardar, 2);
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.Location = new System.Drawing.Point(150, 218);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(150, 5, 150, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(186, 63);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // numericEjemplares
            // 
            this.numericEjemplares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericEjemplares.Location = new System.Drawing.Point(159, 145);
            this.numericEjemplares.Name = "numericEjemplares";
            this.numericEjemplares.Size = new System.Drawing.Size(324, 31);
            this.numericEjemplares.TabIndex = 7;
            // 
            // tlpImagen
            // 
            this.tlpImagen.ColumnCount = 1;
            this.tlpImagen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpImagen.Controls.Add(this.btnSubirImagen, 0, 1);
            this.tlpImagen.Controls.Add(this.pictureBoxImagen, 0, 0);
            this.tlpImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpImagen.Location = new System.Drawing.Point(250, 3);
            this.tlpImagen.Name = "tlpImagen";
            this.tlpImagen.RowCount = 2;
            this.tlpImagen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.96997F));
            this.tlpImagen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.03003F));
            this.tlpImagen.Size = new System.Drawing.Size(488, 333);
            this.tlpImagen.TabIndex = 1;
            // 
            // btnSubirImagen
            // 
            this.btnSubirImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubirImagen.Location = new System.Drawing.Point(100, 258);
            this.btnSubirImagen.Margin = new System.Windows.Forms.Padding(100, 25, 100, 25);
            this.btnSubirImagen.Name = "btnSubirImagen";
            this.btnSubirImagen.Size = new System.Drawing.Size(288, 50);
            this.btnSubirImagen.TabIndex = 0;
            this.btnSubirImagen.Text = "SUBIR IMAGEN";
            this.btnSubirImagen.UseVisualStyleBackColor = true;
            // 
            // pictureBoxImagen
            // 
            this.pictureBoxImagen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImagen.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImagen.Name = "pictureBoxImagen";
            this.pictureBoxImagen.Size = new System.Drawing.Size(482, 227);
            this.pictureBoxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagen.TabIndex = 1;
            this.pictureBoxImagen.TabStop = false;
            // 
            // NuevoLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.tlpPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(958, 515);
            this.Name = "NuevoLibro";
            this.Text = "NuevoLibro";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEjemplares)).EndInit();
            this.tlpImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown numericEjemplares;
        private System.Windows.Forms.TableLayoutPanel tlpImagen;
        private System.Windows.Forms.Button btnSubirImagen;
        private System.Windows.Forms.PictureBox pictureBoxImagen;
    }
}
