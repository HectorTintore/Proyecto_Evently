using SQLite;

namespace Proyecto_Evently.Models.DbModels;

[Table("Lote")]
public class LoteBdModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; } 

    [Indexed]
    public string CodigoLote { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Estado { get; set; }
    //Informacion de la ubicacion
    //Origen del lote   
    public double OrigenLatitud { get; set; }
    public double OrigenLongitud { get; set; }
    public string Origen { get; set; }

    // Destino del lote
    public double DestinoLatitud { get; set; }
    public double DestinoLongitud { get; set; }
    public string Destino { get; set; } 

}