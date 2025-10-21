namespace GUI_Login.vista
{
    partial class frmAgregarInstrumentos
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
            lblSubtitulo = new Label();
            btnSalir = new Button();
            lblTitulo = new Label();
            panelMain = new Panel();
            panelForm = new Panel();
            cmbInstrumento = new ComboBox();
            btnVolver = new Button();
            btnIngresar = new Button();
            label1 = new Label();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelForm.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(116, 86, 174);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(btnSalir);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 120);
            panelHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(40, 75);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(309, 21);
            lblSubtitulo.TabIndex = 4;
            lblSubtitulo.Text = "Agregar nuevos instrumentos a la orquesta";
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
            btnSalir.Location = new Point(550, 20);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(40, 40);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "×";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(35, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(411, 45);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "AGREGAR INSTRUMENTO";
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(248, 248, 252);
            panelMain.Controls.Add(panelForm);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 120);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(30);
            panelMain.Size = new Size(600, 280);
            panelMain.TabIndex = 1;
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.White;
            panelForm.Controls.Add(cmbInstrumento);
            panelForm.Controls.Add(btnVolver);
            panelForm.Controls.Add(btnIngresar);
            panelForm.Controls.Add(label1);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(30, 30);
            panelForm.Name = "panelForm";
            panelForm.Padding = new Padding(20);
            panelForm.Size = new Size(540, 220);
            panelForm.TabIndex = 0;
            // 
            // cmbInstrumento
            // 
            cmbInstrumento.BackColor = Color.FromArgb(230, 231, 233);
            cmbInstrumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInstrumento.FlatStyle = FlatStyle.Flat;
            cmbInstrumento.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbInstrumento.FormattingEnabled = true;
            cmbInstrumento.Location = new Point(50, 80);
            cmbInstrumento.Name = "cmbInstrumento";
            cmbInstrumento.Size = new Size(440, 28);
            cmbInstrumento.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(116, 86, 174);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(287, 140);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(203, 40);
            btnVolver.TabIndex = 2;
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
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(50, 140);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(203, 40);
            btnIngresar.TabIndex = 1;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(45, 30);
            label1.Name = "label1";
            label1.Size = new Size(469, 25);
            label1.TabIndex = 30;
            label1.Text = "SELECCIONE EL NUEVO INSTRUMENTO A AGREGAR";
            // 
            // frmAgregarInstrumentos
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 400);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAgregarInstrumentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Instrumentos";
            Load += frmAgregarInstrumentos_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Label lblSubtitulo;
        private Button btnSalir;
        private Label lblTitulo;
        private Panel panelMain;
        private Panel panelForm;
        private ComboBox cmbInstrumento;
        private Button btnVolver;
        private Button btnIngresar;
        private Label label1;
    }
}