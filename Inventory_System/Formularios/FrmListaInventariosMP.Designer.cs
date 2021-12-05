
namespace Inventory_System.Formularios
{
    partial class FrmListaInventariosMP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaInventariosMP));
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.DgvListaInventariosMP = new System.Windows.Forms.DataGridView();
            this.ColID_InventarioMP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaInventariosMP)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.IndianRed;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(648, 601);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(281, 40);
            this.BtnCancelar.TabIndex = 13;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnReporte
            // 
            this.BtnReporte.BackColor = System.Drawing.Color.Brown;
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReporte.Location = new System.Drawing.Point(13, 520);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(916, 40);
            this.BtnReporte.TabIndex = 12;
            this.BtnReporte.Text = "Mostrar Reporte";
            this.BtnReporte.UseVisualStyleBackColor = false;
            this.BtnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // DgvListaInventariosMP
            // 
            this.DgvListaInventariosMP.AllowUserToAddRows = false;
            this.DgvListaInventariosMP.AllowUserToDeleteRows = false;
            this.DgvListaInventariosMP.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListaInventariosMP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListaInventariosMP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaInventariosMP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID_InventarioMP,
            this.ColFecha,
            this.ColUsuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListaInventariosMP.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListaInventariosMP.Location = new System.Drawing.Point(12, 31);
            this.DgvListaInventariosMP.Name = "DgvListaInventariosMP";
            this.DgvListaInventariosMP.ReadOnly = true;
            this.DgvListaInventariosMP.RowHeadersVisible = false;
            this.DgvListaInventariosMP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaInventariosMP.Size = new System.Drawing.Size(916, 453);
            this.DgvListaInventariosMP.TabIndex = 11;
            // 
            // ColID_InventarioMP
            // 
            this.ColID_InventarioMP.DataPropertyName = "ID_InventarioMP";
            this.ColID_InventarioMP.HeaderText = "Código";
            this.ColID_InventarioMP.Name = "ColID_InventarioMP";
            this.ColID_InventarioMP.ReadOnly = true;
            // 
            // ColFecha
            // 
            this.ColFecha.DataPropertyName = "Fecha";
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            this.ColFecha.Width = 200;
            // 
            // ColUsuario
            // 
            this.ColUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColUsuario.DataPropertyName = "Usuario";
            this.ColUsuario.HeaderText = "Usuario";
            this.ColUsuario.Name = "ColUsuario";
            this.ColUsuario.ReadOnly = true;
            // 
            // FrmListaInventariosMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 672);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnReporte);
            this.Controls.Add(this.DgvListaInventariosMP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaInventariosMP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de todos los Inventarios de Materia Prima";
            this.Load += new System.EventHandler(this.FrmListaInventariosMP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaInventariosMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnReporte;
        private System.Windows.Forms.DataGridView DgvListaInventariosMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_InventarioMP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUsuario;
    }
}