using System.Data;

namespace Logic_Inventory
{
    public class Producto_Categoria
    {
        public int ID_PCategoria { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }

        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPPCategoriaListar");
            return R;
        }
    }
}
