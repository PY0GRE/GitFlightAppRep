using Proyecto1.Pages;

namespace Proyecto1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddNewFlight), typeof(AddNewFlight));
            Routing.RegisterRoute(nameof(AddNewFlightConnection), typeof(AddNewFlightConnection));
            Routing.RegisterRoute(nameof(FlightsConnectionDetailsPage), typeof(FlightsConnectionDetailsPage));
        }
    }
}
