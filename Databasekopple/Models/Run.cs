﻿using SQLite;

namespace Databasekopple.Models
{
    [Table("run")]
    public class Run
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Date { get; set; } // Date
        public TimeSpan StartTime { get; set; } // StartTime
        public double DistanceInKilometers { get; set; } // Distance in kilometers
        public TimeSpan Duration { get; set; } // Duration (hh:mm:ss)
        public double SpeedInKilometers { get; set; } // Speed in km/h
        public double BurnedKilocalories { get; set; } // Burned Kilocalories

        // Badge properties
        public bool IsLongestDuration { get; set; }
        public bool IsLongestDistance { get; set; }
        public bool HasMostCalories { get; set; }
        public bool HasHighestSpeed { get; set; }

    }
}
