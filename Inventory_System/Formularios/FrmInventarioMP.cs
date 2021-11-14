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
    public partial class FrmInventarioMP : Form
    {

        public Logic_Inventory.Inventario_MP MiInventarioMPLocal { get; set; }
        public DataTable DtListarMaterias { get; set; }

        public FrmInventarioMP()
        {
            InitializeComponent();
            MiInventarioMPLocal = new Logic_Inventory.Inventario_MP();
            DtListarMaterias = new DataTable();
        }

        private void FrmInventarioMP_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = Locales.ObjetosGlobales.MiUsuarioGlobal.Nombre;
            Limpiar();
        }


        private void Limpiar()
        {
            DtpFecha.Value = DateTime.Now.Date;
            TxtID.Clear();
            DtListarMaterias = MiInventarioMPLocal.AsignarEsquemaDetalle();
            DgvListaMaterias.DataSource = DtListarMaterias;
            TxtTotal.Text = "0";
        }

        private void BtnAgregarMateria_Click(object sender, EventArgs e)
        {
            Form FormBuscarItem = new Formularios.FrmMPDetalle();
            DialogResult Resp = FormBuscarItem.ShowDialog();
            if (Resp == DialogResult.OK)
            {
                DgvListaMaterias.DataSource = DtListarMaterias;
                TxtTotal.Text = string.Format("{0:C2}", Totalizar());
            }
        }

        private decimal Totalizar()
        {
            decimal R = 0;
            if(DtListarMaterias.Rows.Count > 0)
            {
                foreach(DataRow item in DtListarMaterias.Rows)
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


        //private bool ValidarInventario()
        //{
        //    bool R = false;

        //    if(DtpFecha.Value.Date <= DateTime.Now.Date &&
        //        )
        //}


        private void BtnCrearInventario_Click(object sender, EventArgs e)
        {

        }
    }
}
