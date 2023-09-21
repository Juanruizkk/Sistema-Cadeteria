using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.IO;
namespace EspacioCadeteria;
public class Cadeteria
{
    private string nombre;
    private double telefono;
    private List<Cadete> listadoCadetes;

    private List<Pedido> listadoPedidos;

    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }
    public Cadeteria(string nombre, double telefono, List<Cadete> listadoCadetes = null)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
        this.listadoPedidos = new List<Pedido>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cliente CrearCliente(string nombre, string direccion, double telefono, string observacion)
    {
        Cliente nuevo = new Cliente(nombre, direccion, telefono, observacion);
        return nuevo;
    }
    public Cadete EncontrarCadete(int idCad)
    {
        Cadete cad = listadoCadetes.Find(x => x.Id == idCad);
        return cad;
    }
    public Pedido EncontrarPedido(int numPedido)
    {
        Pedido ped = listadoPedidos.Find(x => x.Numero == numPedido);
        return ped;
    }

    public List<Pedido> getListadoPedido()
    {
        return listadoPedidos;
    }
    public double JornalACobrar(int idCad)
    {
        int cont = 0;

        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Idcadete == idCad)
            {
                cont++;
            }
        }

        return cont * 200;
    }
    public void CrearPedido(int numero, string obs, Cliente cliente, Estado estado, string nombreCliente, string direccionCliente, double telefonoCliente, string observacionCliente)
    {
        var nuevoCliente = CrearCliente(nombreCliente, direccionCliente, telefonoCliente, observacionCliente);
        Pedido nuevoPedido = new Pedido(numero, obs, cliente, estado);
        listadoPedidos.Add(nuevoPedido);
    }

    public void AsignarCadeteAPedido(int idCadete, int numPedido)
    {
        Cadete cadeteAAsignar = EncontrarCadete(idCadete);
        Pedido pedido = EncontrarPedido(numPedido);
        pedido.Idcadete = cadeteAAsignar.getIdCadete();
    }
    public void CambiarEstadoPedido(int numPedido, Estado nuevoEstado)
    {
        Pedido pedido = EncontrarPedido(numPedido);
        pedido.SetEstadoPedido(nuevoEstado);
    }


    public void reasignarPedido(int numPedido, int idCadAAsignar)
    {
        Pedido pedidoAReadignar = EncontrarPedido(numPedido);
        Cadete cadeteAReasignarPedido = EncontrarCadete(idCadAAsignar);
        pedidoAReadignar.Idcadete = cadeteAReasignarPedido.getIdCadete();
    }

    public Informe GenerarInforme()
    {
        Informe nuevoInforme = new Informe();
        InformeCadete CadIndependiente;

        foreach (var cadete in listadoCadetes)
        {
            int cantEnvios = 0;
            double montoGanado = JornalACobrar(cadete.getIdCadete());

            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Idcadete == cadete.getIdCadete())
                {
                    cantEnvios++;
                }
            }
            CadIndependiente = new InformeCadete(cadete.Nombre, montoGanado, cantEnvios);
            nuevoInforme.InformeCadetes.Add(CadIndependiente);
        }
        return nuevoInforme;


    }


}