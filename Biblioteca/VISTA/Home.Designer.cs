namespace Biblioteca.VISTA
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.tlpHome = new System.Windows.Forms.TableLayoutPanel();
            this.pUser = new System.Windows.Forms.Panel();
            this.userIcon = new System.Windows.Forms.PictureBox();
            this.lUser = new System.Windows.Forms.Label();
            this.tlpHome.SuspendLayout();
            this.pUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpHome
            // 
            this.tlpHome.BackColor = System.Drawing.Color.Transparent;
            this.tlpHome.ColumnCount = 5;
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHome.Controls.Add(this.pUser, 1, 1);
            this.tlpHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHome.Location = new System.Drawing.Point(0, 0);
            this.tlpHome.Name = "tlpHome";
            this.tlpHome.RowCount = 3;
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpHome.Size = new System.Drawing.Size(800, 450);
            this.tlpHome.TabIndex = 0;
            // 
            // pUser
            // 
            this.pUser.BackColor = System.Drawing.Color.White;
            this.pUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUser.Controls.Add(this.lUser);
            this.pUser.Controls.Add(this.userIcon);
            this.pUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pUser.Location = new System.Drawing.Point(163, 152);
            this.pUser.Name = "pUser";
            this.pUser.Padding = new System.Windows.Forms.Padding(10);
            this.pUser.Size = new System.Drawing.Size(154, 143);
            this.pUser.TabIndex = 0;
            // 
            // userIcon
            // 
            this.userIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.userIcon.Image = ((System.Drawing.Image)(resources.GetObject("userIcon.Image")));
            this.userIcon.Location = new System.Drawing.Point(10, 10);
            this.userIcon.Name = "userIcon";
            this.userIcon.Size = new System.Drawing.Size(132, 75);
            this.userIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userIcon.TabIndex = 0;
            this.userIcon.TabStop = false;
            // 
            // lUser
            // 
            this.lUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUser.ForeColor = System.Drawing.Color.DarkGreen;
            this.lUser.Location = new System.Drawing.Point(10, 106);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(132, 25);
            this.lUser.TabIndex = 1;
            this.lUser.Text = "USUARIO";
            this.lUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.tlpHome.ResumeLayout(false);
            this.pUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpHome;
        private System.Windows.Forms.Panel pUser;
        private System.Windows.Forms.PictureBox userIcon;
        private System.Windows.Forms.Label lUser;
    }
}