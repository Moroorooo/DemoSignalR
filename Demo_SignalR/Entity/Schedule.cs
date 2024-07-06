using System;
using System.Collections.Generic;

namespace Demo_SignalR.Entity
{
    public partial class Schedule
    {
        public Schedule()
        {
            BookingBadmintonFieldSchedules = new HashSet<BookingBadmintonFieldSchedule>();
        }

        public long ScheduleId { get; set; }
        public string ScheduleName { get; set; } = null!;
        public DateTime StartTimeFrame { get; set; }
        public DateTime EndTimeFrame { get; set; }
        public double Price { get; set; }
        public double TotalHours { get; set; }

        public virtual ICollection<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; }
    }
}
