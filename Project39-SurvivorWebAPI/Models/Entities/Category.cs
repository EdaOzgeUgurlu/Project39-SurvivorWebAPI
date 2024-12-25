

namespace Project39_SurvivorWebAPI.Models.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<Competitor> Competitors { get; set; }
        public DateTime CreatedDate { get; internal set; }
        public int Id { get; internal set; }
        public bool IsDeleted { get; internal set; }
        public DateTime ModifiedDate { get; internal set; }
    }
}
