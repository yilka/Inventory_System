using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Inventory_System.Formularios
{
    public partial class FrmInventarioMP : Form
    {

        public Logic_Inventory.Inventario_MP MiInventarioMPLocal { get; set; }
        public DataTable DtListaMaterias { get; set; }

        public FrmInventarioMP()
        {
            InitializeComponent();
            MiInventarioMPLocal = new Logic_Inventory.Inventario_MP();
            DtListaMaterias = new DataTable();
        }

        private void FrmInventarioMP_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }


        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            DtListaMaterias = MiInventarioMPLocal.AsignarEsquemaDetalle();
            DgvListaMaterias.DataSource = DtListaMaterias;
            TxtTotal.Text = "0";
        }

        private void BtnAgregarMateria_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmMPDetalle();
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
            if(DtListaMaterias.Rows.Count > 0)
            {
                foreach(DataRow item in DtListaMaterias.Rows)
                {
                    R += Convert.ToDecimal(item["Cantidad"]) * Convert.ToDecimal(item["Total"]);
                }
            }
            return R;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidarInventario()
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
                    MessageBox.Show(@"La fecha del inventario no puede ser superior a la fecha actual", "Error de validación", MessageBoxButtons.OK);
                    return false;
                }
            }
            return R;
        }


        private void BtnCrearInventario_Click(object sender, EventArgs e)
        {
            if (ValidarInventario())
            {
                MiInventarioMPLocal.Fecha = DtpFecha.Value.Date;
                MiInventarioMPLocal.MiUsuario.ID_Usuario = Locales.ObjetosGlobales.MiUsuarioGlobal.ID_Usuario;

                LlenarDetalleInventario();

                if (MiInventarioMPLocal.Agregar())
                {
                    MessageBox.Show("El inventario se realizó correctamente", "", MessageBoxButtons.OK);

                    ReportDocument MiReporteInventarioMP = new ReportDocument();

                    MiReporteInventarioMP = new Reportes.RptInventarioMP();

                    MiReporteInventarioMP = MiInventarioMPLocal.Imprimir(MiReporteInventarioMP);

                    FrmVisualizadorReportes MiFormCRV = new FrmVisualizadorReportes();

                    MiFormCRV.CrvVisualizador.ReportSource = MiReporteInventarioMP;

                    MiFormCRV.Show();


                    MiFormCRV.CrvVisualizador.Zoom(1);


                    Limpiar();
                }

            }

        }


        private void LlenarDetalleInventario()
        {
            foreach(DataRow fila in DtListaMaterias.Rows)
            {
                Logic_Inventory.MP_Detalle detalle = new Logic_Inventory.MP_Detalle();

                detalle.MiMateria.ID_Materia = Convert.ToInt32(fila["ID_Materia"]);
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Total = Convert.ToDecimal(fila["Total"]);
                detalle.MiMateria.Nombre = fila["Nombre"].ToString();

                MiInventarioMPLocal.MPListaDetalle.Add(detalle);
            }
        }

        private void BtnEliminarMateria_Click(object sender, EventArgs e)
        {
            int num = Locales.ObjetosGlobales.MiFormGestionInventarioMP.DgvListaMaterias.SelectedRows[0].Index;
            Locales.ObjetosGlobales.MiFormGestionInventarioMP.DtListaMaterias.Rows.RemoveAt(num);
            MessageBox.Show("Materia Prima eliminada de la lista");
            TxtTotal.Text = string.Format("{0:C2}", Totalizar());
        }
    }
}
