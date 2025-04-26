using System.Collections.Generic;
using System.Linq;

namespace RestaurantPedidos.Datos.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        T Obtener(int id);
        IQueryable<T> ObtenerTodos();
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(T entidad);
    }
}