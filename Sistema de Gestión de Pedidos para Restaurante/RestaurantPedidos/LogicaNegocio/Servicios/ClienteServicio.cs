using System.Collections.Generic;
using RestaurantPedidos.Datos.Entidades;

namespace RestaurantPedidos.LogicaNegocio.Interfaces
{
    public interface IClienteServicio
    {
        Cliente ObtenerCliente(int id);
        List<Cliente> ObtenerTodosLosClientes();
        void AgregarCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
    }
}