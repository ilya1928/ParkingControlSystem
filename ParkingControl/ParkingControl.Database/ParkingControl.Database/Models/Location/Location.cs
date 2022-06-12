using System;
using System.Text;

namespace ParkingControl.Database.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string delimeter = ", ";

            stringBuilder.Append(Address.Name).Append(delimeter);
            stringBuilder.Append(Code);

            return stringBuilder.ToString();
        }
    }
}
