using System;
using System.Collections.Generic;

namespace Demo_SignalR.Entity
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public long CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string IsStatus { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
