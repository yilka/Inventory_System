using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Windows.Forms;

namespace Inventory_System.Formularios
{
    public partial class FrmUsoMateriaPrima : Form
    {

        public Logic_Inventory.Uso_MP MiUsoLocal { get; set; }
        public DataTable DtListaMaterias { get; set; }


        public FrmUsoMateriaPrima()
        {
            InitializeComponent();
            MiUsoLocal = new Logic_Inventory.Uso_MP();
            DtListaMaterias = new DataTable();
        }

        private void FrmUsoMateriaPrima_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }


        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            TxtDetalle.Text = "";
            DtListaMaterias = MiUsoLocal.AsignarEsquemaDetalle();
            DgvListaMaterias.DataSource = DtListaMaterias;
            TxtTotal.Text = "0";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregarMateria_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmUsoDetalle();
            DialogResult Resp = FormBuscarItem.ShowDialog();
            if (Resp == DialogResult.OK)
            {
                DgvListaMaterias.DataSource = DtListaMaterias;
                TxtTotal.Text = string.Format("{0:C2}", Totalizar());
            }
        }


        private decimal Totalizar()
        {
            decimal R = 0;
            if (DtListaMaterias.Rows.Count > 0)
            {
                foreach (DataRow item in DtListaMaterias.Rows)
                {
                    R += Convert.ToDecimal(item["Cantidad"]) * Convert.ToDecimal(item["Total"]);
                }
            }
            return R;
        }


        private bool ValidarUso()
        {
            bool R = false;

            if (DtpFecha.Value.Date <= DateTime.Now.Date &&
                DtListaMaterias.Rows.Count > 0)
            {
                R = true;
            }
            else
            {
                if (DtpFecha.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show(@"La fecha del uso no puede ser superior a la fecha actual", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }
            return R;
        }


        private void LlenarDetalleUso()
        {
            foreach (DataRow fila in DtListaMaterias.Rows)
            {
                Logic_Inventory.Uso_Detalle detalle = new Logic_Inventory.Uso_Detalle();

                detalle.MiMateria.ID_Materia = Convert.ToInt32(fila["ID_Materia"]);
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Total = Convert.ToDecimal(fila["Total"]);
                detalle.MiMateria.Nombre = fila["Nombre"].ToString();

                MiUsoLocal.UsoListaDetalle.Add(detalle);
            }
        }

        private void BtnEliminarMateria_Click(object sender, EventArgs e)
        {
            int num = Locales.ObjetosGlobales.MiFormGestionUsoMP.DgvListaMaterias.SelectedRows[0].Index;
            Locales.ObjetosGlobales.MiFormGestionUsoMP.DtListaMaterias.Rows.RemoveAt(num);
            MessageBox.Show("Materia eliminada de la lista");
            TxtTotal.Text = string.Format("{0:C2}", Totalizar());
        }

        private void BtnCrearUso_Click(object sender, EventArgs e)
        {
            if (ValidarUso())
            {
                MiUsoLocal.Fecha = DtpFecha.Value.Date;
                MiUsoLocal.MiUsuario.ID_Usuario = Locales.ObjetosGlobales.MiUsuarioGlobal.ID_Usuario;
                MiUsoLocal.Detalle = TxtDetalle.Text.Trim();

                LlenarDetalleUso();

                if (MiUsoLocal.Agregar())
                {
                    MessageBox.Show("El uso se realizó correctamente", "", MessageBoxButtons.OK);

                    ReportDocument MiReporteUso = new ReportDocument();

                    MiReporteUso = new Reportes.RptUsoMP();

                    MiReporteUso = MiUsoLocal.Imprimir(MiReporteUso);

                    FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                    MiFormCRV.CrvVisualizador.ReportSource = MiReporteUso;

                    MiFormCRV.Show();


                    MiFormCRV.CrvVisualizador.Zoom(1);
                    Limpiar();
                }

            }

        }
    }
}
