using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Evently.Models; 

public class Lote
{
    public int Id { get; set; } 
    public string CodigoLote { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Estado { get; set; }
    // Información de ubicación

    // Información de origen
    public double OrigenLatitud { get; set; }
    public double OrigenLongitud { get; set; }
    public string Origen { get; set; }

    // Información de destino
    public double DestinoLatitud { get; set; }
    public double DestinoLongitud { get; set; }
    public string Destino { get; set; }

    //Infromacion de seguimiento

    // Historial para dibujar la ruta en el mapa
    //public List<PuntoRastreo> HistorialRuta { get; set; } = new List<PuntoRastreo>();

    // Propiedad calculada para obtener la última posición fácilmente
    //public PuntoRastreo UltimaUbicacion => HistorialRuta.LastOrDefault();
}
