namespace RestaurantPedidos.Datos.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Mesa { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}