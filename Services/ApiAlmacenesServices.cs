using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Proyecto_Evently.Models;
using Proyecto_Evently.Services.Interfaces;
using Proyecto_Evently.DTOs;
using System.Diagnostics;

namespace Proyecto_Evently.Services
{
    public class ApiAlmacenesServicesServices : IUbicacionAlmacen
    {
        private readonly HttpClient _httpClient;

        public ApiAlmacenesServicesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UbicacionAlmacen>> ObtenerUbicacioneAsync()
        {
            try
            {
                var dtos = await _httpClient.GetFromJsonAsync<List<UbicacionAlmacenDTO>>("almacenes");
                if (dtos is null) return new();
                var almacenes = dtos.Select(dto => new UbicacionAlmacen
                {
                    Nombre = dto.Nombre,
                    Latitud = dto.Latitud,
                    Longitud = dto.Longitud
                }).ToList();

                return almacenes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error Al obtener Los almacenes");
                return new();
            }

        }
    }
}
