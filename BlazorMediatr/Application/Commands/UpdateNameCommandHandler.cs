namespace BlazorMediatr.Application.Queries {

    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class UpdateNameCommandHandler : IRequestHandler<UpdateNameCommand, String> {

        public UpdateNameCommandHandler() {
        }

        public async Task<string> Handle(UpdateNameCommand request, CancellationToken cancellationToken) {
            // simulate calling a repository
            //   that updates the name in the database and returns it.

            await Task.Delay(500, cancellationToken); 
            if (String.IsNullOrWhiteSpace(request.Rank)) {
                return "Invisible Man";
            }
            if (request.Rank == "President") {
                return "President Abrahan Lincoln";
            }
            if (request.Rank == "General") {
                return "General George Patton";
            }
            if (request.Rank == "Actor") {
                return "David James Elliott";
            }
            // default
            return "Herman Munster";
        }
    }
}
