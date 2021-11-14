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
    }
}
