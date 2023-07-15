using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("DrillDownCharts")]
    public class Chart
    {
        
        public int Id { get; set; }
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
