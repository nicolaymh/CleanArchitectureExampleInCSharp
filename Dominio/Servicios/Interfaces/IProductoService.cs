using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> ObtenerTodos();
        Producto ObtenerPorId(int id);
        void Crear(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(int id);
    }
}