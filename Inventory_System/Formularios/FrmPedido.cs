using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmPedido : Form
    {
        public Logic_Inventory.Pedido MiPedidoLocal { get; set; }
        public DataTable DtListaProductos { get; set; }

        public FrmPedido()
        {
            InitializeComponent();
            MiPedidoLocal = new Logic_Inventory.Pedido();
            DtListaProductos = new DataTable();
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }

        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            TxtCliente.Text = "";
            DtListaProductos = MiPedidoLocal.AsignarEsquemaDetalle();
            DgvListaProductos.DataSource = DtListaProductos;
            TxtTotal.Text = "0";
            MiPedidoLocal = new Logic_Inventory.Pedido();
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmPedidoDetalle();
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
            !string.IsNullOrEmpty(TxtCliente.Text.Trim())&&
                DtListaProductos.Rows.Count > 0)
            {
                R = true;
            }
            else
            {
                if (DtpFecha.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show(@"La fecha del pedido no puede ser superior a la fecha actual", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
                else if(string.IsNullOrEmpty(TxtCliente.Text.Trim())){
                    MessageBox.Show("Se requiere ingresar el nombre del cliente", "", MessageBoxButtons.OK);
                    TxtCliente.Focus();
                    TxtCliente.SelectAll();
                }
                else if(DtListaProductos.Rows.Count <= 0)
                {
                    MessageBox.Show(@"Se debe ingresar un producto para crear el Pedido", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }

       
            }
            return R;
        }

        private void LlenarDetalleInventario()
        {
            foreach (DataRow fila in DtListaProductos.Rows)
            {
                Logic_Inventory.Pedido_Detalle detalle = new Logic_Inventory.Pedido_Detalle();

                detalle.MiProducto.ID_Producto = Convert.ToInt32(fila["ID_Producto"]);
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Total = Convert.ToDecimal(fila["Total"]);
                detalle.MiProducto.Nombre = fila["Nombre"].ToString();

                MiPedidoLocal.PedListaDetalle.Add(detalle);
            }
        }

        private void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            int num = Locales.ObjetosGlobales.MiFormGestionPedido.DgvListaProductos.SelectedRows[0].Index;
            Locales.ObjetosGlobales.MiFormGestionPedido.DtListaProductos.Rows.RemoveAt(num);
            MessageBox.Show("Producto eliminado de la lista");
            TxtTotal.Text = string.Format("{0:C2}", Totalizar());
        }

        private void BtnCrearInventario_Click(object sender, EventArgs e)
        {
            if (ValidarInventario())
            {
                MiPedidoLocal.Fecha = DtpFecha.Value.Date;
                MiPedidoLocal.MiUsuario.ID_Usuario = Locales.ObjetosGlobales.MiUsuarioGlobal.ID_Usuario;
                MiPedidoLocal.Nombre_Cliente = TxtCliente.Text.Trim();

                LlenarDetalleInventario();

                if (MiPedidoLocal.Agregar())
                {
                    MessageBox.Show("El pedido se realizó correctamente", "", MessageBoxButtons.OK);

                    ReportDocument MiReportePedido = new ReportDocument();

                    MiReportePedido = new Reportes.RptPedido();

                    MiReportePedido = MiPedidoLocal.Imprimir(MiReportePedido);

                    FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                    MiFormCRV.CrvVisualizador.ReportSource = MiReportePedido;

                    MiFormCRV.Show();

                    MiFormCRV.CrvVisualizador.Zoom(1);

                    Limpiar();
                }

            }
        }
    }
}
