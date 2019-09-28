namespace BlazorMediatr.Application.Queries {

    using System;
    using MediatR;

    public class UpdateNameCommand : IRequest<String> {

        public String Rank { get; set; } = String.Empty;

        public UpdateNameCommand() {
        }
    }
}
