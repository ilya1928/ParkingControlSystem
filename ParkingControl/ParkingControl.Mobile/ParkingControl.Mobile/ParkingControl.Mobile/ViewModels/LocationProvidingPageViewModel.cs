using ParkingControl.Database.Models;
using System.Collections.Generic;

namespace ParkingControl.Mobile.ViewModels
{
    public class LocationProvidingPageViewModel : ViewModelBase
    {
        public IEnumerable<District> Districts { get; set; }

        public string AdditionalInfo { get; set; }

        District selectedDistrict;
        public District SelectedDistrict
        {
            get { return selectedDistrict; }
            set
            {
                if (selectedDistrict != value)
                {
                    selectedDistrict = value;
                    OnPropertyChanged();
                }
            }
        }

        Address selectedAddress;
        public Address SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                if (selectedAddress != value)
                {
                    selectedAddress = value;
                    OnPropertyChanged();
                }
            }
        }

        Location selectedLocation;
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                if (selectedLocation != value)
                {
                    selectedLocation = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
