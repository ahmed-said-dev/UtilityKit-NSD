using AutoMapper;
using MediatR;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_Widget
{
    public class Get_All_Widget_Query :IRequest<GetAllWidgetResponse>
    {
        public class Handler : IRequestHandler<Get_All_Widget_Query, GetAllWidgetResponse>
        {
            private readonly IWidgetRepository _WidgetRepository;
            private readonly IMapper _Mapper;

            public Handler(IWidgetRepository WidgetRepository,IMapper mapper)
            {
                _WidgetRepository = WidgetRepository;
                _Mapper=mapper;
            }

            public async Task<GetAllWidgetResponse> Handle(Get_All_Widget_Query request, CancellationToken cancellationToken)
            {
                GetAllWidgetResponse GetAllWidgetResponse = new GetAllWidgetResponse();
                var Widgets = await _WidgetRepository.GetAll(cancellationToken);

                GetAllWidgetResponse.GetWidgetDtos = _Mapper.Map<List<Widget>, List<WidgetDto>>(Widgets);
                return GetAllWidgetResponse;
            }
        }

    }
}
