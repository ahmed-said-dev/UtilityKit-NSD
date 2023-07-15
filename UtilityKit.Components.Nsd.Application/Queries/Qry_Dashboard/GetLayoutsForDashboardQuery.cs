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
    public class GetLayoutsForDashboardQuery : IRequest<List<Layout_Response>>
    {
        public class Handler : IRequestHandler<GetLayoutsForDashboardQuery, List<Layout_Response>>
        {
            private readonly IDashboardRepository _dashboardRepository;
                
            public Handler(IDashboardRepository dashboardRepository)
            {
                _dashboardRepository = dashboardRepository;
            }
            public async Task<List<Layout_Response>> Handle(GetLayoutsForDashboardQuery request, CancellationToken cancellationToken)
            {
                var dashboards = await _dashboardRepository.GetLayoutsForDashboard(cancellationToken);

                return new Layout_Response().MapToResponseList(dashboards);
            }
        }
    }
}
