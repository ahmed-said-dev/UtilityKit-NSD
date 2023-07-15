using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Responses;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;

namespace UtilityKit.Components.Nsd.Application.Queries.Qry_Dashboard
{
    public class GetDashboardQuery : IRequest<Dashboard_Response>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetDashboardQuery, Dashboard_Response>
        {
            private readonly IDashboardRepository _dashboardRepository;
            private readonly IWidgetRepository _widgetRepository;
            public Handler(IDashboardRepository dashboardRepository, IWidgetRepository widgetRepository)
            {
                _dashboardRepository = dashboardRepository;
                _widgetRepository = widgetRepository;
            }
            public async Task<Dashboard_Response> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
            {
                var dashboard = await _dashboardRepository.Get(request.Id,cancellationToken);
                foreach (var item in dashboard.layoutCells)
                {
                    if(item.WidgetId is not null)
                    {
                        item.Widget = await _widgetRepository.GetByID((Guid)item.WidgetId, cancellationToken);
                    }
                }
                return new Dashboard_Response().MapToResponse(dashboard);
            }
        }
    }
}
