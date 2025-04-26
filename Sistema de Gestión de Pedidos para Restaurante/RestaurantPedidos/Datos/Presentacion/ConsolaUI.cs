using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantPedidos.Datos;
using RestaurantPedidos.Datos.Entidades;
using RestaurantPedidos.LogicaNegocio.Servicios;

namespace RestaurantPedidos.Presentacion
{
    public class ConsolaUI
    {
        private readonly PlatoServicio _platoServicio;
        private readonly ClienteServicio _clienteServicio;
        private readonly PedidoServicio _pedidoServicio;

        public ConsolaUI(PlatoServicio platoServicio, ClienteServicio clienteServicio, PedidoServicio pedidoServicio)
        {
            _platoServicio = platoServicio;
            _clienteServicio = clienteServicio;
            _pedidoServicio = pedidoServicio;
        }

        public void Ejecutar()
        {
            Console.WriteLine("Bienvenido al Sistema de Gestión de Pedidos del Restaurante");

            while (true)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Gestionar Platos");
                Console.WriteLine("2. Gestionar Clientes");
                Console.WriteLine("3. Gestionar Pedidos");
                Console.WriteLine("4. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionarPlatos();
                        break;
                    case "2":
                        GestionarClientes();
                        break;
                    case "3":
                        GestionarPedidos();
                        break;
                    case "4":
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void GestionarPlatos()
        {
            Console.WriteLine("\n--- Gestión de Platos ---");
            Console.WriteLine("1. Listar Platos");
            Console.WriteLine("2. Agregar Plato");
            Console.WriteLine("3. Editar Plato");
            Console.WriteLine("4. Eliminar Plato");
            Console.WriteLine("5. Volver al menú principal");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    ListarPlatos();
                    break;
                case "2":
                    AgregarPlato();
                    break;
                case "3":
                    EditarPlato();
                    break;
                case "4":
                    EliminarPlato();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        private void ListarPlatos()
        {
            var platos = _platoServicio.ObtenerTodosLosPlatos();
            if (platos.Any())
            {
                Console.WriteLine("\n--- Lista de Platos ---");
                foreach (var plato in platos)
                {
                    Console.WriteLine($"ID: {plato.Id}, Nombre: {plato.Nombre}, Precio: {plato.Precio}, Categoría: {plato.CategoriaPlato?.Nombre}");
                }
            }
            else
            {
                Console.WriteLine("No hay platos registrados.");
            }
        }

        private void AgregarPlato()
        {
            Console.WriteLine("\n--- Agregar Nuevo Plato ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();
            Console.Write("Precio: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.Write("ID de Categoría: ");
                if (int.TryParse(Console.ReadLine(), out int categoriaId))
                {
                    var plato = new Plato { Nombre = nombre, Descripcion = descripcion, Precio = precio, CategoriaPlatoId = categoriaId };
                    _platoServicio.AgregarPlato(plato);
                    Console.WriteLine("Plato agregado exitosamente.");
                }
                else
                {
                    Console.WriteLine("ID de categoría inválido.");
                }
            }
            else
            {
                Console.WriteLine("Precio inválido.");
            }
        }

        private void EditarPlato()
        {
            Console.WriteLine("\n--- Editar Plato ---");
            Console.Write("Ingrese el ID del plato a editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var platoExistente = _platoServicio.ObtenerPlato(id);
                if (platoExistente != null)
                {
                    Console.Write($"Nuevo nombre ({platoExistente.Nombre}): ");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre))
                    {
                        platoExistente.Nombre = nuevoNombre;
                    }

                    Console.Write($"Nueva descripción ({platoExistente.Descripcion}): ");
                    string nuevaDescripcion = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevaDescripcion))
                    {
                        platoExistente.Descripcion = nuevaDescripcion;
                    }

                    Console.Write($"Nuevo precio ({platoExistente.Precio}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio))
                    {
                        platoExistente.Precio = nuevoPrecio;
                    }
                    else
                    {
                        Console.WriteLine("Precio inválido, se mantendrá el precio anterior.");
                    }

                    Console.Write($"Nuevo ID de Categoría ({platoExistente.CategoriaPlatoId}): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaCategoriaId))
                    {
                        platoExistente.CategoriaPlatoId = nuevaCategoriaId;
                    }
                    else
                    {
                        Console.WriteLine("ID de categoría inválido, se mantendrá la categoría anterior.");
                    }

                    _platoServicio.ActualizarPlato(platoExistente);
                    Console.WriteLine("Plato actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el plato con ID: {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID de plato inválido.");
            }
        }

        private void EliminarPlato()
        {
            Console.WriteLine("\n--- Eliminar Plato ---");
            Console.Write("Ingrese el ID del plato a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _platoServicio.EliminarPlato(id);
                Console.WriteLine($"Plato con ID: {id} eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID de plato inválido.");
            }
        }

        private void GestionarClientes()
        {
            Console.WriteLine("\n--- Gestión de Clientes ---");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Agregar Cliente");
            Console.WriteLine("3. Editar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.WriteLine("5. Volver al menú principal");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    ListarClientes();
                    break;
                case "2":
                    AgregarCliente();
                    break;
                case "3":
                    EditarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        private void ListarClientes()
        {
            var clientes = _clienteServicio.ObtenerTodosLosClientes();
            if (clientes.Any())
            {
                Console.WriteLine("\n--- Lista de Clientes ---");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Mesa: {cliente.Mesa}");
                }
            }
            else
            {
                Console.WriteLine("No hay clientes registrados.");
            }
        }

        private void AgregarCliente()
        {
            Console.WriteLine("\n--- Agregar Nuevo Cliente ---");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Mesa: ");
            if (int.TryParse(Console.ReadLine(), out int mesa))
            {
                var cliente = new Cliente { Nombre = nombre, Mesa = mesa };
                _clienteServicio.AgregarCliente(cliente);
                Console.WriteLine("Cliente agregado exitosamente.");
            }
            else
            {
                Console.WriteLine("Número de mesa inválido.");
            }
        }

        private void EditarCliente()
        {
            Console.WriteLine("\n--- Editar Cliente ---");
            Console.Write("Ingrese el ID del cliente a editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var clienteExistente = _clienteServicio.ObtenerCliente(id);
                if (clienteExistente != null)
                {
                    Console.Write($"Nuevo nombre ({clienteExistente.Nombre}): ");
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre))
                    {
                        clienteExistente.Nombre = nuevoNombre;
                    }

                    Console.Write($"Nueva mesa ({clienteExistente.Mesa}): ");
                    if (int.TryParse(Console.ReadLine(), out int nuevaMesa))
                    {
                        clienteExistente.Mesa = nuevaMesa;
                    }
                    else
                    {
                        Console.WriteLine("Número de mesa inválido, se mantendrá la mesa anterior.");
                    }

                    _clienteServicio.ActualizarCliente(clienteExistente);
                    Console.WriteLine("Cliente actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el cliente con ID: {id}.");
                }
            }
            else
            {
                Console.WriteLine("ID de cliente inválido.");
            }
        }

        private void EliminarCliente()
        {
            Console.WriteLine("\n--- Eliminar Cliente ---");
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _clienteServicio.EliminarCliente(id);
                Console.WriteLine($"Cliente con ID: {id} eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID de cliente inválido.");
            }
        }

        private void GestionarPedidos()
        {
            Console.WriteLine("\n--- Gestión de Pedidos ---");
            Console.WriteLine("1. Listar Pedidos");
            Console.WriteLine("2. Agregar Pedido");
            Console.WriteLine("3. Ver Detalles de Pedido");
            Console.WriteLine("4. Eliminar Pedido");
            Console.WriteLine("5. Volver al menú principal");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    ListarPedidos();
                    break;
                case "2":
                    AgregarPedido();
                    break;
                case "3":
                    VerDetallesPedido();
                    break;
                case "4":
                    EliminarPedido();
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        private void ListarPedidos()
        {
            var pedidos = _pedidoServicio.ObtenerTodosLosPedidos();
            if (pedidos.Any())
            {
                Console.WriteLine("\n--- Lista de Pedidos ---");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"ID: {pedido.Id}, Cliente ID: {pedido.ClienteId}, Fecha: {pedido.FechaPedido}, Total: {pedido.Total}");
                }
            }
            else
            {
                Console.WriteLine("No hay pedidos registrados.");
            }
        }

