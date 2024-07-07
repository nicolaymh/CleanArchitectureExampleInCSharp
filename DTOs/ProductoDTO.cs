using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }


        // Ejemplo de lógica de negocio
        public void AplicarDescuento(decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
            {
                throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100.");
            }
            Precio -= Precio * (porcentaje / 100);
        }
    }
}
