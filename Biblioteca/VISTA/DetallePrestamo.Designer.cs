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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.43243F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.45946F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.288288F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 355);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.48387F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.51613F));
            this.tableLayoutPanel2.Controls.Add(this.lLibro, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lUsuario, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lFechaInicio, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLibroValor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaFinTitulo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblUsuarioValor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaInicioValor, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaFinValor, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblFechaLimite, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnDevolver, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(164, 47);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(317, 275);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lLibro
            // 
            this.lLibro.AutoSize = true;
            this.lLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibro.Location = new System.Drawing.Point(3, 0);
            this.lLibro.Name = "lLibro";
            this.lLibro.Size = new System.Drawing.Size(138, 45);
            this.lLibro.TabIndex = 3;
            this.lLibro.Text = "Libro";
            this.lLibro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUsuario.Location = new System.Drawing.Point(3, 45);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(138, 45);
            this.lUsuario.TabIndex = 4;
            this.lUsuario.Text = "Usuario";
            this.lUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFechaInicio
            // 
            this.lFechaInicio.AutoSize = true;
            this.lFechaInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFechaInicio.Location = new System.Drawing.Point(3, 90);
            this.lFechaInicio.Name = "lFechaInicio";
            this.lFechaInicio.Size = new System.Drawing.Size(138, 45);
            this.lFechaInicio.TabIndex = 5;
            this.lFechaInicio.Text = "Fecha Inicio";
            this.lFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLibroValor
            // 
            this.lblLibroValor.AutoSize = true;
            this.lblLibroValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLibroValor.Location = new System.Drawing.Point(146, 0);
            this.lblLibroValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLibroValor.Name = "lblLibroValor";
            this.lblLibroValor.Size = new System.Drawing.Size(169, 45);
            this.lblLibroValor.TabIndex = 6;
            this.lblLibroValor.Text = "label1";
            this.lblLibroValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaFinTitulo
            // 
            this.lblFechaFinTitulo.AutoSize = true;
            this.lblFechaFinTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinTitulo.Location = new System.Drawing.Point(2, 135);
            this.lblFechaFinTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaFinTitulo.Name = "lblFechaFinTitulo";
            this.lblFechaFinTitulo.Size = new System.Drawing.Size(140, 45);
            this.lblFechaFinTitulo.TabIndex = 7;
            this.lblFechaFinTitulo.Text = "Fecha Fin";
            this.lblFechaFinTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsuarioValor
            // 
            this.lblUsuarioValor.AutoSize = true;
            this.lblUsuarioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuarioValor.Location = new System.Drawing.Point(146, 45);
            this.lblUsuarioValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioValor.Name = "lblUsuarioValor";
            this.lblUsuarioValor.Size = new System.Drawing.Size(169, 45);
            this.lblUsuarioValor.TabIndex = 8;
            this.lblUsuarioValor.Text = "label2";
            this.lblUsuarioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaInicioValor
            // 
            this.lblFechaInicioValor.AutoSize = true;
            this.lblFechaInicioValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaInicioValor.Location = new System.Drawing.Point(146, 90);
            this.lblFechaInicioValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaInicioValor.Name = "lblFechaInicioValor";
            this.lblFechaInicioValor.Size = new System.Drawing.Size(169, 45);
            this.lblFechaInicioValor.TabIndex = 9;
            this.lblFechaInicioValor.Text = "label3";
            this.lblFechaInicioValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaFinValor
            // 
            this.lblFechaFinValor.AutoSize = true;
            this.lblFechaFinValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaFinValor.Location = new System.Drawing.Point(146, 135);
            this.lblFechaFinValor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaFinValor.Name = "lblFechaFinValor";
            this.lblFechaFinValor.Size = new System.Drawing.Size(169, 45);
            this.lblFechaFinValor.TabIndex = 10;
            this.lblFechaFinValor.Text = "lblFechaFinValor";
            this.lblFechaFinValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.BackColor = System.Drawing.Color.DarkOrange;
            this.tableLayoutPanel2.SetColumnSpan(this.lblFechaLimite, 2);
            this.lblFechaLimite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFechaLimite.Location = new System.Drawing.Point(2, 180);
            this.lblFechaLimite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(313, 45);
            this.lblFechaLimite.TabIndex = 11;
            this.lblFechaLimite.Text = "FECHA LIMITE: fecha";
            this.lblFechaLimite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDevolver
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnDevolver, 2);
            this.btnDevolver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDevolver.Location = new System.Drawing.Point(53, 231);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(53, 6, 53, 6);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(211, 38);
            this.btnDevolver.TabIndex = 12;
            this.btnDevolver.Text = "DEVOLVER";
            this.btnDevolver.UseVisualStyleBackColor = true;
            // 
            // DetallePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DetallePrestamo";
            this.Text = "DetallePrestamo";
            this.Load += new System.EventHandler(this.DetallePrestamo_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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