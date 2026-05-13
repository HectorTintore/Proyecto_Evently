using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Proyecto_Evently.DTOs;

public class UbicacionAlmacenDTO
{
    [JsonPropertyName("Nombre")]
    public string Nombre { get; set; }
    [JsonPropertyName("Latitud")]
    public double Latitud { get; set; }

    [JsonPropertyName("Longitud")]  
    public double Longitud { get; set; }
}