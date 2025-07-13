namespace TransRD.Views;

public partial class RecuperarClavePage : ContentPage
{
	public RecuperarClavePage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.RecuperarClaveViewModel();
    }
}