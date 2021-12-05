using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmListaPedido : Form
    {
        public DataTable ListaPedido { get; set; }
        public Logic_Inventory.Pedido MiPedido { get; set; }

        public FrmListaPedido()
        {
            InitializeComponent();
            ListaPedido = new DataTable();
            MiPedido = new Logic_Inventory.Pedido();
        }

        private void FrmListaPedido_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaPedido = MiPedido.ListarTodos();
            DgvListaPedido.DataSource = ListaPedido;
            DgvListaPedido.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Pedido MiPedidos = new Logic_Inventory.Pedido();

            if (DgvListaPedido.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaPedido.SelectedRows[0];
                MiPedidos.ID_Pedido = Convert.ToInt32(MiFila.Cells["ColID_Pedido"].Value);

                ReportDocument MiReportePedido = new ReportDocument();

                MiReportePedido = new Reportes.RptPerdida();

                MiReportePedido = MiPedidos.Imprimir(MiReportePedido);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReportePedido;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
