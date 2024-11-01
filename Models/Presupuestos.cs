using EspacioPresupuestoDetalle;

namespace EspacioPresupuesto;
public class Presupuesto{
    int idPresupuesto;
    string nombreDestinario;
    List<PresupuestoDetalle> detalle;

    public Presupuesto(int Id, string NombreDestinario){
        Id = idPresupuesto;
        NombreDestinario = nombreDestinario;
    }

    public void MontoPresupuesto(){}
    public void MontoPresupuestoConIva(){}
    public int CantidadProductos(){
        return 0;
    }
}