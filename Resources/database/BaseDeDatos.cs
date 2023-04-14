
using SQLite;
using App.Resources.models;

namespace App.Resources.BaseDeDatos
{
    public class BaseDatos : SQLiteConnection
    {
        public BaseDatos(string path) : base(path)
        {
            CreateTable<Producto>();
        }

        public void InsertarProducto(string nombre, decimal precio, int cantidad)
        {
            Producto producto = new Producto { Nombre = nombre, Precio = precio, Cantidad = cantidad };
            Insert(producto);
        }

        public Producto ObtenerProducto(int id)
        {
            return Table<Producto>().FirstOrDefault(p => p.Id == id);
        }

        public void EliminarProducto(string nombre)
        {
            var productos = Table<Producto>().Where(p => p.Nombre == nombre);
            foreach (var producto in productos)
            {
                Delete(producto);
            }
        }


    }
}