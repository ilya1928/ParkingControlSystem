using ParkingControl.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParkingControl.Mobile.Views.Reporting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LicensePlatePicturingPage : ContentPage
    {
        private readonly ReportingRequest reportingRequest;
        private FileResult imageFileResult;

        public LicensePlatePicturingPage(ReportingRequest reportingRequest)
        {
            this.reportingRequest = reportingRequest;

            InitializeComponent();
        }

        private async void PickImageButton_Clicked(object sender, EventArgs e)
        {
            imageFileResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            await ReadFileResultAsync(imageFileResult);
        }

        private async void TakeImageButton_Clicked(object sender, EventArgs e)
        {
            imageFileResult = await MediaPicker.CapturePhotoAsync();
            await ReadFileResultAsync(imageFileResult);
        }

        private async Task ReadFileResultAsync(FileResult imageFileResult)
        {
            if (imageFileResult != null)
            {
                var imageStream = await imageFileResult.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => imageStream);
            }
        }

        private async void NextStepButton_Clicked(object sender, EventArgs e)
        {
            reportingRequest.LicensePlate = imageFileResult;
            await Navigation.PushModalAsync(new LocationProvidingPage(reportingRequest));
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}