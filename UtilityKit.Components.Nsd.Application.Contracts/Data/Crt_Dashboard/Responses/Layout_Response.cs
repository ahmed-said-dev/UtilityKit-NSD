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
    public class Layout_Response : LayoutDTO, IResponseMapper<Layout_Response, Layout>
    {
        #region --- IResponseMapper Implementation
        public Layout_Response MapToResponse(Layout domainObject)
        {
            if (domainObject == null)
                return new Layout_Response();

            return new Layout_Response()
            {
                Id = domainObject.Id,
                Name = domainObject.Name,
                LayoutsDescriptions = domainObject.LayoutsDescriptions,
                Thumbnail = domainObject.Thumbnail
            };
        }

        public List<Layout_Response> MapToResponseList(List<Layout> domainObjectList)
        {
            var layoutList = new List<Layout_Response>();

            if (domainObjectList != null)
                foreach (var item in domainObjectList)
                    layoutList.Add(MapToResponse(item));

            return layoutList;
        }
        #endregion
    }
}
