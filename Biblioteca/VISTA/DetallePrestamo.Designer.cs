namespace Biblioteca.VISTA
{
    partial class DetallePrestamo
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
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lLibro = new System.Windows.Forms.Label();
            this.lUsuario = new System.Windows.Forms.Label();
            this.lFechaInicio = new System.Windows.Forms.Label();
            this.lblLibroValor = new System.Windows.Forms.Label();
            this.lblFechaFinTitulo = new System.Windows.Forms.Label();
            this.lblUsuarioValor = new System.Windows.Forms.Label();
            this.lblFechaInicioValor = new System.Windows.Forms.Label();
            this.lblFechaFinValor = new System.Windows.Forms.Label();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.tlpPrincipal.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 3;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPrincipal.Controls.Add(this.tlpInfo, 1, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.43243F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.45946F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.288288F));
            this.tlpPrincipal.Size = new System.Drawing.Size(864, 555);
            this.tlpPrincipal.TabIndex = 1;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 2;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.48387F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.51613F));
            this.tlpInfo.Controls.Add(this.lLibro, 0, 0);
            this.tlpInfo.Controls.Add(this.lUsuario, 0, 1);
            this.tlpInfo.Controls.Add(this.lFechaInicio, 0, 2);
            this.tlpInfo.Controls.Add(this.lblLibroValor, 1, 0);
            this.tlpInfo.Controls.Add(this.lblFechaFinTitulo, 0, 3);
            this.tlpInfo.Controls.Add(this.lblUsuarioValor, 1, 1);
            this.tlpInfo.Controls.Add(this.lblFechaInicioValor, 1, 2);
            this.tlpInfo.Controls.Add(this.lblFechaFinValor, 1, 3);
            this.tlpInfo.Controls.Add(this.lblFechaLimite, 0, 4);
            this.tlpInfo.Controls.Add(this.btnDevolver, 0, 5);
            this.tlpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInfo.Location = new System.Drawing.Point(220, 73);
            this.tlpInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 6;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpInfo.Size = new System.Drawing.Size(424, 430);
            this.tlpInfo.TabIndex = 0;
            // 
            // lLibro
            // 
            this.lLibro.AutoSize = true;
            this.lLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibro.Location = new System.Drawing.Point(4, 0);
            this.lLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLibro.Name = "lLibro";
            this.lLibro.Size = new System.Drawing.Size(184, 71);
            this.lLibro.TabIndex = 3;
            this.lLibro.Text = "Libro";
            this.lLibro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUsuario.Location = new System.Drawing.Point(4, 71);
            this.lUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(184, 71);
            this.lUsuario.TabIndex = 4;
            this.lUsuario.Text = "Usuario";
            this.lUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.AutoSize = true;
            this.lFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFechaInicio.Location = new System.Drawing.Point(4, 142);
            this.lFechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(184, 71);
            this.lFechaInicio.TabIndex = 5;
            this.lFechaInicio.Text = "Fecha Inicio";
            this.lFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLibroValor
            // 
            this.lblLibroValor.AutoSize = true;
            this.lblLibroValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLibroValor.Location = new System.Drawing.Point(195, 0);
            this.lblLibroValor.Name = "lblLibroValor";
            this.lblLibroValor.Size = new System.Drawing.Size(226, 71);
            this.lblLibroValor.TabIndex = 6;
            this.lblLibroValor.Text = "label1";
            this.lblLibroValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaFinTitulo
            // 
            this.lblFechaFinTitulo.AutoSize = true;
            this.lblFechaFinTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinTitulo.Location = new System.Drawing.Point(3, 213);
            this.lblFechaFinTitulo.Name = "lblFechaFinTitulo";
            this.lblFechaFinTitulo.Size = new System.Drawing.Size(186, 71);
            this.lblFechaFinTitulo.TabIndex = 7;
            this.lblFechaFinTitulo.Text = "Fecha Fin";
            this.lblFechaFinTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuarioValor
            // 
            this.lblUsuarioValor.AutoSize = true;
            this.lblUsuarioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuarioValor.Location = new System.Drawing.Point(195, 71);
            this.lblUsuarioValor.Name = "lblUsuarioValor";
            this.lblUsuarioValor.Size = new System.Drawing.Size(226, 71);
            this.lblUsuarioValor.TabIndex = 8;
            this.lblUsuarioValor.Text = "label2";
            this.lblUsuarioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaInicioValor
            // 
            this.lblFechaInicioValor.AutoSize = true;
            this.lblFechaInicioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaInicioValor.Location = new System.Drawing.Point(195, 142);
            this.lblFechaInicioValor.Name = "lblFechaInicioValor";
            this.lblFechaInicioValor.Size = new System.Drawing.Size(226, 71);
            this.lblFechaInicioValor.TabIndex = 9;
            this.lblFechaInicioValor.Text = "label3";
            this.lblFechaInicioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaFinValor
            // 
            this.lblFechaFinValor.AutoSize = true;
            this.lblFechaFinValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinValor.Location = new System.Drawing.Point(195, 213);
            this.lblFechaFinValor.Name = "lblFechaFinValor";
            this.lblFechaFinValor.Size = new System.Drawing.Size(226, 71);
            this.lblFechaFinValor.TabIndex = 10;
            this.lblFechaFinValor.Text = "lblFechaFinValor";
            this.lblFechaFinValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.BackColor = System.Drawing.Color.DarkOrange;
            this.tlpInfo.SetColumnSpan(this.lblFechaLimite, 2);
            this.lblFechaLimite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaLimite.Location = new System.Drawing.Point(3, 284);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(418, 71);
            this.lblFechaLimite.TabIndex = 11;
            this.lblFechaLimite.Text = "FECHA LIMITE: fecha";
            this.lblFechaLimite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDevolver
            // 
            this.tlpInfo.SetColumnSpan(this.btnDevolver, 2);
            this.btnDevolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDevolver.Location = new System.Drawing.Point(80, 364);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(80, 9, 80, 9);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(264, 57);
            this.btnDevolver.TabIndex = 12;
            this.btnDevolver.Text = "DEVOLVER";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // DetallePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 555);
            this.Controls.Add(this.tlpPrincipal);
            this.MinimumSize = new System.Drawing.Size(890, 626);
            this.Name = "DetallePrestamo";
            this.Text = "DetallePrestamo";
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lLibro;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.Label lFechaInicio;
        private System.Windows.Forms.Label lblLibroValor;
        private System.Windows.Forms.Label lblFechaFinTitulo;
        private System.Windows.Forms.Label lblUsuarioValor;
        private System.Windows.Forms.Label lblFechaInicioValor;
        private System.Windows.Forms.Label lblFechaFinValor;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.Button btnDevolver;
    }
}