namespace EspacioCadeteria;
using System.IO;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public abstract class AccesoADatos
{
    public abstract List<Cadete> CargarCadetes(string path);
    public abstract Cadeteria CargarDatosCadeteria(string path);

}

public class AccesoCSV : AccesoADatos
{
    public override List<Cadete> CargarCadetes(string path)
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
    public override Cadeteria CargarDatosCadeteria(string path)
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

            listadoCad = CargarCadetes(Path.Combine(path, "cadetes.csv"));

            nuevaCadeteria = new Cadeteria(nombre, telefono, listadoCad);


        }
        return nuevaCadeteria;
    }
}

public class AccesoJson : AccesoADatos
{
    public override List<Cadete> CargarCadetes(string path)
    {
        string cadetesPath = Path.Combine(path, "cadetes.json");
        string cadetesJson = File.ReadAllText(cadetesPath);
        List<Cadete> listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(cadetesJson);
        return listaCadetes;
    }
    public override Cadeteria CargarDatosCadeteria(string path)
    {
        string json = File.ReadAllText(Path.Combine(path, "Cadeteria.json"));
        Cadeteria nuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
        nuevaCadeteria.ListadoCadetes = CargarCadetes(path);
        return nuevaCadeteria;
    }
}