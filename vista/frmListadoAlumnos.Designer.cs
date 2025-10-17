namespace GUI_Login.vista
{
    partial class frmListadoAlumnos
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label labelTitulo;
        private Label labelDescripcion;
        private Button btnVolver;
        private DataGridView dgwAlumnos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            labelTitulo = new Label();
            labelDescripcion = new Label();
            btnVolver = new Button();
            dgwAlumnos = new DataGridView();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAlumnos).BeginInit();
            SuspendLayout();

            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(116, 86, 174);
            panelHeader.Controls.Add(labelTitulo);
            panelHeader.Controls.Add(labelDescripcion);
            panelHeader.Controls.Add(btnVolver);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 70);
            panelHeader.TabIndex = 0;

            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labelTitulo.ForeColor = Color.White;
            labelTitulo.Location = new Point(20, 8);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(239, 30);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "LISTADO DE ALUMNOS";

            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelDescripcion.ForeColor = Color.White;
            labelDescripcion.Location = new Point(22, 40);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(330, 19);
            labelDescripcion.TabIndex = 1;
            labelDescripcion.Text = "Visualice todos los alumnos registrados en el sistema";

            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.Transparent;
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128);
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(550, 15);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(35, 30);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "←";
            btnVolver.UseVisualStyleBackColor = false;
            btnVolver.Click += btnVolver_Click;

            // 
            // dgwAlumnos
            // 
            dgwAlumnos.AllowUserToAddRows = false;
            dgwAlumnos.AllowUserToDeleteRows = false;
            dgwAlumnos.AllowUserToResizeRows = false;
            dgwAlumnos.BackgroundColor = Color.FromArgb(230, 231, 233);
            dgwAlumnos.BorderStyle = BorderStyle.None;
            dgwAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwAlumnos.Location = new Point(20, 90);
            dgwAlumnos.MultiSelect = false;
            dgwAlumnos.Name = "dgwAlumnos";
            dgwAlumnos.ReadOnly = true;
            dgwAlumnos.RowHeadersVisible = false;
            dgwAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwAlumnos.Size = new Size(560, 320);
            dgwAlumnos.TabIndex = 3;
            dgwAlumnos.TabStop = true;

            // 
            // frmListadoAlumnos
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 450);
            Controls.Add(dgwAlumnos);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "frmListadoAlumnos";
            Text = "Listado de Alumnos";
            KeyPreview = true;
            Load += frmListadoAlumnos_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgwAlumnos).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
