﻿
namespace Inventory_System.Formularios
{
    partial class FrmUsoMateriaPrima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsoMateriaPrima));
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCrearUso = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DgvListaMaterias = new System.Windows.Forms.DataGridView();
            this.ColID_Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEliminarMateria = new System.Windows.Forms.Button();
            this.BtnAgregarMateria = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtDetalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMaterias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(17, 619);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(99, 38);
            this.BtnCancelar.TabIndex = 23;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCrearUso
            // 
            this.BtnCrearUso.BackColor = System.Drawing.Color.SlateGray;
            this.BtnCrearUso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearUso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearUso.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCrearUso.Location = new System.Drawing.Point(763, 597);
            this.BtnCrearUso.Name = "BtnCrearUso";
            this.BtnCrearUso.Size = new System.Drawing.Size(159, 38);
            this.BtnCrearUso.TabIndex = 22;
            this.BtnCrearUso.Text = "Crear Uso";
            this.BtnCrearUso.UseVisualStyleBackColor = false;
            this.BtnCrearUso.Click += new System.EventHandler(this.BtnCrearUso_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtTotal.Location = new System.Drawing.Point(691, 549);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(231, 29);
            this.TxtTotal.TabIndex = 21;
            this.TxtTotal.Text = "0";
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(574, 552);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Valor Total";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DgvListaMaterias);
            this.groupBox2.Controls.Add(this.BtnEliminarMateria);
            this.groupBox2.Controls.Add(this.BtnAgregarMateria);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(917, 383);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // DgvListaMaterias
            // 
            this.DgvListaMaterias.AllowUserToAddRows = false;
            this.DgvListaMaterias.AllowUserToDeleteRows = false;
            this.DgvListaMaterias.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListaMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListaMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaMaterias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID_Materia,
            this.ColNombre,
            this.ColCantidad,
            this.ColTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListaMaterias.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListaMaterias.Location = new System.Drawing.Point(6, 62);
            this.DgvListaMaterias.MultiSelect = false;
            this.DgvListaMaterias.Name = "DgvListaMaterias";
            this.DgvListaMaterias.ReadOnly = true;
            this.DgvListaMaterias.RowHeadersVisible = false;
            this.DgvListaMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaMaterias.Size = new System.Drawing.Size(905, 304);
            this.DgvListaMaterias.TabIndex = 3;
            this.DgvListaMaterias.VirtualMode = true;
            // 
            // ColID_Materia
            // 
            this.ColID_Materia.DataPropertyName = "ID_Materia";
            this.ColID_Materia.HeaderText = "Código";
            this.ColID_Materia.Name = "ColID_Materia";
            this.ColID_Materia.ReadOnly = true;
            // 
            // ColNombre
            // 
            this.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombre.DataPropertyName = "Nombre";
            this.ColNombre.HeaderText = "Materia Prima";
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColCantidad
            // 
            this.ColCantidad.DataPropertyName = "Cantidad";
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            // 
            // ColTotal
            // 
            this.ColTotal.DataPropertyName = "Total";
            this.ColTotal.HeaderText = "Precio";
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            // 
            // BtnEliminarMateria
            // 
            this.BtnEliminarMateria.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnEliminarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminarMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminarMateria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnEliminarMateria.Location = new System.Drawing.Point(238, 18);
            this.BtnEliminarMateria.Name = "BtnEliminarMateria";
            this.BtnEliminarMateria.Size = new System.Drawing.Size(220, 38);
            this.BtnEliminarMateria.TabIndex = 2;
            this.BtnEliminarMateria.Text = "Eliminar Materia";
            this.BtnEliminarMateria.UseVisualStyleBackColor = false;
            this.BtnEliminarMateria.Click += new System.EventHandler(this.BtnEliminarMateria_Click);
            // 
            // BtnAgregarMateria
            // 
            this.BtnAgregarMateria.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAgregarMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregarMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarMateria.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAgregarMateria.Location = new System.Drawing.Point(6, 18);
            this.BtnAgregarMateria.Name = "BtnAgregarMateria";
            this.BtnAgregarMateria.Size = new System.Drawing.Size(215, 38);
            this.BtnAgregarMateria.TabIndex = 1;
            this.BtnAgregarMateria.Text = "Agregar Materia";
            this.BtnAgregarMateria.UseVisualStyleBackColor = false;
            this.BtnAgregarMateria.Click += new System.EventHandler(this.BtnAgregarMateria_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtDetalle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpFecha);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(917, 139);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // TxtDetalle
            // 
            this.TxtDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDetalle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtDetalle.Location = new System.Drawing.Point(41, 104);
            this.TxtDetalle.Multiline = true;
            this.TxtDetalle.Name = "TxtDetalle";
            this.TxtDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtDetalle.Size = new System.Drawing.Size(831, 29);
            this.TxtDetalle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(37, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Detalle";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtUsuario.Location = new System.Drawing.Point(41, 44);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.ReadOnly = true;
            this.TxtUsuario.Size = new System.Drawing.Size(180, 29);
            this.TxtUsuario.TabIndex = 5;
            this.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(37, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario que realiza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(522, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de Ingreso";
            // 
            // DtpFecha
            // 
            this.DtpFecha.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DtpFecha.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Location = new System.Drawing.Point(526, 43);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(346, 29);
            this.DtpFecha.TabIndex = 0;
            // 
            // FrmUsoMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 672);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnCrearUso);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsoMateriaPrima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uso de Materia Prima";
            this.Load += new System.EventHandler(this.FrmUsoMateriaPrima_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaMaterias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCrearUso;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DgvListaMaterias;
        private System.Windows.Forms.Button BtnEliminarMateria;
        private System.Windows.Forms.Button BtnAgregarMateria;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
    }
}