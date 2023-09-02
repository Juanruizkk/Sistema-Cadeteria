using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace EspacioCadeteria;
public class Cadeteria
{
    private string nombre;
    private double telefono;
    private List<Cadete> listadoCadetes;

    public Cadeteria(string nombre, double telefono, List<Cadete> listadoCadetes = null)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cliente crearCliente(string nombre, string direccion, double telefono, string observacion)
    {
        Cliente nuevo = new Cliente(nombre, direccion, telefono, observacion);
        return nuevo;
    }

    public Pedido crearPedido(int numero, string obs, Cliente cliente, Estado estado)
    {
        Pedido nuevoPedido = new Pedido(numero, obs, cliente, estado);
        return nuevoPedido;
    }

    public void asignarPedidoACadete(int idCadete, Pedido nuevoPedido)
    {

        Cadete cadeteAsignado = listadoCadetes.Find(x => x.Id == idCadete);
        cadeteAsignado.agregarPedidoALista(nuevoPedido);
    }


    public void cambiarEstadoPedido(int numPedido, Estado nuevoEstado)
    {

        var result = (from cad in listadoCadetes
                      from pedido in cad.ListaPedidos
                      where pedido.Numero == numPedido
                      select pedido).FirstOrDefault();
        if (result != null)
        {
            result.Estado = nuevoEstado;
        }
    }

    public void reasignarPedido(Cadete cadeteAAsignar, Cadete cadeteARemover, int numPedido)
    {
        var pedidoAAsignar = cadeteARemover.reasignarPedidoCadete(cadeteARemover, numPedido);
        cadeteAAsignar.agregarPedidoALista(pedidoAAsignar);
    }

    public Cadete encontrarCadete(int idCad)
    {
        Cadete cad = listadoCadetes.Find(x => x.Id == idCad);
        return cad;
    }


}