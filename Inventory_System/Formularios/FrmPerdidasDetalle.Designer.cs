
namespace Inventory_System.Formularios
{
    partial class FrmPerdidasDetalle
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvListaProductos = new System.Windows.Forms.DataGridView();
            this.ColID_Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidadEnStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.Sienna;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCancelar.Location = new System.Drawing.Point(488, 595);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(281, 40);
            this.BtnCancelar.TabIndex = 11;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.Peru;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAceptar.Location = new System.Drawing.Point(162, 595);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(281, 40);
            this.BtnAceptar.TabIndex = 10;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NudCantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 133);
            this.panel1.TabIndex = 9;
            // 
            // NudCantidad
            // 
            this.NudCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NudCantidad.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NudCantidad.Location = new System.Drawing.Point(406, 71);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(120, 29);
            this.NudCantidad.TabIndex = 1;
            this.NudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(332, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad por Agregar";
            // 
            // DgvListaProductos
            // 
            this.DgvListaProductos.AllowUserToAddRows = false;
            this.DgvListaProductos.AllowUserToDeleteRows = false;
            this.DgvListaProductos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DgvListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID_Producto,
            this.ColNombre,
            this.ColCantidadEnStock,
            this.ColPrecio});
            this.DgvListaProductos.Location = new System.Drawing.Point(12, 38);
            this.DgvListaProductos.Name = "DgvListaProductos";
            this.DgvListaProductos.ReadOnly = true;
            this.DgvListaProductos.RowHeadersVisible = false;
            this.DgvListaProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaProductos.Size = new System.Drawing.Size(916, 319);
            this.DgvListaProductos.TabIndex = 8;
            // 
            // ColID_Producto
            // 
            this.ColID_Producto.DataPropertyName = "ID_Producto";
            this.ColID_Producto.HeaderText = "Código";
            this.ColID_Producto.Name = "ColID_Producto";
            this.ColID_Producto.ReadOnly = true;
            // 
            // ColNombre
            // 
            this.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombre.DataPropertyName = "Nombre";
            this.ColNombre.HeaderText = "Nombre";
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColCantidadEnStock
            // 
            this.ColCantidadEnStock.DataPropertyName = "CantidadEnStock";
            this.ColCantidadEnStock.HeaderText = "Cantidad Almacenada";
            this.ColCantidadEnStock.Name = "ColCantidadEnStock";
            this.ColCantidadEnStock.ReadOnly = true;
            this.ColCantidadEnStock.Width = 150;
            // 
            // ColPrecio
            // 
            this.ColPrecio.DataPropertyName = "Precio";
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            // 
            // FrmPerdidasDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 672);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvListaProductos);
            this.MaximizeBox = false;
            this.Name = "FrmPerdidasDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPerdidasDetalle";
            this.Load += new System.EventHandler(this.FrmPerdidasDetalle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvListaProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID_Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidadEnStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
    }
}