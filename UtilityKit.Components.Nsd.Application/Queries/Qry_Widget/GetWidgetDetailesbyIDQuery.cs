using AutoMapper;
using FluentValidation;
using MediatR;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Application.Errors.Design;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_Widget
{
    public class GetWidgetDetailesbyIDQuery : IRequest<WidgetDetailesRespones>
    {
        public Guid WidgetID { get; set; }
        public class Handler : IRequestHandler<GetWidgetDetailesbyIDQuery, WidgetDetailesRespones>
        {
            private readonly IWidgetRepository _WidgetRepository;
            private readonly IMapper _Mapper;

            public Handler(IWidgetRepository WidgetRepository,IMapper mapper)
            {
                _WidgetRepository = WidgetRepository;
                _Mapper=mapper;
            }

            public async Task<WidgetDetailesRespones> Handle(GetWidgetDetailesbyIDQuery request,
                CancellationToken cancellationToken)
            {
                WidgetDetailesRespones widgetDetailesRespones = new WidgetDetailesRespones();
                var widgetDetailes = await _WidgetRepository.GetByID(request.WidgetID, cancellationToken);
                widgetDetailesRespones.widgetDetailes = _Mapper.Map<Widget, WidgetDto>(widgetDetailes);
                return widgetDetailesRespones;
            }

            #region --- Vallidation

            public class Validator : AbstractValidator<GetWidgetDetailesbyIDQuery>
            {
                public Validator()
                {
                    RuleFor(x => x.WidgetID).NotEmpty().WithMessage(WidgetErros.Widget_ID);
                }
            }

            #endregion
        }

    }
}
