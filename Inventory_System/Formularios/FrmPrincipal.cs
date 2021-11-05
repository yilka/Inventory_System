using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
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
                    break;

                case 2:
                    mantenimientosToolStripMenuItem.Visible = false;
                    reportesToolStripMenuItem.Visible = false;
                    break;
            }
        }
    }
}
