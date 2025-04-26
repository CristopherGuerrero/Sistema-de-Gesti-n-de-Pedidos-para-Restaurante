# Sistema de Gestión de Pedidos para Restaurante

**RestaurantPedidos CLI: Gestión Integral de Restaurante**

**Descripción:**

RestaurantPedidos CLI es una aplicación de consola desarrollada para gestionar de manera integral los elementos clave de un restaurante, incluyendo la administración de platos del menú, la gestión básica de clientes y el procesamiento de pedidos. El sistema está diseñado para optimizar la operación del restaurante a través de una interfaz de consola intuitiva y funcional.

**Requerimientos Funcionales:**

1.  **Gestión de Platos:**
    * Permitir agregar nuevos platos con nombre, descripción, precio y categoría.
    * Permitir editar la información de platos existentes.
    * Permitir eliminar platos del menú.
    * Permitir listar todos los platos disponibles con sus detalles.

2.  **Gestión de Clientes:**
    * Permitir registrar nuevos clientes con nombre y número de mesa.
    * Permitir editar la información de un cliente.
    * Permitir eliminar clientes del sistema.
    * Permitir consultar la lista de clientes.

3.  **Gestión de Pedidos:**
    * Permitir crear nuevos pedidos asociando un cliente.
    * Permitir ver los detalles de un pedido específico, incluyendo los platos y el total.
    * Permitir eliminar pedidos del sistema.
    * Permitir listar todos los pedidos registrados.

**Requerimientos No Funcionales:**

1.  **Integridad de Datos:**
    * Validar la entrada de datos para asegurar su correcto almacenamiento (por ejemplo, precios numéricos, IDs de categoría existentes).
    * Mantener la consistencia de las relaciones entre platos y categorías.
    * Manejar errores de entrada de datos de forma controlada.

2.  **Usabilidad:**
    * Presentar una interfaz de consola clara con menús y opciones bien definidas.
    * Guiar al usuario durante las operaciones de agregar, editar y eliminar.
    * Proporcionar mensajes informativos y de error comprensibles.

3.  **Organización y Mantenibilidad:**
    * Organizar el código en capas lógicas (presentación, lógica de negocio, acceso a datos).
    * Utilizar nombres de variables y métodos descriptivos.
    * Implementar manejo de excepciones para mejorar la robustez.
