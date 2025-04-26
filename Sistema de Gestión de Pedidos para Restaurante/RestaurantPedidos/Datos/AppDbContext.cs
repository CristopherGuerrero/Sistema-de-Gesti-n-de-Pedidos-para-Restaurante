using Microsoft.EntityFrameworkCore;
using RestaurantPedidos.Datos.Entidades;

namespace RestaurantPedidos.Datos
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<CategoriaPlato> CategoriasPlato { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePedido>()
                .HasKey(dp => new { dp.PedidoId, dp.PlatoId });

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(p => p.DetallesPedido) // Usar el nombre correcto de la propiedad
                .HasForeignKey(dp => dp.PedidoId);

            modelBuilder.Entity<DetallePedido>()
                .HasOne(dp => dp.Plato)
                .WithMany(p => p.DetallesPedido)
                .HasForeignKey(dp => dp.PlatoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}