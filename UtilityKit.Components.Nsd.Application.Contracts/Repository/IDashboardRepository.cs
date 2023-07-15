using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Repository
{
    public interface IDashboardRepository
    {
        Task<Dashboard> AddDashboard(Dashboard dashboard, CancellationToken token);
        Task<List<Dashboard>> GetAll(CancellationToken cancellationToken);
        Task<List<Layout>> GetLayoutsForDashboard(CancellationToken cancellationToken);
        Task<List<DataSource>> GetDatasourceForDashboard(CancellationToken cancellationToken);
        Task<Dashboard> Get(Guid id, CancellationToken cancellationToken);
        Task<bool> Delete(Guid id, CancellationToken cancellationToken);
        Dashboard UpdateDashboard(Dashboard dashboard, CancellationToken token);
    }
}
