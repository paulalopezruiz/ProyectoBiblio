namespace Biblioteca.VISTA
{
    partial class DetalleUsuario
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
            this.tbDni = new System.Windows.Forms.MaskedTextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.btnVerPrestamos = new System.Windows.Forms.Button();
            this.lNombre = new System.Windows.Forms.Label();
            this.lTlf = new System.Windows.Forms.Label();
            this.lDni = new System.Windows.Forms.Label();
            this.tlpPrincipal.SuspendLayout();
            this.tlpEdit.SuspendLayout();
            this.tlpInfo.SuspendLayout();
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
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.Size = new System.Drawing.Size(958, 555);
            this.tlpPrincipal.TabIndex = 1;
            // 
            // tlpEdit
            // 
            this.tlpEdit.ColumnCount = 1;
            this.tlpEdit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEdit.Controls.Add(this.tbDni, 0, 2);
            this.tlpEdit.Controls.Add(this.tbNombre, 0, 0);
            this.tlpEdit.Controls.Add(this.tbTelefono, 0, 1);
            this.tlpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdit.Location = new System.Drawing.Point(722, 143);
            this.tlpEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpEdit.Name = "tlpEdit";
            this.tlpEdit.RowCount = 4;
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpEdit.Size = new System.Drawing.Size(232, 267);
            this.tlpEdit.TabIndex = 1;
            // 
            // tbDni
            // 
            this.tbDni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDni.Location = new System.Drawing.Point(3, 135);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(226, 31);
            this.tbDni.TabIndex = 2;
            this.tbDni.Visible = false;
            // 
            // tbNombre
            // 
            this.tbNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNombre.Location = new System.Drawing.Point(3, 3);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(226, 31);
            this.tbNombre.TabIndex = 0;
            this.tbNombre.Visible = false;
            // 
            // tbTelefono
            // 
            this.tbTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTelefono.Location = new System.Drawing.Point(3, 69);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(226, 31);
            this.tbTelefono.TabIndex = 1;
            this.tbTelefono.Visible = false;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpInfo.Controls.Add(this.lblNombre, 0, 0);
            this.tlpInfo.Controls.Add(this.lblTelefono, 0, 1);
            this.tlpInfo.Controls.Add(this.lblDNI, 0, 2);
            this.tlpInfo.Controls.Add(this.btnVerPrestamos, 0, 3);
            this.tlpInfo.Controls.Add(this.lNombre, 1, 0);
            this.tlpInfo.Controls.Add(this.lTlf, 1, 1);
            this.tlpInfo.Controls.Add(this.lDni, 1, 2);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(243, 143);
            this.tlpInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 4;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpInfo.Size = new System.Drawing.Size(471, 267);
            this.tlpInfo.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombre.Location = new System.Drawing.Point(4, 0);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(96, 25);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTelefono.Location = new System.Drawing.Point(4, 66);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(96, 25);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Telefono";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDNI.Location = new System.Drawing.Point(4, 132);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(96, 25);
            this.lblDNI.TabIndex = 2;
            this.lblDNI.Text = "DNI";
            // 
            // btnVerPrestamos
            // 
            this.btnVerPrestamos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.tlpInfo.SetColumnSpan(this.btnVerPrestamos, 2);
            this.btnVerPrestamos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVerPrestamos.Location = new System.Drawing.Point(150, 203);
            this.btnVerPrestamos.Margin = new System.Windows.Forms.Padding(150, 5, 150, 5);
            this.btnVerPrestamos.Name = "btnVerPrestamos";
            this.btnVerPrestamos.Size = new System.Drawing.Size(171, 59);
            this.btnVerPrestamos.TabIndex = 6;
            this.btnVerPrestamos.Text = "Ver Prestamos";
            this.btnVerPrestamos.UseVisualStyleBackColor = false;
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lNombre.Location = new System.Drawing.Point(107, 0);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(361, 25);
            this.lNombre.TabIndex = 7;
            this.lNombre.Text = "label1";
            // 
            // lTlf
            // 
            this.lTlf.AutoSize = true;
            this.lTlf.Dock = System.Windows.Forms.DockStyle.Top;
            this.lTlf.Location = new System.Drawing.Point(107, 66);
            this.lTlf.Name = "lTlf";
            this.lTlf.Size = new System.Drawing.Size(361, 25);
            this.lTlf.TabIndex = 8;
            this.lTlf.Text = "label2";
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Dock = System.Windows.Forms.DockStyle.Top;
            this.lDni.Location = new System.Drawing.Point(107, 132);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(361, 25);
            this.lDni.TabIndex = 9;
            this.lDni.Text = "label3";
            // 
            // DetalleUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 555);
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(984, 588);
            this.Name = "DetalleUsuario";
            this.Text = "DetalleUsuario";
            this.Load += new System.EventHandler(this.DetalleUsuario_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpEdit.ResumeLayout(false);
            this.tlpEdit.PerformLayout();
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Button btnVerPrestamos;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Label lTlf;
        private System.Windows.Forms.Label lDni;
        private System.Windows.Forms.TableLayoutPanel tlpEdit;
        private System.Windows.Forms.MaskedTextBox tbDni;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.MaskedTextBox tbTelefono;
    }
}