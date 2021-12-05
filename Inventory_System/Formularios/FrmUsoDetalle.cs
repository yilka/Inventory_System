using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmUsoDetalle : Form
    {
        public DataTable ListaMaterias { get; set; }
        public Logic_Inventory.Materia_Prima MiMateria { get; set; }

        public FrmUsoDetalle()
        {
            InitializeComponent();
            ListaMaterias = new DataTable();
            MiMateria = new Logic_Inventory.Materia_Prima();
        }

        private void FrmUsoDetalle_Load(object sender, EventArgs e)
        {
            LlenarLista();
        }

        private void LlenarLista()
        {
            ListaMaterias = MiMateria.ListarEnDetalle();
            DgvListaMaterias.DataSource = ListaMaterias;
            DgvListaMaterias.ClearSelection();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private bool ValidarDatos()
        {
            bool R = false;
            if (DgvListaMaterias.SelectedRows.Count == 1 &&
                NudCantidad.Value > 0)
            {
                R = true;
            }
            else
            {
                if (NudCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser cero o negativa", "Error de validación", MessageBoxButtons.OK);
                }
            }
            return R;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DataRow NuevaFila = Locales.ObjetosGlobales.MiFormGestionUsoMP.DtListaMaterias.NewRow();

                NuevaFila["ID_Materia"] = Convert.ToInt32(DgvListaMaterias.SelectedRows[0].Cells["ColID_Materia"].Value);
                NuevaFila["Nombre"] = DgvListaMaterias.SelectedRows[0].Cells["ColNombre"].Value.ToString();
                NuevaFila["Total"] = DgvListaMaterias.SelectedRows[0].Cells["ColPrecio"].Value.ToString();
                NuevaFila["Cantidad"] = NudCantidad.Value;

                Locales.ObjetosGlobales.MiFormGestionUsoMP.DtListaMaterias.Rows.Add(NuevaFila);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
