using Databasekopple.Data;

namespace Databasekopple;

public partial class PreviousRuns : ContentPage
{

    private RunRepository _runRepository;
    public PreviousRuns()
	{
		InitializeComponent();

		runsList.ItemsSource = App.RunRepository.GetAllRuns();
	}

	private void OnDelete(object sender, EventArgs e)
	{
		Button button = (Button)sender;

		App.RunRepository.Delete((int)button.BindingContext);

		runsList.ItemsSource = App.RunRepository.GetAllRuns();
	}

	async private void OnClickNewRun(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new NewRun());
    }

    private void OnClickRefresh(object sender, EventArgs e)
    {
        _runRepository = new RunRepository("C:\\Users\\tobia\\AppData\\Local\\Packages\\457c8ff2-537c-4b17-8f38-bd921a85bbbf_9zz4h110yvjzm\\LocalState\\run.db");
		_runRepository.GetAllRuns();
    }
}