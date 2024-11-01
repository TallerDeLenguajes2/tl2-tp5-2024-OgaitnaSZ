using EspacioPresupuestoDetalle;
using System.Collections.Generic;
using System.Linq;

namespace EspacioPresupuesto;
public class Presupuesto{
    public int idPresupuesto{ get; set; }
    public string nombreDestinario{ get; set; }
    public List<PresupuestoDetalle> Detalle { get; set; } = new List<PresupuestoDetalle>();

    public Presupuesto(int Id, string NombreDestinario){
        Id = idPresupuesto;
        NombreDestinario = nombreDestinario;
    }

        public int MontoPresupuesto()
        {
            return Detalle.Sum(d => d.producto.precio * d.cantidad);
        }

        public int MontoPresupuestoConIva()
        {
            const double iva = 0.21;
            return (int)(MontoPresupuesto() * (1 + iva));
        }

        public int CantidadProductos()
        {
            return Detalle.Sum(d => d.cantidad);
        }
}