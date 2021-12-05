using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmMateriaPrimaGestion : Form
    {
        private Logic_Inventory.Materia_Prima MiMateriaLocal { get; set; }
        private bool FlagActivar { get; set; }
        public DataTable ListaMateriaNormal { get; set; }
        public DataTable ListaMateriaConFiltro { get; set; }


        public FrmMateriaPrimaGestion()
        {
            InitializeComponent();
            MiMateriaLocal = new Logic_Inventory.Materia_Prima();
        }

        private void FrmMateriaPrimaGestion_Load(object sender, EventArgs e)
        {
            LlenarListaMaterias(CbVerMateriasActivos.Checked);
            CargarDatosComboCategoria();
            CargarDatosComboProveedor();
            LimpiarForm();
            ActivarBotonAgregar();
        }


        private void CargarDatosComboCategoria()
        {
            Logic_Inventory.MP_Categoria ObjCategoria = new Logic_Inventory.MP_Categoria();
            DataTable Datos = new DataTable();
            Datos = ObjCategoria.Listar();

            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Categoria";

            CboxCategoria.DataSource = Datos;
            CboxCategoria.SelectedIndex = -1;
        }

        private void CargarDatosComboProveedor()
        {
            Logic_Inventory.Proveedor ObjProveedor = new Logic_Inventory.Proveedor();
            DataTable Datos = new DataTable();
            Datos = ObjProveedor.ListarCombo();

            CboxProveedor.ValueMember = "ID";
            CboxProveedor.DisplayMember = "Proveedor";

            CboxProveedor.DataSource = Datos;
            CboxProveedor.SelectedIndex = -1;
        }


        private void LimpiarForm()
        {
            TxtID.Clear();
            TxtNombre.Clear();
            TxtCodigoBarras.Text = TxtCodigoBarras.Tag.ToString();
            TxtPrecio.Clear();
            TxtCantidadStock.Clear();
            CboxCategoria.SelectedIndex = -1;
            CboxProveedor.SelectedIndex = -1;
            TxtDescripcion.Clear();
            CbActivo.Checked = false;
        }



        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarBotonAgregar();
            DgvLista.ClearSelection();
        }



        private void ActivarBotonAgregar()
        {
            BtnAgregar.Enabled = true;
            BtnEditar.Enabled = false;
            BtnEliminar.Enabled = false;
            TxtCodigoBarras.Enabled = true;
        }


        private void ActivarEditarYEliminar()
        {
            BtnAgregar.Enabled = false;
            BtnEditar.Enabled = true;
            BtnEliminar.Enabled = true;
            TxtCodigoBarras.Enabled = false;
        }




        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        private void LlenarListaMaterias(bool VerActivos, string FiltroBusqueda = "")
        {
            Logic_Inventory.Materia_Prima MiMateria = new Logic_Inventory.Materia_Prima();

            if (!string.IsNullOrEmpty(FiltroBusqueda.Trim()))
            {
                ListaMateriaConFiltro = MiMateria.Listar(VerActivos, FiltroBusqueda);
                DgvLista.DataSource = ListaMateriaConFiltro;
            }
            else
            {
                ListaMateriaNormal = MiMateria.Listar(VerActivos);
                DgvLista.DataSource = ListaMateriaNormal;
            }
            DgvLista.ClearSelection();
        }



        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1)
            {
                LimpiarForm();
                DataGridViewRow MiFila = DgvLista.SelectedRows[0];
                int IdMateria = Convert.ToInt32(MiFila.Cells["ColID_Materia"].Value);

                MiMateriaLocal = new Logic_Inventory.Materia_Prima();
                MiMateriaLocal = MiMateriaLocal.Consultar(IdMateria);

                TxtID.Text = MiMateriaLocal.ID_Materia.ToString();
                TxtCodigoBarras.Text = MiMateriaLocal.Codigo_Barras;
                TxtNombre.Text = MiMateriaLocal.Nombre;
                TxtPrecio.Text = MiMateriaLocal.Precio.ToString();
                TxtCantidadStock.Text = MiMateriaLocal.CantidadEnStock.ToString();
                CboxCategoria.SelectedValue = MiMateriaLocal.Categoria.ID_MPCategoria;
                CboxProveedor.SelectedValue = MiMateriaLocal.MiProveedor.ID_Proveedor;
                TxtDescripcion.Text = MiMateriaLocal.Descripcion;
                CbActivo.Checked = MiMateriaLocal.Activo;

                ActivarEditarYEliminar();
            }
        }

        private bool ValidarDatos()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()) &&
                TxtCodigoBarras.Text.Trim() != TxtCodigoBarras.Tag.ToString() &&
                !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecio.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCantidadStock.Text.Trim()) &&
                CboxCategoria.SelectedIndex > -1 &&
                CboxProveedor.SelectedIndex > -1)
            {
                if (!BtnEditar.Enabled)
                {
                    R = true;
                }
            }
            return R;
        }



        private bool ValidarDatosEditar()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()) &&
                TxtCodigoBarras.Text.Trim() != TxtCodigoBarras.Tag.ToString() &&
                !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecio.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCantidadStock.Text.Trim()) &&
                CboxCategoria.SelectedIndex > -1 &&
                CboxProveedor.SelectedIndex > -1)
            {
                if (BtnEditar.Enabled)
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
                DialogResult RespuestaMateria = MessageBox.Show("¿Está seguro que desea agregar esta materia prima?", "Confirmación requerida", MessageBoxButtons.YesNo);

                if (RespuestaMateria == DialogResult.Yes)
                {
                    Logic_Inventory.Materia_Prima MiMateria = new Logic_Inventory.Materia_Prima();

                    MiMateria.Codigo_Barras = TxtCodigoBarras.Text.Trim();
                    MiMateria.Nombre = TxtNombre.Text.Trim();
                    MiMateria.Precio = Convert.ToDecimal(value: TxtPrecio.Text);
                    MiMateria.Descripcion = TxtDescripcion.Text.Trim();
                    MiMateria.CantidadEnStock = Convert.ToInt32(TxtCantidadStock.Text);
                    MiMateria.Categoria.ID_MPCategoria = Convert.ToInt32(CboxCategoria.SelectedValue);
                    MiMateria.MiProveedor.ID_Proveedor = Convert.ToInt32(CboxProveedor.SelectedValue);


                    bool CodigoExiste = MiMateria.ConsultarPorCodigoBarras();


                    if (!CodigoExiste)
                    {
                        if (MiMateria.Agregar())
                        {
                            MessageBox.Show("Materia prima agregada correctamente.", "", MessageBoxButtons.OK);

                            LimpiarForm();
                            LlenarListaMaterias(true);
                            ActivarBotonAgregar();
                        }
                    }
                    else
                    {
                        if (CodigoExiste)
                        {
                            MessageBox.Show("El código de barras ingresado pertenece a otra materia prima", "", MessageBoxButtons.OK);
                            TxtCodigoBarras.Focus();
                            TxtCodigoBarras.SelectAll();
                        }
                    }
                }
            }
        }

        private void TxtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            TxtCodigoBarras.ForeColor = Color.DarkGray;
            if (TxtCodigoBarras.Text == TxtCodigoBarras.Tag.ToString())
            {
                TxtCodigoBarras.ForeColor = Color.White;
            }
        }

        private void TxtCodigoBarras_Enter(object sender, EventArgs e)
        {
            if (TxtCodigoBarras.Text == TxtCodigoBarras.Tag.ToString())
            {
                TxtCodigoBarras.Clear();
            }
        }

        private void TxtCodigoBarras_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()))
            {
                TxtCodigoBarras.Text = TxtCodigoBarras.Tag.ToString();
            }
        }

        private void CbVerMateriasActivos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarListaMaterias(CbVerMateriasActivos.Checked);
            if (CbVerMateriasActivos.Checked)
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Materia_Prima MiMateria = new Logic_Inventory.Materia_Prima();
            MiMateria.ID_Materia = Convert.ToInt32(TxtID.Text.Trim());

            if (MiMateria.ConsultarPorID())
            {
                if (FlagActivar)
                {
                    if (MiMateria.Activar())
                    {
                        MessageBox.Show("Materia prima activada correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaMaterias(CbVerMateriasActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
                else
                {
                    if (MiMateria.Desactivar())
                    {
                        MessageBox.Show("Materia prima eliminada correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaMaterias(true);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosEditar())
            {
                Logic_Inventory.Materia_Prima MiMateria = new Logic_Inventory.Materia_Prima();

                MiMateria.ID_Materia = Convert.ToInt32(TxtID.Text.Trim());
                MiMateria.Codigo_Barras = TxtCodigoBarras.Text.Trim();
                MiMateria.Nombre = TxtNombre.Text.Trim();
                MiMateria.Precio = Convert.ToDecimal(value: TxtPrecio.Text);
                MiMateria.Descripcion = TxtDescripcion.Text.Trim();
                MiMateria.CantidadEnStock = Convert.ToInt32(TxtCantidadStock.Text);
                MiMateria.Categoria.ID_MPCategoria = Convert.ToInt32(CboxCategoria.SelectedValue);
                MiMateria.MiProveedor.ID_Proveedor = Convert.ToInt32(CboxProveedor.SelectedValue);

                if (MiMateria.ConsultarPorID())
                {
                    if (MiMateria.Editar())
                    {
                        MessageBox.Show("Materia prima editada correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaMaterias(CbVerMateriasActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarListaMaterias(CbVerMateriasActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                LlenarListaMaterias(CbVerMateriasActivos.Checked);
            }
        }


        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void TxtCantidadStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }
    }
}
