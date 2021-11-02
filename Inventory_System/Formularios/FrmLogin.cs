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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Locales.ObjetosGlobales.MiFormPrincipal.Show();
            this.Hide();

          // if(!string.IsNullOrEmpty(TxtUsuario.Text.Trim()) &&
            //    !string.IsNullOrEmpty(TxtContrasenna.Text.Trim()))
            //{
              //  string u = TxtUsuario.Text.Trim();
                //string p = TxtContrasenna.Text.Trim();

                //Logic_Inventory.Usuario MiUsuario = new Logic_Inventory.Usuario();
                //int IdUsuarioValidado = MiUsuario.ValidarLogIn(u, p);

                //if(IdUsuarioValidado > 0)
                //{
                  //  Locales.ObjetosGlobales.MiUsuarioGlobal = MiUsuario.Consultar(IdUsuarioValidado);
                    //Locales.ObjetosGlobales.MiFormPrincipal.Show();
                    //this.Hide();
               // }
                //else
                //{
                  //  MessageBox.Show("El Usuario o la contraseña es incorrecto", "", MessageBoxButtons.OK);
                    //TxtContrasenna.Focus();
                    //TxtContrasenna.SelectAll();
                //}

            //}
        }

        private void BtnVerPass_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasenna.UseSystemPasswordChar = false;
        }

        private void BtnVerPass_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasenna.UseSystemPasswordChar = true;
        }
    }
}
