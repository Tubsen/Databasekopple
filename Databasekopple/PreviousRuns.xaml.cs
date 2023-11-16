using Databasekopple.Data;

namespace Databasekopple;

public partial class PreviousRuns : ContentPage
{
    public PreviousRuns()
    {
        InitializeComponent();

        //runsList.ItemsSource = App.RunRepository.GetAllRuns();

        var allSessions = App.RunRepository.GetAllRuns(); // Vervang dit door de juiste methode

        // Sorteer de sessies op datum, waarbij de meest recente bovenaan staat
        var sortedSessions = allSessions.OrderByDescending(s => s.Date);

        runsList.ItemsSource = sortedSessions;
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
        var allSessions = App.RunRepository.GetAllRuns();

        // Sorteer de sessies op datum, waarbij de meest recente bovenaan staat
        var sortedSessions = allSessions.OrderByDescending(s => s.Date);

        runsList.ItemsSource = sortedSessions;
    }
}