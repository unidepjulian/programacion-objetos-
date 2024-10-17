using proy.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace proy
{
     class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|            Menu Principal            |");
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("| 1. Gestionar Clientes                |");
                Console.WriteLine("| 2. Gestionar Citas                   |");
                Console.WriteLine("| 3. Gestionar Servicios               |");
                Console.WriteLine("| 4. Gestionar Productos               |");
                Console.WriteLine("| 5. Gestionar Inventario              |");
                Console.WriteLine("| 6. Gestionar Facturas                |");
                Console.WriteLine("| 7. Gestionar Peluqueros              |");
                Console.WriteLine("| 8. Salir                             |");
                Console.WriteLine("+--------------------------------------+");

                Console.Write("Seleccione una opción -> ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        GestionarClientes();
                        break;
                    case "2":
                        GestionarCitas();
                        break;
                    case "3":
                        GestionarServicios();
                        break;
                    case "4":
                        GestionarProductos();
                        break;
                    case "5":
                        GestionarInventario();
                        break;
                    case "6":
                        GestionarFacturas();
                        break;
                    case "7":
                        GestionarPeluqueros();
                        break;
                    case "8":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GestionarClientes()
        {
            Cliente cliente = new Cliente();
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Clientes        │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Cliente              │");
            Console.WriteLine("│  [2]  Ver Clientes                 │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                     Console.Write("Ingrese el nombre del cliente: ");
    string nombre = Console.ReadLine().Trim();

    // Validación del nombre
    while (string.IsNullOrEmpty(nombre))
    {
        Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
        Console.Write("Ingrese el nombre del cliente: ");
        nombre = Console.ReadLine().Trim();
    }

    Console.Write("Ingrese el teléfono del cliente: ");
    string telefono = Console.ReadLine().Trim();

    // Validación del teléfono
    while (true)
    {
        if (telefono.Length < 10 || telefono.Length > 15 || !telefono.All(char.IsDigit))
        {
            Console.WriteLine("El teléfono debe contener solo dígitos y tener entre 10 y 15 caracteres. Intente de nuevo.");
            Console.Write("Ingrese el teléfono del cliente: ");
            telefono = Console.ReadLine().Trim();
        }
        else
        {
            break; // Sale del ciclo si el teléfono es válido
        }
    }

    cliente.AgregarCliente(new Cliente { Nombre = nombre, Telefono = telefono });
    break;

                case "2":
                    var clientes = cliente.ObtenerClientes();
                    foreach (var c in clientes)
                    {
                        Console.WriteLine($"ID: {c.IdCliente}, Nombre: {c.Nombre}, Teléfono: {c.Telefono}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

        static void GestionarCitas()
        {
            Cita cita = new Cita();
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Citas           │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Cita                 │");
            Console.WriteLine("│  [2]  Ver Citas por CLiente        │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el ID del cliente: ");
                    int idCliente = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la fecha de la cita (dd/mm/aaaa): ");
                    DateTime fechaCita = DateTime.Parse(Console.ReadLine());
                    Console.Write("Ingrese la hora de la cita (hh:mm): ");
                    TimeSpan horaCita = TimeSpan.Parse(Console.ReadLine());  // Leer la hora
                    Console.Write("Ingrese la descripción: ");
                    string descripcion = Console.ReadLine();
                    cita.AgregarCita(new Cita { IdCliente = idCliente, FechaCita = fechaCita, HoraCita=horaCita , Descripcion = descripcion });
                    break;
                case "2":
                    Console.Write("Ingrese el ID del cliente: ");
                    int idClienteCitas = int.Parse(Console.ReadLine());
                    var citas = cita.ObtenerCitasPorCliente(idClienteCitas);
                    foreach (var c in citas)
                    {
                        string fechaFormateada = c.FechaCita.ToString("dd/MM/yyyy");
                        Console.WriteLine($"ID: {c.IdCita}, Fecha: {fechaFormateada}, HoraCita: {c.HoraCita}, Descripción: {c.Descripcion}");

                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

        static void GestionarServicios()
        {
            Servicio servicio = new Servicio();
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Servicios       │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Servicios            │");
            Console.WriteLine("│  [2]  Ver Servicios                │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre del servicio: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el precio del servicio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    servicio.AgregarServicio(new Servicio { NombreServicio = nombre, Precio = precio });
                    break;
                case "2":
                    var servicios = servicio.ObtenerServicios();
                    foreach (var s in servicios)
                    {
                        Console.WriteLine($"ID: {s.IdServicio}, Nombre: {s.NombreServicio}, Precio: {s.Precio}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }
        static void GestionarProductos()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Productos       │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Productos            │");
            Console.WriteLine("│  [2]  Ver Productos                │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Producto nuevoProducto = new Producto();
                    Console.Write("Ingrese el nombre del producto: ");
                    nuevoProducto.NombreProducto = Console.ReadLine();
                    Console.Write("Ingrese el precio del producto: ");
                    nuevoProducto.Precio = decimal.Parse(Console.ReadLine());
                    nuevoProducto.AgregarProducto();
                    Console.WriteLine("Producto agregado exitosamente. Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                case "2":
                    var productos = Producto.ObtenerProductos();
                    foreach (var p in productos)
                    {
                        Console.WriteLine($"ID: {p.IdProducto}, Nombre: {p.NombreProducto}, Precio: {p.Precio}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

        static void GestionarInventario()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Inventario      │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Producto             │"); 
            Console.WriteLine("│       Gestión de Inventario        │"); 
            Console.WriteLine("│                                    │");
            Console.WriteLine("│  [2]  Ver Inventario               │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Inventario inventario = new Inventario();
                    Console.Write("Ingrese el ID del producto: ");
                    int idProducto = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    inventario.AgregarProducto(idProducto, cantidad);
                    Console.WriteLine("Producto agregado al inventario exitosamente. Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                case "2":
                    var inventarioLista = new Inventario().ObtenerInventario();
                    foreach (var item in inventarioLista)
                    {
                        Console.WriteLine($"Producto: {item.Item1.NombreProducto}, Cantidad: {item.Item2}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

        static void GestionarFacturas()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Facturas        │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Facturas             │");
            Console.WriteLine("│  [2]  Ver Facturas                 │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Factura nuevaFactura = new Factura();
                    Console.Write("Ingrese el ID de la cita: ");
                    nuevaFactura.IdCita = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el total: ");
                    nuevaFactura.Total = decimal.Parse(Console.ReadLine());
                    nuevaFactura.AgregarFactura();
                    Console.WriteLine("Factura agregada exitosamente. Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                case "2":
                    var facturas = Factura.ObtenerFacturas();
                    foreach (var f in facturas)
                    {
                        Console.WriteLine($"ID: {f.IdFactura}, ID Cita: {f.IdCita}, Total: {f.Total}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

        static void GestionarPeluqueros()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────┐");
            Console.WriteLine("│         Gestión de Peluquero       │");
            Console.WriteLine("├────────────────────────────────────┤");
            Console.WriteLine("│  [1]  Agregar Peluquero            │");
            Console.WriteLine("│  [2]  Ver Peluquero                │");
            Console.WriteLine("└────────────────────────────────────┘");
            Console.Write("Seleccione una opción -> ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Peluquero nuevoPeluquero = new Peluquero();
                    Console.Write("Ingrese el nombre del peluquero: ");
                    nuevoPeluquero.Nombre = Console.ReadLine();
                    Console.Write("Ingrese la especialidad del peluquero: ");
                    nuevoPeluquero.Especialidad = Console.ReadLine();
                    nuevoPeluquero.AgregarPeluquero();
                    Console.WriteLine("Peluquero agregado exitosamente. Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                case "2":
                    var peluqueros = Peluquero.ObtenerPeluqueros();
                    foreach (var p in peluqueros)
                    {
                        Console.WriteLine($"ID: {p.IdPeluquero}, Nombre: {p.Nombre}, Especialidad: {p.Especialidad}");
                    }
                    Console.WriteLine("Presione una tecla para continuar.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("*******************************");
                    Console.WriteLine("*        Error de opción       *");
                    Console.WriteLine("*******************************");
                    Console.WriteLine("* Opción no válida, vuelva a   *");
                    Console.WriteLine("* intentar.                    *");
                    Console.WriteLine("*******************************");
                    break;
            }
        }

    }

}
    

