using EspacioProducto;

namespace Repositorios;
public class ProductoRepository : IProductoRepository{
    private readonly List<Producto> Productos = new List<Producto>();

    public void CrearProducto(Producto producto){
        Productos.Add(producto);
    }

    public void ModificarProducto(int id, Producto producto){
        Producto prodExistente = Productos.FirstOrDefault(p => p.idProducto == id);
        if (prodExistente != null){
            prodExistente.descripcion = producto.descripcion;
            prodExistente.precio = producto.precio;
        }
    }

    public List<Producto> ListarProductos(){
        return Productos;
    }

    public Producto ObtenerProductoPorId(int id){
        return Productos.FirstOrDefault(p => p.idProducto == id);
    }

    public void EliminarProducto(int id){
        Producto producto = ObtenerProductoPorId(id);
        if (producto != null){
            Productos.Remove(producto);
        }
    }
}
