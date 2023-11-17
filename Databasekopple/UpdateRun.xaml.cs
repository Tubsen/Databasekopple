using Databasekopple.Models;
using Databasekopple.ViewModels;

namespace Databasekopple;

public partial class UpdateRun : ContentPage
{
    private RunViewModel _runViewModel;

    public UpdateRun(INavigation navigation, Run run)
    {
        InitializeComponent();

        // Create a ViewModel for the Run
        _runViewModel = new RunViewModel(navigation, run);

        // Set the BindingContext to the ViewModel
        BindingContext = _runViewModel;

        // Pass the INavigation instance to the ViewModel or store it as needed
    }


    private void OnClickedUpdateRun(object sender, EventArgs e)
    {
        // Execute the update command in the ViewModel
        

        // Navigate back to the previous page (assuming you're using NavigationPage)
        Navigation.PopAsync();
    }
}