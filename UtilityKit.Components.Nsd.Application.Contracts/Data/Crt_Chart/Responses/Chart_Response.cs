using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Responses
{
    public class Chart_Response : ConfigurationDefinitionDto, IResponseMapper<Chart_Response, List<ConfigurationDefinitionItem>>
    {
        public Chart_Response MapToResponse(List<ConfigurationDefinitionItem> domainObject)
        {
            return new Chart_Response()
            {
                ConfigurationDefinitions = domainObject
            };
        }

        public List<Chart_Response> MapToResponseList(List<List<ConfigurationDefinitionItem>> domainObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
