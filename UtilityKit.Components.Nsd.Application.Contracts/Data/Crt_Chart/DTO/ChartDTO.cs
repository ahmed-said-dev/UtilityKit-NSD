using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Chart.DTO
{
    public class ChartDTO
    {
        public string? DomainName { get; set; }
        public string? AssetTableName { get; set; }
        public int AssetGroup { get; set; }
        public string? AssetType { get; set; }
        public int IsBasic { get; set; }
        public string? GovId { get; set; }
        public string? CityId { get; set; }
        public int TotalLength { get; set; }
    }
}
