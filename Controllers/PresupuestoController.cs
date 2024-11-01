// Ubicación: Controllers/PresupuestosController.cs
using Microsoft.AspNetCore.Mvc;
using EspacioPresupuesto;
using EspacioPresupuestoDetalle;
using Repositorios;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresupuestosController : ControllerBase{
    private readonly IPresupuestoRepository PresupuestoRepository;
    private readonly IProductoRepository productoRepository1;

    public PresupuestosController(IPresupuestoRepository presupuestoRepository, IProductoRepository productoRepository){
        PresupuestoRepository = presupuestoRepository;
        productoRepository1 = productoRepository;
    }

    // POST /api/Presupuesto: Permite crear un Presupuesto
    [HttpPost]
    public IActionResult CrearPresupuesto([FromBody] Presupuesto presupuesto){
        PresupuestoRepository.CrearPresupuesto(presupuesto);
        return CreatedAtAction(nameof(ObtenerPresupuestoPorId), new { id = presupuesto.idPresupuesto }, presupuesto);
    }

    // POST /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente y una cantidad al presupuesto
    [HttpPost("{id}/ProductoDetalle")]
    public IActionResult AgregarProductoAPresupuesto(int id, [FromBody] PresupuestoDetalle detalle){
        var presupuesto = PresupuestoRepository.ObtenerPresupuestoPorId(id);
        if (presupuesto == null){
            return NotFound("No se encontró un presupuesto con ese ID.");
        }

        var producto = productoRepository1.ObtenerProductoPorId(detalle.producto.idProducto);
        if (producto == null){
            return BadRequest("El producto no existe.");
        }

        PresupuestoRepository.AgregarProductoAPresupuesto(id, producto, detalle.cantidad);
        return NoContent();
    }

    // GET /api/presupuesto: Permite listar los presupuestos existentes.
    [HttpGet]
    public IActionResult ListarPresupuestos(){
        var presupuestos = PresupuestoRepository.ListarPresupuestos();
        return Ok(presupuestos);
    }

    // GET /api/Presupuesto/{id}: Permite agregar un Producto existente y una cantidad al presupuesto
    [HttpGet("{id}")]
    public IActionResult ObtenerPresupuestoPorId(int id){
        var presupuesto = PresupuestoRepository.ObtenerPresupuestoPorId(id);
        if (presupuesto == null){
            return NotFound();
        }
        return Ok(presupuesto);
    }
}
