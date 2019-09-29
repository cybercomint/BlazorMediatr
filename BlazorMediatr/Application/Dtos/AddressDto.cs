using System;

namespace BlazorMediatr.Application.Dtos {

    public class AddressDto {

        public String City { get; }

        public String State { get; }

        public String Street { get; }

        public String Zip { get; }

        public AddressDto(String street, String city, String state, String zip) {
            if (string.IsNullOrWhiteSpace(street)) {
                throw new ArgumentException(Constants.NullEmptyOrWhiteSpace, nameof(street));
            }

            if (string.IsNullOrWhiteSpace(city)) {
                throw new ArgumentException(Constants.NullEmptyOrWhiteSpace, nameof(city));
            }

            if (string.IsNullOrWhiteSpace(state)) {
                throw new ArgumentException(Constants.NullEmptyOrWhiteSpace, nameof(state));
            }

            if (string.IsNullOrWhiteSpace(zip)) {
                throw new ArgumentException(Constants.NullEmptyOrWhiteSpace, nameof(zip));
            }

            this.Street = street;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        public String ToSingleLineAddress() {
            return $"{this.Street} {this.City}, {this.State} {this.Zip}";
        }
    }
}
