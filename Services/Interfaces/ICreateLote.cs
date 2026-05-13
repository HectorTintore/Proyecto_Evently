using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Evently.Models;

namespace Proyecto_Evently.Services.Interfaces; 

public interface ICreateLote
{
    Task Init();
    Task<int> UpsertLoteAsync(Lote lote); // crear o Actualizar
    Task<List<Lote>> GetLotesAsync();
    Task<Lote> GetLotePorIdAsync(int id);
    Task DeleteLoteAsync(int id); 
   
}
