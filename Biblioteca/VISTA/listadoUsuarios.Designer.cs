namespace Biblioteca.VISTA
{
    partial class listadoUsuarios
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tlpFiltro = new System.Windows.Forms.TableLayoutPanel();
            this.lBuscar = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.flowListado = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpPrincipal.SuspendLayout();
            this.tlpFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.AutoSize = true;
            this.tlpPrincipal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPrincipal.ColumnCount = 4;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.Controls.Add(this.btnNuevo, 3, 0);
            this.tlpPrincipal.Controls.Add(this.tlpFiltro, 0, 0);
            this.tlpPrincipal.Controls.Add(this.flowListado, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.MinimumSize = new System.Drawing.Size(533, 288);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.11111F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.88889F));
            this.tlpPrincipal.Size = new System.Drawing.Size(533, 288);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(376, 30);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(30);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(127, 29);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // tlpFiltro
            // 
            this.tlpFiltro.AutoSize = true;
            this.tlpFiltro.ColumnCount = 1;
            this.tlpFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFiltro.Controls.Add(this.lBuscar, 0, 0);
            this.tlpFiltro.Controls.Add(this.tbNombre, 0, 1);
            this.tlpFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltro.Location = new System.Drawing.Point(23, 23);
            this.tlpFiltro.Margin = new System.Windows.Forms.Padding(23);
            this.tlpFiltro.Name = "tlpFiltro";
            this.tlpFiltro.RowCount = 2;
            this.tlpFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFiltro.Size = new System.Drawing.Size(164, 43);
            this.tlpFiltro.TabIndex = 1;
            // 
            // lBuscar
            // 
            this.lBuscar.AutoSize = true;
            this.lBuscar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lBuscar.Location = new System.Drawing.Point(3, 0);
            this.lBuscar.Name = "lBuscar";
            this.lBuscar.Size = new System.Drawing.Size(158, 16);
            this.lBuscar.TabIndex = 0;
            this.lBuscar.Text = "Busca por nombre:";
            // 
            // tbNombre
            // 
            this.tbNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbNombre.Location = new System.Drawing.Point(3, 19);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(158, 22);
            this.tbNombre.TabIndex = 1;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            // 
            // flowListado
            // 
            this.flowListado.AutoScroll = true;
            this.tlpPrincipal.SetColumnSpan(this.flowListado, 4);
            this.flowListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowListado.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowListado.Location = new System.Drawing.Point(2, 91);
            this.flowListado.Margin = new System.Windows.Forms.Padding(2);
            this.flowListado.Name = "flowListado";
            this.flowListado.Size = new System.Drawing.Size(529, 195);
            this.flowListado.TabIndex = 4;
            this.flowListado.WrapContents = false;
            // 
            // listadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 288);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(533, 288);
            this.Name = "listadoUsuarios";
            this.Text = "listadoUsuarios";
            this.Load += new System.EventHandler(this.listadoUsuarios_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.tlpFiltro.ResumeLayout(false);
            this.tlpFiltro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpFiltro;
        private System.Windows.Forms.Label lBuscar;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.FlowLayoutPanel flowListado;
        private System.Windows.Forms.Button btnNuevo;
    }
}