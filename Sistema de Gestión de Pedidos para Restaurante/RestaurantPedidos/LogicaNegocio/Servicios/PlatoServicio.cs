using System.Collections.Generic;
using RestaurantPedidos.Datos.Entidades;

namespace RestaurantPedidos.LogicaNegocio.Interfaces
{
    public interface IPlatoServicio
    {
        Plato ObtenerPlato(int id);
        List<Plato> ObtenerTodosLosPlatos();
        void AgregarPlato(Plato plato);
        void ActualizarPlato(Plato plato);
        void EliminarPlato(int id);
    }
}