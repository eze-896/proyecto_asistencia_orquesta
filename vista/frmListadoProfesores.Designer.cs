namespace GUI_Login.vista
{
    partial class frmListadoProfesores
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelHeader;
        private Label labelTitulo;
        private Label labelDescripcion;
        private Button btnVolver;
        private DataGridView dgvProfesores;

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
            dgvProfesores = new DataGridView();

            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).BeginInit();
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
            labelTitulo.Size = new Size(256, 30);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "LISTADO DE PROFESORES";

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
            labelDescripcion.Text = "Visualice todos los profesores registrados en el sistema";

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
            // dgvProfesores
            // 
            dgvProfesores.AllowUserToAddRows = false;
            dgvProfesores.AllowUserToDeleteRows = false;
            dgvProfesores.AllowUserToResizeRows = false;
            dgvProfesores.BackgroundColor = Color.FromArgb(230, 231, 233);
            dgvProfesores.BorderStyle = BorderStyle.None;
            dgvProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesores.Location = new Point(20, 90);
            dgvProfesores.MultiSelect = false;
            dgvProfesores.Name = "dgvProfesores";
            dgvProfesores.ReadOnly = true;
            dgvProfesores.RowHeadersVisible = false;
            dgvProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProfesores.Size = new Size(560, 320);
            dgvProfesores.TabIndex = 3;
            dgvProfesores.TabStop = true;

            // 
            // frmListadoProfesores
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 450);
            Controls.Add(dgvProfesores);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Name = "frmListadoProfesores";
            Text = "Listado de Profesores";
            KeyPreview = true;
            Load += frmListadoProfesores_Load;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProfesores).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
