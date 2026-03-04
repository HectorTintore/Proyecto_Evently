namespace Proyecto_Evently.Views;

public partial class Detalles : ContentPage
{
	public Detalles ()
	{
		InitializeComponent();
	}

    private void FiltroPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;
        string seleccion = picker.SelectedItem.ToString();

      
    }
}