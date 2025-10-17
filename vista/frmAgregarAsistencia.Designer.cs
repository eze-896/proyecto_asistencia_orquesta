namespace GUI_Login.vista
{
    partial class frmAgregarAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarAsistencia));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            datePicker = new DateTimePicker();
            cmbActividad = new ComboBox();
            chkListaAlumnos = new CheckedListBox();
            btnVolver = new Button();
            btnGuardar = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            btnCerrar = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            label1.Text = "Registro de Asistencias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(116, 86, 174);
            label2.Location = new Point(50, 140);
            label2.Name = "label2";
            label2.Size = new Size(42, 17);
            label2.TabIndex = 15;
            label2.Text = "Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(116, 86, 174);
            label3.Location = new Point(50, 210);
            label3.Name = "label3";
            label3.Size = new Size(65, 17);
            label3.TabIndex = 16;
            label3.Text = "Actividad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(116, 86, 174);
            label4.Location = new Point(300, 140);
            label4.Name = "label4";
            label4.Size = new Size(140, 17);
            label4.TabIndex = 17;
            label4.Text = "Alumnos que asistieron";
            // 
            // datePicker
            // 
            datePicker.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePicker.CalendarForeColor = Color.FromArgb(64, 64, 64);
            datePicker.CalendarMonthBackground = Color.FromArgb(240, 242, 245);
            datePicker.CalendarTitleBackColor = Color.FromArgb(116, 86, 174);
            datePicker.CalendarTitleForeColor = Color.White;
            datePicker.CalendarTrailingForeColor = Color.Gray;
            datePicker.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            datePicker.Format = DateTimePickerFormat.Short;
            datePicker.Location = new Point(50, 165);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(220, 27);
            datePicker.TabIndex = 0;
            // 
            // cmbActividad
            // 
            cmbActividad.BackColor = Color.FromArgb(240, 242, 245);
            cmbActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActividad.FlatStyle = FlatStyle.Flat;
            cmbActividad.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbActividad.ForeColor = Color.FromArgb(64, 64, 64);
            cmbActividad.FormattingEnabled = true;
            cmbActividad.Location = new Point(50, 235);
            cmbActividad.Name = "cmbActividad";
            cmbActividad.Size = new Size(220, 28);
            cmbActividad.TabIndex = 1;
            // 
            // chkListaAlumnos
            // 
            chkListaAlumnos.BackColor = Color.FromArgb(240, 242, 245);
            chkListaAlumnos.BorderStyle = BorderStyle.None;
            chkListaAlumnos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkListaAlumnos.ForeColor = Color.FromArgb(64, 64, 64);
            chkListaAlumnos.FormattingEnabled = true;
            chkListaAlumnos.Location = new Point(300, 165);
            chkListaAlumnos.Name = "chkListaAlumnos";
            chkListaAlumnos.ScrollAlwaysVisible = true;
            chkListaAlumnos.Size = new Size(220, 216);
            chkListaAlumnos.TabIndex = 2;
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
            btnVolver.TabIndex = 4;
            btnVolver.Text = "↩ VOLVER";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(116, 86, 174);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 68, 140);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(50, 430);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(220, 40);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "💾 GUARDAR ASISTENCIAS";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
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
            label7.Size = new Size(265, 30);
            label7.TabIndex = 0;
            label7.Text = "Control de Asistencias 📋";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(530, 15);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.TabIndex = 5;
            btnCerrar.Text = "×";
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(116, 86, 174);
            panel2.Location = new Point(50, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(220, 2);
            panel2.TabIndex = 21;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(116, 86, 174);
            panel3.Location = new Point(300, 387);
            panel3.Name = "panel3";
            panel3.Size = new Size(220, 2);
            panel3.TabIndex = 22;
            // 
            // frmAsistencia
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(572, 500);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnCerrar);
            Controls.Add(panel1);
            Controls.Add(btnVolver);
            Controls.Add(btnGuardar);
            Controls.Add(chkListaAlumnos);
            Controls.Add(cmbActividad);
            Controls.Add(datePicker);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAsistencia";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de Asistencias";
            Load += frmAsistencia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker datePicker;
        private ComboBox cmbActividad;
        private CheckedListBox chkListaAlumnos;
        private Button btnVolver;
        private Button btnGuardar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label7;
        private Button btnCerrar;
        private Panel panel2;
        private Panel panel3;
    }
}