using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Connection
    {
        public string ConnectionId { get; set; } = string.Empty;
        public string Airline { get; set; } = string.Empty;
        public string DepartureCity { get; set; } = string.Empty;
        public string ArrivalCity { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        public string CreatedById { get; set; } = string.Empty;
        public User CreatedBy { get; set; } = new();
        public ICollection<FlightConnection> FlightConnections { get; set; } = [];
    }
}
