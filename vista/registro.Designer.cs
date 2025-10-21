namespace GUI_Login
{
    partial class Registro
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
            txtNombreRegistro = new TextBox();
            lblNombreRegistro = new Label();
            lblContraseñaRegistro = new Label();
            lblContraConfirm = new Label();
            txtContraRegistro = new TextBox();
            txtContraConfirm = new TextBox();
            pictureBox1 = new PictureBox();
            btnRegistro = new Button();
            btnVolver = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtNombreRegistro
            // 
            txtNombreRegistro.BackColor = Color.FromArgb(230, 231, 233);
            txtNombreRegistro.BorderStyle = BorderStyle.None;
            txtNombreRegistro.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreRegistro.Location = new Point(34, 191);
            txtNombreRegistro.Multiline = true;
            txtNombreRegistro.Name = "txtNombreRegistro";
            txtNombreRegistro.Size = new Size(270, 28);
            txtNombreRegistro.TabIndex = 3;
            // 
            // lblNombreRegistro
            // 
            lblNombreRegistro.AutoSize = true;
            lblNombreRegistro.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreRegistro.ForeColor = Color.FromArgb(116, 86, 174);
            lblNombreRegistro.Location = new Point(34, 150);
            lblNombreRegistro.Name = "lblNombreRegistro";
            lblNombreRegistro.Size = new Size(237, 27);
            lblNombreRegistro.TabIndex = 4;
            lblNombreRegistro.Text = "Ingrese su nombre";
            // 
            // lblContraseñaRegistro
            // 
            lblContraseñaRegistro.AutoSize = true;
            lblContraseñaRegistro.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraseñaRegistro.ForeColor = Color.FromArgb(116, 86, 174);
            lblContraseñaRegistro.Location = new Point(34, 235);
            lblContraseñaRegistro.Name = "lblContraseñaRegistro";
            lblContraseñaRegistro.Size = new Size(283, 27);
            lblContraseñaRegistro.TabIndex = 5;
            lblContraseñaRegistro.Text = "Ingrese su contraseña";
            // 
            // lblContraConfirm
            // 
            lblContraConfirm.AutoSize = true;
            lblContraConfirm.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblContraConfirm.ForeColor = Color.FromArgb(116, 86, 174);
            lblContraConfirm.Location = new Point(34, 319);
            lblContraConfirm.Name = "lblContraConfirm";
            lblContraConfirm.Size = new Size(270, 27);
            lblContraConfirm.TabIndex = 6;
            lblContraConfirm.Text = "Repite tu contraseña";
            // 
            // txtContraRegistro
            // 
            txtContraRegistro.BackColor = Color.FromArgb(230, 231, 233);
            txtContraRegistro.BorderStyle = BorderStyle.None;
            txtContraRegistro.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraRegistro.Location = new Point(34, 278);
            txtContraRegistro.Multiline = true;
            txtContraRegistro.Name = "txtContraRegistro";
            txtContraRegistro.PasswordChar = '*';
            txtContraRegistro.Size = new Size(270, 28);
            txtContraRegistro.TabIndex = 7;
            // 
            // txtContraConfirm
            // 
            txtContraConfirm.BackColor = Color.FromArgb(230, 231, 233);
            txtContraConfirm.BorderStyle = BorderStyle.None;
            txtContraConfirm.Font = new Font("MS UI Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraConfirm.Location = new Point(34, 361);
            txtContraConfirm.Multiline = true;
            txtContraConfirm.Name = "txtContraConfirm";
            txtContraConfirm.PasswordChar = '*';
            txtContraConfirm.Size = new Size(270, 28);
            txtContraConfirm.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Adobe_Express___file;
            pictureBox1.Location = new Point(34, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnRegistro
            // 
            btnRegistro.BackColor = Color.FromArgb(116, 86, 174);
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.Location = new Point(34, 408);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(270, 35);
            btnRegistro.TabIndex = 10;
            btnRegistro.Text = "REGISTRARSE";
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += BtnRegistro_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(116, 86, 174);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(33, 449);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(271, 39);
            btnVolver.TabIndex = 11;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += BtnVolver_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(116, 86, 174);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(272, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(54, 25);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(338, 532);
            Controls.Add(btnSalir);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistro);
            Controls.Add(pictureBox1);
            Controls.Add(txtContraConfirm);
            Controls.Add(txtContraRegistro);
            Controls.Add(lblContraConfirm);
            Controls.Add(lblContraseñaRegistro);
            Controls.Add(lblNombreRegistro);
            Controls.Add(txtNombreRegistro);
            FormBorderStyle = FormBorderStyle.None;
            Name = "registro";
            Text = "registro";
            Load += Registro_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreRegistro;
        private Label lblNombreRegistro;
        private Label lblContraseñaRegistro;
        private Label lblContraConfirm;
        private TextBox txtContraRegistro;
        private TextBox txtContraConfirm;
        private PictureBox pictureBox1;
        private Button btnRegistro;
        private Button btnVolver;
        private Button btnSalir;
    }
}