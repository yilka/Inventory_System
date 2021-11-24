
namespace Inventory_System.Formularios
{
    partial class FrmProveedorGestion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProveedorGestion));
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtContacto = new System.Windows.Forms.TextBox();
            this.CbActivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTelefono = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCedulaJ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.ColID_Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCedula_Juridica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContacto_Directo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CbVerProveedoresActivos = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtBuscar.Location = new System.Drawing.Point(84, 19);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(791, 29);
            this.TxtBuscar.TabIndex = 18;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(10, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Buscar";
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Sienna;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(1064, 564);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(95, 38);
            this.BtnCancelar.TabIndex = 16;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.BurlyWood;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnLimpiar.Location = new System.Drawing.Point(834, 564);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(190, 38);
            this.BtnLimpiar.TabIndex = 15;
            this.BtnLimpiar.Text = "Limpiar Formulario";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Sienna;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnEliminar.Location = new System.Drawing.Point(331, 564);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(95, 38);
            this.BtnEliminar.TabIndex = 14;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.BackColor = System.Drawing.Color.Tan;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnEditar.Location = new System.Drawing.Point(182, 564);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(95, 38);
            this.BtnEditar.TabIndex = 13;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.Peru;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAgregar.Location = new System.Drawing.Point(21, 564);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(95, 38);
            this.BtnAgregar.TabIndex = 12;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtContacto);
            this.groupBox1.Controls.Add(this.CbActivo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtEmail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtTelefono);
            this.groupBox1.Controls.Add(this.TxtDireccion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtCedulaJ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(10, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1171, 252);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Proveedor";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(626, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 24);
            this.label11.TabIndex = 21;
            this.label11.Text = "Contacto Directo";
            // 
            // TxtContacto
            // 
            this.TxtContacto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtContacto.Location = new System.Drawing.Point(630, 62);
            this.TxtContacto.Name = "TxtContacto";
            this.TxtContacto.Size = new System.Drawing.Size(198, 29);
            this.TxtContacto.TabIndex = 20;
            // 
            // CbActivo
            // 
            this.CbActivo.AutoSize = true;
            this.CbActivo.Location = new System.Drawing.Point(1047, 209);
            this.CbActivo.Name = "CbActivo";
            this.CbActivo.Size = new System.Drawing.Size(80, 28);
            this.CbActivo.TabIndex = 19;
            this.CbActivo.Text = "Activo";
            this.CbActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(324, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Correo Electrónico";
            // 
            // TxtEmail
            // 
            this.TxtEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtEmail.Location = new System.Drawing.Point(328, 144);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(198, 29);
            this.TxtEmail.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(924, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dirección";
            // 
            // TxtTelefono
            // 
            this.TxtTelefono.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtTelefono.Location = new System.Drawing.Point(630, 144);
            this.TxtTelefono.Name = "TxtTelefono";
            this.TxtTelefono.Size = new System.Drawing.Size(198, 29);
            this.TxtTelefono.TabIndex = 6;
            this.TxtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTelefono_KeyPress);
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtDireccion.Location = new System.Drawing.Point(928, 62);
            this.TxtDireccion.Multiline = true;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtDireccion.Size = new System.Drawing.Size(199, 111);
            this.TxtDireccion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Teléfono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cédula Jurídica ";
            // 
            // TxtCedulaJ
            // 
            this.TxtCedulaJ.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtCedulaJ.Location = new System.Drawing.Point(18, 144);
            this.TxtCedulaJ.Name = "TxtCedulaJ";
            this.TxtCedulaJ.Size = new System.Drawing.Size(198, 29);
            this.TxtCedulaJ.TabIndex = 4;
            this.TxtCedulaJ.Tag = "Requerido";
            this.TxtCedulaJ.TextChanged += new System.EventHandler(this.TxtCedulaJ_TextChanged);
            this.TxtCedulaJ.Enter += new System.EventHandler(this.TxtCedulaJ_Enter);
            this.TxtCedulaJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCedulaJ_KeyPress);
            this.TxtCedulaJ.Leave += new System.EventHandler(this.TxtCedulaJ_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // TxtNombre
            // 
            this.TxtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtNombre.Location = new System.Drawing.Point(328, 62);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(199, 29);
            this.TxtNombre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // TxtID
            // 
            this.TxtID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtID.Location = new System.Drawing.Point(17, 62);
            this.TxtID.Name = "TxtID";
            this.TxtID.ReadOnly = true;
            this.TxtID.Size = new System.Drawing.Size(199, 29);
            this.TxtID.TabIndex = 0;
            // 
            // DgvLista
            // 
            this.DgvLista.AllowUserToAddRows = false;
            this.DgvLista.AllowUserToDeleteRows = false;
            this.DgvLista.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID_Proveedor,
            this.ColCedula_Juridica,
            this.ColNombre,
            this.ColContacto_Directo,
            this.ColTelefono});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvLista.Location = new System.Drawing.Point(14, 70);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.ReadOnly = true;
            this.DgvLista.RowHeadersVisible = false;
            this.DgvLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLista.Size = new System.Drawing.Size(1171, 198);
            this.DgvLista.TabIndex = 10;
            this.DgvLista.VirtualMode = true;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLista_CellClick);
            // 
            // ColID_Proveedor
            // 
            this.ColID_Proveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColID_Proveedor.DataPropertyName = "ID_Proveedor";
            this.ColID_Proveedor.HeaderText = "Código";
            this.ColID_Proveedor.Name = "ColID_Proveedor";
            this.ColID_Proveedor.ReadOnly = true;
            // 
            // ColCedula_Juridica
            // 
            this.ColCedula_Juridica.DataPropertyName = "Cedula_Juridica";
            this.ColCedula_Juridica.HeaderText = "Cédula";
            this.ColCedula_Juridica.Name = "ColCedula_Juridica";
            this.ColCedula_Juridica.ReadOnly = true;
            this.ColCedula_Juridica.Width = 200;
            // 
            // ColNombre
            // 
            this.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombre.DataPropertyName = "Nombre";
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColContacto_Directo
            // 
            this.ColContacto_Directo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColContacto_Directo.DataPropertyName = "Contacto_Directo";
            this.ColContacto_Directo.HeaderText = "Contacto Directo";
            this.ColContacto_Directo.Name = "ColContacto_Directo";
            this.ColContacto_Directo.ReadOnly = true;
            this.ColContacto_Directo.Width = 349;
            // 
            // ColTelefono
            // 
            this.ColTelefono.DataPropertyName = "Telefono";
            this.ColTelefono.HeaderText = "Teléfono";
            this.ColTelefono.Name = "ColTelefono";
            this.ColTelefono.ReadOnly = true;
            this.ColTelefono.Width = 250;
            // 
            // CbVerProveedoresActivos
            // 
            this.CbVerProveedoresActivos.AutoSize = true;
            this.CbVerProveedoresActivos.Checked = true;
            this.CbVerProveedoresActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerProveedoresActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbVerProveedoresActivos.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CbVerProveedoresActivos.Location = new System.Drawing.Point(995, 42);
            this.CbVerProveedoresActivos.Name = "CbVerProveedoresActivos";
            this.CbVerProveedoresActivos.Size = new System.Drawing.Size(190, 22);
            this.CbVerProveedoresActivos.TabIndex = 19;
            this.CbVerProveedoresActivos.Text = "Ver Proveedores Activos";
            this.CbVerProveedoresActivos.UseVisualStyleBackColor = true;
            this.CbVerProveedoresActivos.CheckedChanged += new System.EventHandler(this.CbVerProveedoresActivos_CheckedChanged);
            // 
            // FrmProveedorGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 620);
            this.Controls.Add(this.CbVerProveedoresActivos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvLista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmProveedorGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Proveedor";
            this.Load += new System.EventHandler(this.FrmProveedorGestion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CbActivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtTelefono;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCedulaJ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtContacto;
        private System.Windows.Forms.CheckBox CbVerProveedoresActivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCedula_Juridica;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContacto_Directo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefono;
    }
}