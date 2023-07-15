using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Responses
{
    public class Dashboard_Response : DashboardDto, IResponseMapper<Dashboard_Response, Dashboard>
    {
        #region --- Properties
        public Guid Id { get; set; }
        #endregion

        #region --- IResponseMapper Implementation
        public Dashboard_Response MapToResponse(Dashboard domainObject)
        {
            if (domainObject == null)
                return new Dashboard_Response();

            Dashboard_Response response = new Dashboard_Response()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                DataSourceId = domainObject.DataSourceId,
                CreationDate = domainObject.CreationDate.ToString("dd-MM-yyyy"),
                LastModifiedDate = domainObject.LastModifiedDate.ToString("dd-MM-yyyy"),
                Description = domainObject.Description,
                LayoutId = domainObject.LayoutId,
                LastModifiedBy = domainObject.LastModifiedBy,
                CreatedBy = domainObject.CreatedBy,
                Tags = domainObject.Tags,
                layoutCells = new(),
            };
            if (domainObject.layoutCells != null)
                foreach (var item in domainObject.layoutCells)
                    response.layoutCells.Add(new()
                    {
                        Id = item.Id,
                        DashboardId = item.DashboardId,
                        CellSize = item.CellSize,
                        WidgetId = item.WidgetId,
                        Widget = item.Widget,
                        CellsDefinition= item.CellsDefinition,
                    });
            return response;
        }

        public List<Dashboard_Response> MapToResponseList(List<Dashboard> domainObjectList)
        {
            var dashboardList = new List<Dashboard_Response>();

            if (domainObjectList != null)
                foreach (var item in domainObjectList)
                    dashboardList.Add(MapToResponse(item));

            return dashboardList;
        }
        #endregion
    }
}
