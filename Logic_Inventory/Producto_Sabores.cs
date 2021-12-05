using System.Data;

namespace Logic_Inventory
{
    public class Producto_Sabores
    {
        public int ID_Sabores { get; set; }
        public string Sabor { get; set; }



        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPSaboresListar");
            return R;
        }
    }
}
