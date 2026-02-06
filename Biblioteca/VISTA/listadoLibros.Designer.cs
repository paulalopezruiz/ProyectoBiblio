namespace Biblioteca.VISTA
{
    partial class listadoLibros
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
            this.tliTiutlo = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAutor = new System.Windows.Forms.TableLayoutPanel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.lAutor = new System.Windows.Forms.Label();
            this.cbTitulo = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbDisponible = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tliTiutlo.SuspendLayout();
            this.tlpAutor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNuevo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpAutor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tliTiutlo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbDisponible, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.28306F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.71694F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(855, 431);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tliTiutlo
            // 
            this.tliTiutlo.ColumnCount = 1;
            this.tliTiutlo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.Controls.Add(this.lTitulo, 0, 0);
            this.tliTiutlo.Controls.Add(this.cbTitulo, 0, 1);
            this.tliTiutlo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tliTiutlo.Location = new System.Drawing.Point(3, 3);
            this.tliTiutlo.Name = "tliTiutlo";
            this.tliTiutlo.RowCount = 2;
            this.tliTiutlo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.Size = new System.Drawing.Size(207, 159);
            this.tliTiutlo.TabIndex = 0;
            // 
            // tlpAutor
            // 
            this.tlpAutor.ColumnCount = 1;
            this.tlpAutor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.Controls.Add(this.comboBox1, 0, 1);
            this.tlpAutor.Controls.Add(this.lAutor, 0, 0);
            this.tlpAutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAutor.Location = new System.Drawing.Point(216, 3);
            this.tlpAutor.Name = "tlpAutor";
            this.tlpAutor.RowCount = 2;
            this.tlpAutor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.Size = new System.Drawing.Size(207, 159);
            this.tlpAutor.TabIndex = 1;
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTitulo.Location = new System.Drawing.Point(3, 0);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(201, 79);
            this.lTitulo.TabIndex = 0;
            this.lTitulo.Text = "Titulo";
            this.lTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lAutor
            // 
            this.lAutor.AutoSize = true;
            this.lAutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lAutor.Location = new System.Drawing.Point(3, 0);
            this.lAutor.Name = "lAutor";
            this.lAutor.Size = new System.Drawing.Size(201, 79);
            this.lAutor.TabIndex = 1;
            this.lAutor.Text = "Autor";
            this.lAutor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbTitulo
            // 
            this.cbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTitulo.FormattingEnabled = true;
            this.cbTitulo.Location = new System.Drawing.Point(3, 82);
            this.cbTitulo.Name = "cbTitulo";
            this.cbTitulo.Size = new System.Drawing.Size(201, 33);
            this.cbTitulo.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 33);
            this.comboBox1.TabIndex = 2;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNuevo.Location = new System.Drawing.Point(669, 47);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(30, 47, 30, 47);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(156, 71);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 168);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(849, 260);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cbDisponible
            // 
            this.cbDisponible.AutoSize = true;
            this.cbDisponible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDisponible.Location = new System.Drawing.Point(451, 3);
            this.cbDisponible.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.cbDisponible.Name = "cbDisponible";
            this.cbDisponible.Size = new System.Drawing.Size(185, 159);
            this.cbDisponible.TabIndex = 10;
            this.cbDisponible.Text = "Disponibilidad";
            this.cbDisponible.UseVisualStyleBackColor = true;
            // 
            // listadoLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "listadoLibros";
            this.Text = "listadoLibros";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tliTiutlo.ResumeLayout(false);
            this.tliTiutlo.PerformLayout();
            this.tlpAutor.ResumeLayout(false);
            this.tlpAutor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpAutor;
        private System.Windows.Forms.Label lAutor;
        private System.Windows.Forms.TableLayoutPanel tliTiutlo;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.ComboBox cbTitulo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbDisponible;
    }
}