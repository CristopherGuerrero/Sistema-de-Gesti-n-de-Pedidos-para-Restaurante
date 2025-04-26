using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RestaurantPedidos.Datos;

namespace RestaurantPedidos.Factories
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=RestaurantPedidosDB;Trusted_Connection=True;"; // Tu cadena de conexión aquí

            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}