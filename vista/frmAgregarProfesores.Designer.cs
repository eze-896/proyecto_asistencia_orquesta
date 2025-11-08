namespace GUI_Login.vista
{
    partial class FrmAgregarProfesores
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
            panelHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnSalir = new Button();
            panelMain = new Panel();
            panelForm = new Panel();
            cmbInstrumentos = new ComboBox();
            label7 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            btnVolver = new Button();
            btnIngresar = new Button();
            txtTelefono = new TextBox();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(116, 86, 174);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(btnSalir);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 120);
            panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(35, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(379, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REGISTRO PROFESORES";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 12F);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(40, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(278, 21);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Complete los datos del nuevo profesor";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(850, 20);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(40, 40);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "×";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 248, 252);
            panelMain.Controls.Add(panelForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 120);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(30);
            panelMain.Size = new Size(900, 580);
            panelMain.TabIndex = 1;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(cmbInstrumentos);
            panelForm.Controls.Add(label7);
            panelForm.Controls.Add(txtEmail);
            panelForm.Controls.Add(label6);
            panelForm.Controls.Add(btnVolver);
            panelForm.Controls.Add(btnIngresar);
            panelForm.Controls.Add(txtTelefono);
            panelForm.Controls.Add(txtDni);
            panelForm.Controls.Add(txtApellido);
            panelForm.Controls.Add(txtNombre);
            panelForm.Controls.Add(label5);
            panelForm.Controls.Add(label4);
            panelForm.Controls.Add(label3);
            panelForm.Controls.Add(label2);
            panelForm.Controls.Add(label1);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(30, 30);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(40);
            panelForm.Size = new Size(840, 520);
            panelForm.TabIndex = 0;
            // 
            // cmbInstrumentos
            // 
            cmbInstrumentos.BackColor = Color.FromArgb(248, 248, 252);
            cmbInstrumentos.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstrumentos.FlatStyle = FlatStyle.Flat;
            cmbInstrumentos.Font = new Font("Segoe UI", 11F);
            cmbInstrumentos.ForeColor = Color.FromArgb(64, 64, 64);
            cmbInstrumentos.FormattingEnabled = true;
            cmbInstrumentos.Location = new Point(450, 241);
            cmbInstrumentos.Name = "cmbInstrumentos";
            cmbInstrumentos.Size = new Size(320, 28);
            cmbInstrumentos.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(116, 86, 174);
            label7.Location = new Point(450, 211);
            label7.Name = "label7";
            label7.Size = new Size(195, 21);
            label7.TabIndex = 25;
            label7.Text = "Instrumento que enseña";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(248, 248, 252);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.FromArgb(64, 64, 64);
            txtEmail.Location = new Point(80, 241);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 27);
            txtEmail.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(116, 86, 174);
            label6.Location = new Point(80, 211);
            label6.Name = "label6";
            label6.Size = new Size(53, 21);
            label6.TabIndex = 23;
            label6.Text = "Email";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(240, 240, 240);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220);
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnVolver.ForeColor = Color.FromArgb(64, 64, 64);
            btnVolver.Location = new Point(450, 400);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(320, 45);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "← VOLVER AL PRINCIPAL";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += BtnVolver_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(116, 86, 174);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 68, 140);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(80, 400);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 45);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "👨‍🏫 INGRESAR PROFESOR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += BtnIngresar_Click;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(248, 248, 252);
            txtTelefono.BorderStyle = BorderStyle.FixedSingle;
            txtTelefono.Font = new Font("Segoe UI", 11F);
            txtTelefono.ForeColor = Color.FromArgb(64, 64, 64);
            txtTelefono.Location = new Point(450, 180);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(320, 27);
            txtTelefono.TabIndex = 4;
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.FromArgb(248, 248, 252);
            txtDni.BorderStyle = BorderStyle.FixedSingle;
            txtDni.Font = new Font("Segoe UI", 11F);
            txtDni.ForeColor = Color.FromArgb(64, 64, 64);
            txtDni.Location = new Point(80, 180);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(320, 27);
            txtDni.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(248, 248, 252);
            txtApellido.BorderStyle = BorderStyle.FixedSingle;
            txtApellido.Font = new Font("Segoe UI", 11F);
            txtApellido.ForeColor = Color.FromArgb(64, 64, 64);
            txtApellido.Location = new Point(450, 120);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(320, 27);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(248, 248, 252);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 11F);
            txtNombre.ForeColor = Color.FromArgb(64, 64, 64);
            txtNombre.Location = new Point(80, 120);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(320, 27);
            txtNombre.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(116, 86, 174);
            label5.Location = new Point(450, 150);
            label5.Name = "label5";
            label5.Size = new Size(77, 21);
            label5.TabIndex = 19;
            label5.Text = "Teléfono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(116, 86, 174);
            label4.Location = new Point(80, 150);
            label4.Name = "label4";
            label4.Size = new Size(40, 21);
            label4.TabIndex = 18;
            label4.Text = "DNI";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(116, 86, 174);
            label3.Location = new Point(450, 90);
            label3.Name = "label3";
            label3.Size = new Size(75, 21);
            label3.TabIndex = 17;
            label3.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(116, 86, 174);
            label2.Location = new Point(80, 90);
            label2.Name = "label2";
            label2.Size = new Size(73, 21);
            label2.TabIndex = 16;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(75, 30);
            label1.Name = "label1";
            label1.Size = new Size(201, 32);
            label1.TabIndex = 15;
            label1.Text = "Nuevo Profesor ";
            // 
            // frmAgregarProfesores
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "frmAgregarProfesores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Profesores";
            Load += FrmAgregarProfesores_Load;
            KeyDown += FrmAgregarProfesores_KeyDown;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnSalir;
        private Panel panelMain;
        private Panel panelForm;
        private ComboBox cmbInstrumentos;
        private Label label7;
        private TextBox txtEmail;
        private Label label6;
        private Button btnVolver;
        private Button btnIngresar;
        private TextBox txtTelefono;
        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}