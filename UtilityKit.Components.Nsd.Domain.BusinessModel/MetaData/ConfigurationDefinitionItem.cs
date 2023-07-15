using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.SharedKernel.Enum;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData
{
    public class ConfigurationDefinitionItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public ConfigType Type { get; set; }
        public string[] Options { get; set; }
        public string DefaultValue { get; set; }
    }
}
