using EspacioPresupuesto;
using EspacioProducto;
using EspacioPresupuestoDetalle;

namespace Repositorios;
public class PresupuestoRepository : IPresupuestoRepository{
    private readonly List<Presupuesto> Presupuestos = new List<Presupuesto>();

    public void CrearPresupuesto(Presupuesto presupuesto){
        Presupuestos.Add(presupuesto);
    }

    public List<Presupuesto> ListarPresupuestos(){
        return Presupuestos;
    }

    public Presupuesto ObtenerPresupuestoPorId(int id){
        return Presupuestos.FirstOrDefault(p => p.idPresupuesto == id);
    }

    public void AgregarProductoAPresupuesto(int idPresupuesto, Producto producto, int cantidad){
        Presupuesto presupuesto = ObtenerPresupuestoPorId(idPresupuesto);
        if (presupuesto != null){
            var detalle = presupuesto.Detalle.FirstOrDefault(d => d.producto.idProducto == producto.idProducto);
            if (detalle != null){
                detalle.cantidad += cantidad; //Si el producto ya estaba agregado, suma una cantidad
            }else{
                presupuesto.Detalle.Add(new PresupuestoDetalle(producto, cantidad));
            }
        }
    }

    public void EliminarPresupuesto(int id){
        Presupuesto presupuesto = ObtenerPresupuestoPorId(id);
        if (presupuesto != null){
            Presupuestos.Remove(presupuesto);
        }
    }
}
