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
            this.bBorrar = new System.Windows.Forms.Button();
            this.paint = new System.Windows.Forms.Panel();
            this.lPrestamo = new System.Windows.Forms.Label();
            this.lFecha = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.52045F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.50929F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.97026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lPrestamo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.paint, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.bBorrar, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 96);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bBorrar
            // 
            this.bBorrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bBorrar.Location = new System.Drawing.Point(335, 32);
            this.bBorrar.Margin = new System.Windows.Forms.Padding(20, 32, 20, 32);
            this.bBorrar.Name = "bBorrar";
            this.bBorrar.Size = new System.Drawing.Size(81, 32);
            this.bBorrar.TabIndex = 6;
            this.bBorrar.Text = "Borrar";
            this.bBorrar.UseVisualStyleBackColor = true;
            // 
            // paint
            // 
            this.paint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paint.Location = new System.Drawing.Point(244, 30);
            this.paint.Margin = new System.Windows.Forms.Padding(30);
            this.paint.Name = "paint";
            this.paint.Size = new System.Drawing.Size(41, 36);
            this.paint.TabIndex = 9;
            // 
            // lPrestamo
            // 
            this.lPrestamo.AutoSize = true;
            this.lPrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lPrestamo.Location = new System.Drawing.Point(2, 0);
            this.lPrestamo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPrestamo.Name = "lPrestamo";
            this.lPrestamo.Size = new System.Drawing.Size(124, 96);
            this.lPrestamo.TabIndex = 10;
            this.lPrestamo.Text = "Prestamo";
            this.lPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFecha
            // 
            this.lFecha.AutoSize = true;
            this.lFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFecha.Location = new System.Drawing.Point(130, 0);
            this.lFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFecha.Name = "lFecha";
            this.lFecha.Size = new System.Drawing.Size(82, 96);
            this.lFecha.TabIndex = 11;
            this.lFecha.Text = "Fecha";
            this.lFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TarjetaPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TarjetaPrestamo";
            this.Size = new System.Drawing.Size(436, 96);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bBorrar;
        private System.Windows.Forms.Panel paint;
        private System.Windows.Forms.Label lPrestamo;
        private System.Windows.Forms.Label lFecha;
    }
}
