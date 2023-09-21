using EspacioCadeteria;
public enum Estado
{
    EnCamino,
    Entregado,
    EnPreparacion


}
public class Pedido
{
    private int numero;
    private string? obs;
    private Cliente cliente;
    private Estado estado;

    private int idcadete;
    public Pedido(int numero, string? obs, Cliente cliente, Estado estado, int idCad)
    {
        this.Numero = numero;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = estado;
        this.Idcadete = idCad;
    }
    public Pedido(int numero, string? obs, Estado estado, int idCad, string nombreCliente, string direccionCliente, double telCad, string datosRefCliente)
    {
        this.Numero = numero;
        this.obs = obs;

    }

    public Pedido(int numero, string? obs, Cliente cliente, Estado estado)
    {
        this.numero = numero;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = estado;
    }

    public int Numero { get => numero; set => numero = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public int Idcadete { get => idcadete; set => idcadete = value; }

    public void SetEstadoPedido(Estado nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public Estado GetEstadoPedido()
    {
        return estado;
    }
    public string verDireccionPedido(Cliente cliente)
    {
        return cliente.Direccion;
    }

    public string verDatosClientes(Cliente cliente)
    {
        string result = $"Nombre: {cliente.Nombre}, Tel: {cliente.Telefono}, Direc.: {cliente.Direccion}, Referencia Direc.: {cliente.DatosRefenciaDireccion}";
        return result;
    }
}