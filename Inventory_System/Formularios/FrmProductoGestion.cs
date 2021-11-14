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
    public partial class FrmProductoGestion : Form
    {
        private Logic_Inventory.Producto MiProductoLocal { get; set; }
        private bool FlagActivar { get; set; }
        public DataTable ListaProductoNormal { get; set; }
        public DataTable ListaProductoConFiltro { get; set; }

        public FrmProductoGestion()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void LimpiarForm()
        {
            TxtID.Clear();
            TxtCodigoBarras.Text = TxtCodigoBarras.Tag.ToString();
            TxtNombre.Clear();
            TxtPrecio.Clear();
            TxtCantidadStock.Clear();
            CboxCategoria.SelectedIndex = -1;
            CboxSabor.SelectedIndex = -1;
            TxtDescripcion.Clear();
            CbActivo.Checked = false;
        }


        private void CargarDatosComboCategoria()
        {
            Logic_Inventory.Producto_Categoria ObjCategoria = new Logic_Inventory.Producto_Categoria();
            DataTable Datos = new DataTable();
            Datos = ObjCategoria.Listar();

            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Categoria";

            CboxCategoria.DataSource = Datos;
            CboxCategoria.SelectedIndex = -1;
        }


        private void CargarDatosComboSabor()
        {
            Logic_Inventory.Producto_Sabores ObjSabor = new Logic_Inventory.Producto_Sabores();
            DataTable Datos = new DataTable();
            Datos = ObjSabor.Listar();

            CboxSabor.ValueMember = "ID";
            CboxSabor.DisplayMember = "Sabor";

            CboxSabor.DataSource = Datos;
            CboxSabor.SelectedIndex = -1;
        }



        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm();
            ActivarBotonAgregar();
            DgvLista.ClearSelection();

        }

        private void FrmProductoGestion_Load(object sender, EventArgs e)
        {
            LlenarListaProductos(CbVerProductosActivos.Checked);
            CargarDatosComboCategoria();
            CargarDatosComboSabor();
            LimpiarForm();
            ActivarBotonAgregar();
        }


        private void LlenarListaProductos(bool VerActivos, string FiltroBusqueda = "")
        {
            Logic_Inventory.Producto MiProducto = new Logic_Inventory.Producto();

            if (!string.IsNullOrEmpty(FiltroBusqueda.Trim()))
            {
                ListaProductoConFiltro = MiProducto.Listar(VerActivos, FiltroBusqueda);
                DgvLista.DataSource = ListaProductoConFiltro;
            }
            else
            {
                ListaProductoNormal = MiProducto.Listar(VerActivos);
                DgvLista.DataSource = ListaProductoNormal;
            }
            DgvLista.ClearSelection();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Logic_Inventory.Producto MiProducto = new Logic_Inventory.Producto();
            MiProducto.ID_Producto = Convert.ToInt32(TxtID.Text.Trim());

            if (MiProducto.ConsultarPorID())
            {
                if (FlagActivar)
                {
                    if (MiProducto.Activar())
                    {
                        MessageBox.Show("Producto activado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProductos(CbVerProductosActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
                else
                {
                    if (MiProducto.Desactivar())
                    {
                        MessageBox.Show("Producto eliminado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProductos(true);
                        ActivarBotonAgregar();
                    }
                }
            }
        }

        private void CbVerProductosActivos_CheckedChanged(object sender, EventArgs e)
        {
            LlenarListaProductos(CbVerProductosActivos.Checked);
            if (CbVerProductosActivos.Checked)
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



        private void DgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvLista.SelectedRows.Count == 1)
            {
                LimpiarForm();
                DataGridViewRow MiFila = DgvLista.SelectedRows[0];
                int IdProducto = Convert.ToInt32(MiFila.Cells["ColID_Producto"].Value);

                MiProductoLocal = new Logic_Inventory.Producto();
                MiProductoLocal = MiProductoLocal.Consultar(IdProducto);

                TxtID.Text = MiProductoLocal.ID_Producto.ToString();
                TxtCodigoBarras.Text = MiProductoLocal.Codigo_Barras;
                TxtNombre.Text = MiProductoLocal.Nombre;
                TxtPrecio.Text = MiProductoLocal.Precio.ToString();
                TxtCantidadStock.Text = MiProductoLocal.CantidadEnStock.ToString();
                CboxCategoria.SelectedValue = MiProductoLocal.Categoria.ID_PCategoria;
                CboxSabor.SelectedValue = MiProductoLocal.MiSabor.ID_Sabores;
                TxtDescripcion.Text = MiProductoLocal.Descripcion;
                CbActivo.Checked = MiProductoLocal.Activo;

                ActivarEditarYEliminar();
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

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
        }

        private void TxtCantidadStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Herramientas.CaracteresNumeros(e);
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
                CboxSabor.SelectedIndex > -1)
            {
                if (!BtnEditar.Enabled)
                {
                    R = true;
                }
            }
            return R;
        }


        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtBuscar.Text.Trim()) && TxtBuscar.Text.Count() >= 2)
            {
                LlenarListaProductos(CbVerProductosActivos.Checked, TxtBuscar.Text.Trim());
            }
            else
            {
                LlenarListaProductos(CbVerProductosActivos.Checked);
            }
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult RespuestaProducto = MessageBox.Show("¿Está seguro que desea agregar este producto?", "Confirmación requerida", MessageBoxButtons.YesNo);

                if (RespuestaProducto == DialogResult.Yes)
                {
                    Logic_Inventory.Producto MiProducto = new Logic_Inventory.Producto();

                    MiProducto.Codigo_Barras = TxtCodigoBarras.Text.Trim();
                    MiProducto.Nombre = TxtNombre.Text.Trim();
                    MiProducto.Precio = Convert.ToDecimal(value: TxtPrecio.Text);
                    MiProducto.Descripcion = TxtDescripcion.Text.Trim();
                    MiProducto.CantidadEnStock = Convert.ToInt32(TxtCantidadStock.Text);
                    MiProducto.Categoria.ID_PCategoria = Convert.ToInt32(CboxCategoria.SelectedValue);
                    MiProducto.MiSabor.ID_Sabores = Convert.ToInt32(CboxSabor.SelectedValue);


                    bool CodigoExiste = MiProducto.ConsultarPorCodigoBarras();


                    if (!CodigoExiste)
                    {
                        if (MiProducto.Agregar())
                        {
                            MessageBox.Show("Producto agregado correctamente.", "", MessageBoxButtons.OK);

                            LimpiarForm();
                            LlenarListaProductos(true);
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

        private bool ValidarDatosEditar()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCodigoBarras.Text.Trim()) &&
                TxtCodigoBarras.Text.Trim() != TxtCodigoBarras.Tag.ToString() &&
                !string.IsNullOrEmpty(TxtNombre.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecio.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCantidadStock.Text.Trim()) &&
                CboxCategoria.SelectedIndex > -1 &&
                CboxSabor.SelectedIndex > -1)
            {
                if (BtnEditar.Enabled)
                {
                    R = true;
                }
            }
            return R;
        }


        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosEditar())
            {
                Logic_Inventory.Producto MiProducto = new Logic_Inventory.Producto();

                MiProducto.ID_Producto = Convert.ToInt32(TxtID.Text.Trim());
                MiProducto.Codigo_Barras = TxtCodigoBarras.Text.Trim();
                MiProducto.Nombre = TxtNombre.Text.Trim();
                MiProducto.Precio = Convert.ToDecimal(value: TxtPrecio.Text);
                MiProducto.Descripcion = TxtDescripcion.Text.Trim();
                MiProducto.CantidadEnStock = Convert.ToInt32(TxtCantidadStock.Text);
                MiProducto.Categoria.ID_PCategoria = Convert.ToInt32(CboxCategoria.SelectedValue);
                MiProducto.MiSabor.ID_Sabores = Convert.ToInt32(CboxSabor.SelectedValue);

                if (MiProducto.ConsultarPorID())
                {
                    if (MiProducto.Editar())
                    {
                        MessageBox.Show("Producto editado correctamente", "", MessageBoxButtons.OK);
                        LimpiarForm();
                        LlenarListaProductos(CbVerProductosActivos.Checked);
                        ActivarBotonAgregar();
                    }
                }
            }
        }
    }
}
