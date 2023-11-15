using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Databasekopple.Models
{        
    [SQLite.Table("run")]
    public class Run
    {
        [PrimaryKey, AutoIncrement, SQLite.Column("Id")]
        public int Id { get; set; }
        public DateTime Date { get; set; } // Date
        public DateTime StartTime { get; set; } // StartTime
        public double DistanceInKilometers { get; set; } // Distance in kilometers
        public TimeSpan Duration { get; set; } // Duration (hh:mm:ss)
        public double SpeedInKilometers { get; set; } // Speed in km/h
        public double BurnedKilocalories { get; set; } // Burned Kilocalories

    }
}
