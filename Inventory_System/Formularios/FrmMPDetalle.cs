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
    public partial class FrmMPDetalle : Form
    {

        public DataTable ListaMaterias { get; set; }
        public DataTable ListaMateriasConFiltro { get; set; }
        public Logic_Inventory.Materia_Prima MiMateria { get; set; }

        public FrmMPDetalle()
        {
            InitializeComponent();
            ListaMaterias = new DataTable();
            ListaMateriasConFiltro = new DataTable();
            MiMateria = new Logic_Inventory.Materia_Prima(); 
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmMPDetalle_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }


        private void LlenarLista()
        {
            ListaMaterias = MiMateria.ListarEnDetalle();
            DgvListaMaterias.DataSource = ListaMaterias;
            DgvListaMaterias.ClearSelection();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DataRow NuevaFila = Locales.ObjetosGlobales.MiFormGestionInventarioMP.DtListaMaterias.NewRow();

                NuevaFila["ID_Materia"] = Convert.ToInt32(DgvListaMaterias.SelectedRows[0].Cells["ColID_Materia"].Value);
                NuevaFila["Nombre"] = DgvListaMaterias.SelectedRows[0].Cells["ColNombre"].Value.ToString();
                NuevaFila["Total"] = DgvListaMaterias.SelectedRows[0].Cells["ColPrecio"].Value.ToString();
                NuevaFila["Cantidad"] = NudCantidad.Value;

                Locales.ObjetosGlobales.MiFormGestionInventarioMP.DtListaMaterias.Rows.Add(NuevaFila);
                this.DialogResult = DialogResult.OK;
            }
        }


        private bool ValidarDatos()
        {
            bool R = false;
            if(DgvListaMaterias.SelectedRows.Count == 1 &&
                NudCantidad.Value > 0)
            {
                R = true;
            }
            else
            {
                if(NudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser cero o negativa", "Error de validación", MessageBoxButtons.OK);
                }
            }
            return R;
        }
    }
}
