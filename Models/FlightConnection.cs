using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class FlightConnection
    {
        // Necesario para la key, en dataContext
        public string FlightNumber { get; set; } = string.Empty;

        public string ConnectionId { get; set; } = string.Empty;


        public Flight Flight { get; set; } = new ();
        public Connection Connection { get; set; } = new ();
    }
}
