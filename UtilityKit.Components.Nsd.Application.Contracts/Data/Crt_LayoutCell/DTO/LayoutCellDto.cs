using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_LayoutCell.DTO
{
    public class LayoutCellDto
    {
        public int CellSize { get; set; }
        public Guid? WidgetId { get; set; }
        public Guid DashboardId { get; set; }
        public string CellsDefinition { get; set; }
        public List<ConfigurationItem>? Configurations { get; set; }
    }
}
