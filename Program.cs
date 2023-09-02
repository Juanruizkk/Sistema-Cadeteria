using EspacioCadeteria;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

accesoADatos cargarDatos = new accesoADatos();
string path = @"C:\Juan Ruiz\Taller de lenguajes 2\tl2-tp1-2023-Juanruizkk\Sistema Cadeteria";

Cadeteria cadeteriaPEPE = cargarDatos.cargarDatosCadeteria(path);

Console.WriteLine("------  Bienvenido al sistema  ------");

Console.WriteLine("Ingrese que operacion desea realizar: ");

Console.Write(@"1 - Dar de alta un Pedido y asignarle a un nuevo Cadete
2- Cambiar estado de un Pedido
3- Reasignar un Pedido
4- Salir del sistema");


int op = int.Parse(Console.ReadLine());
do
{
    Cliente nuevoCliente = null;
    switch (op)
    {
        case 1:
            Console.WriteLine("Para crear un pedido debe crear un cliente primero");

            do
            {
                Console.WriteLine(@"Ingrese los datos del cliente separados por ','. Nombre, Direccion, Telefono, Observacion");
                Console.WriteLine("Ej.: Juan, Bolivia 4712, 3814452417, Esq. Martin Rodriguez");
                string input = Console.ReadLine();
                string[] separado = input.Split(',');

                if (separado.Length == 4)
                {
                    string nombre = separado[0].Trim();
                    string direccion = separado[1].Trim();
                    double telefono = double.Parse(separado[2].Trim());
                    string observacion = separado[3].Trim();
                    nuevoCliente = cadeteriaPEPE.crearCliente(nombre, direccion, telefono, observacion);
                    break;
                }
                else
                {
                    Console.Write("Ingrese de nuevo los datos");
                }

            } while (true);
            Console.WriteLine("Ingrese el numero del pedido");
            int numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese a observacion del pedido:");
            string obs = Console.ReadLine();
            Console.WriteLine(@"Ingrese el estado del pedido:
    1- En Camino
    2- Entregado
    3- En Preparacion");

            int eleccion = int.Parse(Console.ReadLine());
            Estado estado = Estado.EnPreparacion;
            switch (eleccion)
            {
                case 1:
                    estado = Estado.EnCamino;
                    break;
                case 2:
                    estado = Estado.Entregado;
                    break;
                case 3:
                    estado = Estado.EnPreparacion;
                    break;
            }
            Pedido nuevoPedido = cadeteriaPEPE.crearPedido(numero, obs, nuevoCliente, estado);
            Console.WriteLine("Ingrese el id del cadete");
            int idCadete = int.Parse(Console.ReadLine());

            cadeteriaPEPE.asignarPedidoACadete(idCadete, nuevoPedido);

            Console.WriteLine("Pedido Cargado con Exito");
            break;
        case 2:
            Console.WriteLine("Ingrese el numero del pedido que desea reasignar");
            int numPedido = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo estado del Pedido (1- En Camino, 2- Entregado, 3- En Preparacion)");
            int eleccionEstado = int.Parse(Console.ReadLine());
            Estado estadoACambiar = Estado.EnPreparacion;
            switch (eleccionEstado)
            {
                case 1:
                    estadoACambiar = Estado.EnCamino;
                    break;
                case 2:
                    estadoACambiar = Estado.Entregado;
                    break;
                case 3:
                    estadoACambiar = Estado.EnPreparacion;
                    break;
            }

            cadeteriaPEPE.cambiarEstadoPedido(numPedido, estadoACambiar);
            Console.WriteLine("Estado Cambiado con Exito");
            break;
        case 3:
            Console.WriteLine("Ingrese numero del pedido que desea reasignar");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cadete al que desea reasignar el pedido");
            int idCadAAsignar = int.Parse(Console.ReadLine());

            Cadete cadeteAAsignar = cadeteriaPEPE.encontrarCadete(idCadAAsignar);

            Console.WriteLine("Ingrese el id del cadete al que desea remover el pedido");
            int idCadAremover = int.Parse(Console.ReadLine());
            Cadete cadeteARemover = cadeteriaPEPE.encontrarCadete(idCadAremover);



            cadeteriaPEPE.reasignarPedido(cadeteAAsignar, cadeteARemover, num);
            break;


    }
    Console.WriteLine("Ingrese que operacion desea realizar: ");

    Console.Write(@"1 - Dar de alta un Pedido y asignarle a un nuevo Cadete
2- Cambiar estado de un Pedido
3- Reasignar un Pedido
4- Salir del sistema");

    op = int.Parse(Console.ReadLine());
} while (op != 4);
