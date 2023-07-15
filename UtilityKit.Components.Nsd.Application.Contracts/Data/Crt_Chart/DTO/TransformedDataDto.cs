namespace ChartsProject.Models
{
    public class TransformedDataDto
    {
        public string arg { get; set; }
        public int val { get; set; }
        public string? DomainName { get; set; }
        public string? AssetTableName { get; set; }
        public int AssetGroup { get; set; }
        public string? AssetType { get; set; }
        public int IsBasic { get; set; }
        public string? GovId { get; set; }
        public string? CityId { get; set; }
        public int TotalLength { get; set; }
    }
}
