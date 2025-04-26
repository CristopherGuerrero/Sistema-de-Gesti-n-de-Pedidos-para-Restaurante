using Microsoft.EntityFrameworkCore;
using RestaurantPedidos.Datos;
using RestaurantPedidos.Datos.Entidades;
using RestaurantPedidos.LogicaNegocio.Interfaces;

namespace RestaurantPedidos.LogicaNegocio.Servicios
{
    public class PlatoServicio : IPlatoServicio
    {
        private readonly AppDbContext _context;

        public PlatoServicio(AppDbContext context)
        {
            _context = context;
        }

        public Plato ObtenerPlato(int id)
        {
            return _context.Platos.Find(id);
        }

        public List<Plato> ObtenerTodosLosPlatos()
        {
            return _context.Platos.Include(p => p.CategoriaPlato).ToList();
        }

        public void AgregarPlato(Plato plato)
        {
            _context.Platos.Add(plato);
            _context.SaveChanges();
        }

        public void ActualizarPlato(Plato plato)
        {
            _context.Platos.Update(plato);
            _context.SaveChanges();
        }

        public void EliminarPlato(int id)
        {
            var plato = _context.Platos.Find(id);
            if (plato != null)
            {
                _context.Platos.Remove(plato);
                _context.SaveChanges();
            }
        }
    }
}