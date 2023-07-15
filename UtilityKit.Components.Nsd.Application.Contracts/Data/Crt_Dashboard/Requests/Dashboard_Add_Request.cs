using G2Kit.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.DTO;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Dashboard.Requests
{
    public class Dashboard_Add_Request : DashboardDto, IRequestMapper<Dashboard>
    {
        #region --- IRequestMapper Implementation
        public Dashboard? MapToDomain()
        {
            return new()
            {
                Name = this.Name,
                Description = this.Description,
                Tags = this.Tags,
                CreationDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                DataSourceId = this.DataSourceId,
                LayoutId = this.LayoutId,
                CreatedBy = this.CreatedBy,
                LastModifiedBy = this.LastModifiedBy,
            };
        }
        #endregion
    }
}
