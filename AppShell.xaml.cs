using Proyecto1.Pages;

namespace Proyecto1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FlightsConnectionDetailsPage), typeof(FlightsConnectionDetailsPage));
        }
    }
}
