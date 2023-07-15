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
    public class GetDataSourcesForDashboardQuery : IRequest<List<Datasource_Response>>
    {
        public class Handler : IRequestHandler<GetDataSourcesForDashboardQuery, List<Datasource_Response>>
        {
            private readonly IDashboardRepository _dashboardRepository;

            public Handler(IDashboardRepository dashboardRepository)
            {
                _dashboardRepository = dashboardRepository;
            }
            public async Task<List<Datasource_Response>> Handle(GetDataSourcesForDashboardQuery request, CancellationToken cancellationToken)
            {
                var dashboards = await _dashboardRepository.GetDatasourceForDashboard(cancellationToken);

                return new Datasource_Response().MapToResponseList(dashboards);
            }
        }
    }
}
