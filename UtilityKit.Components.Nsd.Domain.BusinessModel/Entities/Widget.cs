using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;
using UtilityKit.Components.Nsd.Domain.SharedKernel.Enum;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("Widgets")]
    public class Widget
    {
        #region --- Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public string Thumbnail { get; set; }
        public string? WidgetFileSource { get; set; }
        [Required]
        public List<Industry> Industries { get; set; }
        [Required]
        public int MinCellSize { get; set; }
        [Required]
        public bool isBuiltIn { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public List<ConfigurationDefinitionItem>? ConfigurationDefinitions { get; set; }
        #endregion
        #region --- Navigation Properties
        public ICollection<LayoutCell> LayoutCells { get; set; }
        #endregion
    }
}
