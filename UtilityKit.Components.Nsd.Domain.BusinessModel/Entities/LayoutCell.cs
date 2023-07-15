using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("LayoutCells")]
    public class LayoutCell
    {
        #region --- Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int CellSize { get; set; }
        [ForeignKey(nameof(Widget))]
        public Guid? WidgetId { get; set; }
        [ForeignKey(nameof(Dashboard))]
        public Guid DashboardId { get; set; }
        public string CellsDefinition { get; set; }
        public List<ConfigurationItem>? Configurations { get; set; }
        #endregion
        #region --- Navigation Properties
        public Widget Widget { get; set; }
        public Dashboard Dashboard { get; set; }
        #endregion
    }
}
