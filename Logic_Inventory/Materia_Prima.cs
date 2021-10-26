using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logic_Inventory
{
    public class Materia_Prima
    {
        public int ID_Materia { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEnStock { get; set; }
        public bool Activo { get; set; }

        public MP_Categoria Categoria { get; set; }
        public Proveedor MiProveedor { get; set; }

        public Materia_Prima()
        {
            Categoria = new MP_Categoria();
            MiProveedor = new Proveedor();
        }

        public bool Agregar()
        {
            bool R = false;
            return R;
        }


        public bool Editar()
        {
            bool R = false;
            return R;
        }


        public bool Desactivar()
        {
            bool R = false;
            return R;
        }


        public Materia_Prima Consultar(int ID_Materia)
        {
            Materia_Prima R = new Materia_Prima();
            return R;
        }

        public bool ConsultarPorID()
        {
            bool R = false;
            return R;
        }


        public DataTable Listar()
        {
            DataTable R = new DataTable();
            return R;
        }

    }
}
