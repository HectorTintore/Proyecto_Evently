using Proyecto_Evently.ViewModels;

namespace Proyecto_Evently.Views;

public partial class Ordenes : ContentPage
{
    public Ordenes(CreateLoteViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
