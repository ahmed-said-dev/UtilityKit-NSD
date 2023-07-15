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
    public class ChartRepository : IChartRepository
    {
        private readonly DbSet<Chart> _chartContext;

        #region --- Constructor
        public ChartRepository(NsdDbContext context)
        {
            _chartContext = context.Set<Chart>();
        }
        #endregion



        #region --- Get Chart Data
        public Task<List<Chart>> GetChartData()
        {
            return _chartContext.ToListAsync();
        }

        #endregion




    }
}
