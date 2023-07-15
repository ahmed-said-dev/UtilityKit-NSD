using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO
{
    public class DashboardDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public Guid DataSourceId { get; set; }
        public Guid LayoutId { get; set; }
        public string? CreationDate { get; set; }
        public string? LastModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
        public List<LayoutCell>? layoutCells { get; set; }
    }
}
