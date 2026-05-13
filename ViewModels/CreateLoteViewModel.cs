using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_Evently.Models;
using Proyecto_Evently.Services.Interfaces;

namespace Proyecto_Evently.ViewModels
{
    public partial class CreateLoteViewModel : ObservableObject
    {
        private readonly ICreateLote _crearLoteService;
        private readonly IUbicacionAlmacen _ubicacionAlmacen;

        [ObservableProperty]
        private string _codigoLote;

        [ObservableProperty]
        private string _descripcion;

        [ObservableProperty]
        private bool _isBusy;

        // Propiedad para la lista de lotes guardados
        [ObservableProperty]
        private ObservableCollection<Lote> _lotes = new();

        // Propiedades para la selección en los Pickers
        [ObservableProperty]
        private UbicacionAlmacen _origenSeleccionado;

        [ObservableProperty]
        private UbicacionAlmacen _destinoSeleccionado; // Corregido el nombre (sin la 'i' extra)

        // Catálogo de almacenes
        public ObservableCollection<UbicacionAlmacen> Ubicaciones { get; set; } = new();

        public CreateLoteViewModel(ICreateLote crearLote, IUbicacionAlmacen ubicacionAlmacen)
        {
            _crearLoteService = crearLote;
            _ubicacionAlmacen = ubicacionAlmacen;
            _ = CargarAlmacenes();
        }

        [RelayCommand]
        public async Task CargarLotesDb()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var listaDb = await _crearLoteService.GetLotesAsync();

                Lotes.Clear();
                foreach (var lote in listaDb)
                {
                    Lotes.Add(lote);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"No se pudieron cargar: {ex.Message}", "OK");
            }
            finally { IsBusy = false; }
        }

        private async Task CargarAlmacenes()
        {
            try
            {
                var lista = await _ubicacionAlmacen.ObtenerUbicacioneAsync();
                Ubicaciones.Clear();
                foreach (var item in lista) { Ubicaciones.Add(item); }
            }
            catch (Exception ex) { /* Manejar error silenciosamente o alertar */ }
        }

        [RelayCommand]
        private async Task GuardarLote()
        {
            if (IsBusy) return;
            if (string.IsNullOrWhiteSpace(CodigoLote) || OrigenSeleccionado == null || DestinoSeleccionado == null)
            {
                await Shell.Current.DisplayAlert("Error", "Faltan datos", "OK");
                return;
            }

            try
            {
                IsBusy = true;
                var nuevoLote = new Lote
                {
                    CodigoLote = CodigoLote,
                    Descripcion = Descripcion,
                    FechaCreacion = DateTime.Now,
                    Estado = "Pendiente",
                    OrigenLatitud = OrigenSeleccionado.Latitud,
                    OrigenLongitud = OrigenSeleccionado.Longitud,
                    Origen = OrigenSeleccionado.Nombre, 
                    DestinoLatitud = DestinoSeleccionado.Latitud,
                    DestinoLongitud = DestinoSeleccionado.Longitud,
                    Destino = DestinoSeleccionado.Nombre 
                };

                await _crearLoteService.UpsertLoteAsync(nuevoLote);
                await Shell.Current.DisplayAlert("Éxito", "Lote guardado", "OK");
                await CargarLotesDb(); // Recargar la lista automáticamente
            }
            catch (Exception ex) { await Shell.Current.DisplayAlert("Error", ex.Message, "OK"); }
            finally { IsBusy = false; }
        }
    }
}