using System.Collections.Generic;

namespace RestaurantPedidos.Datos.Entidades
{
    public class CategoriaPlato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Plato> Platos { get; set; } = new List<Plato>();
    }
}