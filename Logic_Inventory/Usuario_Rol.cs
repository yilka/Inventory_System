using System.Data;

namespace Logic_Inventory
{
    public class Usuario_Rol
    {
        public int ID_Rol { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }


        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MyCnn = new Conexion();
            R = MyCnn.DMLSelect("SPUsuarioRolListar");
            return R;
        }

    }
}
