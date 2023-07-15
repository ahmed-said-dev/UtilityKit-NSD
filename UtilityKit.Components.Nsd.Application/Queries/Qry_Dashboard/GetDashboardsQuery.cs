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
    public class GetDashboardsQuery : IRequest<List<Dashboard_Response>>
    {
        public class Handler : IRequestHandler<GetDashboardsQuery, List<Dashboard_Response>>
        {
            private readonly IDashboardRepository _dashboardRepository;

            public Handler(IDashboardRepository dashboardRepository)
            {
                _dashboardRepository = dashboardRepository;
            }
            public async Task<List<Dashboard_Response>> Handle(GetDashboardsQuery request, CancellationToken cancellationToken)
            {
                var dashboards = await _dashboardRepository.GetAll(cancellationToken);

                return new Dashboard_Response().MapToResponseList(dashboards);
            }
        }
    }
}
