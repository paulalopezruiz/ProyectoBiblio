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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.flpLibros = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpAutor = new System.Windows.Forms.TableLayoutPanel();
            this.cbAutores = new System.Windows.Forms.ComboBox();
            this.lAutor = new System.Windows.Forms.Label();
            this.tliTiutlo = new System.Windows.Forms.TableLayoutPanel();
            this.lTitulo = new System.Windows.Forms.Label();
            this.cbTitulos = new System.Windows.Forms.ComboBox();
            this.cbDisponible = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpAutor.SuspendLayout();
            this.tliTiutlo.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.btnNuevo, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpLibros, 0, 1);
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
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(684, 49);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(45, 47, 60, 47);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(111, 66);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.AbrirNuevoLibro);
            // 
            // flpLibros
            // 
            this.flpLibros.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpLibros, 4);
            this.flpLibros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLibros.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLibros.Location = new System.Drawing.Point(3, 167);
            this.flpLibros.Name = "flpLibros";
            this.flpLibros.Size = new System.Drawing.Size(849, 261);
            this.flpLibros.TabIndex = 9;
            this.flpLibros.WrapContents = false;
            this.flpLibros.Paint += new System.Windows.Forms.PaintEventHandler(this.flpLibros_Paint);
            // 
            // tlpAutor
            // 
            this.tlpAutor.ColumnCount = 1;
            this.tlpAutor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.Controls.Add(this.cbAutores, 0, 1);
            this.tlpAutor.Controls.Add(this.lAutor, 0, 0);
            this.tlpAutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAutor.Location = new System.Drawing.Point(216, 3);
            this.tlpAutor.Name = "tlpAutor";
            this.tlpAutor.RowCount = 2;
            this.tlpAutor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAutor.Size = new System.Drawing.Size(207, 158);
            this.tlpAutor.TabIndex = 1;
            // 
            // cbAutores
            // 
            this.cbAutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAutores.FormattingEnabled = true;
            this.cbAutores.Location = new System.Drawing.Point(3, 82);
            this.cbAutores.Name = "cbAutores";
            this.cbAutores.Size = new System.Drawing.Size(201, 33);
            this.cbAutores.TabIndex = 2;
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
            // tliTiutlo
            // 
            this.tliTiutlo.ColumnCount = 1;
            this.tliTiutlo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.Controls.Add(this.lTitulo, 0, 0);
            this.tliTiutlo.Controls.Add(this.cbTitulos, 0, 1);
            this.tliTiutlo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tliTiutlo.Location = new System.Drawing.Point(3, 3);
            this.tliTiutlo.Name = "tliTiutlo";
            this.tliTiutlo.RowCount = 2;
            this.tliTiutlo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tliTiutlo.Size = new System.Drawing.Size(207, 158);
            this.tliTiutlo.TabIndex = 0;
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
            // cbTitulos
            // 
            this.cbTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTitulos.FormattingEnabled = true;
            this.cbTitulos.Location = new System.Drawing.Point(3, 82);
            this.cbTitulos.Name = "cbTitulos";
            this.cbTitulos.Size = new System.Drawing.Size(201, 33);
            this.cbTitulos.TabIndex = 1;
            // 
            // cbDisponible
            // 
            this.cbDisponible.AutoSize = true;
            this.cbDisponible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDisponible.Location = new System.Drawing.Point(451, 3);
            this.cbDisponible.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
            this.cbDisponible.Name = "cbDisponible";
            this.cbDisponible.Size = new System.Drawing.Size(185, 158);
            this.cbDisponible.TabIndex = 10;
            this.cbDisponible.Text = "Disponibilidad";
            this.cbDisponible.UseVisualStyleBackColor = true;
            this.cbDisponible.CheckedChanged += new System.EventHandler(this.cbDisponible_CheckedChanged);
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
            this.tlpAutor.ResumeLayout(false);
            this.tlpAutor.PerformLayout();
            this.tliTiutlo.ResumeLayout(false);
            this.tliTiutlo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpAutor;
        private System.Windows.Forms.Label lAutor;
        private System.Windows.Forms.TableLayoutPanel tliTiutlo;
        private System.Windows.Forms.Label lTitulo;
        private System.Windows.Forms.ComboBox cbTitulos;
        private System.Windows.Forms.ComboBox cbAutores;
        private System.Windows.Forms.FlowLayoutPanel flpLibros;
        private System.Windows.Forms.CheckBox cbDisponible;
        private System.Windows.Forms.Button btnNuevo;
    }
}