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
    public class LayoutCellRepository : ILayoutCellRepository
    {
        private readonly DbSet<LayoutCell> _layoutCellContext;
        #region --- Constructor
        public LayoutCellRepository(NsdDbContext context)
        {
            _layoutCellContext = context.Set<LayoutCell>();

        }
        #endregion
        public async Task<LayoutCell> Get(Guid id, CancellationToken cancellationToken)
        {
            var x = await _layoutCellContext.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
            return x;
        }

        public LayoutCell Update(LayoutCell layoutCell, CancellationToken token)
        {
            _layoutCellContext.Update(layoutCell);
            return layoutCell;
        }
    }
}
