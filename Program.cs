using EspacioCadeteria;
using System.IO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
Console.WriteLine("------  Bienvenido al sistema  ------");

Console.WriteLine("Como desea cargar los datos de la cadeteria: (1- Archivo csv. 2- Archivo Json)");
AccesoADatos cargar;
switch (int.Parse(Console.ReadLine()))
{
    case 1:
        cargar = new AccesoCSV();
        break;
    case 2:
        cargar = new AccesoJson();
        break;
    default:
        cargar = null;
        break;
}

string path = @"C:\Juan Ruiz\Taller de lenguajes 2\tl2-tp1-2023-Juanruizkk\Sistema Cadeteria";

Cadeteria cadeteriaPEPE = cargar.CargarDatosCadeteria(path);



Console.WriteLine("Ingrese que operacion desea realizar: ");

Console.Write(@"1 - Dar de alta un Pedido 
2- Asignarle a un nuevo Cadete
3- Cambiar estado de un Pedido
4- Reasignar un Pedido
5- Ver Jornal a cobrar de un Cadete
6- Salir del sistema");



int op = int.Parse(Console.ReadLine());
do
{

    Cliente nuevoCliente = null;
    switch (op)
    {
        case 1:
            Console.WriteLine("Para crear un pedido debe crear un cliente primero");
            string nombreCliente;
            string direccionCliente;
            double telefonoCliente;
            string observacionCliente;
            do
            {
                Console.WriteLine(@"Ingrese los datos del cliente separados por ','. Nombre, Direccion, Telefono, Observacion");
                Console.WriteLine("Ej.: Juan, Bolivia 4712, 3814452417, Esq. Martin Rodriguez");
                string input = Console.ReadLine();
                string[] separado = input.Split(',');

                if (separado.Length == 4)
                {
                    nombreCliente = separado[0].Trim();
                    direccionCliente = separado[1].Trim();
                    telefonoCliente = double.Parse(separado[2].Trim());
                    observacionCliente = separado[3].Trim();
                    nuevoCliente = cadeteriaPEPE.CrearCliente(nombreCliente, direccionCliente, telefonoCliente, observacionCliente);
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
            cadeteriaPEPE.CrearPedido(numero, obs, nuevoCliente, estado, nombreCliente, direccionCliente, telefonoCliente, observacionCliente);

            break;
        case 2:
            Console.WriteLine("Ingrese el id del cadete");
            int idCadete = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero del pedido");
            int num = int.Parse(Console.ReadLine());

            cadeteriaPEPE.AsignarCadeteAPedido(idCadete, num);

            Console.WriteLine("Pedido Cargado con Exito");
            break;
        case 3:
            Console.WriteLine("Ingrese el numero del pedido que desea cambiar su estado");
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

            cadeteriaPEPE.CambiarEstadoPedido(numPedido, estadoACambiar);
            Console.WriteLine("Estado Cambiado con Exito");
            break;
        case 4:
            Console.WriteLine("Ingrese numero del pedido que desea reasignar");
            int numPed = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del cadete al que desea reasignar el pedido");
            int idCadAAsignar = int.Parse(Console.ReadLine());
            cadeteriaPEPE.reasignarPedido(numPed, idCadAAsignar);
            Console.WriteLine("Pedido reasignado con exito");
            break;
        case 5:
            Console.WriteLine("Ingrese el id del cadete que desea ver cuanto cobrara");
            int idCadAVerJornal = int.Parse(Console.ReadLine());
            Console.WriteLine("El cadete cobrara {0}:", cadeteriaPEPE.JornalACobrar(idCadAVerJornal));
            break;


    }
    Console.WriteLine("Ingrese que operacion desea realizar: ");

    Console.Write(@"1 - Dar de alta un Pedido 
2- Asignarle a un nuevo Cadete
3- Cambiar estado de un Pedido
4- Reasignar un Pedido
5- Ver Jornal a cobrar de un Cadete
6- Salir del sistema");

    op = int.Parse(Console.ReadLine());
} while (op != 6);

/* cadeteriaPEPE.GenerarInforme(path); */
