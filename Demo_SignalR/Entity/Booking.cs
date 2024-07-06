using System;
using System.Collections.Generic;

namespace Demo_SignalR.Entity
{
    public partial class Booking
    {
        public Booking()
        {
            BookingBadmintonFieldSchedules = new HashSet<BookingBadmintonFieldSchedule>();
        }

        public long BookingId { get; set; }
        public DateTime CreatedAt { get; set; }
        public double TotalPrice { get; set; }
        public string BookingType { get; set; } = null!;
        public bool? CheckInStatus { get; set; }
        public string IsStatus { get; set; } = null!;
        public long CustomerId { get; set; }
        public string PaymentType { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; }
    }
}
