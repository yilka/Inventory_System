using System.Windows.Forms;

namespace Inventory_System.Locales
{
    public static class ObjetosGlobales
    {
        public static Form MiFormPrincipal = new Formularios.FrmPrincipal();

        public static Logic_Inventory.Usuario MiUsuarioGlobal = new Logic_Inventory.Usuario();

        public static Formularios.FrmUsuarioGestion MiFormGestionUsuarios = new Formularios.FrmUsuarioGestion();

    }
}
