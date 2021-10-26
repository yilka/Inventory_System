using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Logic_Inventory
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEnStock { get; set; }
        public bool Activo { get; set; }

        public Producto_Categoria Categoria { get; set; }

        public Producto()
        {
            Categoria = new Producto_Categoria();
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


        public Producto Consultar(int ID_Producto)
        {
            Producto R = new Producto();
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
