namespace EspacioCadeteria;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private double telefono;




    public Cadete(int id, string? nombre)
    {
        this.id = id;
        this.nombre = nombre;

    }
    public Cadete()
    {

    }

    public Cadete(int id, string nombre, string direccion, double telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;

    }

    public int getIdCadete()
    {
        return this.id;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }

}
