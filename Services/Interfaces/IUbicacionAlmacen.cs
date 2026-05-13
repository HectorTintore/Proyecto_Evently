using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Evently.Models;

namespace Proyecto_Evently.Services.Interfaces;

public interface IUbicacionAlmacen
{
   
    Task<List<UbicacionAlmacen>> ObtenerUbicacioneAsync();
}