using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;
using UtilityKit.Components.Nsd.Domain.SharedKernel.Enum;

namespace UtilityKit.Components.Nsd.Application.Contracts.Data.Crt_Widget.DTO
{
    public class WidgetDto
    {
        #region --- Columns
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string? WidgetFileSource { get; set; }
        public List<Industry> Industries { get; set; }
        public int MinCellSize { get; set; }
        public bool isBuiltIn { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public List<ConfigurationDefinitionItem>? ConfigurationDefinitions { get; set; }
        #endregion
    }
}
