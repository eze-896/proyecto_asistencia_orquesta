namespace GUI_Login.vista
{
    partial class frmAgregarAlumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarAlumnos));
            txtDni = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtTelePadres = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnIngresar = new Button();
            btnVolver = new Button();
            label6 = new Label();
            cmbInstrumentos = new ComboBox();
            btnSalir = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.FromArgb(240, 242, 245);
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.ForeColor = Color.FromArgb(64, 64, 64);
            txtDni.Location = new Point(50, 245);
            txtDni.Multiline = true;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(220, 32);
            txtDni.TabIndex = 2;
            txtDni.Text = "Ingrese DNI";
            txtDni.Enter += txtDni_Enter;
            txtDni.Leave += txtDni_Leave;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(240, 242, 245);
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.FromArgb(64, 64, 64);
            txtNombre.Location = new Point(50, 165);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 32);
            txtNombre.TabIndex = 0;
            txtNombre.Text = "Ingrese nombre";
            txtNombre.Enter += txtNombre_Enter;
            txtNombre.Leave += txtNombre_Leave;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(240, 242, 245);
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.ForeColor = Color.FromArgb(64, 64, 64);
            txtApellido.Location = new Point(300, 165);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(220, 32);
            txtApellido.TabIndex = 1;
            txtApellido.Text = "Ingrese apellido";
            txtApellido.Enter += txtApellido_Enter;
            txtApellido.Leave += txtApellido_Leave;
            // 
            // txtTelePadres
            // 
            txtTelePadres.BackColor = Color.FromArgb(240, 242, 245);
            txtTelePadres.BorderStyle = BorderStyle.None;
            txtTelePadres.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelePadres.ForeColor = Color.FromArgb(64, 64, 64);
            txtTelePadres.Location = new Point(50, 325);
            txtTelePadres.Multiline = true;
            txtTelePadres.Name = "txtTelePadres";
            txtTelePadres.Size = new Size(220, 32);
            txtTelePadres.TabIndex = 3;
            txtTelePadres.Text = "Ingrese teléfono";
            txtTelePadres.Enter += txtTelePadres_Enter;
            txtTelePadres.Leave += txtTelePadres_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(45, 90);
            label1.Name = "label1";
            label1.Size = new Size(240, 30);
            label1.TabIndex = 14;
            label1.Text = "Nuevo Alumno Musical";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(116, 86, 174);
            label2.Location = new Point(50, 140);
            label2.Name = "label2";
            label2.Size = new Size(60, 17);
            label2.TabIndex = 15;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(116, 86, 174);
            label3.Location = new Point(300, 140);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 16;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(116, 86, 174);
            label4.Location = new Point(50, 220);
            label4.Name = "label4";
            label4.Size = new Size(30, 17);
            label4.TabIndex = 17;
            label4.Text = "DNI";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(116, 86, 174);
            label5.Location = new Point(50, 300);
            label5.Name = "label5";
            label5.Size = new Size(124, 17);
            label5.TabIndex = 18;
            label5.Text = "Teléfono de padres";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(116, 86, 174);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 68, 140);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(50, 430);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(220, 40);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "🎵 INGRESAR ALUMNO";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.White;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderColor = Color.FromArgb(116, 86, 174);
            btnVolver.FlatAppearance.BorderSize = 2;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 243, 250);
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.FromArgb(116, 86, 174);
            btnVolver.Location = new Point(300, 430);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(220, 40);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "↩ VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(116, 86, 174);
            label6.Location = new Point(300, 220);
            label6.Name = "label6";
            label6.Size = new Size(159, 17);
            label6.TabIndex = 19;
            label6.Text = "Instrumento a aprender";
            // 
            // cmbInstrumentos
            // 
            cmbInstrumentos.BackColor = Color.FromArgb(240, 242, 245);
            cmbInstrumentos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstrumentos.FlatStyle = FlatStyle.Flat;
            cmbInstrumentos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbInstrumentos.ForeColor = Color.FromArgb(64, 64, 64);
            cmbInstrumentos.FormattingEnabled = true;
            cmbInstrumentos.Location = new Point(300, 245);
            cmbInstrumentos.Name = "cmbInstrumentos";
            cmbInstrumentos.Size = new Size(220, 28);
            cmbInstrumentos.TabIndex = 4;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.FromArgb(116, 86, 174);
            btnSalir.Location = new Point(530, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(30, 30);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "×";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(116, 86, 174);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label7);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(572, 70);
            panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(20, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(70, 20);
            label7.Name = "label7";
            label7.Size = new Size(235, 30);
            label7.TabIndex = 0;
            label7.Text = "Registro de Alumnos 🎶";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(116, 86, 174);
            panel2.Location = new Point(50, 197);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 2);
            panel2.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(116, 86, 174);
            panel3.Location = new Point(300, 197);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 2);
            panel3.TabIndex = 22;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(116, 86, 174);
            panel4.Location = new Point(50, 277);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 2);
            panel4.TabIndex = 23;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(116, 86, 174);
            panel5.Location = new Point(50, 357);
            panel5.Name = "panel5";
            panel5.Size = new Size(220, 2);
            panel5.TabIndex = 24;
            // 
            // frmAlumnos
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(572, 500);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(cmbInstrumentos);
            Controls.Add(label6);
            Controls.Add(btnVolver);
            Controls.Add(btnIngresar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTelePadres);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDni);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAlumnos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Alumnos";
            Load += frmAlumnos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtTelePadres;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnIngresar;
        private Button btnVolver;
        private Label label6;
        private ComboBox cmbInstrumentos;
        private Button btnSalir;
        private Panel panel1;
        private Label label7;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}