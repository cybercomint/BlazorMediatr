namespace BlazorMediatr.Pages {

    using System;
    using System.Threading.Tasks;
    using BlazorMediatr.Application.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    public class IndexBase : ComponentBase {

        protected String PageTitle { get; private set; } = String.Empty;

        protected String Address { get; private set; } = "Loading...";

        [Inject]
        protected IMediator Mediator { get; set; }

        protected String Name { get; private set; } = String.Empty;

        public IndexBase() {
            this.PageTitle = "Blazor with MediatR";
        }

        protected async Task SetName(String rank) {
            // similar to controller methods, keep these thin and clean.

            this.Name = await this.Mediator.Send(new UpdateNameCommand { Rank = rank });
        }

        protected override async Task OnInitializedAsync() {
            // similar to controller methods, keep these thin and clean.

            this.Address = await this.Mediator.Send(new GetAddressQuery());
        }
    }
}
