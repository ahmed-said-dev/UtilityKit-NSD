using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO
{
    public class LayoutDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LayoutDescription>? LayoutsDescriptions { get; set; }
        public string Thumbnail { get; set; }
    }
}
