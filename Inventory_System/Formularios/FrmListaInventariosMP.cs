using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmListaInventariosMP : Form
    {
        public DataTable ListaInventariosMP { get; set; }
        public Logic_Inventory.Inventario_MP MiInventarioMP { get; set; }

        public FrmListaInventariosMP()
        {
            InitializeComponent();
            ListaInventariosMP = new DataTable();
            MiInventarioMP = new Logic_Inventory.Inventario_MP();
        }

        private void FrmListaInventariosMP_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaInventariosMP = MiInventarioMP.ListarTodos();
            DgvListaInventariosMP.DataSource = ListaInventariosMP;
            DgvListaInventariosMP.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Inventario_MP MiInventarioMP = new Logic_Inventory.Inventario_MP();

            if (DgvListaInventariosMP.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaInventariosMP.SelectedRows[0];
                MiInventarioMP.ID_InventarioMP = Convert.ToInt32(MiFila.Cells["ColID_InventarioMP"].Value);

                ReportDocument MiReporteInventarioMP = new ReportDocument();

                MiReporteInventarioMP = new Reportes.RptInventarioMP();

                MiReporteInventarioMP = MiInventarioMP.Imprimir(MiReporteInventarioMP);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReporteInventarioMP;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
