using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("Dashboards")]
    public class Dashboard
    {
        #region --- Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Tags { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [ForeignKey(nameof(DataSource))]
        public Guid DataSourceId { get; set; }
        [ForeignKey(nameof(Layout))]
        public Guid LayoutId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }

        #endregion

        #region --- Navigation Properties
        public ICollection<LayoutCell> layoutCells { get; set; }
        public Layout Layout { get; set; }
        public DataSource DataSource { get; set; }
        #endregion
    }
}
