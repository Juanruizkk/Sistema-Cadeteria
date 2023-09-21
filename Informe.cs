namespace EspacioCadeteria;
public class Informe
{
    private List<InformeCadete> informeCadetes;

    public Informe()
    {
        this.informeCadetes = new List<InformeCadete>();
    }

    public List<InformeCadete> InformeCadetes { get => informeCadetes; set => informeCadetes = value; }


}

public class InformeCadete
{
    private string nombre;
    private double monto;

    private int cantEnvios;



    public global::System.String Nombre { get => nombre; set => nombre = value; }
    public global::System.Double Monto { get => monto; set => monto = value; }
    public int CantEnvios { get => cantEnvios; set => cantEnvios = value; }

    public InformeCadete(string nombre, double monto, int cantidadEnvios)
    {
        Nombre = nombre;
        Monto = monto;
        cantEnvios = cantidadEnvios;
    }

    /*  public generarInformePorCadete()
     {
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


             Console.WriteLine($"Cadete: {cadete.Nombre}");
             Console.WriteLine($"Cantidad de Envíos: {cantEnvios}");
             Console.WriteLine($"Monto Ganado: ${montoGanado}\n");
         }
         int totalEnvios = listadoPedidos.Count;
         double montoTotalGanado = totalEnvios * 500;
         Console.WriteLine("Totales:");
         Console.WriteLine($"Cantidad de Envíos Total: {totalEnvios}");
         Console.WriteLine($"Monto Total Ganado: ${montoTotalGanado}");
     } */


}