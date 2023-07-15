using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.Responses
{
    public class LayoutCell_Response : LayoutCellDto, IResponseMapper<LayoutCell_Response, LayoutCell>
    {
        #region --- Properties
        public Guid Id { get; set; }
        #endregion
        public LayoutCell_Response MapToResponse(LayoutCell domainObject)
        {
            if (domainObject == null)
                return new LayoutCell_Response();

            return new LayoutCell_Response()
            {
                Id = domainObject.Id,
               CellsDefinition = domainObject.CellsDefinition,
               CellSize = domainObject.CellSize,
               Configurations = domainObject.Configurations,
               DashboardId = domainObject.DashboardId,
               WidgetId = domainObject.WidgetId,
            };
        }

        public List<LayoutCell_Response> MapToResponseList(List<LayoutCell> domainObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
