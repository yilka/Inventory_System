using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmReportesProductos : Form
    {
        private Logic_Inventory.Producto MiProductoLocal { get; set; }
        public DataTable ListaProductoNormal { get; set; }
        public FrmReportesProductos()
        {
            InitializeComponent();
            ListaProductoNormal = new DataTable();
            MiProductoLocal = new Logic_Inventory.Producto();
        }

        private void FrmReportesProductos_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenarLista()
        {
            ListaProductoNormal = MiProductoLocal.ListarTodos();
            DgvLista.DataSource = ListaProductoNormal;
            DgvLista.ClearSelection();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Producto MiProducto = new Logic_Inventory.Producto();

            if (DgvLista.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvLista.SelectedRows[0];
                MiProducto.ID_Producto = Convert.ToInt32(MiFila.Cells["ColID_Producto"].Value);

                ReportDocument MiReporteProducto = new ReportDocument();

                MiReporteProducto = new Reportes.RptProducto();

                MiReporteProducto = MiProducto.Imprimir(MiReporteProducto);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReporteProducto;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
