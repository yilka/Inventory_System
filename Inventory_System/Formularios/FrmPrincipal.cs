using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public Logic_Inventory.Producto MiProducto { get; set; }
        public Logic_Inventory.Materia_Prima MiMateria { get; set; }
        public FrmPrincipal()
        {
            InitializeComponent();
            MiProducto = new Logic_Inventory.Producto();
            MiMateria = new Logic_Inventory.Materia_Prima();
        }


        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionUsuarios.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionUsuarios = new FrmUsuarioGestion();
                Locales.ObjetosGlobales.MiFormGestionUsuarios.Show();
            }
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionProveedores.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionProveedores = new FrmProveedorGestion();
                Locales.ObjetosGlobales.MiFormGestionProveedores.Show();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LblUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;

            switch (Locales.ObjetosGlobales.MiUsuarioGlobal.Rol.ID_Rol)
            {
                case 1:
                    mantenimientosToolStripMenuItem.Visible = false;
                    reportesToolStripMenuItem.Visible = false;
                    break;

                case 2:
                    break;
            }
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionProducto.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionProducto = new FrmProductoGestion();
                Locales.ObjetosGlobales.MiFormGestionProducto.Show();
            }

        }

        private void materiaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionMateriaPrima.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionMateriaPrima = new FrmMateriaPrimaGestion();
                Locales.ObjetosGlobales.MiFormGestionMateriaPrima.Show();
            }
        }

        private void inventarioMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionInventarioMP.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionInventarioMP = new FrmInventarioMP();
                Locales.ObjetosGlobales.MiFormGestionInventarioMP.Show();
            }
        }

        private void inventarioProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionInventarioProducto.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionInventarioProducto = new FrmInventarioProducto();
                Locales.ObjetosGlobales.MiFormGestionInventarioProducto.Show();
            }

        }

        private void perdidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionPerdidas.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionPerdidas = new FrmPerdidas();
                Locales.ObjetosGlobales.MiFormGestionPerdidas.Show();
            }

        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionPedido.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionPedido = new FrmPedido();
                Locales.ObjetosGlobales.MiFormGestionPedido.Show();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locales.ObjetosGlobales.MiLogin.Show();
            this.Hide();
        }

        private void usoDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormGestionUsoMP.Visible)
            {
                Locales.ObjetosGlobales.MiFormGestionUsoMP = new FrmUsoMateriaPrima();
                Locales.ObjetosGlobales.MiFormGestionUsoMP.Show();
            }
        }



        private void listaDeTodosLosProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument MiReporteProductos = new ReportDocument();

            MiReporteProductos = new Reportes.RptTodosLosProductos();

            MiReporteProductos = MiProducto.ImprimirTodos(MiReporteProductos);

            FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

            MiFormCRV.CrvVisualizador.ReportSource = MiReporteProductos;

            MiFormCRV.Show();

            MiFormCRV.CrvVisualizador.Zoom(1);
        }

        private void listaDeTodaLaMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument MiReporteMaterias = new ReportDocument();

            MiReporteMaterias = new Reportes.RptTodasLasMateriasPrimas();

            MiReporteMaterias = MiMateria.ImprimirTodos(MiReporteMaterias);

            FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

            MiFormCRV.CrvVisualizador.ReportSource = MiReporteMaterias;

            MiFormCRV.Show();

            MiFormCRV.CrvVisualizador.Zoom(1);
        }

 

        private void listaInventarioProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormListaInventariosP.Visible)
            {
                Locales.ObjetosGlobales.MiFormListaInventariosP = new FrmListaInvetariosProducto();
                Locales.ObjetosGlobales.MiFormListaInventariosP.Show();
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormReportesProductos.Visible)
            {
                Locales.ObjetosGlobales.MiFormReportesProductos = new FrmReportesProductos();
                Locales.ObjetosGlobales.MiFormReportesProductos.Show();
            }
        }

        private void materiaPrimaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormReportesMaterias.Visible)
            {
                Locales.ObjetosGlobales.MiFormReportesMaterias = new FrmReportesMaterias();
                Locales.ObjetosGlobales.MiFormReportesMaterias.Show();
            }
        }

        private void palilloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument MiReporteGeneralPalillo = new ReportDocument();

            MiReporteGeneralPalillo = new Reportes.RptGeneralPalillo();

            MiReporteGeneralPalillo = MiProducto.ImprimirPalillo(MiReporteGeneralPalillo);

            FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

            MiFormCRV.CrvVisualizador.ReportSource = MiReporteGeneralPalillo;

            MiFormCRV.Show();

            MiFormCRV.CrvVisualizador.Zoom(1);
        }

        private void paletasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument MiReporteGeneralPaletas = new ReportDocument();

            MiReporteGeneralPaletas = new Reportes.RptGeneralPaletas();

            MiReporteGeneralPaletas = MiProducto.ImprimirPaletas(MiReporteGeneralPaletas);

            FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

            MiFormCRV.CrvVisualizador.ReportSource = MiReporteGeneralPaletas;

            MiFormCRV.Show();

            MiFormCRV.CrvVisualizador.Zoom(1);
        }

        private void bolisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument MiReporteGeneralBolis = new ReportDocument();

            MiReporteGeneralBolis = new Reportes.RptGeneralBolis();

            MiReporteGeneralBolis = MiProducto.ImprimirBolis(MiReporteGeneralBolis);

            FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

            MiFormCRV.CrvVisualizador.ReportSource = MiReporteGeneralBolis;

            MiFormCRV.Show();

            MiFormCRV.CrvVisualizador.Zoom(1);
        }

        private void listaInventariosMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormListaInventariosMP.Visible)
            {
                Locales.ObjetosGlobales.MiFormListaInventariosMP = new FrmListaInventariosMP();
                Locales.ObjetosGlobales.MiFormListaInventariosMP.Show();
            }
        }

        private void listaPérdidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormListaPerdidas.Visible)
            {
                Locales.ObjetosGlobales.MiFormListaPerdidas = new FrmListaPerdidas();
                Locales.ObjetosGlobales.MiFormListaPerdidas.Show();
            }
        }

        private void listaPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormListaPedido.Visible)
            {
                Locales.ObjetosGlobales.MiFormListaPedido = new FrmListaPedido();
                Locales.ObjetosGlobales.MiFormListaPedido.Show();
            }
        }

        private void listaUsosDeMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Locales.ObjetosGlobales.MiFormListaUsos.Visible)
            {
                Locales.ObjetosGlobales.MiFormListaUsos = new FrmListaUsos();
                Locales.ObjetosGlobales.MiFormListaUsos.Show();
            }
        }
    }
}
