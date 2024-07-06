using System;
using System.Collections.Generic;

namespace Demo_SignalR.Entity
{
    public partial class BadmintonField
    {
        public BadmintonField()
        {
            BookingBadmintonFieldSchedules = new HashSet<BookingBadmintonFieldSchedule>();
        }

        public long BadmintonFieldId { get; set; }
        public string BadmintonFieldName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; }
    }
}
