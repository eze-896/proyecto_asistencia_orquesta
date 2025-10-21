namespace GUI_Login.vista
{
    partial class frmModificarAlumnos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstAlumnosModificar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtTelePadres;
        private System.Windows.Forms.ComboBox cmbInstrumentos;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblInstrumento;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelFormulario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelFormulario = new System.Windows.Forms.Panel();
            this.lblInstrumento = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbInstrumentos = new System.Windows.Forms.ComboBox();
            this.txtTelePadres = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.lstAlumnosModificar = new System.Windows.Forms.ListBox();
            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelFormulario.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Controls.Add(this.btnSalir);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 120);
            this.panelHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(35, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(355, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "MODIFICAR ALUMNOS";

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 75);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(350, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Seleccione un alumno y modifique sus datos";

            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(850, 20);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(40, 40);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "×";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.panelMain.Controls.Add(this.lstAlumnosModificar);
            this.panelMain.Controls.Add(this.panelFormulario);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 120);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(30);
            this.panelMain.Size = new System.Drawing.Size(900, 580);
            this.panelMain.TabIndex = 1;

            // 
            // panelFormulario
            // 
            this.panelFormulario.BackColor = System.Drawing.Color.White;
            this.panelFormulario.Controls.Add(this.lblInstrumento);
            this.panelFormulario.Controls.Add(this.lblTelefono);
            this.panelFormulario.Controls.Add(this.lblDni);
            this.panelFormulario.Controls.Add(this.lblApellido);
            this.panelFormulario.Controls.Add(this.lblNombre);
            this.panelFormulario.Controls.Add(this.cmbInstrumentos);
            this.panelFormulario.Controls.Add(this.txtTelePadres);
            this.panelFormulario.Controls.Add(this.txtDni);
            this.panelFormulario.Controls.Add(this.txtApellido);
            this.panelFormulario.Controls.Add(this.txtNombre);
            this.panelFormulario.Controls.Add(this.btnVolver);
            this.panelFormulario.Controls.Add(this.btnGuardarCambios);
            this.panelFormulario.Location = new System.Drawing.Point(340, 30);
            this.panelFormulario.Name = "panelFormulario";
            this.panelFormulario.Size = new System.Drawing.Size(530, 520);
            this.panelFormulario.TabIndex = 1;

            // 
            // lblInstrumento
            // 
            this.lblInstrumento.AutoSize = true;
            this.lblInstrumento.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblInstrumento.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblInstrumento.Location = new System.Drawing.Point(30, 240);
            this.lblInstrumento.Name = "lblInstrumento";
            this.lblInstrumento.Size = new System.Drawing.Size(195, 21);
            this.lblInstrumento.TabIndex = 15;
            this.lblInstrumento.Text = "Instrumento a aprender";

            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblTelefono.Location = new System.Drawing.Point(30, 180);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(160, 21);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Teléfono de padres";

            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblDni.Location = new System.Drawing.Point(30, 120);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(36, 21);
            this.lblDni.TabIndex = 13;
            this.lblDni.Text = "DNI";

            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblApellido.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblApellido.Location = new System.Drawing.Point(280, 60);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(75, 21);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellido";

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.lblNombre.Location = new System.Drawing.Point(30, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(76, 21);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre";

            // 
            // cmbInstrumentos
            // 
            this.cmbInstrumentos.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.cmbInstrumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInstrumentos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbInstrumentos.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.cmbInstrumentos.FormattingEnabled = true;
            this.cmbInstrumentos.Location = new System.Drawing.Point(30, 270);
            this.cmbInstrumentos.Name = "cmbInstrumentos";
            this.cmbInstrumentos.Size = new System.Drawing.Size(470, 28);
            this.cmbInstrumentos.TabIndex = 4;

            // 
            // txtTelePadres
            // 
            this.txtTelePadres.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.txtTelePadres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelePadres.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelePadres.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.txtTelePadres.Location = new System.Drawing.Point(30, 210);
            this.txtTelePadres.Name = "txtTelePadres";
            this.txtTelePadres.Size = new System.Drawing.Size(470, 27);
            this.txtTelePadres.TabIndex = 3;

            // 
            // txtDni
            // 
            this.txtDni.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDni.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDni.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.txtDni.Location = new System.Drawing.Point(30, 150);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(470, 27);
            this.txtDni.TabIndex = 2;

            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.txtApellido.Location = new System.Drawing.Point(280, 90);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(220, 27);
            this.txtApellido.TabIndex = 1;

            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(248, 248, 252);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.txtNombre.Location = new System.Drawing.Point(30, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 27);
            this.txtNombre.TabIndex = 0;

            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnVolver.Location = new System.Drawing.Point(280, 350);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(220, 45);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "← VOLVER AL PRINCIPAL";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.btnGuardarCambios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(94, 68, 140);
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(30, 350);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(220, 45);
            this.btnGuardarCambios.TabIndex = 5;
            this.btnGuardarCambios.Text = "💾 GUARDAR CAMBIOS";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);

            // 
            // lstAlumnosModificar
            // 
            this.lstAlumnosModificar.BackColor = System.Drawing.Color.White;
            this.lstAlumnosModificar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAlumnosModificar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstAlumnosModificar.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lstAlumnosModificar.FormattingEnabled = true;
            this.lstAlumnosModificar.ItemHeight = 20;
            this.lstAlumnosModificar.Location = new System.Drawing.Point(30, 30);
            this.lstAlumnosModificar.Name = "lstAlumnosModificar";
            this.lstAlumnosModificar.Size = new System.Drawing.Size(280, 520);
            this.lstAlumnosModificar.TabIndex = 0;
            this.lstAlumnosModificar.SelectedIndexChanged += new System.EventHandler(this.lstAlumnosModificar_SelectedIndexChanged);

            // 
            // frmModificarAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmModificarAlumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Alumnos";
            this.Load += new System.EventHandler(this.frmModificarAlumnos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmModificarAlumnos_KeyDown);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelFormulario.ResumeLayout(false);
            this.panelFormulario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}