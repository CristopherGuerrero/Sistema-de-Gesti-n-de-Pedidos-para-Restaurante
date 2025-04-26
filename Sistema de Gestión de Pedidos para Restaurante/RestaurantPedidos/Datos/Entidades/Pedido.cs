using RestaurantPedidos.Datos.Entidades; // Esta línea puede ser redundante, pero no causa error aquí

namespace RestaurantPedidos.Datos.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; } // Cambiado a FechaPedido para coincidir con el uso en ConsolaUI
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetallePedido> DetallesPedido { get; set; } = new List<DetallePedido>(); // Cambiado a DetallesPedido
        public decimal Total { get; set; }
    }
}