using EspacioProducto;

namespace Repositorios;
public interface IProductoRepository{
    void CrearProducto(Producto producto);
    void ModificarProducto(int id, Producto producto);
    List<Producto> ListarProductos();
    Producto ObtenerProductoPorId(int id);
    void EliminarProducto(int id);
}
