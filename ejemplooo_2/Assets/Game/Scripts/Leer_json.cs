using JetBrains.Annotations;
using System.Collections.Generic;

[System.Serializable]
public class ItemDataJson
{
    public string nombre;
    public string rareza;
    public int valor;
    public string iconoId; 

    public string Nombre { get => nombre; set => nombre = value; }
    public string Rareza { get => rareza; set => rareza = value; }
    public int Valor { get => valor; set => valor = value; }
    public string Imagen { get => iconoId; set => iconoId = value; }
}

[System.Serializable]
public class MissionObjective
{
    public string itemName;
    public int cantidad; 

    public string ItemName { get => itemName; set => itemName = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }   
}

[System.Serializable]
public class MissionData
{
  public int id;
  public string titulo;
  public List<MissionObjective> objetivos;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public List<MissionObjective> Objetivos { get => objetivos; set => objetivos = value; }
}

[System.Serializable]
public class leer_json
{
    public List<ItemDataJson> coleccionables;
    public List<MissionData> misiones;
}


