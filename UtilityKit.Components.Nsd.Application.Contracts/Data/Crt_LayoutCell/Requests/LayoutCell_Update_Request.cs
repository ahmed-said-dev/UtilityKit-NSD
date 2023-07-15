using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.Requests
{
    public class LayoutCell_Update_Request : LayoutCellDto, IRequestMapper<LayoutCell>
    {
        #region --- Properties
        public Guid Id { get; set; }
        #endregion

        #region --- IRequestMapper Implementation
        public LayoutCell? MapToDomain()
        {
            return new()
            {
                Id = this.Id,
                WidgetId = this.WidgetId,
                CellsDefinition = this.CellsDefinition,
                CellSize = this.CellSize,
                DashboardId = this.DashboardId,
                Configurations = this.Configurations,
            };
        }
        #endregion
    }
}
