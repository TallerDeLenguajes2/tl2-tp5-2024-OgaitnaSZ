using Microsoft.AspNetCore.Mvc;
using Repositorios;
using EspacioProducto;

[Route("[controller]")]
[ApiController]
public class ProductoController  : ControllerBase{
    private readonly IProductoRepository ProductoRepository;

    public ProductoController(IProductoRepository productoRepository){
        ProductoRepository = productoRepository;
    }

    // POST /api/Producto: Permite crear un nuevo Producto.
    [HttpPost]
    public IActionResult CrearProducto([FromBody] Producto producto){
        // El código de estado HTTP 201 (Created) es mas adecuado cuando se crea un nuevo recurso.
        try{
            ProductoRepository.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.idProducto }, producto);
        }catch(Exception ex) {
            return BadRequest("Error al crear el producto: " + ex.Message);
        }
    }

    // GET /api/Producto: Permite listar los Productos existentes
    [HttpGet]
    public IActionResult ListarProductos(){
        try {
            var productos = ProductoRepository.ListarProductos();
            return Ok(productos);
        }catch (Exception ex) {
            return BadRequest("Error al listar productos: " + ex.Message);
        }
    }

    // PUT /api/Producto/{id}
    [HttpPut("{id}")]
    public IActionResult ModificarProducto(int id, [FromBody] Producto producto){
        var productoExistente = ProductoRepository.ObtenerProductoPorId(id);
        if (productoExistente == null){
            return NotFound("No se encontró un producto con ese ID.");
        }

        try {
            ProductoRepository.ModificarProducto(id, producto);
            // El código de estado HTTP 201 (NoContent) es mas adecuado cuando una solicitud se procesa correctamente pero no hay contenido que devolver.
            return NoContent();
        }catch (Exception ex) {
            return BadRequest("Error al modificar el producto: " + ex.Message);
        }
    }

    //Agregados
    [HttpGet("{id}")]
    public IActionResult ObtenerProductoPorId(int id){
        var producto = ProductoRepository.ObtenerProductoPorId(id);
        if (producto == null){
            return NotFound("No se encontró un producto con ese ID.");
        }
        return Ok(producto);
    }
}

