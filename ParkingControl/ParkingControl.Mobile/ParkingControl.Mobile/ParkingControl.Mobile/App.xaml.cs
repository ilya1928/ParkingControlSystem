using ParkingControl.Mobile.Services.AzureFunction;
using ParkingControl.Mobile.Services.BlobStorage;
using ParkingControl.Mobile.Services.Location;
using ParkingControl.Mobile.Services.Report;
using Xamarin.Forms;

namespace ParkingControl.Mobile
{
    public partial class App : Application
    {
        public static LocationsManager LocationsManagerInstance { get; private set; }
        public static ReportsManager ReportsManagerInstance { get; private set; }
        public static BlobStorageManager BlobStorageManagerInstance { get; private set; }
        public static AzureFunctionsManager AzureFunctionsManagerInstance { get; private set; }

        public App()
        {
            LocationsManagerInstance = new LocationsManager(new LocationService());
            ReportsManagerInstance = new ReportsManager(new ReportService());
            BlobStorageManagerInstance = new BlobStorageManager(new BlobStorageService());
            AzureFunctionsManagerInstance = new AzureFunctionsManager(new AzureFunctionService());

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
