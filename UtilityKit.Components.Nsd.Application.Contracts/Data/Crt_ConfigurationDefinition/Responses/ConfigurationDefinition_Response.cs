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
    public class ConfigurationDefinition_Response : ConfigurationDefinitionDto, IResponseMapper<ConfigurationDefinition_Response, List<ConfigurationDefinitionItem>>
    {
        public ConfigurationDefinition_Response MapToResponse(List<ConfigurationDefinitionItem> domainObject)
        {
            return new ConfigurationDefinition_Response()
            {
                ConfigurationDefinitions = domainObject
            };
        }

        public List<ConfigurationDefinition_Response> MapToResponseList(List<List<ConfigurationDefinitionItem>> domainObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
