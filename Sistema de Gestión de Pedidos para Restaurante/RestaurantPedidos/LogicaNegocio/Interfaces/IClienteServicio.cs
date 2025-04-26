using RestaurantPedidos.Datos;
using RestaurantPedidos.Datos.Entidades;
using RestaurantPedidos.LogicaNegocio.Interfaces;

namespace RestaurantPedidos.LogicaNegocio.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly AppDbContext _context;

        public ClienteServicio(AppDbContext context)
        {
            _context = context;
        }

        public Cliente ObtenerCliente(int id)
        {
            return _context.Clientes.Find(id);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return _context.Clientes.ToList();
        }

        public void AgregarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void ActualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}

