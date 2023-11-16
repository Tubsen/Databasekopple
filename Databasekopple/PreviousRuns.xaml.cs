using Databasekopple.Data;
using Databasekopple.ViewModels;

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

    public void LoadRuns()
    {
        // Load runs from the repository
        var runsList = App.RunRepository.GetAllRuns();

        // Determine the run with the longest duration
        var longestDurationRun = runsList.OrderByDescending(r => r.Duration).FirstOrDefault();

        // Determine the run with the longest distance
        var longestDistanceRun = runsList.OrderByDescending(r => r.DistanceInKilometers).FirstOrDefault();

        // Determine the run with the most calories burned
        var mostCaloriesRun = runsList.OrderByDescending(r => r.BurnedKilocalories).FirstOrDefault();

        // Determine the run with the highest speed
        var highestSpeedRun = runsList.OrderByDescending(r => r.SpeedInKilometers).FirstOrDefault();

        longestDistanceRun.IsLongestDistance = true;
        longestDurationRun.IsLongestDuration = true;
        mostCaloriesRun.HasMostCalories = true;
        highestSpeedRun.HasHighestSpeed = true;

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
        LoadRuns();
    }
}