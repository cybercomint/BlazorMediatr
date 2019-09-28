namespace BlazorMediatr.Application.Queries {

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetAddressHandler : IRequestHandler<GetAddressQuery, String> {

        public GetAddressHandler() {
        }

        public async Task<String> Handle(GetAddressQuery request, CancellationToken cancellationToken) {
            // simulate call to repository

            await Task.Delay(1000, cancellationToken);
            return "1600 Pennsylvania Avenue, Washington DC 20500";
        }
    }
}
