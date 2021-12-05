using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmListaPerdidas : Form
    {
        public DataTable ListaPerdidas { get; set; }
        public Logic_Inventory.Perdidas MiPerdidas { get; set; }

        public FrmListaPerdidas()
        {
            InitializeComponent();
            ListaPerdidas = new DataTable();
            MiPerdidas = new Logic_Inventory.Perdidas();
        }

        private void FrmListaPerdidas_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaPerdidas = MiPerdidas.ListarTodos();
            DgvListaPerdidas.DataSource = ListaPerdidas;
            DgvListaPerdidas.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Perdidas MiPerdida = new Logic_Inventory.Perdidas();

            if (DgvListaPerdidas.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaPerdidas.SelectedRows[0];
                MiPerdida.ID_Perdidas = Convert.ToInt32(MiFila.Cells["ColID_Perdidas"].Value);

                ReportDocument MiReportePerdida = new ReportDocument();

                MiReportePerdida = new Reportes.RptPerdida();

                MiReportePerdida = MiPerdida.Imprimir(MiReportePerdida);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReportePerdida;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
