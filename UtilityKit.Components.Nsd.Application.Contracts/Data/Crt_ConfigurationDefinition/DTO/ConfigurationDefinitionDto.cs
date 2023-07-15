using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;
using UtilityKit.Components.Nsd.Domain.SharedKernel.Enum;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_ConfigurationDefinition.DTO
{
    public class ConfigurationDefinitionDto
    {
        public List<ConfigurationDefinitionItem> ConfigurationDefinitions { get; set; }
    }
}
