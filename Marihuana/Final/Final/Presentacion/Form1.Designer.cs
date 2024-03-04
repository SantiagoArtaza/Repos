namespace Final
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboMedicos = new ComboBox();
            txtPaciente = new TextBox();
            txtMotivoconsulta = new TextBox();
            dtpFecha = new DateTimePicker();
            dgvTurnos = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            ColMedico = new DataGridViewTextBoxColumn();
            ColMotivo = new DataGridViewTextBoxColumn();
            ColFecha = new DataGridViewTextBoxColumn();
            ColHora = new DataGridViewTextBoxColumn();
            ColAcciones = new DataGridViewButtonColumn();
            btnAgregar = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtHora = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).BeginInit();
            SuspendLayout();
            // 
            // cboMedicos
            // 
            cboMedicos.FormattingEnabled = true;
            cboMedicos.Location = new Point(56, 97);
            cboMedicos.Name = "cboMedicos";
            cboMedicos.Size = new Size(218, 23);
            cboMedicos.TabIndex = 0;
            // 
            // txtPaciente
            // 
            txtPaciente.Location = new Point(56, 51);
            txtPaciente.Name = "txtPaciente";
            txtPaciente.Size = new Size(417, 23);
            txtPaciente.TabIndex = 1;
            // 
            // txtMotivoconsulta
            // 
            txtMotivoconsulta.Location = new Point(56, 145);
            txtMotivoconsulta.Name = "txtMotivoconsulta";
            txtMotivoconsulta.Size = new Size(417, 23);
            txtMotivoconsulta.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(56, 201);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(149, 23);
            dtpFecha.TabIndex = 4;
            // 
            // dgvTurnos
            // 
            dgvTurnos.AllowUserToAddRows = false;
            dgvTurnos.AllowUserToDeleteRows = false;
            dgvTurnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnos.Columns.AddRange(new DataGridViewColumn[] { Id, ColMedico, ColMotivo, ColFecha, ColHora, ColAcciones });
            dgvTurnos.Location = new Point(56, 245);
            dgvTurnos.Name = "dgvTurnos";
            dgvTurnos.ReadOnly = true;
            dgvTurnos.RowTemplate.Height = 25;
            dgvTurnos.Size = new Size(543, 150);
            dgvTurnos.TabIndex = 5;
            dgvTurnos.CellContentClick += dgvTurnos_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            // 
            // ColMedico
            // 
            ColMedico.HeaderText = "Medico";
            ColMedico.Name = "ColMedico";
            ColMedico.ReadOnly = true;
            // 
            // ColMotivo
            // 
            ColMotivo.HeaderText = "MOTIVO CONSULTA";
            ColMotivo.Name = "ColMotivo";
            ColMotivo.ReadOnly = true;
            // 
            // ColFecha
            // 
            ColFecha.HeaderText = "FECHA";
            ColFecha.Name = "ColFecha";
            ColFecha.ReadOnly = true;
            // 
            // ColHora
            // 
            ColHora.HeaderText = "HORA";
            ColHora.Name = "ColHora";
            ColHora.ReadOnly = true;
            // 
            // ColAcciones
            // 
            ColAcciones.HeaderText = "ACCIONES";
            ColAcciones.Name = "ColAcciones";
            ColAcciones.ReadOnly = true;
            ColAcciones.Resizable = DataGridViewTriState.True;
            ColAcciones.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(490, 200);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(109, 23);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(233, 423);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(379, 423);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(277, 201);
            txtHora.Name = "txtHora";
            txtHora.Size = new Size(196, 23);
            txtHora.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 516);
            Controls.Add(txtHora);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTurnos);
            Controls.Add(dtpFecha);
            Controls.Add(txtMotivoconsulta);
            Controls.Add(txtPaciente);
            Controls.Add(cboMedicos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvTurnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboMedicos;
        private TextBox txtPaciente;
        private TextBox txtMotivoconsulta;
        private DateTimePicker dtpFecha;
        private DataGridView dgvTurnos;
        private Button btnAgregar;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn ColMedico;
        private DataGridViewTextBoxColumn ColMotivo;
        private DataGridViewTextBoxColumn ColFecha;
        private DataGridViewTextBoxColumn ColHora;
        private DataGridViewButtonColumn ColAcciones;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtHora;
    }
}