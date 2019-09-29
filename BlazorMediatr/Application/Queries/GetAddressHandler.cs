namespace BlazorMediatr.Application.Queries {

    using System.Threading;
    using System.Threading.Tasks;
    using BlazorMediatr.Application.Dtos;
    using MediatR;

    public class GetAddressHandler : IRequestHandler<GetAddressQuery, AddressDto> {

        public GetAddressHandler() {
        }

        public async Task<AddressDto> Handle(GetAddressQuery request, CancellationToken cancellationToken) {
            // simulate call to repository

            await Task.Delay(1000, cancellationToken);
            return new AddressDto("1600 Pennsylvania Avenue", "Washington", "DC", "20500");
        }
    }
}
