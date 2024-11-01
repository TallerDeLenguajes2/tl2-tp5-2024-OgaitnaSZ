using EspacioPresupuesto;
using EspacioProducto;
using System.Collections.Generic;
namespace Repositorios;
public interface IPresupuestoRepository{
    void CrearPresupuesto(Presupuesto presupuesto);
    List<Presupuesto> ListarPresupuestos();
    Presupuesto ObtenerPresupuestoPorId(int id);
    void AgregarProductoAPresupuesto(int idPresupuesto, Producto producto, int cantidad);
    void EliminarPresupuesto(int id);
}
