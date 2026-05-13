using Proyecto_Evently.Models;
using Proyecto_Evently.Models.DbModels;
using Proyecto_Evently.Services.Interfaces;
using SQLite;

namespace Proyecto_Evently.Services;

public class CreateLote : ICreateLote
{

    private SQLiteAsyncConnection _database;

    public async Task Init()
    {
        if (_database is not null) return; 
         var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Evently.db");
        _database = new SQLiteAsyncConnection(dbPath);
        await _database.CreateTableAsync<LoteBdModel>();
    }
    //Crear Lote 
    public async Task<int> UpsertLoteAsync(Lote lote)
    {
        await Init();

        var dbModel = new LoteBdModel
        {
            Id = lote.Id,
            CodigoLote = lote.CodigoLote,
            Descripcion = lote.Descripcion,
            FechaCreacion = lote.FechaCreacion,
            Estado = lote.Estado,
            OrigenLatitud = lote.OrigenLatitud,
            OrigenLongitud = lote.OrigenLongitud,
            Origen = lote.Origen,   
            DestinoLatitud = lote.DestinoLatitud,
            DestinoLongitud = lote.DestinoLongitud,
            Destino = lote.Destino
        };

        await _database.InsertAsync(dbModel);

        lote.Id = dbModel.Id;
        return await _database.InsertOrReplaceAsync(lote);
    }

    public async Task<List<Lote>> GetLotesAsync()
    {
        await Init();
        var dbItems = await _database.Table<LoteBdModel>().ToListAsync();

        return dbItems.Select(db => new Lote
        {
            Id = db.Id,
            CodigoLote = db.CodigoLote,
            Descripcion = db.Descripcion,
            FechaCreacion = db.FechaCreacion,
            Estado = db.Estado,
            OrigenLatitud = db.OrigenLatitud,
            OrigenLongitud = db.OrigenLongitud, 
            Origen = db.Origen, 
            DestinoLatitud = db.DestinoLatitud,
            DestinoLongitud = db.DestinoLongitud,
            Destino = db.Destino
        }).ToList();
    }
    //Hola solo estoy probando si es difernte

    public async Task<Lote> GetLotePorIdAsync(int id)
    {
        await Init();
        var dbItem = await _database.Table<LoteBdModel>().FirstOrDefaultAsync(x => x.Id == id);
        if (dbItem == null) return null;
        return new Lote
        {
            Id = dbItem.Id,
            CodigoLote = dbItem.CodigoLote,
            Descripcion = dbItem.Descripcion,
            FechaCreacion = dbItem.FechaCreacion,
            Estado = dbItem.Estado,
            OrigenLatitud = dbItem.OrigenLatitud,
            OrigenLongitud = dbItem.OrigenLongitud,
            Origen = dbItem.Origen, 
            DestinoLatitud = dbItem.DestinoLatitud,
            DestinoLongitud = dbItem.DestinoLongitud,
            Destino = dbItem.Destino


        };
    }

    public async Task DeleteLoteAsync(int id)
    {
        await Init(); 
        await _database.DeleteAsync<LoteBdModel>(id);
    }


}