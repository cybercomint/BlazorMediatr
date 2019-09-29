namespace BlazorMediatr.Pages {

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    public class SelfContainedExampleBase : ComponentBase {

        public String Result { get; set; }

        public ViewModel Model { get; private set; }

        [Inject]
        public IMediator Mediator { get; set; }

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
            this.Model = new ViewModel(selections.Roles, selections.Names);
        }

        public class GetSelectionsQuery : IRequest<SelectionsDto> {
        }

        public class GetSelectionsQueryHandler : IRequestHandler<GetSelectionsQuery, SelectionsDto> {

            public async Task<SelectionsDto> Handle(GetSelectionsQuery request, CancellationToken cancellationToken) {
                await Task.Delay(500, cancellationToken);  // simulate call to repository
                return new SelectionsDto {
                    Roles = new List<String> { "Actor", "Actress", "General", "President" },
                    Names = new List<String> { "Abrahan Lincoln", "David James Elliott", "George Patton", "Jessica Chastain" }
                };
            }
        }

        public class SelectionsDto {

            public IList<String> Names { get; set; }

            public IList<String> Roles { get; set; }

            public SelectionsDto() {
            }
        }

        public class VerifyAnswerCommand : IRequest<Boolean> {

            public String Name { get; set; } = String.Empty;

            public String Role { get; set; } = String.Empty;

            public VerifyAnswerCommand() {
            }
        }

        public class VerifyAnswerCommandHandler : IRequestHandler<VerifyAnswerCommand, Boolean> {

            public VerifyAnswerCommandHandler() {
            }

            public async Task<Boolean> Handle(VerifyAnswerCommand request, CancellationToken cancellationToken) {
                await Task.Delay(500, cancellationToken); // simulate calling a repository or business object, etc.
                switch (request.Role) {
                    case "Actor":
                        if (request.Name == "David James Elliott") {
                            return true;
                        }
                        break;

                    case "Actress":
                        if (request.Name == "Jessica Chastain") {
                            return true;
                        }
                        break;

                    case "General":
                        if (request.Name == "George Patton") {
                            return true;
                        }
                        break;

                    case "President":
                        if (request.Name == "Abrahan Lincoln") {
                            return true;
                        }
                        break;

                    default:
                        break;
                }
                return false;
            }
        }

        public class ViewModel {

            public IList<string> Names { get; }

            public IList<string> Roles { get; }

            public String SelectedName { get; set; }

            public String SelectedRole { get; set; }

            public ViewModel(IList<String> roles, IList<String> names) {
                this.Roles = roles;
                this.Names = names;
            }
        }
    }
}
