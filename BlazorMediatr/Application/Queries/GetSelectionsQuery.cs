namespace BlazorMediatr.Application.Queries {

    using BlazorMediatr.Application.Models;
    using MediatR;

    public class GetSelectionsQuery : IRequest<SelectionsDto> {
    }
}
