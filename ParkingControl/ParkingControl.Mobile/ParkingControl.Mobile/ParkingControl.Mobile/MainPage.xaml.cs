using ParkingControl.Mobile.Models;
using ParkingControl.Mobile.Views.Reporting;
using System;
using Xamarin.Forms;

namespace ParkingControl.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ReportViolationButton_Clicked(object sender, EventArgs e)
        {
            var reportingRequest = new ReportingRequest
            {
                ReportId = Guid.NewGuid()
            };

            await Navigation.PushModalAsync(new PanoramaPicturingPage(reportingRequest));
        }
    }
}
