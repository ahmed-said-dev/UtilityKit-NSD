using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.Requests
{
    public class ConfigurationDefinition_Add_Request : ConfigurationDefinitionDto, IRequestMapper<List<ConfigurationDefinitionItem>>
    {
        public List<ConfigurationDefinitionItem>? MapToDomain()
        {
            var x = new List<ConfigurationDefinitionItem>();
            x = this.ConfigurationDefinitions;
            return x;
        }
    }
}
