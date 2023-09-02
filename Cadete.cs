namespace EspacioCadeteria;
public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private double telefono;
    private List<Pedido> listaPedidos;



    public Cadete(int id, string? nombre)
    {
        this.id = id;
        this.nombre = nombre;

    }

    public Cadete(int id, string nombre, string direccion, double telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listaPedidos = new List<Pedido>();
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }


    public void agregarPedidoALista(Pedido nuevoPedido)
    {

        listaPedidos.Add(nuevoPedido);
    }

    /*  public List<Pedido> darAltaPedido(List<Pedido> listaPedidos, int numPedido)
     {
         int indice = listaPedidos.FindIndex(Pedido => Pedido.Numero == numPedido);

         if (indice != -1)
         {
             listaPedidos[indice].Cliente = null;
             listaPedidos.RemoveAt(indice);
         }

         return listaPedidos;


     } */

    public float JornalACobrar()
    {
        int contadorPedidosEntregados = 0;

        foreach (var p in ListaPedidos)
        {
            if (p.Estado == Estado.Entregado)
            {
                contadorPedidosEntregados++;
            }
        }

        float aCobrar = contadorPedidosEntregados * 500;
        return aCobrar;
    }

    public Pedido reasignarPedidoCadete(Cadete CadeteARremoverPedido, int numPedido)
    {
        int indice = CadeteARremoverPedido.listaPedidos.FindIndex(Pedido => Pedido.Numero == numPedido);
        var pedidoAAsignar = listaPedidos[indice];
        listaPedidos.RemoveAt(indice);
        return pedidoAAsignar;
    }

}
