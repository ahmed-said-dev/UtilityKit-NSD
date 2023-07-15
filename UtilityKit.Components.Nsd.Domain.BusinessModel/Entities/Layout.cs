using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UtilityKit.Components.Nsd.Domain.BusinessModel.MetaData;

namespace UtilityKit.Components.Nsd.Domain.BusinessModel.Entities
{
    [Table("Layouts")]
    public class Layout
    {
        #region --- Columns
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LayoutDescription>? LayoutsDescriptions { get; set; }
        public string Thumbnail { get; set; }
        #endregion

        #region --- Navigation Properties
        public ICollection<Dashboard> Dashboards { get; set; }
        #endregion
    }
}
