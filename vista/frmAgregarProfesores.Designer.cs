namespace GUI_Login.vista
{
    partial class frmAgregarProfesores
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
            btnVolver = new Button();
            btnIngresar = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTelefono = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtDni = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            cmbInstrumentos = new ComboBox();
            label7 = new Label();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(116, 86, 174);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(265, 330);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(203, 35);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(116, 86, 174);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(34, 330);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(203, 35);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "INGRESAR PROFESOR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(116, 86, 174);
            label5.Location = new Point(34, 180);
            label5.Name = "label5";
            label5.Size = new Size(93, 19);
            label5.TabIndex = 19;
            label5.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(116, 86, 174);
            label4.Location = new Point(34, 112);
            label4.Name = "label4";
            label4.Size = new Size(46, 19);
            label4.TabIndex = 18;
            label4.Text = "DNI:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(116, 86, 174);
            label3.Location = new Point(265, 48);
            label3.Name = "label3";
            label3.Size = new Size(84, 19);
            label3.TabIndex = 17;
            label3.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(116, 86, 174);
            label2.Location = new Point(34, 48);
            label2.Name = "label2";
            label2.Size = new Size(82, 19);
            label2.TabIndex = 16;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(34, 13);
            label1.Name = "label1";
            label1.Size = new Size(370, 24);
            label1.TabIndex = 15;
            label1.Text = "DATOS DEL NUEVO PROFESOR";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(230, 231, 233);
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(34, 207);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(203, 28);
            txtTelefono.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(230, 231, 233);
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(265, 77);
            txtApellido.Multiline = true;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(203, 28);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(230, 231, 233);
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(34, 77);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(203, 28);
            txtNombre.TabIndex = 0;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.FromArgb(230, 231, 233);
            txtDni.BorderStyle = BorderStyle.None;
            txtDni.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDni.Location = new Point(34, 143);
            txtDni.Multiline = true;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(203, 28);
            txtDni.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(116, 86, 174);
            label6.Location = new Point(34, 248);
            label6.Name = "label6";
            label6.Size = new Size(61, 19);
            label6.TabIndex = 23;
            label6.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(230, 231, 233);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(34, 275);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(203, 28);
            txtEmail.TabIndex = 4;
            // 
            // cmbInstrumentos
            // 
            cmbInstrumentos.BackColor = Color.FromArgb(230, 231, 233);
            cmbInstrumentos.FlatStyle = FlatStyle.Flat;
            cmbInstrumentos.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbInstrumentos.FormattingEnabled = true;
            cmbInstrumentos.Location = new Point(265, 143);
            cmbInstrumentos.Name = "cmbInstrumentos";
            cmbInstrumentos.Size = new Size(203, 24);
            cmbInstrumentos.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(265, 112);
            label7.Name = "label7";
            label7.Size = new Size(234, 19);
            label7.TabIndex = 25;
            label7.Text = "Instrumento que enseña:";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(116, 86, 174);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(448, 12);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(54, 25);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmProfesores
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(514, 389);
            Controls.Add(btnSalir);
            Controls.Add(label7);
            Controls.Add(cmbInstrumentos);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(btnVolver);
            Controls.Add(btnIngresar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtDni);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProfesores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProfesores";
            Load += frmProfesores_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVolver;
        private Button btnIngresar;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTelefono;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtDni;
        private Label label6;
        private TextBox txtEmail;
        private ComboBox cmbInstrumentos;
        private Label label7;
        private Button btnSalir;
    }
}