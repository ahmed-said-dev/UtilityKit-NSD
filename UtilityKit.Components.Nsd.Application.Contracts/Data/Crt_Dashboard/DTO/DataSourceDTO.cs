using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO
{
    public class DataSourceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionDescription { get; set; }
    }
}
