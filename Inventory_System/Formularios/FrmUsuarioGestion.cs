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
    public partial class FrmUsuarioGestion : Form
    {
        private Logic_Inventory.Usuario MiUsuarioLocal { get; set; }

        public DataTable ListaUsuariosNormal { get; set; }
        public DataTable ListaUsuariosConFiltro { get; set; }
        private bool FlagActivar { get; set; }
        private bool FlagCambioPassword { get; set; }


        public FrmUsuarioGestion()
        {
            InitializeComponent();

            MiUsuarioLocal = new Logic_Inventory.Usuario();
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            LlenarListaUsuarios(CbVerUsuariosActivos.Checked);
            CargarDatosRol();
            LimpiarForm();
            ActivarBotonAgregar();

        }


        private void LlenarListaUsuarios(bool VerActivos, string FiltroBusqueda = "")
        {
            Logic_Inventory.Usuario MiUsuario = new Logic_Inventory.Usuario();

            if (!string.IsNullOrEmpty(FiltroBusqueda.Trim()))
            {
                ListaUsuariosConFiltro = MiUsuario.Listar(VerActivos, FiltroBusqueda);
                DgvLista.DataSource = ListaUsuariosConFiltro;
            }
            else
            {
                ListaUsuariosNormal = MiUsuario.Listar(VerActivos);
                DgvLista.DataSource = ListaUsuariosNormal;
            }
            DgvLista.ClearSelection();

        }


        private void CargarDatosRol()
        {
            Logic_Inventory.Usuario_Rol ObjUsuarioRol = new Logic_Inventory.Usuario_Rol();
            DataTable Datos = new DataTable();
            Datos = ObjUsuarioRol.Listar();

            CboxTipoUsuario.ValueMember = "ID";
            CboxTipoUsuario.DisplayMember = "Descripcion";
            CboxTipoUsuario.DataSource = Datos;
            CboxTipoUsuario.SelectedIndex = -1;
        }

        private void LimpiarForm()
        {
            TxtID.Clear();
            TxtCedula.Clear();
            TxtDireccion.Clear();

            TxtNombre.Clear();
            TxtTelefono.Clear();

            TxtEmail.Clear();
            CboxTipoUsuario.SelectedIndex = -1;

            TxtUserName.Clear();
            TxtPass.Clear();
            CbActivo.Checked = false;

        }

        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtCedula.Enabled = true;
        }

        private void ActivarEditarYEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            TxtCedula.Enabled = false;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarBotonAgregar();
            DgvLista.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1)
            {
                LimpiarForm();
                DataGridViewRow MiFila = DgvLista.SelectedRows[0];
                int ID_Usuario = Convert.ToInt32(MiFila.Cells["ColID_Usuario"].Value);

                MiUsuarioLocal = new Logic_Inventory.Usuario();
                MiUsuarioLocal = MiUsuarioLocal.Consultar(ID_Usuario);

                TxtID.Text = MiUsuarioLocal.ID_Usuario.ToString();
                TxtCedula.Text = MiUsuarioLocal.Cedula;
                TxtNombre.Text = MiUsuarioLocal.Nombre;
                TxtTelefono.Text = MiUsuarioLocal.Telefono;
                TxtDireccion.Text = MiUsuarioLocal.Direccion;
                CboxTipoUsuario.SelectedValue = MiUsuarioLocal.Rol.ID_Rol;
                TxtEmail.Text = MiUsuarioLocal.Email;
                TxtUserName.Text = MiUsuarioLocal.UserName;
                //TxtPass.Text = MiUsuarioLocal.Password;
                CbActivo.Checked = MiUsuarioLocal.Activo;

                ActivarEditarYEliminar();
            }

        }

        private void TxtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  e.Handled = Herramientas.CaracteresTexto(e, true);
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = Herramientas.CaracteresTexto(e, true);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void CbVerUsuariosActivos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarListaUsuarios(CbVerUsuariosActivos.Checked);

            if (CbVerUsuariosActivos.Checked)
            {
                BtnEliminar.Text = "Eliminar";
                FlagActivar = false;
            }
            else
            {
                BtnEliminar.Text = "Activar";
                FlagActivar = true;
            }
        }



        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCedula.Text.Trim()) &&
                TxtCedula.Text.Trim() != TxtCedula.Tag.ToString() &&
                !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtTelefono.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserName.Text.Trim()) &&
                CboxTipoUsuario.SelectedIndex > -1)
            {
                if (BtnEditar.Enabled)
                {
                    R = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(TxtPass.Text.Trim()))
                    {
                        R = true;
                    }
                }

            }

            return R;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult RespuestaUsuario = MessageBox.Show("¿Está seguro que desea agregar este usuario?", "Confirmación requerida", MessageBoxButtons.YesNo);

                if (RespuestaUsuario == DialogResult.Yes)
                {
                    Logic_Inventory.Usuario MiUsuario = new Logic_Inventory.Usuario();

                    MiUsuario.Cedula = TxtCedula.Text.Trim();
                    MiUsuario.Nombre = TxtNombre.Text.Trim();
                    MiUsuario.Telefono = TxtTelefono.Text.Trim();
                    MiUsuario.Direccion = TxtDireccion.Text.Trim();
                    MiUsuario.Email = TxtEmail.Text.Trim();
                    MiUsuario.UserName = TxtUserName.Text.Trim();
                    MiUsuario.Contrasena = TxtPass.Text.Trim();
                    MiUsuario.Rol.ID_Rol = Convert.ToInt32(CboxTipoUsuario.SelectedValue);

                    bool CedulaExiste = MiUsuario.ConsultarPorCedula();
                    bool UserExiste = MiUsuario.ConsultarPorUserName();


                    if (!CedulaExiste && !UserExiste)
                    {
                        if (MiUsuario.Agregar())
                        {
                            MessageBox.Show("Usuario agregado correctamente.", "", MessageBoxButtons.OK);

                            LimpiarForm();
                            LlenarListaUsuarios(true);
                            ActivarBotonAgregar();
                        }
                    }
                    else
                    {
                        if (CedulaExiste)
                        {
                            MessageBox.Show("La cédula ingresada ha sido usada por otro usuario", "", MessageBoxButtons.OK);
                            TxtCedula.Focus();
                            TxtCedula.SelectAll();
                        }
                        else if (UserExiste)
                        {
                            MessageBox.Show("El Nombre de Usuario ingresado ya fue usado", "", MessageBoxButtons.OK);
                            TxtUserName.Focus();
                            TxtUserName.SelectAll();
                        }
                    }
                }
            }
        }

        private void TxtCedula_TextChanged(object sender, EventArgs e)
        {
            TxtCedula.ForeColor = Color.DarkGray;
            if (TxtCedula.Text == TxtCedula.Tag.ToString())
            {
                TxtCedula.ForeColor = Color.LightGray;
            }
        }

        private void TxtCedula_Enter(object sender, EventArgs e)
        {
            if (TxtCedula.Text == TxtCedula.Tag.ToString())
            {
                TxtCedula.Clear();
            }
        }

        private void TxtCedula_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCedula.Text.Trim()))
            {
                TxtCedula.Text = TxtCedula.Tag.ToString();
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarListaUsuarios(CbVerUsuariosActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                LlenarListaUsuarios(CbVerUsuariosActivos.Checked);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Usuario MiUsuario = new Logic_Inventory.Usuario();
            MiUsuario.ID_Usuario = Convert.ToInt32(TxtID.Text.Trim());

            if (MiUsuario.ConsultarPorID())
            {
                if (FlagActivar)
                {
                    if (MiUsuario.Activar())
                    {
                        MessageBox.Show("Usuario activado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaUsuarios(CbVerUsuariosActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
                else
                {
                    if (MiUsuario.Desactivar())
                    {
                        MessageBox.Show("Usuario eliminado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaUsuarios(true);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Logic_Inventory.Usuario MiUsuario = new Logic_Inventory.Usuario();

                MiUsuario.ID_Usuario = Convert.ToInt32(TxtID.Text.Trim());
                MiUsuario.Cedula = TxtCedula.Text.Trim();
                MiUsuario.Nombre = TxtNombre.Text.Trim();
                MiUsuario.Telefono = TxtTelefono.Text.Trim();
                MiUsuario.Direccion = TxtDireccion.Text.Trim();
                MiUsuario.Email = TxtEmail.Text.Trim();
                MiUsuario.UserName = TxtUserName.Text.Trim();
                MiUsuario.Contrasena = "";
                if (FlagCambioPassword)
                {
                    MiUsuario.Contrasena = TxtPass.Text.Trim();
                }

                MiUsuario.Rol.ID_Rol = Convert.ToInt32(CboxTipoUsuario.SelectedValue);
                if(MiUsuario.ConsultarPorID())
                {
                    if (MiUsuario.Editar())
                    {
                        MessageBox.Show("Usuario editado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaUsuarios(CbVerUsuariosActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }

            }
        }

        private void TxtPass_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(TxtPass.Text.Trim()) && BtnEditar.Enabled)
            {
                FlagCambioPassword = true;
            }
            else
            {
                FlagCambioPassword = false;
            }
        }


    }
}
