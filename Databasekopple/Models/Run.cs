using SQLite;

namespace Databasekopple.Models
{        
    [Table("run")]
    public class Run
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public DateTime Date { get; set; } // Date
        public TimeSpan StartTime { get; set; } // StartTime
        public double DistanceInKilometers { get; set; } // Distance in kilometers
        public TimeSpan Duration { get; set; } // Duration (hh:mm:ss)
        public double SpeedInKilometers { get; set; } // Speed in km/h
        public double BurnedKilocalories { get; set; } // Burned Kilocalories

    }
}
