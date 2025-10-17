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
            label3 = new Label();
            label1 = new Label();
            btnVolver = new Button();
            btnIngresar = new Button();
            cmbInstrumento = new ComboBox();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 83);
            label3.Name = "label3";
            label3.Size = new Size(0, 17);
            label3.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(116, 86, 174);
            label1.Location = new Point(34, 48);
            label1.Name = "label1";
            label1.Size = new Size(492, 19);
            label1.TabIndex = 30;
            label1.Text = "SELECCIONE EL NUEVO INSTRUMENTO A AGREGAR";
            // 
            // btnVolver
            // 
            btnVolver.BackColor = Color.FromArgb(116, 86, 174);
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.FlatAppearance.BorderSize = 0;
            btnVolver.FlatStyle = FlatStyle.Flat;
            btnVolver.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVolver.ForeColor = Color.White;
            btnVolver.Location = new Point(254, 143);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(203, 35);
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
            btnIngresar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(34, 143);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(203, 35);
            btnIngresar.TabIndex = 1;
            btnIngresar.Text = "INGRESAR INSTRUMENTO";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // cmbInstrumento
            // 
            cmbInstrumento.BackColor = Color.FromArgb(230, 231, 233);
            cmbInstrumento.FlatStyle = FlatStyle.Flat;
            cmbInstrumento.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbInstrumento.FormattingEnabled = true;
            cmbInstrumento.Location = new Point(34, 95);
            cmbInstrumento.Name = "cmbInstrumento";
            cmbInstrumento.Size = new Size(423, 24);
            cmbInstrumento.TabIndex = 0;
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
            btnSalir.TabIndex = 3;
            btnSalir.Text = "X";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmInstrumentos
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(514, 200);
            Controls.Add(btnSalir);
            Controls.Add(cmbInstrumento);
            Controls.Add(btnVolver);
            Controls.Add(btnIngresar);
            Controls.Add(label1);
            Controls.Add(label3);
            Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(164, 165, 169);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmInstrumentos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmInstrumentos";
            Load += frmInstrumentos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label1;
        private Button btnVolver;
        private Button btnIngresar;
        private ComboBox cmbInstrumento;
        private Button btnSalir;
    }
}