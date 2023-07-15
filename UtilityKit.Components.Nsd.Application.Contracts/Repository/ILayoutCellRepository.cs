using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Repository
{
    public interface ILayoutCellRepository
    {
        Task<LayoutCell> Get(Guid id, CancellationToken cancellationToken);
        LayoutCell Update(LayoutCell layoutCell, CancellationToken token);
    }
}
