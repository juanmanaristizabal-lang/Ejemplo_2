using System.Collections.Generic;

[System.Serializable]
public class ItemDataJson
{
    public string nombre;
    public string rareza;
    public int valor;
    public string imagen; 

    public string Nombre { get => nombre; set => nombre = value; }
    public string Rareza { get => rareza; set => rareza = value; }
    public int Valor { get => valor; set => valor = value; }
    public string Imagen { get => imagen; set => imagen = value; }
}

[System.Serializable]
public class MissionData
{
    public int id;
    public string titulo;
    public string descripcion;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}

[System.Serializable]
public class leer_json
{
    public List<ItemDataJson> coleccionables;
    public List<MissionData> misiones;
}


