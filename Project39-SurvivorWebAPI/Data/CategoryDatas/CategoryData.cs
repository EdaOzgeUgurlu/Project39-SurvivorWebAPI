using Project39_SurvivorWebAPI.Data.CompetitorDatas;

namespace Project39_SurvivorWebAPI.Data.CategoryData
{
    public class CategoryData
    {
        public string Name { get; set; } = "";
        public List<CompetitorData> Competitors { get; set; }
    }
}
