
namespace Project39_SurvivorWebAPI.Models.Entities
{
    public class Competitor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime ModifiedDate { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public bool IsDeleted { get; internal set; }
        public int Id { get; internal set; }
    }
}
