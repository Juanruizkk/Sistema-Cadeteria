namespace EspacioCadeteria;
public class Cliente
{
    private string nombre;
    private string direccion;
    private double telefono;
    private string datosRefenciaDireccion;

    public Cliente(string nombre, string direccion, double telefono, string datosRefenciaDireccion = null)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosRefenciaDireccion = datosRefenciaDireccion;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public string DatosRefenciaDireccion { get => datosRefenciaDireccion; set => datosRefenciaDireccion = value; }
}
