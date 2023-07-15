using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.Entities;
using UtilityKit.Components.Nsd.Infrastrcuture.Constants;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Infrastrcuture.Configurations
{
    public class ConfigurationDefinitionItemConfiguration : IEntityTypeConfiguration<Widget>
    {
        public void Configure(EntityTypeBuilder<Widget> builder)
        {
            builder.Property(b => b.ConfigurationDefinitions)
           .HasColumnType(ColumnTypes.JSONB)
           .HasConversion(
             v => JsonConvert.SerializeObject(v),
             v => JsonConvert.DeserializeObject<List<ConfigurationDefinitionItem>>(v));
        }
    }
}
