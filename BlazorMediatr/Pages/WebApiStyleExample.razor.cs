namespace BlazorMediatr.Pages {

    using System;
    using System.Threading.Tasks;
    using BlazorMediatr.Application.Commands;
    using BlazorMediatr.Application.Models;
    using BlazorMediatr.Application.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    public class WebApiStyleExampleBase : ComponentBase {

        [Inject]
        public IMediator Mediator { get; set; }

        public WebApiStyleViewModel Model { get; private set; }

        public String Result { get; set; }

        public async Task VerifySelections() {
            var result = await this.Mediator.Send(new VerifyAnswerCommand { Name = this.Model.SelectedName, Role = this.Model.SelectedRole });
            if (result) {
                this.Result = $"Outstanding, {this.Model.SelectedName}'s role is {this.Model.SelectedRole}";
            } else {
                this.Result = "Sorry give it another try.";
            }
        }

        protected override async Task OnInitializedAsync() {
            var selections = await this.Mediator.Send(new GetSelectionsQuery());
            this.Model = new WebApiStyleViewModel(selections.Roles, selections.Names);
        }
    }
}
