namespace Biblioteca.VISTA
{
    partial class DetalleLibros
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
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEdit = new System.Windows.Forms.TableLayoutPanel();
            this.tbEditAutor = new System.Windows.Forms.TextBox();
            this.tbEditTitulo = new System.Windows.Forms.TextBox();
            this.nudEditEjemplares = new System.Windows.Forms.NumericUpDown();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.btnVerPrestamos = new System.Windows.Forms.Button();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lAutor = new System.Windows.Forms.Label();
            this.lEjemplares = new System.Windows.Forms.Label();
            this.pictureBoxPortada = new System.Windows.Forms.PictureBox();
            this.tlpPrincipal.SuspendLayout();
            this.tlpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditEjemplares)).BeginInit();
            this.tlpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortada)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.Controls.Add(this.tlpEdit, 2, 1);
            this.tlpPrincipal.Controls.Add(this.tlpInfo, 1, 1);
            this.tlpPrincipal.Controls.Add(this.pictureBoxPortada, 1, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.38606F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.96422F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.649717F));
            this.tlpPrincipal.Size = new System.Drawing.Size(644, 348);
            this.tlpPrincipal.TabIndex = 1;
            // 
            // tlpEdit
            // 
            this.tlpEdit.ColumnCount = 1;
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpEdit.Controls.Add(this.tbEditAutor, 0, 1);
            this.tlpEdit.Controls.Add(this.tbEditTitulo, 0, 0);
            this.tlpEdit.Controls.Add(this.nudEditEjemplares, 0, 2);
            this.tlpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdit.Location = new System.Drawing.Point(486, 160);
            this.tlpEdit.Name = "tlpEdit";
            this.tlpEdit.RowCount = 4;
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.Size = new System.Drawing.Size(155, 164);
            this.tlpEdit.TabIndex = 2;
            // 
            // tbEditAutor
            // 
            this.tbEditAutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEditAutor.Location = new System.Drawing.Point(2, 43);
            this.tbEditAutor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEditAutor.Name = "tbEditAutor";
            this.tbEditAutor.Size = new System.Drawing.Size(152, 22);
            this.tbEditAutor.TabIndex = 1;
            this.tbEditAutor.Visible = false;
            // 
            // tbEditTitulo
            // 
            this.tbEditTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEditTitulo.Location = new System.Drawing.Point(2, 2);
            this.tbEditTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbEditTitulo.Name = "tbEditTitulo";
            this.tbEditTitulo.Size = new System.Drawing.Size(152, 22);
            this.tbEditTitulo.TabIndex = 0;
            this.tbEditTitulo.Visible = false;
            // 
            // nudEditEjemplares
            // 
            this.nudEditEjemplares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudEditEjemplares.Location = new System.Drawing.Point(2, 84);
            this.nudEditEjemplares.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudEditEjemplares.Name = "nudEditEjemplares";
            this.nudEditEjemplares.Size = new System.Drawing.Size(152, 22);
            this.nudEditEjemplares.TabIndex = 2;
            this.nudEditEjemplares.Visible = false;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInfo.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpInfo.Controls.Add(this.lblAutor, 0, 1);
            this.tlpInfo.Controls.Add(this.lblISBN, 0, 2);
            this.tlpInfo.Controls.Add(this.btnVerPrestamos, 0, 3);
            this.tlpInfo.Controls.Add(this.lTitulo, 1, 0);
            this.tlpInfo.Controls.Add(this.lAutor, 1, 1);
            this.tlpInfo.Controls.Add(this.lEjemplares, 1, 2);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(164, 160);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 4;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.Size = new System.Drawing.Size(316, 164);
            this.tlpInfo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(94, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAutor.Location = new System.Drawing.Point(3, 41);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(94, 16);
            this.lblAutor.TabIndex = 1;
            this.lblAutor.Text = "Autor";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblISBN.Location = new System.Drawing.Point(3, 82);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(94, 16);
            this.lblISBN.TabIndex = 2;
            this.lblISBN.Text = "Nº Ejemplares";
            // 
            // btnVerPrestamos
            // 
            this.btnVerPrestamos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tlpInfo.SetColumnSpan(this.btnVerPrestamos, 2);
            this.btnVerPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVerPrestamos.Location = new System.Drawing.Point(100, 126);
            this.btnVerPrestamos.Margin = new System.Windows.Forms.Padding(100, 3, 100, 3);
            this.btnVerPrestamos.Name = "btnVerPrestamos";
            this.btnVerPrestamos.Size = new System.Drawing.Size(116, 35);
            this.btnVerPrestamos.TabIndex = 6;
            this.btnVerPrestamos.Text = "Ver Prestamos";
            this.btnVerPrestamos.UseVisualStyleBackColor = false;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTitulo.Location = new System.Drawing.Point(102, 0);
            this.lTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(212, 16);
            this.lTitulo.TabIndex = 7;
            this.lTitulo.Text = "label1";
            // 
            // lAutor
            // 
            this.lAutor.AutoSize = true;
            this.lAutor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lAutor.Location = new System.Drawing.Point(102, 41);
            this.lAutor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAutor.Name = "lAutor";
            this.lAutor.Size = new System.Drawing.Size(212, 16);
            this.lAutor.TabIndex = 8;
            this.lAutor.Text = "lAutor";
            // 
            // lEjemplares
            // 
            this.lEjemplares.AutoSize = true;
            this.lEjemplares.Dock = System.Windows.Forms.DockStyle.Top;
            this.lEjemplares.Location = new System.Drawing.Point(102, 82);
            this.lEjemplares.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lEjemplares.Name = "lEjemplares";
            this.lEjemplares.Size = new System.Drawing.Size(212, 16);
            this.lEjemplares.TabIndex = 9;
            this.lEjemplares.Text = "label3";
            // 
            // pictureBoxPortada
            // 
            this.pictureBoxPortada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPortada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPortada.Location = new System.Drawing.Point(164, 3);
            this.pictureBoxPortada.Name = "pictureBoxPortada";
            this.pictureBoxPortada.Size = new System.Drawing.Size(316, 151);
            this.pictureBoxPortada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPortada.TabIndex = 1;
            this.pictureBoxPortada.TabStop = false;
            // 
            // DetalleLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 348);
            this.Controls.Add(this.tlpPrincipal);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(662, 393);
            this.Name = "DetalleLibros";
            this.Text = "DetalleLibros";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpEdit.ResumeLayout(false);
            this.tlpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditEjemplares)).EndInit();
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPortada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Button btnVerPrestamos;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.Label lAutor;
        private System.Windows.Forms.Label lEjemplares;
        private System.Windows.Forms.PictureBox pbPortada;
        private System.Windows.Forms.PictureBox pictureBoxPortada;
        private System.Windows.Forms.TableLayoutPanel tlpEdit;
        private System.Windows.Forms.TextBox tbEditAutor;
        private System.Windows.Forms.TextBox tbEditTitulo;
        private System.Windows.Forms.NumericUpDown nudEditEjemplares;
    }
}