        private void AgregarPedido()
        {
            Console.WriteLine("\n--- Agregar Nuevo Pedido ---");
            Console.Write("ID del Cliente: ");
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                var cliente = _clienteServicio.ObtenerCliente(clienteId);
                if (cliente != null)
                {
                    var pedido = new Pedido { ClienteId = clienteId, FechaPedido = DateTime.Now };
                    _pedidoServicio.AgregarPedido(pedido);
                    Console.WriteLine($"Pedido agregado exitosamente para el cliente con ID: {clienteId}.");
                }
                else
                {
                    Console.WriteLine($"No se encontró el cliente con ID: {clienteId}.");
                }
            }
            else
            {
                Console.WriteLine("ID de cliente inválido.");
            }
        }

        private void VerDetallesPedido()
        {
            Console.WriteLine("\n--- Ver Detalles del Pedido ---");
            Console.Write("Ingrese el ID del pedido a ver: ");
            if (int.TryParse(Console.ReadLine(), out int pedidoId))
            {
                var pedido = _pedidoServicio.ObtenerPedidoConDetalles(pedidoId);
                if (pedido != null)
                {
                    Console.WriteLine($"\n--- Detalles del Pedido ID: {pedido.Id} ---");
                    Console.WriteLine($"Cliente ID: {pedido.ClienteId}");
                    Console.WriteLine($"Fecha del Pedido: {pedido.FechaPedido}");
                    Console.WriteLine("--- Platos en el Pedido ---");
                    if (pedido.DetallesPedido.Any())
                    {
                        foreach (var detalle in pedido.DetallesPedido)
                        {
                            Console.WriteLine($"- {detalle.Plato?.Nombre} (Cantidad: {detalle.Cantidad}, Precio Unitario: {detalle.PrecioUnitario}, Subtotal: {detalle.Subtotal})");
                        }
                        Console.WriteLine($"Total del Pedido: {pedido.Total}");
                    }
                    else
                    {
                        Console.WriteLine("No hay platos en este pedido.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró el pedido con ID: {pedidoId}.");
                }
            }
            else
            {
                Console.WriteLine("ID de pedido inválido.");
            }
        }

        private void EliminarPedido()
        {
            Console.WriteLine("\n--- Eliminar Pedido ---");
            Console.Write("Ingrese el ID del pedido a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _pedidoServicio.EliminarPedido(id);
                Console.WriteLine($"Pedido con ID: {id} eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID de pedido inválido.");
            }
        }
    }
}