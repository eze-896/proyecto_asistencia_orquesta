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

        private void InitializeComponent()
        {
            this.lstAlumnosModificar = new System.Windows.Forms.ListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtTelePadres = new System.Windows.Forms.TextBox();
            this.cmbInstrumentos = new System.Windows.Forms.ComboBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblInstrumento = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.btnSalir);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Text = "MODIFICAR ALUMNOS";
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.AutoSize = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Text = "×";
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            this.btnSalir.Size = new System.Drawing.Size(30, 30);
            this.btnSalir.Location = new System.Drawing.Point(520, 20);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lstAlumnosModificar
            // 
            this.lstAlumnosModificar.Location = new System.Drawing.Point(20, 90);
            this.lstAlumnosModificar.Size = new System.Drawing.Size(250, 300);
            this.lstAlumnosModificar.SelectedIndexChanged += new System.EventHandler(this.lstAlumnosModificar_SelectedIndexChanged);
            // 
            // Labels
            // 
            int labelX = 290;
            int inputX = 400;
            int yBase = 100;
            int spacing = 40;

            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Location = new System.Drawing.Point(labelX, yBase);
            this.txtNombre.Location = new System.Drawing.Point(inputX, yBase);

            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Location = new System.Drawing.Point(labelX, yBase + spacing);
            this.txtApellido.Location = new System.Drawing.Point(inputX, yBase + spacing);

            this.lblDni.Text = "DNI:";
            this.lblDni.Location = new System.Drawing.Point(labelX, yBase + spacing * 2);
            this.txtDni.Location = new System.Drawing.Point(inputX, yBase + spacing * 2);

            this.lblTelefono.Text = "Teléfono Padres:";
            this.lblTelefono.Location = new System.Drawing.Point(labelX, yBase + spacing * 3);
            this.txtTelePadres.Location = new System.Drawing.Point(inputX, yBase + spacing * 3);

            this.lblInstrumento.Text = "Instrumento:";
            this.lblInstrumento.Location = new System.Drawing.Point(labelX, yBase + spacing * 4);
            this.cmbInstrumentos.Location = new System.Drawing.Point(inputX, yBase + spacing * 4);

            // 
            // Botones
            // 
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(116, 86, 174);
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.Location = new System.Drawing.Point(inputX, yBase + spacing * 5);
            this.btnGuardarCambios.Size = new System.Drawing.Size(150, 35);
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);

            this.btnVolver.Text = "Volver";
            this.btnVolver.BackColor = System.Drawing.Color.LightGray;
            this.btnVolver.Location = new System.Drawing.Point(inputX, yBase + spacing * 6);
            this.btnVolver.Size = new System.Drawing.Size(70, 30);
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // 
            // Form
            // 
            this.ClientSize = new System.Drawing.Size(580, 420);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lstAlumnosModificar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtTelePadres);
            this.Controls.Add(this.cmbInstrumentos);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblInstrumento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Alumnos";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            Load += new System.EventHandler(this.frmModificarAlumnos_Load);
        }
    }
}
