using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Logic_Inventory
{
    public class Crystal
    {
        public ReportDocument Reporte { get; set; }
        public DataTable Datos { get; set; }

        public Crystal(ReportDocument pRpt)
        {
            Reporte = pRpt;
        }

        public Crystal()
        {

        }

        public ReportDocument GenerarReporte()
        {
            if (Datos.Rows.Count > 0)
            {
                Reporte.SetDataSource(Datos);

                return Reporte;
            }
            else
            { return null; }
        }

    }

}

