namespace EspacioCadeteria;
using System.IO;
using System;

public class accesoADatos
{
    public List<Cadete> cargarCadetesAListado(string path)
    {

        List<Cadete> listadoCadetes = new List<Cadete>();
        string pathArchivo = path;
        StreamReader str = new StreamReader(pathArchivo);
        string separador = ",";
        string linea;

        str.ReadLine();

        while ((linea = str.ReadLine()) != null)
        {
            string[] fila = linea.Split(separador);
            int id = int.Parse(fila[0]);
            string nombre = fila[1];
            string direccion = fila[2];
            double telefono = double.Parse(fila[3]);

            Cadete nuevoCad = new Cadete(id, nombre, direccion, telefono);
            listadoCadetes.Add(nuevoCad);


        }
        return listadoCadetes;
    }

    public Cadeteria cargarDatosCadeteria(string path)
    {
        string pathArchivo = path;
        pathArchivo = Path.Combine(pathArchivo, "Cadeteria.csv");
        StreamReader str = new StreamReader(pathArchivo);
        string separador = ",";
        string linea;

        str.ReadLine();
        List<Cadete> listadoCad;
        Cadeteria nuevaCadeteria = null;


        while ((linea = str.ReadLine()) != null)
        {
            string[] fila = linea.Split(separador);
            string nombre = fila[0];
            double telefono = Convert.ToDouble(fila[1]);

            listadoCad = cargarCadetesAListado(Path.Combine(path, "cadetes.csv"));

            nuevaCadeteria = new Cadeteria(nombre, telefono, listadoCad);


        }
        return nuevaCadeteria;

    }
}
