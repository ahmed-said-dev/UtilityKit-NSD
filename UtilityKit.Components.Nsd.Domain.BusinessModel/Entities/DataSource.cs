using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("DataSources")]
    public class DataSource
    {
        #region --- Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(500)]
        public string ConnectionDescription { get; set; }
        #endregion

        #region --- Navigation Properties
        public ICollection<Dashboard> Dashboards { get; set; }
        #endregion
    }
}
