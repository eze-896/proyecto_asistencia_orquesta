namespace GUI_Login
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            lblContraseña = new Label();
            checkBxMostrarContraseña = new CheckBox();
            btnIniciarsesion = new Button();
            btnSalir = new Button();
            btnRegistro = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Adobe_Express___file;
            pictureBox1.Location = new Point(28, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.FromArgb(116, 86, 174);
            lblUsuario.Location = new Point(28, 185);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(104, 27);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(230, 231, 233);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(28, 215);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(216, 28);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.BackColor = Color.FromArgb(230, 231, 233);
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(28, 293);
            txtContraseña.Multiline = true;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(216, 28);
            txtContraseña.TabIndex = 4;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = Color.FromArgb(116, 86, 174);
            lblContraseña.Location = new Point(28, 263);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(152, 27);
            lblContraseña.TabIndex = 3;
            lblContraseña.Text = "Contraseña";
            // 
            // checkBxMostrarContraseña
            // 
            checkBxMostrarContraseña.AutoSize = true;
            checkBxMostrarContraseña.Cursor = Cursors.Hand;
            checkBxMostrarContraseña.FlatStyle = FlatStyle.Flat;
            checkBxMostrarContraseña.Location = new Point(96, 343);
            checkBxMostrarContraseña.Name = "checkBxMostrarContraseña";
            checkBxMostrarContraseña.Size = new Size(145, 21);
            checkBxMostrarContraseña.TabIndex = 5;
            checkBxMostrarContraseña.Text = "Mostrar Contraseña";
            checkBxMostrarContraseña.UseVisualStyleBackColor = true;
            checkBxMostrarContraseña.CheckedChanged += checkBxMostrarContraseña_CheckedChanged;
            // 
            // btnIniciarsesion
            // 
            btnIniciarsesion.BackColor = Color.FromArgb(116, 86, 174);
            btnIniciarsesion.Cursor = Cursors.Hand;
            btnIniciarsesion.FlatAppearance.BorderSize = 0;
            btnIniciarsesion.FlatStyle = FlatStyle.Flat;
            btnIniciarsesion.ForeColor = Color.White;
            btnIniciarsesion.Location = new Point(28, 387);
            btnIniciarsesion.Name = "btnIniciarsesion";
            btnIniciarsesion.Size = new Size(216, 35);
            btnIniciarsesion.TabIndex = 6;
            btnIniciarsesion.Text = "INICIAR SESION";
            btnIniciarsesion.UseVisualStyleBackColor = false;
            btnIniciarsesion.Click += btnIniciarsesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(116, 86, 174);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(207, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(54, 25);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.BackColor = Color.FromArgb(116, 86, 174);
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Location = new Point(28, 428);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(216, 36);
            btnRegistro.TabIndex = 14;
            btnRegistro.Text = "REGISTRARSE";
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(273, 489);
            Controls.Add(btnRegistro);
            Controls.Add(btnSalir);
            Controls.Add(btnIniciarsesion);
            Controls.Add(checkBxMostrarContraseña);
            Controls.Add(txtContraseña);
            Controls.Add(lblContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(pictureBox1);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Label lblContraseña;
        private CheckBox checkBxMostrarContraseña;
        private Button btnIniciarsesion;
        private Button btnSalir;
        private Button btnRegistro;
    }
}
