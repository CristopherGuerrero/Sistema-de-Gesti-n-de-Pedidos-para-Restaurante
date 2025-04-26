namespace RestaurantPedidos.Datos.Entidades
{
    public class DetallePedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int PlatoId { get; set; }
        public Plato Plato { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario; // Agregada propiedad calculada Subtotal
    }
}