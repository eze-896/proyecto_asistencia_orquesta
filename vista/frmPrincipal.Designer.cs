namespace GUI_Login
{
    partial class FrmPrincipal
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            menuGestion = new ToolStripMenuItem();
            menuAgregar = new ToolStripMenuItem();
            menuAlumnos = new ToolStripMenuItem();
            menuInstrumentos = new ToolStripMenuItem();
            menuProfesores = new ToolStripMenuItem();
            menuModificar = new ToolStripMenuItem();
            menuModificarAlumnos = new ToolStripMenuItem();
            menuModificarProfesores = new ToolStripMenuItem();
            menuEliminar = new ToolStripMenuItem();
            menuEliminarAlumnos = new ToolStripMenuItem();
            menuEliminarProfesores = new ToolStripMenuItem();
            menuEliminarInstrumentos = new ToolStripMenuItem();
            menuAsistencia = new ToolStripMenuItem();
            menuListados = new ToolStripMenuItem();
            menuListadoAlumnos = new ToolStripMenuItem();
            menuListadoProfesores = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblSubtitulo = new Label();
            btnSalir = new Button();
            lblTitulo = new Label();
            panelMain = new Panel();
            panelGrid = new Panel();
            lblGridTitle = new Label();
            dgwTablaAsistencia = new DataGridView();
            menuStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwTablaAsistencia).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(116, 86, 174);
            menuStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuGestion, menuAsistencia, menuListados });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuGestion
            // 
            menuGestion.DropDownItems.AddRange(new ToolStripItem[] { menuAgregar, menuModificar, menuEliminar });
            menuGestion.ForeColor = Color.White;
            menuGestion.Name = "menuGestion";
            menuGestion.Size = new Size(85, 24);
            menuGestion.Text = "GESTIÓN";
            // 
            // menuAgregar
            // 
            menuAgregar.BackColor = Color.FromArgb(116, 86, 174);
            menuAgregar.DropDownItems.AddRange(new ToolStripItem[] { menuAlumnos, menuInstrumentos, menuProfesores });
            menuAgregar.ForeColor = Color.White;
            menuAgregar.Name = "menuAgregar";
            menuAgregar.Size = new Size(188, 24);
            menuAgregar.Text = "➕ AGREGAR";
            // 
            // menuAlumnos
            // 
            menuAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuAlumnos.ForeColor = Color.White;
            menuAlumnos.Name = "menuAlumnos";
            menuAlumnos.Size = new Size(220, 24);
            menuAlumnos.Text = "👥 ALUMNOS";
            menuAlumnos.Click += MenuAlumnos_Click;
            // 
            // menuInstrumentos
            // 
            menuInstrumentos.BackColor = Color.FromArgb(116, 86, 174);
            menuInstrumentos.ForeColor = Color.White;
            menuInstrumentos.Name = "menuInstrumentos";
            menuInstrumentos.Size = new Size(220, 24);
            menuInstrumentos.Text = "🎵 INSTRUMENTOS";
            menuInstrumentos.Click += MenuInstrumentos_Click;
            // 
            // menuProfesores
            // 
            menuProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuProfesores.ForeColor = Color.White;
            menuProfesores.Name = "menuProfesores";
            menuProfesores.Size = new Size(220, 24);
            menuProfesores.Text = "👨‍🏫 PROFESORES";
            menuProfesores.Click += MenuProfesor_Click;
            // 
            // menuModificar
            // 
            menuModificar.BackColor = Color.FromArgb(116, 86, 174);
            menuModificar.DropDownItems.AddRange(new ToolStripItem[] { menuModificarAlumnos, menuModificarProfesores });
            menuModificar.ForeColor = Color.White;
            menuModificar.Name = "menuModificar";
            menuModificar.Size = new Size(188, 24);
            menuModificar.Text = "✏️ MODIFICAR";
            // 
            // menuModificarAlumnos
            // 
            menuModificarAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuModificarAlumnos.ForeColor = Color.White;
            menuModificarAlumnos.Name = "menuModificarAlumnos";
            menuModificarAlumnos.Size = new Size(195, 24);
            menuModificarAlumnos.Text = "👥 ALUMNOS";
            menuModificarAlumnos.Click += MenuModificarAlumnos_Click;
            // 
            // menuModificarProfesores
            // 
            menuModificarProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuModificarProfesores.ForeColor = Color.White;
            menuModificarProfesores.Name = "menuModificarProfesores";
            menuModificarProfesores.Size = new Size(195, 24);
            menuModificarProfesores.Text = "👨‍🏫 PROFESORES";
            menuModificarProfesores.Click += MenuModificarProfesores_Click;
            // 
            // menuEliminar
            // 
            menuEliminar.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminar.DropDownItems.AddRange(new ToolStripItem[] { menuEliminarAlumnos, menuEliminarProfesores, menuEliminarInstrumentos });
            menuEliminar.ForeColor = Color.White;
            menuEliminar.Name = "menuEliminar";
            menuEliminar.Size = new Size(188, 24);
            menuEliminar.Text = "🗑️ ELIMINAR";
            // 
            // menuEliminarAlumnos
            // 
            menuEliminarAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarAlumnos.ForeColor = Color.White;
            menuEliminarAlumnos.Name = "menuEliminarAlumnos";
            menuEliminarAlumnos.Size = new Size(220, 24);
            menuEliminarAlumnos.Text = "👥 ALUMNOS";
            menuEliminarAlumnos.Click += MenuEliminarAlumnos_Click;
            // 
            // menuEliminarProfesores
            // 
            menuEliminarProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarProfesores.ForeColor = Color.White;
            menuEliminarProfesores.Name = "menuEliminarProfesores";
            menuEliminarProfesores.Size = new Size(220, 24);
            menuEliminarProfesores.Text = "👨‍🏫 PROFESORES";
            menuEliminarProfesores.Click += MenuEliminarProfesores_Click;
            // 
            // menuEliminarInstrumentos
            // 
            menuEliminarInstrumentos.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarInstrumentos.ForeColor = Color.White;
            menuEliminarInstrumentos.Name = "menuEliminarInstrumentos";
            menuEliminarInstrumentos.Size = new Size(220, 24);
            menuEliminarInstrumentos.Text = "🎵 INSTRUMENTOS";
            menuEliminarInstrumentos.Click += MenuEliminarInstrumentos_Click;
            // 
            // menuAsistencia
            // 
            menuAsistencia.ForeColor = Color.White;
            menuAsistencia.Name = "menuAsistencia";
            menuAsistencia.Size = new Size(133, 24);
            menuAsistencia.Text = "📋 ASISTENCIA";
            menuAsistencia.Click += MenuAsistencia_Click;
            // 
            // menuListados
            // 
            menuListados.DropDownItems.AddRange(new ToolStripItem[] { menuListadoAlumnos, menuListadoProfesores });
            menuListados.ForeColor = Color.White;
            menuListados.Name = "menuListados";
            menuListados.Size = new Size(117, 24);
            menuListados.Text = "📄 LISTADOS";
            // 
            // menuListadoAlumnos
            // 
            menuListadoAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuListadoAlumnos.ForeColor = Color.White;
            menuListadoAlumnos.Name = "menuListadoAlumnos";
            menuListadoAlumnos.Size = new Size(195, 24);
            menuListadoAlumnos.Text = "👥 ALUMNOS";
            menuListadoAlumnos.Click += MenuListadoAlumnos_Click;
            // 
            // menuListadoProfesores
            // 
            menuListadoProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuListadoProfesores.ForeColor = Color.White;
            menuListadoProfesores.Name = "menuListadoProfesores";
            menuListadoProfesores.Size = new Size(195, 24);
            menuListadoProfesores.Text = "👨‍🏫 PROFESORES";
            menuListadoProfesores.Click += MenuListadoProfesores_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(116, 86, 174);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(btnSalir);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 28);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 120);
            panelHeader.TabIndex = 4;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(40, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(379, 21);
            lblSubtitulo.TabIndex = 4;
            lblSubtitulo.Text = "Resumen de asistencias y porcentajes de los alumnos";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(850, 20);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(40, 40);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "×";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(35, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 45);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "CONTROL GENERAL";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 248, 252);
            panelMain.Controls.Add(panelGrid);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 148);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(30);
            panelMain.Size = new Size(900, 552);
            panelMain.TabIndex = 5;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(lblGridTitle);
            panelGrid.Controls.Add(dgwTablaAsistencia);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(30, 30);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(840, 492);
            panelGrid.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGridTitle.ForeColor = Color.FromArgb(116, 86, 174);
            lblGridTitle.Location = new Point(25, 20);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(258, 30);
            lblGridTitle.TabIndex = 1;
            lblGridTitle.Text = "Resumen de Asistencias";
            // 
            // dgwTablaAsistencia
            // 
            dgwTablaAsistencia.AllowUserToAddRows = false;
            dgwTablaAsistencia.AllowUserToDeleteRows = false;
            dgwTablaAsistencia.AllowUserToResizeRows = false;
            dgwTablaAsistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwTablaAsistencia.BackgroundColor = Color.White;
            dgwTablaAsistencia.BorderStyle = BorderStyle.None;
            dgwTablaAsistencia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgwTablaAsistencia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(116, 86, 174);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(8);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgwTablaAsistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgwTablaAsistencia.ColumnHeadersHeight = 50;
            dgwTablaAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(164, 165, 169);
            dataGridViewCellStyle2.Padding = new Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(230, 225, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgwTablaAsistencia.DefaultCellStyle = dataGridViewCellStyle2;
            dgwTablaAsistencia.EnableHeadersVisualStyles = false;
            dgwTablaAsistencia.GridColor = Color.FromArgb(240, 240, 240);
            dgwTablaAsistencia.Location = new Point(25, 65);
            dgwTablaAsistencia.Name = "dgwTablaAsistencia";
            dgwTablaAsistencia.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgwTablaAsistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgwTablaAsistencia.RowHeadersVisible = false;
            dgwTablaAsistencia.RowTemplate.Height = 40;
            dgwTablaAsistencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwTablaAsistencia.Size = new Size(790, 400);
            dgwTablaAsistencia.TabIndex = 0;
            dgwTablaAsistencia.Sorted += DgwTablaAsistencia_Sorted;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión Orquestal";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwTablaAsistencia).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuGestion;
        private ToolStripMenuItem menuAgregar;
        private ToolStripMenuItem menuAlumnos;
        private ToolStripMenuItem menuInstrumentos;
        private ToolStripMenuItem menuProfesores;
        private ToolStripMenuItem menuModificar;
        private ToolStripMenuItem menuModificarAlumnos;
        private ToolStripMenuItem menuModificarProfesores;
        private ToolStripMenuItem menuEliminar;
        private ToolStripMenuItem menuEliminarAlumnos;
        private ToolStripMenuItem menuEliminarProfesores;
        private ToolStripMenuItem menuEliminarInstrumentos;
        private ToolStripMenuItem menuAsistencia;
        private ToolStripMenuItem menuListados;
        private ToolStripMenuItem menuListadoAlumnos;
        private ToolStripMenuItem menuListadoProfesores;
        private Panel panelHeader;
        private Label lblSubtitulo;
        private Button btnSalir;
        private Label lblTitulo;
        private Panel panelMain;
        private Panel panelGrid;
        private Label lblGridTitle;
        private DataGridView dgwTablaAsistencia;
    }
}