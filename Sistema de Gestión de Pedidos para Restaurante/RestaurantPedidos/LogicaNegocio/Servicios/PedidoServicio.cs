using System.Collections.Generic;
using RestaurantPedidos.Datos.Entidades;

namespace RestaurantPedidos.LogicaNegocio.Interfaces
{
    public interface IPedidoServicio
    {
        Pedido ObtenerPedido(int id);
        List<Pedido> ObtenerTodosLosPedidos();
        void AgregarPedido(Pedido pedido);
        void ActualizarPedido(Pedido pedido);
        void EliminarPedido(int id);
        void AgregarDetallePedido(int pedidoId, int platoId, int cantidad);
    }
}