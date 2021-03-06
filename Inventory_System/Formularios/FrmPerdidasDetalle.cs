using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmPerdidasDetalle : Form
    {

        public DataTable ListaProductos { get; set; }
        public Logic_Inventory.Producto MiProducto { get; set; }

        public FrmPerdidasDetalle()
        {
            InitializeComponent();
            ListaProductos = new DataTable();
            MiProducto = new Logic_Inventory.Producto();
        }

        private void FrmPerdidasDetalle_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }


        private void LlenarLista()
        {
            ListaProductos = MiProducto.ListarEnDetalle();
            DgvListaProductos.DataSource = ListaProductos;
            DgvListaProductos.ClearSelection();
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private bool ValidarDatos()
        {
            bool R = false;
            if (DgvListaProductos.SelectedRows.Count == 1 &&
                NudCantidad.Value > 0)
            {
                R = true;
            }
            else
            {
                if (NudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser cero o negativa", "Error de validación", MessageBoxButtons.OK);
                }
            }
            return R;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DataRow NuevaFila = Locales.ObjetosGlobales.MiFormGestionPerdidas.DtListaProductos.NewRow();

                NuevaFila["ID_Producto"] = Convert.ToInt32(DgvListaProductos.SelectedRows[0].Cells["ColID_Producto"].Value);
                NuevaFila["Nombre"] = DgvListaProductos.SelectedRows[0].Cells["ColNombre"].Value.ToString();
                NuevaFila["Total"] = DgvListaProductos.SelectedRows[0].Cells["ColPrecio"].Value.ToString();
                NuevaFila["Cantidad"] = NudCantidad.Value;

                Locales.ObjetosGlobales.MiFormGestionPerdidas.DtListaProductos.Rows.Add(NuevaFila);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
