using Databasekopple.ViewModels;

namespace Databasekopple;

public partial class NewRun : ContentPage
{
    public RunViewModel ViewModel { get; set; }

    public NewRun()
    {
        InitializeComponent();
        ViewModel = new RunViewModel(Navigation);
        BindingContext = ViewModel;

        datePicker.MaximumDate = DateTime.Now;
    }
}