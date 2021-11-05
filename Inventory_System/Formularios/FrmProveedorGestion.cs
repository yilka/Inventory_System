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
    public partial class FrmProveedorGestion : Form
    {
        private Logic_Inventory.Proveedor MiProveedorLocal { get; set; }
        public DataTable ListaProveedorNormal { get; set; }
        public DataTable ListaProveedorConFiltro { get; set; }
        private bool FlagActivar { get; set; }

        public FrmProveedorGestion()
        {
            InitializeComponent();
            MiProveedorLocal = new Logic_Inventory.Proveedor();
        }

        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtCedulaJ.Enabled = true;
        }

        private void ActivarEditarYEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            TxtCedulaJ.Enabled = false;
        }

        private void LimpiarForm()
        {
            TxtID.Clear();
            TxtCedulaJ.Clear();
            TxtDireccion.Clear();

            TxtNombre.Clear();
            TxtTelefono.Clear();

            TxtEmail.Clear();
            TxtContacto.Clear();
            CbActivo.Checked = false;
        }

        private void FrmProveedorGestion_Load(object sender, EventArgs e)
        {
            LlenarListaProveedores(CbVerProveedoresActivos.Checked);
            LimpiarForm();
            ActivarBotonAgregar();
        }


        private void LlenarListaProveedores(bool VerActivos, string FiltroBusqueda = "")
        {
            Logic_Inventory.Proveedor MiProveedor = new Logic_Inventory.Proveedor();
            if (!string.IsNullOrEmpty(FiltroBusqueda.Trim()))
            {
                ListaProveedorConFiltro = MiProveedor.Listar(VerActivos, FiltroBusqueda);
                DgvLista.DataSource = ListaProveedorConFiltro;
            }
            else
            {
                ListaProveedorNormal = MiProveedor.Listar(VerActivos);
                DgvLista.DataSource = ListaProveedorNormal;
            }
            DgvLista.ClearSelection();

            //Logic_Inventory.Proveedor MiProveedor = new Logic_Inventory.Proveedor();
            //DataTable Datos = new DataTable();
            //Datos = MiProveedor.ListarTodos();
            //DgvLista.DataSource = Datos;

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarBotonAgregar();
            DgvLista.ClearSelection();
        }


        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCedulaJ.Text.Trim()) &&
                TxtCedulaJ.Text.Trim() != TxtCedulaJ.Tag.ToString() &&
                !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtTelefono.Text.Trim()))
            {
                if (!BtnEditar.Enabled)
                {
                    R = true;
                }
            }

            return R;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult RespuestaProveedor = MessageBox.Show("¿Está seguro que desea agregar este proveedor?", "Confirmación requerida", MessageBoxButtons.YesNo);

                if (RespuestaProveedor == DialogResult.Yes)
                {
                    Logic_Inventory.Proveedor MiProveedor = new Logic_Inventory.Proveedor();

                    MiProveedor.Cedula_Juridica = TxtCedulaJ.Text.Trim();
                    MiProveedor.Nombre = TxtNombre.Text.Trim();
                    MiProveedor.Telefono = TxtTelefono.Text.Trim();
                    MiProveedor.Direccion = TxtDireccion.Text.Trim();
                    MiProveedor.Email = TxtEmail.Text.Trim();
                    MiProveedor.Contacto_Directo = TxtContacto.Text.Trim();


                    //bool IDExiste = MiProveedor.ConsultarPorID();
                    bool CedulaExiste = MiProveedor.ConsultarPorCedula();


                    if (/*!IDExiste &&*/ !CedulaExiste)
                    {
                        if (MiProveedor.Agregar())
                        {
                            MessageBox.Show("Proveedor agregado correctamente.", "", MessageBoxButtons.OK);

                            LimpiarForm();
                            LlenarListaProveedores(true);
                            ActivarBotonAgregar();
                        }
                    }
                    else
                    {
                        //if (IDExiste)
                        //{
                        //    MessageBox.Show("El ID ingresado ha sido usado para otro proveedor", "", MessageBoxButtons.OK);
                        //}
                        /*else*/ if (CedulaExiste)
                        {
                            MessageBox.Show("La cédula jurídica ingresada ha sido usada para otro proveedor", "", MessageBoxButtons.OK);
                            TxtCedulaJ.Focus();
                            TxtCedulaJ.SelectAll();
                        }
                    }
                }
            }
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

                int IdProveedor = Convert.ToInt32(MiFila.Cells["ColID_Proveedor"].Value);

                MiProveedorLocal = new Logic_Inventory.Proveedor();
                MiProveedorLocal = MiProveedorLocal.Consultar(IdProveedor);

                TxtID.Text = MiProveedorLocal.ID_Proveedor.ToString();
                TxtCedulaJ.Text = MiProveedorLocal.Cedula_Juridica;
                TxtNombre.Text = MiProveedorLocal.Nombre;
                TxtEmail.Text = MiProveedorLocal.Email;
                TxtContacto.Text = MiProveedorLocal.Contacto_Directo;
                TxtTelefono.Text = MiProveedorLocal.Telefono;
                TxtDireccion.Text = MiProveedorLocal.Direccion;
                CbActivo.Checked = MiProveedorLocal.Activo;

                ActivarEditarYEliminar();
            }
        }

        private void TxtCedulaJ_TextChanged(object sender, EventArgs e)
        {
            TxtCedulaJ.ForeColor = Color.DarkGray;
            if (TxtCedulaJ.Text == TxtCedulaJ.Tag.ToString())
            {
                TxtCedulaJ.ForeColor = Color.LightGray;
            }
        }

        private void TxtCedulaJ_Enter(object sender, EventArgs e)
        {
            if (TxtCedulaJ.Text == TxtCedulaJ.Tag.ToString())
            {
                TxtCedulaJ.Clear();
            }
        }

        private void TxtCedulaJ_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCedulaJ.Text.Trim()))
            {
                TxtCedulaJ.Text = TxtCedulaJ.Tag.ToString();
            }
        }

        private void TxtCedulaJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Logic_Inventory.Proveedor MiProveedor = new Logic_Inventory.Proveedor();

                MiProveedor.ID_Proveedor = Convert.ToInt32(TxtID.Text.Trim());
                MiProveedor.Cedula_Juridica = TxtCedulaJ.Text.Trim();
                MiProveedor.Nombre = TxtNombre.Text.Trim();
                MiProveedor.Telefono = TxtTelefono.Text.Trim();
                MiProveedor.Direccion = TxtDireccion.Text.Trim();
                MiProveedor.Email = TxtEmail.Text.Trim();
                MiProveedor.Contacto_Directo = TxtContacto.Text.Trim();

                if (MiProveedor.ConsultarPorID())
                {
                    if (MiProveedor.Editar())
                    {
                        MessageBox.Show("Proveedor editado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProveedores(CbVerProveedoresActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Proveedor MiProveedor = new Logic_Inventory.Proveedor();
            MiProveedor.ID_Proveedor = Convert.ToInt32(TxtID.Text.Trim());

            if (MiProveedor.ConsultarPorID())
            {
                if (FlagActivar)
                {
                    if (MiProveedor.Activar())
                    {
                        MessageBox.Show("Proveedor activado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProveedores(CbVerProveedoresActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
                else
                {
                    if (MiProveedor.Desactivar())
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProveedores(true);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void CbVerProveedoresActivos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarListaProveedores(CbVerProveedoresActivos.Checked);
            if (CbVerProveedoresActivos.Checked)
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
    }
}
