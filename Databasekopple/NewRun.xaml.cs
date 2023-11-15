using Databasekopple.ViewModels;

namespace Databasekopple;

public partial class NewRun : ContentPage
{
	public NewRun()
	{
		InitializeComponent();
        BindingContext = new RunViewModel();
    }
}