using Proyecto_Evently.ViewModels;

namespace Proyecto_Evently.Views;

public partial class LotesPrueba : ContentPage
{
	public LotesPrueba(CreateLoteViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}