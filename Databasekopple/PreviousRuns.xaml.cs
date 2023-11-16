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

    // Handles the delete button click event for a run session
    private void OnDelete(object sender, EventArgs e)
    {
        // Casts the sender as a Button to access its properties
        Button button = (Button)sender;

        // Retrieves the BindingContext of the button, assuming it is an integer representing the run session ID
        App.RunRepository.Delete((int)button.BindingContext);

        // Refreshes the runsList.ItemsSource with the updated list of run sessions
        runsList.ItemsSource = App.RunRepository.GetAllRuns();
    }

    // Handles the click event for creating a new run session
    async private void OnClickNewRun(object sender, EventArgs e)
    {
        // Navigates to the NewRun page when the "New Run" button is clicked
        await Navigation.PushAsync(new NewRun());
    }

    // Handles the click event for refreshing the list of run sessions
    private void OnClickRefresh(object sender, EventArgs e)
    {
        // Retrieves all run sessions from the repository
        var allSessions = App.RunRepository.GetAllRuns();

        // Sorts the run sessions based on the date, with the most recent sessions appearing first
        var sortedSessions = allSessions.OrderByDescending(s => s.Date);

        // Updates the runsList.ItemsSource with the sorted list of run sessions
        runsList.ItemsSource = sortedSessions;

        // Calls the LoadRuns method (assuming it exists) to perform additional actions related to loading runs
        LoadRuns();
    }

}