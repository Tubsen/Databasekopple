namespace Databasekopple;

public partial class PreviousRuns : ContentPage
{
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
}