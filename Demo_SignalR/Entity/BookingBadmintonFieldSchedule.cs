using System;
using System.Collections.Generic;

namespace Demo_SignalR.Entity
{
    public partial class BookingBadmintonFieldSchedule
    {
        public long OrderBadmintonFieldScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long BookingId { get; set; }
        public long BadmintonField { get; set; }
        public long ScheduleId { get; set; }

        public virtual BadmintonField BadmintonFieldNavigation { get; set; } = null!;
        public virtual Booking Booking { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
    }
}
