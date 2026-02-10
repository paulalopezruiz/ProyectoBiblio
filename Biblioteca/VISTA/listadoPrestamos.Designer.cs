namespace Biblioteca.VISTA
{
    partial class listadoPrestamos
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
            this.tlpLibro = new System.Windows.Forms.TableLayoutPanel();
            this.lLibro = new System.Windows.Forms.Label();
            this.cbLibro = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.flowListado = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpUserFliter = new System.Windows.Forms.TableLayoutPanel();
            this.lUsuario = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.tlpPrincipal.SuspendLayout();
            this.tlpLibro.SuspendLayout();
            this.tlpUserFliter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.AutoSize = true;
            this.tlpPrincipal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPrincipal.ColumnCount = 4;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPrincipal.Controls.Add(this.tlpLibro, 1, 0);
            this.tlpPrincipal.Controls.Add(this.btnNuevo, 3, 0);
            this.tlpPrincipal.Controls.Add(this.flowListado, 0, 1);
            this.tlpPrincipal.Controls.Add(this.tlpUserFliter, 0, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPrincipal.MinimumSize = new System.Drawing.Size(855, 431);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 2;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.31884F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.68116F));
            this.tlpPrincipal.Size = new System.Drawing.Size(855, 431);
            this.tlpPrincipal.TabIndex = 1;
            this.tlpPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tlpLibro
            // 
            this.tlpLibro.AutoSize = true;
            this.tlpLibro.ColumnCount = 1;
            this.tlpLibro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpLibro.Controls.Add(this.lLibro, 0, 1);
            this.tlpLibro.Controls.Add(this.cbLibro, 0, 2);
            this.tlpLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLibro.Location = new System.Drawing.Point(301, 5);
            this.tlpLibro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpLibro.Name = "tlpLibro";
            this.tlpLibro.RowCount = 4;
            this.tlpLibro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLibro.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLibro.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLibro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLibro.Size = new System.Drawing.Size(278, 150);
            this.tlpLibro.TabIndex = 9;
            // 
            // lLibro
            // 
            this.lLibro.AutoSize = true;
            this.lLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lLibro.Location = new System.Drawing.Point(4, 41);
            this.lLibro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lLibro.Name = "lLibro";
            this.lLibro.Size = new System.Drawing.Size(270, 25);
            this.lLibro.TabIndex = 0;
            this.lLibro.Text = "Libro";
            this.lLibro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbLibro
            // 
            this.cbLibro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbLibro.FormattingEnabled = true;
            this.cbLibro.Location = new System.Drawing.Point(4, 71);
            this.cbLibro.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbLibro.Name = "cbLibro";
            this.cbLibro.Size = new System.Drawing.Size(270, 33);
            this.cbLibro.TabIndex = 1;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNuevo.Location = new System.Drawing.Point(606, 47);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(45, 47, 60, 47);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(189, 66);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // flowListado
            // 
            this.flowListado.AutoScroll = true;
            this.tlpPrincipal.SetColumnSpan(this.flowListado, 4);
            this.flowListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowListado.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowListado.Location = new System.Drawing.Point(3, 163);
            this.flowListado.Name = "flowListado";
            this.flowListado.Size = new System.Drawing.Size(849, 265);
            this.flowListado.TabIndex = 4;
            this.flowListado.WrapContents = false;
            this.flowListado.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // tlpUserFliter
            // 
            this.tlpUserFliter.AutoSize = true;
            this.tlpUserFliter.ColumnCount = 1;
            this.tlpUserFliter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserFliter.Controls.Add(this.lUsuario, 0, 1);
            this.tlpUserFliter.Controls.Add(this.cbUsuario, 0, 2);
            this.tlpUserFliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUserFliter.Location = new System.Drawing.Point(15, 5);
            this.tlpUserFliter.Margin = new System.Windows.Forms.Padding(15, 5, 4, 5);
            this.tlpUserFliter.Name = "tlpUserFliter";
            this.tlpUserFliter.RowCount = 4;
            this.tlpUserFliter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUserFliter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUserFliter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpUserFliter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUserFliter.Size = new System.Drawing.Size(278, 150);
            this.tlpUserFliter.TabIndex = 8;
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lUsuario.Location = new System.Drawing.Point(4, 41);
            this.lUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(270, 25);
            this.lUsuario.TabIndex = 0;
            this.lUsuario.Text = "Usuario";
            this.lUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbUsuario
            // 
            this.cbUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(4, 71);
            this.cbUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(270, 33);
            this.cbUsuario.TabIndex = 1;
            // 
            // listadoPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 431);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "listadoPrestamos";
            this.Load += new System.EventHandler(this.listadoPrestamos_Load);
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.tlpLibro.ResumeLayout(false);
            this.tlpLibro.PerformLayout();
            this.tlpUserFliter.ResumeLayout(false);
            this.tlpUserFliter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.FlowLayoutPanel flowListado;
        private System.Windows.Forms.TableLayoutPanel tlpUserFliter;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.TableLayoutPanel tlpLibro;
        private System.Windows.Forms.Label lLibro;
        private System.Windows.Forms.ComboBox cbLibro;
    }
}