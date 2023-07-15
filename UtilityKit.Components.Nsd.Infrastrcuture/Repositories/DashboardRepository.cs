using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Repository;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DbSet<Dashboard> _dashboardContext;
        private readonly DbSet<Layout> _layoutContext;
        private readonly DbSet<LayoutCell> _layoutCellContext;
        private readonly DbSet<DataSource> _dataSourceContext;

        #region --- Constructor
        public DashboardRepository(NsdDbContext context)
        {
            _dashboardContext = context.Set<Dashboard>();
            _layoutContext = context.Set<Layout>();
            _layoutCellContext = context.Set<LayoutCell>();
            _dataSourceContext = context.Set<DataSource>();
        }
        #endregion

        #region --- Add Dashboard
        public async Task<Dashboard> AddDashboard(Dashboard dashboard, CancellationToken token)
        {
            await _dashboardContext.AddAsync(dashboard, token);
            var layout = await _layoutContext.AsNoTracking().Where(x => x.Id == dashboard.LayoutId).FirstOrDefaultAsync(token);
            foreach(var description in layout.LayoutsDescriptions)
            {
                LayoutCell layoutCell = new LayoutCell()
                {
                    CellSize = int.Parse(description.LayoutCellSize),
                    DashboardId = dashboard.Id,
                    CellsDefinition = description.LayoutCellName,
                };

                await _layoutCellContext.AddAsync(layoutCell, token);
            }
  
            return dashboard;
        }
        #endregion

        #region --- Get All Dashboards
        public async Task<List<Dashboard>> GetAll(CancellationToken cancellationToken)
        {
            return await _dashboardContext.AsNoTracking().Include(x => x.layoutCells).OrderByDescending(x => x.LastModifiedDate).ThenBy(x => x.LastModifiedDate).ToListAsync(cancellationToken);
        }
        #endregion

        #region --- Get Dashboard
        public async Task<Dashboard> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _dashboardContext.AsNoTracking().Include(x => x.layoutCells).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
        #endregion

        #region --- Update Dashboard
        public Dashboard UpdateDashboard(Dashboard dashboard, CancellationToken token)
        {
            _dashboardContext.Update(dashboard);
            return dashboard;
        }
        #endregion

        #region --- Delete Dashboard
        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
        {
            var dashboard = await _dashboardContext.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            return _dashboardContext.Remove(dashboard) is not null;
        }
        #endregion

        #region --- Get Layouts For Dashboard
        public async Task<List<Layout>> GetLayoutsForDashboard(CancellationToken cancellationToken)
        {
            return await _layoutContext.AsNoTracking().ToListAsync(cancellationToken);
        }
        #endregion

        #region --- Get DataSources For Dashboard
        public async Task<List<DataSource>> GetDatasourceForDashboard(CancellationToken cancellationToken)
        {
            return await _dataSourceContext.AsNoTracking().ToListAsync(cancellationToken);
        }
        #endregion
    }
}
