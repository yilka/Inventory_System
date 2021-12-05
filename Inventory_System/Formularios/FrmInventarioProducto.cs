using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmInventarioProducto : Form
    {
        public Logic_Inventory.Inventario_Producto MiInventarioPLocal { get; set; }
        public DataTable DtListaProductos { get; set; }

        public FrmInventarioProducto()
        {
            InitializeComponent();
            MiInventarioPLocal = new Logic_Inventory.Inventario_Producto();
            DtListaProductos = new DataTable();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInventarioProducto_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }


        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            DtListaProductos = MiInventarioPLocal.AsignarEsquemaDetalle();
            DgvListaProductos.DataSource = DtListaProductos;
            TxtTotal.Text = "0";
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmInventarioPDetalle();
            DialogResult Resp = FormBuscarItem.ShowDialog();
            if (Resp == DialogResult.OK)
            {
                DgvListaProductos.DataSource = DtListaProductos;
                TxtTotal.Text = string.Format("{0:C2}", Totalizar());
            }
        }

        private decimal Totalizar()
        {
            decimal R = 0;
            if (DtListaProductos.Rows.Count > 0)
            {
                foreach (DataRow item in DtListaProductos.Rows)
                {
                    R += Convert.ToDecimal(item["Cantidad"]) * Convert.ToDecimal(item["Total"]);
                }
            }
            return R;
        }


        private bool ValidarInventario()
        {
            bool R = false;

            if (DtpFecha.Value.Date <= DateTime.Now.Date &&
                DtListaProductos.Rows.Count > 0)
            {
                R = true;
            }
            else
            {
                if (DtpFecha.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show(@"La fecha del inventario no puede ser superior a la fecha actual", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }
            return R;
        }


        private void LlenarDetalleInventario()
        {
            foreach (DataRow fila in DtListaProductos.Rows)
            {
                Logic_Inventory.Inv_Prod_Detalle detalle = new Logic_Inventory.Inv_Prod_Detalle();

                detalle.MiProducto.ID_Producto = Convert.ToInt32(fila["ID_Producto"]);
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Total = Convert.ToDecimal(fila["Total"]);
                detalle.MiProducto.Nombre = fila["Nombre"].ToString();

                MiInventarioPLocal.ProdListaDetalle.Add(detalle);
            }
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            int num = Locales.ObjetosGlobales.MiFormGestionInventarioProducto.DgvListaProductos.SelectedRows[0].Index;
            Locales.ObjetosGlobales.MiFormGestionInventarioProducto.DtListaProductos.Rows.RemoveAt(num);
            MessageBox.Show("Producto eliminada de la lista");
            TxtTotal.Text = string.Format("{0:C2}", Totalizar());
        }



        private void BtnCrearInventario_Click(object sender, EventArgs e)
        {
            if (ValidarInventario())
            {
                MiInventarioPLocal.Fecha = DtpFecha.Value.Date;
                MiInventarioPLocal.MiUsuario.ID_Usuario = Locales.ObjetosGlobales.MiUsuarioGlobal.ID_Usuario;

                LlenarDetalleInventario();

                if (MiInventarioPLocal.Agregar())
                {
                    MessageBox.Show("El inventario se realizó correctamente", "", MessageBoxButtons.OK);

                    ReportDocument MiReporteInventarioProd = new ReportDocument();

                    MiReporteInventarioProd = new Reportes.RptInventarioProd();

                    MiReporteInventarioProd = MiInventarioPLocal.Imprimir(MiReporteInventarioProd);

                    FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                    MiFormCRV.CrvVisualizador.ReportSource = MiReporteInventarioProd;

                    MiFormCRV.Show();


                    MiFormCRV.CrvVisualizador.Zoom(1);

                    Limpiar();
                }

            }

        }
    }
}
