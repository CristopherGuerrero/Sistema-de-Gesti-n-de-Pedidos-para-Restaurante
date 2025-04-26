using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantPedidos.Datos;
using RestaurantPedidos.LogicaNegocio.Servicios;
using RestaurantPedidos.Presentacion;

namespace RestaurantPedidos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configurar los servicios
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(" Server = (localdb)\\mssqllocaldb; Database = RestaurantPedidosDB; Trusted_Connection = True;")); // Tu cadena de conexión


            services.AddScoped<PlatoServicio>();
            services.AddScoped<ClienteServicio>();
            services.AddScoped<PedidoServicio>();

            var serviceProvider = services.BuildServiceProvider();

            // Obtener instancias de los servicios
            var platoServicio = serviceProvider.GetService<PlatoServicio>();
            var clienteServicio = serviceProvider.GetService<ClienteServicio>();
            var pedidoServicio = serviceProvider.GetService<PedidoServicio>();

            // Crear e iniciar la interfaz de usuario de consola
            var consolaUI = new ConsolaUI(platoServicio, clienteServicio, pedidoServicio);
            consolaUI.Ejecutar();
        }
    }
}