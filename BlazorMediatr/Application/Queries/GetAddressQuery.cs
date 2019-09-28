namespace BlazorMediatr.Application.Queries {

    using System;
    using MediatR;

    public class GetAddressQuery : IRequest<String> {

        public GetAddressQuery() {
        }
    }
}
