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
    public class Datasource_Response : DataSourceDTO, IResponseMapper<Datasource_Response, DataSource>
    {
        #region --- IResponseMapper Implementation
        public Datasource_Response MapToResponse(DataSource domainObject)
        {
            if (domainObject == null)
                return new Datasource_Response();

            return new Datasource_Response()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                ConnectionDescription = domainObject.ConnectionDescription,
            };
        }

        public List<Datasource_Response> MapToResponseList(List<DataSource> domainObjectList)
        {
            var datasourceList = new List<Datasource_Response>();

            if (domainObjectList != null)
                foreach (var item in domainObjectList)
                    datasourceList.Add(MapToResponse(item));

            return datasourceList;
        }
        #endregion
    }
}
