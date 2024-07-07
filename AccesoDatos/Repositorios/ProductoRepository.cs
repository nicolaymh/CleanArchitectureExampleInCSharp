using Dominio.Entidades;
using Dominio.Servicios.Interfaces;
using System.Collections.Generic;

namespace AccesoDatos.Repositorios
{
    public class ProductoRepository : IProductoService
    {
        private readonly List<Producto> _productos;

        public ProductoRepository()
        {
            // Inicializar la lista con algunos productos de ejemplo
            _productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Producto 1", Precio = 100 },
                new Producto { Id = 2, Nombre = "Producto 2", Precio = 200 }
            };
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public Producto ObtenerPorId(int id)
        {
            return _productos.Find(p => p.Id == id);
        }

        public void Crear(Producto producto)
        {
            _productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            var existente = _productos.Find(p => p.Id == producto.Id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Precio = producto.Precio;
            }
        }

        public void Eliminar(int id)
        {
            var producto = _productos.Find(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
        }
    }
}
