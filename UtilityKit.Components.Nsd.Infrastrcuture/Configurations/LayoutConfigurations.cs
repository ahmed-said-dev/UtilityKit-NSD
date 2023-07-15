using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;
using UtilityKit.Components.Nsd.Infrastrcuture.Constants;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Configurations
{
    public class LayoutConfigurations : IEntityTypeConfiguration<Layout>
    {
        public void Configure(EntityTypeBuilder<Layout> builder)
        {
            builder.HasMany(a => a.Dashboards).WithOne(z => z.Layout).OnDelete(DeleteBehavior.Restrict);

            builder.Property(b => b.LayoutsDescriptions)
                .HasColumnType(ColumnTypes.JSONB)
                .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<LayoutDescription>>(v));
        }
    }
}
