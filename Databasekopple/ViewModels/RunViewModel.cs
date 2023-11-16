using Databasekopple.Data;
using Databasekopple.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Databasekopple.ViewModels
{
    public class RunViewModel : INotifyPropertyChanged
    {
        private RunRepository _runRepository;
        private readonly INavigation _navigation;

        public Run RunSession { get; private set; }

        private ObservableCollection<Run> _runsList;
        public ObservableCollection<Run> RunsList
        {
            get { return _runsList; }
            set
            {
                if (_runsList != value)
                {
                    _runsList = value;
                    NotifyPropertyChanged(nameof(RunsList));
                }
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date.Date;  // Retrieve only the date part
            set => _date = value.Date;  // Store only the date part
        }

        // Represents whether the activity has the longest duration
        private bool _isLongestDuration;

        // Property for accessing and updating the IsLongestDuration field
        public bool IsLongestDuration
        {
            get => _isLongestDuration;
            set
            {
                _isLongestDuration = value;
                NotifyPropertyChanged(nameof(IsLongestDuration));
            }
        }

        // Represents whether the activity has the longest distance
        private bool _isLongestDistance;

        // Property for accessing and updating the IsLongestDistance field
        public bool IsLongestDistance
        {
            get => _isLongestDistance;
            set
            {
                _isLongestDistance = value;
                NotifyPropertyChanged(nameof(IsLongestDistance));
            }
        }

        // Represents whether the activity has the most calories burned
        private bool _hasMostCalories;

        // Property for accessing and updating the HasMostCalories field
        public bool HasMostCalories
        {
            get => _hasMostCalories;
            set
            {
                _hasMostCalories = value;
                NotifyPropertyChanged(nameof(HasMostCalories));
            }
        }

        // Represents whether the activity has the highest speed
        private bool _hasHighestSpeed;

        // Property for accessing and updating the HasHighestSpeed field
        public bool HasHighestSpeed
        {
            get => _hasHighestSpeed;
            set
            {
                _hasHighestSpeed = value;
                NotifyPropertyChanged(nameof(HasHighestSpeed));
            }
        }

        // Represents the hours part of the activity start time
        private int? _hoursStartTime;

        // Property for accessing and updating the HoursStartTime field with validation
        public int? HoursStartTime
        {
            get => _hoursStartTime;
            set
            {
                if (value >= 0 && value < 24)
                {
                    _hoursStartTime = value;
                    NotifyPropertyChanged(nameof(HoursStartTime));
                }
                else
                {
                    _hoursStartTime = null;
                    NotifyPropertyChanged(nameof(HoursStartTime));
                }
            }
        }

        // Represents the minutes part of the activity start time
        private int? _minutesStartTime;

        // Property for accessing and updating the MinutesStartTime field with validation
        public int? MinutesStartTime
        {
            get => _minutesStartTime;
            set
            {
                if (value >= 0 && value < 60)
                {
                    _minutesStartTime = value;
                    NotifyPropertyChanged(nameof(MinutesStartTime));
                }
                else
                {
                    _minutesStartTime = null;
                    NotifyPropertyChanged(nameof(MinutesStartTime));
                }
            }
        }

        // Represents the seconds part of the activity start time
        private int? _secondsStartTime;

        // Property for accessing and updating the SecondsStartTime field with validation
        public int? SecondsStartTime
        {
            get => _secondsStartTime;
            set
            {
                if (value >= 0 && value < 60)
                {
                    _secondsStartTime = value;
                    NotifyPropertyChanged(nameof(SecondsStartTime));
                }
                else
                {
                    _secondsStartTime = null;
                    NotifyPropertyChanged(nameof(SecondsStartTime));
                }
            }
        }

        // Represents the distance traveled in kilometers
        private int? _kilometers;

        // Property for accessing and updating the Kilometers field with validation
        public int? Kilometers
        {
            get => _kilometers;
            set
            {
                if (value >= 0 && value <= 50)
                {
                    _kilometers = value;
                    NotifyPropertyChanged(nameof(Kilometers));
                }
                else
                {
                    _kilometers = null;
                    NotifyPropertyChanged(nameof(Kilometers));
                }
            }
        }

        // Represents the hours part of the activity duration
        private int? _hoursLength;

        // Property for accessing and updating the HoursLength field with validation
        public int? HoursLength
        {
            get => _hoursLength;
            set
            {
                if (value >= 0 && value < 24)
                {
                    _hoursLength = value;
                    NotifyPropertyChanged(nameof(HoursLength));
                }
                else
                {
                    _hoursLength = null;
                    NotifyPropertyChanged(nameof(HoursLength));
                }
            }
        }

        // Represents the minutes part of the activity duration
        private int? _minutesLength;

        // Property for accessing and updating the MinutesLength field with validation
        public int? MinutesLength
        {
            get => _minutesLength;
            set
            {
                if (value >= 0 && value < 60)
                {
                    _minutesLength = value;
                    NotifyPropertyChanged(nameof(MinutesLength));
                }
                else
                {
                    _minutesLength = null;
                    NotifyPropertyChanged(nameof(MinutesLength));
                }
            }
        }

        // Represents the seconds part of the activity duration
        private int? _secondsLength;

        // Property for accessing and updating the SecondsLength field with validation
        public int? SecondsLength
        {
            get => _secondsLength;
            set
            {
                if (value >= 0 && value < 60)
                {
                    _secondsLength = value;
                    NotifyPropertyChanged(nameof(SecondsLength));
                }
                else
                {
                    _secondsLength = null;
                    NotifyPropertyChanged(nameof(SecondsLength));
                }
            }
        }

        // Represents the speed of the activity in kilometers per hour
        private int? _speedInKilometers;

        // Property for accessing and updating the SpeedInKilometers field with validation
        public int? SpeedInKilometers
        {
            get => _speedInKilometers;
            set
            {
                if (value >= 0 && value <= 15)
                {
                    _speedInKilometers = value;
                    NotifyPropertyChanged(nameof(SpeedInKilometers));
                }
                else
                {
                    _speedInKilometers = null;
                    NotifyPropertyChanged(nameof(SpeedInKilometers));
                }
            }
        }

        // Represents the number of kilocalories burned during the activity
        private int? _kilocalories;

        // Property for accessing and updating the Kilocalories field with validation
        public int? Kilocalories
        {
            get => _kilocalories;
            set
            {
                if (value >= 0 && value <= 2000)
                {
                    _kilocalories = value;
                    NotifyPropertyChanged(nameof(Kilocalories));
                }
                else
                {
                    _kilocalories = null;
                    NotifyPropertyChanged(nameof(Kilocalories));
                }
            }
        }

        // Represents any error message related to the activity input
        private string _errorMessage;

        // Property for accessing and updating the ErrorMessage field
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }


        // Command to save the run session
        public ICommand SaveCommand { get; private set; }

        // Constructor to initialize the ViewModel
        public RunViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SaveCommand = new Command(CreateRunSession);

            // Initialize the RunRepository with the database path
            _runRepository = new RunRepository("/data/user/0/com.companyname.databasekopple/files/run.db");
            Date = DateTime.Now; // Set the default date to the current date and time
        }

        // Method to create a new run session
        public async void CreateRunSession(object parameter)
        {
            // Check if all required fields are filled
            if (HoursStartTime == null || MinutesStartTime == null || SecondsStartTime == null ||
                HoursLength == null || MinutesLength == null || SecondsLength == null ||
                Kilometers == null || SpeedInKilometers == null || Kilocalories == null)
            {
                ErrorMessage = "All fields must be filled."; // Set an error message
                return; // Exit the method if validation fails
            }

            // Create TimeSpan objects for start time and run duration
            TimeSpan startTime = new TimeSpan((int)HoursStartTime, (int)MinutesStartTime, (int)SecondsStartTime);
            TimeSpan timeLength = new TimeSpan((int)HoursLength, (int)MinutesLength, (int)SecondsLength);

            // Format the date as dd/MM/yyyy
            string formattedDate = Date.ToString("dd/MM/yyyy");

            // Create a new Run object with the provided details
            RunSession = new Run
            {
                Date = formattedDate,
                StartTime = startTime,
                DistanceInKilometers = (int)Kilometers,
                Duration = timeLength,
                SpeedInKilometers = (int)SpeedInKilometers,
                BurnedKilocalories = (int)Kilocalories,
            };

            // Add the run session to the repository
            _runRepository.Add(RunSession);

            // Navigate back after saving
            await _navigation.PopAsync();
        }

        // Event to notify changes in property values
        public event PropertyChangedEventHandler PropertyChanged;

        // Method to invoke PropertyChanged event
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}