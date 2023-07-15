using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Configurations
{
    public class DataSourceConfigurations : IEntityTypeConfiguration<DataSource>
    {
        public void Configure(EntityTypeBuilder<DataSource> builder)
        {
            builder.HasMany(a => a.Dashboards).WithOne(z => z.DataSource).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
