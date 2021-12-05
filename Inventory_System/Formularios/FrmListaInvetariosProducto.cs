using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmListaInvetariosProducto : Form
    {
        public DataTable ListaInventariosP { get; set; }
        public Logic_Inventory.Inventario_Producto MiInventarioP { get; set; }


        public FrmListaInvetariosProducto()
        {
            InitializeComponent();
            ListaInventariosP = new DataTable();
            MiInventarioP = new Logic_Inventory.Inventario_Producto();
        }

        private void ListaInvetariosProducto_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaInventariosP = MiInventarioP.ListarTodos();
            DgvListaInventariosP.DataSource = ListaInventariosP;
            DgvListaInventariosP.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Inventario_Producto MiInventarioP = new Logic_Inventory.Inventario_Producto();

            if (DgvListaInventariosP.SelectedRows.Count == 1)
            {
                DataGridViewRow MiFila = DgvListaInventariosP.SelectedRows[0];
                MiInventarioP.ID_InventarioP = Convert.ToInt32(MiFila.Cells["ColID_InventarioP"].Value);

                ReportDocument MiReporteInventarioProd = new ReportDocument();

                MiReporteInventarioProd = new Reportes.RptInventarioProd();

                MiReporteInventarioProd = MiInventarioP.Imprimir(MiReporteInventarioProd);

                FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                MiFormCRV.CrvVisualizador.ReportSource = MiReporteInventarioProd;

                MiFormCRV.Show();

                MiFormCRV.CrvVisualizador.Zoom(1);
            }
        }
    }
}
