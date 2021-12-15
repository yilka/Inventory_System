using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;


namespace Inventory_System.Formularios
{
    public partial class FrmPerdidas : Form
    {
        public Logic_Inventory.Perdidas MiPerdidaLocal { get; set; }
        public DataTable DtListaProductos { get; set; }

        public FrmPerdidas()
        {
            InitializeComponent();
            MiPerdidaLocal = new Logic_Inventory.Perdidas();
            DtListaProductos = new DataTable();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPerdidas_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }

        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            TxtDetalle.Text = "";
            DtListaProductos = MiPerdidaLocal.AsignarEsquemaDetalle();
            DgvListaProductos.DataSource = DtListaProductos;
            TxtTotal.Text = "0";
            MiPerdidaLocal = new Logic_Inventory.Perdidas();
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmPerdidasDetalle();
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
                    MessageBox.Show(@"La fecha de la pérdida no puede ser superior a la fecha actual", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                else if (DtListaProductos.Rows.Count <= 0)
                {
                    MessageBox.Show(@"Se debe ingresar un producto para crear la Pérdida", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }
            return R;
        }



        private void LlenarDetalleInventario()
        {
            foreach (DataRow fila in DtListaProductos.Rows)
            {
                Logic_Inventory.Perdidas_Detalle detalle = new Logic_Inventory.Perdidas_Detalle();

                detalle.MiProducto.ID_Producto = Convert.ToInt32(fila["ID_Producto"]);
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Total = Convert.ToDecimal(fila["Total"]);
                detalle.MiProducto.Nombre = fila["Nombre"].ToString();

                MiPerdidaLocal.PerdListaDetalle.Add(detalle);
            }
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            int num = Locales.ObjetosGlobales.MiFormGestionPerdidas.DgvListaProductos.SelectedRows[0].Index;
            Locales.ObjetosGlobales.MiFormGestionPerdidas.DtListaProductos.Rows.RemoveAt(num);
            MessageBox.Show("Producto eliminado de la lista");
            TxtTotal.Text = string.Format("{0:C2}", Totalizar());
        }

        private void BtnCrearInventario_Click(object sender, EventArgs e)
        {
            if (ValidarInventario())
            {
                MiPerdidaLocal.Fecha = DtpFecha.Value.Date;
                MiPerdidaLocal.MiUsuario.ID_Usuario = Locales.ObjetosGlobales.MiUsuarioGlobal.ID_Usuario;
                MiPerdidaLocal.Detalle = TxtDetalle.Text.Trim();

                LlenarDetalleInventario();

                if (MiPerdidaLocal.Agregar())
                {
                    MessageBox.Show("La pérdida se realizó correctamente", "", MessageBoxButtons.OK);

                    ReportDocument MiReportePerdida = new ReportDocument();

                    MiReportePerdida = new Reportes.RptPerdida();

                    MiReportePerdida = MiPerdidaLocal.Imprimir(MiReportePerdida);

                    FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                    MiFormCRV.CrvVisualizador.ReportSource = MiReportePerdida;

                    MiFormCRV.Show();


                    MiFormCRV.CrvVisualizador.Zoom(1);
                    Limpiar();
                }

            }
        }
    }
}
