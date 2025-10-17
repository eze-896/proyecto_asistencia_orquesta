namespace GUI_Login
{
    partial class frmPrincipal
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
            menuStrip1 = new MenuStrip();
            menuGestion = new ToolStripMenuItem();
            menuAgregar = new ToolStripMenuItem();
            menuAlumnos = new ToolStripMenuItem();
            menuInstrumentos = new ToolStripMenuItem();
            menuProfesores = new ToolStripMenuItem();
            menuModificar = new ToolStripMenuItem();
            menuModificarAlumnos = new ToolStripMenuItem();
            menuModificarProfesores = new ToolStripMenuItem();
            menuModificarInstrumentos = new ToolStripMenuItem();
            menuEliminar = new ToolStripMenuItem();
            menuEliminarAlumnos = new ToolStripMenuItem();
            menuEliminarProfesores = new ToolStripMenuItem();
            menuEliminarInstrumentos = new ToolStripMenuItem();
            menuAsistencia = new ToolStripMenuItem();
            menuListados = new ToolStripMenuItem();
            menuListadoAlumnos = new ToolStripMenuItem();
            menuListadoProfesores = new ToolStripMenuItem();
            dgwTablaAsistencia = new DataGridView();
            btnSalir = new Button();
            label1 = new Label();
            panelHeader = new Panel();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwTablaAsistencia).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(116, 86, 174);
            menuStrip1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuGestion, menuAsistencia, menuListados });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(584, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuGestion
            // 
            menuGestion.DropDownItems.AddRange(new ToolStripItem[] { menuAgregar, menuModificar, menuEliminar });
            menuGestion.ForeColor = Color.White;
            menuGestion.Name = "menuGestion";
            menuGestion.Size = new Size(75, 21);
            menuGestion.Text = "GESTIÓN";
            // 
            // menuAgregar
            // 
            menuAgregar.BackColor = Color.FromArgb(116, 86, 174);
            menuAgregar.DropDownItems.AddRange(new ToolStripItem[] { menuAlumnos, menuInstrumentos, menuProfesores });
            menuAgregar.ForeColor = Color.White;
            menuAgregar.Name = "menuAgregar";
            menuAgregar.Size = new Size(180, 22);
            menuAgregar.Text = "➕ AGREGAR";
            // 
            // menuAlumnos
            // 
            menuAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuAlumnos.ForeColor = Color.White;
            menuAlumnos.Name = "menuAlumnos";
            menuAlumnos.Size = new Size(199, 22);
            menuAlumnos.Text = "👥 ALUMNOS";
            menuAlumnos.Click += menuAlumnos_Click;
            // 
            // menuInstrumentos
            // 
            menuInstrumentos.BackColor = Color.FromArgb(116, 86, 174);
            menuInstrumentos.ForeColor = Color.White;
            menuInstrumentos.Name = "menuInstrumentos";
            menuInstrumentos.Size = new Size(199, 22);
            menuInstrumentos.Text = "🎵 INSTRUMENTOS";
            menuInstrumentos.Click += menuInstrumentos_Click;
            // 
            // menuProfesores
            // 
            menuProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuProfesores.ForeColor = Color.White;
            menuProfesores.Name = "menuProfesores";
            menuProfesores.Size = new Size(199, 22);
            menuProfesores.Text = "👨‍🏫 PROFESORES";
            menuProfesores.Click += menuProfesor_Click;
            // 
            // menuModificar
            // 
            menuModificar.BackColor = Color.FromArgb(116, 86, 174);
            menuModificar.DropDownItems.AddRange(new ToolStripItem[] { menuModificarAlumnos, menuModificarProfesores, menuModificarInstrumentos });
            menuModificar.ForeColor = Color.White;
            menuModificar.Name = "menuModificar";
            menuModificar.Size = new Size(180, 22);
            menuModificar.Text = "✏️ MODIFICAR";
            // 
            // menuModificarAlumnos
            // 
            menuModificarAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuModificarAlumnos.ForeColor = Color.White;
            menuModificarAlumnos.Name = "menuModificarAlumnos";
            menuModificarAlumnos.Size = new Size(199, 22);
            menuModificarAlumnos.Text = "👥 ALUMNOS";
            menuModificarAlumnos.Click += menuModificarAlumnos_Click;
            // 
            // menuModificarProfesores
            // 
            menuModificarProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuModificarProfesores.ForeColor = Color.White;
            menuModificarProfesores.Name = "menuModificarProfesores";
            menuModificarProfesores.Size = new Size(199, 22);
            menuModificarProfesores.Text = "👨‍🏫 PROFESORES";
            // 
            // menuModificarInstrumentos
            // 
            menuModificarInstrumentos.BackColor = Color.FromArgb(116, 86, 174);
            menuModificarInstrumentos.ForeColor = Color.White;
            menuModificarInstrumentos.Name = "menuModificarInstrumentos";
            menuModificarInstrumentos.Size = new Size(199, 22);
            menuModificarInstrumentos.Text = "🎵 INSTRUMENTOS";
            // 
            // menuEliminar
            // 
            menuEliminar.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminar.DropDownItems.AddRange(new ToolStripItem[] { menuEliminarAlumnos, menuEliminarProfesores, menuEliminarInstrumentos });
            menuEliminar.ForeColor = Color.White;
            menuEliminar.Name = "menuEliminar";
            menuEliminar.Size = new Size(180, 22);
            menuEliminar.Text = "🗑️ ELIMINAR";
            // 
            // menuEliminarAlumnos
            // 
            menuEliminarAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarAlumnos.ForeColor = Color.White;
            menuEliminarAlumnos.Name = "menuEliminarAlumnos";
            menuEliminarAlumnos.Size = new Size(199, 22);
            menuEliminarAlumnos.Text = "👥 ALUMNOS";
            menuEliminarAlumnos.Click += menuEliminarAlumnos_Click;
            // 
            // menuEliminarProfesores
            // 
            menuEliminarProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarProfesores.ForeColor = Color.White;
            menuEliminarProfesores.Name = "menuEliminarProfesores";
            menuEliminarProfesores.Size = new Size(199, 22);
            menuEliminarProfesores.Text = "👨‍🏫 PROFESORES";
            // 
            // menuEliminarInstrumentos
            // 
            menuEliminarInstrumentos.BackColor = Color.FromArgb(116, 86, 174);
            menuEliminarInstrumentos.ForeColor = Color.White;
            menuEliminarInstrumentos.Name = "menuEliminarInstrumentos";
            menuEliminarInstrumentos.Size = new Size(199, 22);
            menuEliminarInstrumentos.Text = "🎵 INSTRUMENTOS";
            // 
            // menuAsistencia
            // 
            menuAsistencia.ForeColor = Color.White;
            menuAsistencia.Name = "menuAsistencia";
            menuAsistencia.Size = new Size(116, 21);
            menuAsistencia.Text = "📋 ASISTENCIA";
            menuAsistencia.Click += menuAsistencia_Click;
            // 
            // menuListados
            // 
            menuListados.DropDownItems.AddRange(new ToolStripItem[] { menuListadoAlumnos, menuListadoProfesores });
            menuListados.ForeColor = Color.White;
            menuListados.Name = "menuListados";
            menuListados.Size = new Size(104, 21);
            menuListados.Text = "📄 LISTADOS";
            // 
            // menuListadoAlumnos
            // 
            menuListadoAlumnos.BackColor = Color.FromArgb(116, 86, 174);
            menuListadoAlumnos.ForeColor = Color.White;
            menuListadoAlumnos.Name = "menuListadoAlumnos";
            menuListadoAlumnos.Size = new Size(178, 22);
            menuListadoAlumnos.Text = "👥 ALUMNOS";
            menuListadoAlumnos.Click += menuListadoAlumnos_Click;
            // 
            // menuListadoProfesores
            // 
            menuListadoProfesores.BackColor = Color.FromArgb(116, 86, 174);
            menuListadoProfesores.ForeColor = Color.White;
            menuListadoProfesores.Name = "menuListadoProfesores";
            menuListadoProfesores.Size = new Size(178, 22);
            menuListadoProfesores.Text = "👨‍🏫 PROFESORES";
            menuListadoProfesores.Click += menuListadoProfesores_Click;
            // 
            // dgwTablaAsistencia
            // 
            dgwTablaAsistencia.AllowUserToAddRows = false;
            dgwTablaAsistencia.BackgroundColor = Color.FromArgb(230, 231, 233);
            dgwTablaAsistencia.BorderStyle = BorderStyle.None;
            dgwTablaAsistencia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwTablaAsistencia.Location = new Point(34, 148);
            dgwTablaAsistencia.Name = "dgwTablaAsistencia";
            dgwTablaAsistencia.ReadOnly = true;
            dgwTablaAsistencia.Size = new Size(518, 269);
            dgwTablaAsistencia.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(538, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(30, 30);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "×";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 15);
            label1.Name = "label1";
            label1.Size = new Size(212, 30);
            label1.TabIndex = 3;
            label1.Text = "CONTROL GENERAL";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(116, 86, 174);
            panelHeader.Controls.Add(label2);
            panelHeader.Controls.Add(btnSalir);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 25);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(584, 70);
            panelHeader.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 45);
            label2.Name = "label2";
            label2.Size = new Size(321, 17);
            label2.TabIndex = 4;
            label2.Text = "Resumen de asistencias y porcentajes de los alumnos";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 441);
            Controls.Add(panelHeader);
            Controls.Add(dgwTablaAsistencia);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            MainMenuStrip = menuStrip1;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión Orquestal";
            Load += frmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwTablaAsistencia).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
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
        private ToolStripMenuItem menuModificarInstrumentos;
        private ToolStripMenuItem menuEliminar;
        private ToolStripMenuItem menuEliminarAlumnos;
        private ToolStripMenuItem menuEliminarProfesores;
        private ToolStripMenuItem menuEliminarInstrumentos;
        private ToolStripMenuItem menuAsistencia;
        private ToolStripMenuItem menuListados;
        private ToolStripMenuItem menuListadoAlumnos;
        private ToolStripMenuItem menuListadoProfesores;
        private DataGridView dgwTablaAsistencia;
        private Button btnSalir;
        private Label label1;
        private Panel panelHeader;
        private Label label2;
    }
}