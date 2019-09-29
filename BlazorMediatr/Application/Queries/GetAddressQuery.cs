namespace BlazorMediatr.Application.Queries {

    using BlazorMediatr.Application.Dtos;
    using MediatR;

    public class GetAddressQuery : IRequest<AddressDto> {

        public GetAddressQuery() {
        }
    }
}
