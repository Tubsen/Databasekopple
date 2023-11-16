﻿using Databasekopple.Data;
using Databasekopple.Models;
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


        private DateTime _date;
        public DateTime Date
        {
            get => _date.Date;  // Retrieve only the date part
            set => _date = value.Date;  // Store only the date part
        }

        private int? _hoursStartTime;
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

        private int? _minutesStartTime;
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

        private int? _secondsStartTime;
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

        private int? _kilometers;
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

        private int? _hoursLength;
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

        private int? _minutesLength;
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

        private int? _secondsLength;
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

        private int? _speedInKilometers;
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

        private int? _kilocalories;
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

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand SaveCommand { get; private set; }

        public RunViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SaveCommand = new Command(CreateRunSession);
            _runRepository = new RunRepository("C:\\Users\\tobia\\AppData\\Local\\Packages\\457c8ff2-537c-4b17-8f38-bd921a85bbbf_9zz4h110yvjzm\\LocalState\\run.db");
            Date = DateTime.Now;
        }

        public async void CreateRunSession(object parameter)
        {
            // Checks if all the fields are filled
            if (HoursStartTime == null || MinutesStartTime == null || SecondsStartTime == null ||
                HoursLength == null || MinutesLength == null || SecondsLength == null ||
                Kilometers == null || SpeedInKilometers == null || Kilocalories == null)
            {
                ErrorMessage = "Alles moet ingevuld worden";
                return;
            }

            TimeSpan startTime = new TimeSpan((int)HoursStartTime, (int)MinutesStartTime, (int)SecondsStartTime);
            TimeSpan timeLength = new TimeSpan((int)HoursLength, (int)MinutesLength, (int)SecondsLength);

            RunSession = new Run
            {
                Date = Date,
                StartTime = startTime,
                DistanceInKilometers = (int)Kilometers,
                Duration = timeLength,
                SpeedInKilometers = (int)SpeedInKilometers,
                BurnedKilocalories = (int)Kilocalories,
            };
            _runRepository.Add(RunSession);

            await _navigation.PopAsync();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}