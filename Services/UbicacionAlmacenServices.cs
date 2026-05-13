using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Evently.Models;
using Proyecto_Evently.Services.Interfaces;

namespace Proyecto_Evently.Services
{
    internal class UbicacionAlmacenServices : IUbicacionAlmacen
    {
        public async Task<List<UbicacionAlmacen>> ObtenerUbicacioneAsync()
        {
            await Task.Delay(1000); // Simula una llamada a una API o base de datos 

            return new List<UbicacionAlmacen>
            {
                new UbicacionAlmacen { Nombre = "Almacén Central", Latitud = 40.7128, Longitud = -74.0060 },
                new UbicacionAlmacen { Nombre = "Almacén Norte", Latitud = 41.8781, Longitud = -87.6298 },
                new UbicacionAlmacen { Nombre = "Almacén Sur", Latitud = 34.0522, Longitud = -118.2437 }
            };
        }
    }
}
