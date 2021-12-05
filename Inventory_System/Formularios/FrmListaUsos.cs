using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmListaUsos : Form
    {
        public DataTable ListaUsos { get; set; }
        public Logic_Inventory.Uso_MP MiUso { get; set; }

        public FrmListaUsos()
        {
            InitializeComponent();
            ListaUsos = new DataTable();
            MiUso = new Logic_Inventory.Uso_MP();
        }

        private void FrmListaUsos_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaUsos = MiUso.ListarTodos();
            DgvListaUsos.DataSource = ListaUsos;
            DgvListaUsos.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Uso_MP MiUsos = new Logic_Inventory.Uso_MP();

            if (DgvListaUsos.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaUsos.SelectedRows[0];
                MiUsos.ID_Uso = Convert.ToInt32(MiFila.Cells["ColID_Uso"].Value);

                ReportDocument MiReporteUso = new ReportDocument();

                MiReporteUso = new Reportes.RptUsoMP();

                MiReporteUso = MiUsos.Imprimir(MiReporteUso);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReporteUso;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
