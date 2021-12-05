using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmReportesMaterias : Form
    {
        private Logic_Inventory.Materia_Prima MiMateriaLocal { get; set; }
        public DataTable ListaMateria { get; set; }

        public FrmReportesMaterias()
        {
            InitializeComponent();
            ListaMateria = new DataTable();
            MiMateriaLocal = new Logic_Inventory.Materia_Prima();
        }

        private void FrmReportesMaterias_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }
        private void LlenarLista()
        {
            ListaMateria = MiMateriaLocal.ListarTodos();
            DgvLista.DataSource = ListaMateria;
            DgvLista.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Materia_Prima MiMateria = new Logic_Inventory.Materia_Prima();

            if (DgvLista.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvLista.SelectedRows[0];
                MiMateria.ID_Materia = Convert.ToInt32(MiFila.Cells["ColID_Materia"].Value);

                ReportDocument MiReporteMateria = new ReportDocument();

                MiReporteMateria = new Reportes.RptMateria();

                MiReporteMateria = MiMateria.Imprimir(MiReporteMateria);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReporteMateria;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
