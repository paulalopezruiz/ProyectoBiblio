namespace Biblioteca
{
    partial class TarjetaPrestamo
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lFecha = new System.Windows.Forms.Label();
            this.lPrestamo = new System.Windows.Forms.Label();
            this.pEstado = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.Controls.Add(this.lFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lPrestamo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pEstado, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 150);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFecha.Location = new System.Drawing.Point(303, 0);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(174, 150);
            this.lFecha.TabIndex = 11;
            this.lFecha.Text = "Fecha";
            this.lFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lFecha.Click += new System.EventHandler(this.lFecha_Click);
            // 
            // lPrestamo
            // 
            this.lPrestamo.AutoSize = true;
            this.lPrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPrestamo.Location = new System.Drawing.Point(3, 0);
            this.lPrestamo.Name = "lPrestamo";
            this.lPrestamo.Size = new System.Drawing.Size(294, 150);
            this.lPrestamo.TabIndex = 10;
            this.lPrestamo.Text = "Prestamo";
            this.lPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lPrestamo.Click += new System.EventHandler(this.lPrestamo_Click);
            // 
            // pEstado
            // 
            this.pEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEstado.Location = new System.Drawing.Point(525, 47);
            this.pEstado.Margin = new System.Windows.Forms.Padding(45, 47, 45, 47);
            this.pEstado.Name = "pEstado";
            this.pEstado.Size = new System.Drawing.Size(84, 56);
            this.pEstado.TabIndex = 9;
            // 
            // TarjetaPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TarjetaPrestamo";
            this.Size = new System.Drawing.Size(654, 150);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pEstado;
        private System.Windows.Forms.Label lPrestamo;
        private System.Windows.Forms.Label lFecha;
    }
}
