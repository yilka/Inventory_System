using System.Windows.Forms;

namespace Inventory_System.Locales
{
    public static class ObjetosGlobales
    {
        public static Form MiFormPrincipal = new Formularios.FrmPrincipal();

        public static Form MiLogin = new Formularios.FrmLogin();

        public static Logic_Inventory.Usuario MiUsuarioGlobal = new Logic_Inventory.Usuario();

        public static Formularios.FrmUsuarioGestion MiFormGestionUsuarios = new Formularios.FrmUsuarioGestion();

        public static Formularios.FrmProveedorGestion MiFormGestionProveedores = new Formularios.FrmProveedorGestion();

        public static Formularios.FrmProductoGestion MiFormGestionProducto = new Formularios.FrmProductoGestion();

        public static Formularios.FrmMateriaPrimaGestion MiFormGestionMateriaPrima = new Formularios.FrmMateriaPrimaGestion();

        public static Formularios.FrmInventarioMP MiFormGestionInventarioMP = new Formularios.FrmInventarioMP();

        public static Formularios.FrmInventarioProducto MiFormGestionInventarioProducto = new Formularios.FrmInventarioProducto();

        public static Formularios.FrmPedido MiFormGestionPedido = new Formularios.FrmPedido();

        public static Formularios.FrmPerdidas MiFormGestionPerdidas = new Formularios.FrmPerdidas();

        public static Formularios.FrmUsoMateriaPrima MiFormGestionUsoMP = new Formularios.FrmUsoMateriaPrima();

        public static Formularios.FrmListaInvetariosProducto MiFormListaInventariosP = new Formularios.FrmListaInvetariosProducto();

        public static Formularios.FrmReportesProductos MiFormReportesProductos = new Formularios.FrmReportesProductos();

        public static Formularios.FrmReportesMaterias MiFormReportesMaterias = new Formularios.FrmReportesMaterias();

        public static Formularios.FrmListaInventariosMP MiFormListaInventariosMP = new Formularios.FrmListaInventariosMP();

        public static Formularios.FrmListaPerdidas MiFormListaPerdidas = new Formularios.FrmListaPerdidas();

        public static Formularios.FrmListaPedido MiFormListaPedido = new Formularios.FrmListaPedido();

        public static Formularios.FrmListaUsos MiFormListaUsos = new Formularios.FrmListaUsos();
    }
}
