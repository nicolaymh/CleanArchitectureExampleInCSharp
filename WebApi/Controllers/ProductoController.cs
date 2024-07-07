using Dominio.Entidades;
using Dominio.Servicios.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene todos los productos.
        /// </summary>
        /// <returns>Una lista de productos.</returns>
        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<IEnumerable<ProductoDTO>> ObtenerTodos()
        {
            var productos = _productoService.ObtenerTodos();
            if (!productos.Any())
            {
                return NotFound(new { Mensaje = "No se encontraron productos" });
            }

            var productosDTO = productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio
            }).ToList();

            return Ok(new { Mensaje = "Productos obtenidos exitosamente", Datos = productosDTO });
        }

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto.</param>
        /// <returns>El producto con el ID especificado.</returns>
        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public ActionResult<ProductoDTO> ObtenerPorId(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Mensaje = "ID de producto inválido" });
            }

            var producto = _productoService.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound(new { Mensaje = "Producto no encontrado" });
            }

            var productoDTO = new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };

            return Ok(new { Mensaje = "Producto obtenido exitosamente", Datos = productoDTO });
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productoDTO">El producto a crear.</param>
        /// <returns>El producto creado.</returns>
        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Produces("application/json")]
        public IActionResult Crear(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                return BadRequest(new { Mensaje = "Datos del producto no proporcionados" });
            }

            if (string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Precio <= 0)
            {
                return BadRequest(new { Mensaje = "Nombre del producto o precio inválidos" });
            }

            var existente = _productoService.ObtenerPorId(productoDTO.Id);
            if (existente != null)
            {
                return Conflict(new { Mensaje = "Un producto con el mismo ID ya existe" });
            }

            var producto = new Producto
            {
                Id = productoDTO.Id,
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio
            };

            _productoService.Crear(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, new { Mensaje = "Producto creado exitosamente", Datos = productoDTO });
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="productoDTO">El producto a actualizar.</param>
        /// <returns>El producto actualizado.</returns>
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public IActionResult Actualizar(ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                return BadRequest(new { Mensaje = "Datos del producto no proporcionados" });
            }

            if (string.IsNullOrWhiteSpace(productoDTO.Nombre) || productoDTO.Precio <= 0)
            {
                return BadRequest(new { Mensaje = "Nombre del producto o precio inválidos" });
            }

            var existente = _productoService.ObtenerPorId(productoDTO.Id);
            if (existente == null)
            {
                return NotFound(new { Mensaje = "Producto no encontrado para actualizar" });
            }

            var producto = new Producto
            {
                Id = productoDTO.Id,
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio
            };

            _productoService.Actualizar(producto);
            return Ok(new { Mensaje = "Producto actualizado exitosamente", Datos = productoDTO });
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <returns>Una confirmación de que el producto ha sido eliminado.</returns>
        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public IActionResult Eliminar(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Mensaje = "ID de producto inválido" });
            }

            var existente = _productoService.ObtenerPorId(id);
            if (existente == null)
            {
                return NotFound(new { Mensaje = "Producto no encontrado para eliminar" });
            }

            _productoService.Eliminar(id);
            return Ok(new { Mensaje = "Producto eliminado exitosamente" });
        }
    }
}
