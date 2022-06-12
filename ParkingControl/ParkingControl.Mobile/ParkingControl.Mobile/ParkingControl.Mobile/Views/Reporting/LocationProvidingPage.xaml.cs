using ParkingControl.Mobile.Enums;
using ParkingControl.Mobile.Models;
using ParkingControl.Mobile.ViewModels;
using ParkingControl.Shared.DTO.Report;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkingControl.Mobile.Views.Reporting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationProvidingPage : ContentPage
    {
        private readonly ReportingRequest reportingRequest;

        public LocationProvidingPage(ReportingRequest reportingRequest)
        {
            this.reportingRequest = reportingRequest;
            BindingContext = new LocationProvidingPageViewModel();

            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            var vm = BindingContext as LocationProvidingPageViewModel;
            vm.Districts = await App.LocationsManagerInstance.GetDistrictsAsync();

            base.OnAppearing();
        }

        private async void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as LocationProvidingPageViewModel;
            reportingRequest.Location = vm.SelectedLocation;

            await App.BlobStorageManagerInstance.UploadPhotoAsync(PhotoType.LicensePlate, reportingRequest.ReportId, reportingRequest.LicensePlate);
            await App.BlobStorageManagerInstance.UploadPhotoAsync(PhotoType.Panorama, reportingRequest.ReportId, reportingRequest.Panorama);

            await App.ReportsManagerInstance.CreateReportAsync(new CreateReportRequest
            {
                Id = reportingRequest.ReportId,
                LocationId = reportingRequest.Location.Id,
                AdditionalInfo = reportingRequest.AdditionalInfo
            });

            await App.AzureFunctionsManagerInstance.TriggerPlateRecognitionAsync(reportingRequest.ReportId);
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}