using System.Windows.Forms;

namespace Inventory_System.Locales
{
    public static class ObjetosGlobales
    {
        public static Form MiFormPrincipal = new Formularios.FrmPrincipal();

        public static Logic_Inventory.Usuario MiUsuarioGlobal = new Logic_Inventory.Usuario();

        public static Formularios.FrmUsuarioGestion MiFormGestionUsuarios = new Formularios.FrmUsuarioGestion();

        public static Formularios.FrmProveedorGestion MiFormGestionProveedores = new Formularios.FrmProveedorGestion();

        public static Formularios.FrmProductoGestion MiFormGestionProducto = new Formularios.FrmProductoGestion();

        public static Formularios.FrmMateriaPrimaGestion MiFormGestionMateriaPrima = new Formularios.FrmMateriaPrimaGestion();

        public static Formularios.FrmInventarioMP MiFormGestionInventarioMP = new Formularios.FrmInventarioMP();

        public static Formularios.FrmInventarioProducto MiFormGestionInventarioProducto = new Formularios.FrmInventarioProducto();

        public static Formularios.FrmPedido MiFormGestionPedido = new Formularios.FrmPedido();

        public static Formularios.FrmPerdidas MiFormGestionPerdidas = new Formularios.FrmPerdidas();

    }
}
