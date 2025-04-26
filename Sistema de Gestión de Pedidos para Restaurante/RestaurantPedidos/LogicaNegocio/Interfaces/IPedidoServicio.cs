using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantPedidos.Datos;
using RestaurantPedidos.Datos.Entidades;
using RestaurantPedidos.LogicaNegocio.Interfaces;

namespace RestaurantPedidos.LogicaNegocio.Servicios
{
    public class PedidoServicio : IPedidoServicio
    {
        private readonly AppDbContext _context;

        public PedidoServicio(AppDbContext context)
        {
            _context = context;
        }

        public Pedido ObtenerPedido(int id)
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.DetallesPedido) // Usar el nombre correcto de la propiedad
                    .ThenInclude(d => d.Plato)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> ObtenerTodosLosPedidos()
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.DetallesPedido) // Usar el nombre correcto de la propiedad
                    .ThenInclude(d => d.Plato)
                .ToList();
        }

        public void AgregarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void ActualizarPedido(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }

        public void EliminarPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }

        public void AgregarDetallePedido(int pedidoId, int platoId, int cantidad)
        {
            var pedido = _context.Pedidos.Find(pedidoId);
            var plato = _context.Platos.Find(platoId);

            if (pedido != null && plato != null)
            {
                var detalle = new DetallePedido
                {
                    PedidoId = pedidoId,
                    PlatoId = platoId,
                    Cantidad = cantidad,
                    PrecioUnitario = plato.Precio
                };
                _context.DetallesPedido.Add(detalle);
                pedido.DetallesPedido.Add(detalle); // Usar el nombre correcto de la propiedad
                pedido.Total += cantidad * plato.Precio;
                _context.SaveChanges();
            }
        }

        public Pedido ObtenerPedidoConDetalles(int id) // Implementación del método que faltaba
        {
            return _context.Pedidos
                .Where(p => p.Id == id)
                .Include(p => p.Cliente)
                .Include(p => p.DetallesPedido)
                    .ThenInclude(d => d.Plato)
                .FirstOrDefault();
        }
    }
}