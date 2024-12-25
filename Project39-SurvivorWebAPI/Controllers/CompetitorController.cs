using Microsoft.AspNetCore.Mvc;
using Project39_SurvivorWebAPI.Data.CompetitorDatas;
using Project39_SurvivorWebAPI.Models.Context;
using Project39_SurvivorWebAPI.Models.Entities;

namespace Project39_SurvivorWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCompetitors()
        {
            var competitors = _context.Competitors.ToList();
            return Ok(competitors);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompetitor(int id)
        {
            var competitor = _context.Competitors.Find(id);
            return Ok(competitor);
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult GetCompetitorsByCategory(int categoryId)
        {
            var competitors = _context.Competitors.Where(x => x.CategoryId == categoryId).ToList();
            return Ok(competitors);
        }

        [HttpPost]
        public IActionResult CreateCompetitor(CreateCompetitorData createCompetitorData)
        {
            var competitor = new Competitor
            {
                FirstName = createCompetitorData.FirstName,
                LastName = createCompetitorData.LastName,
                CategoryId = createCompetitorData.CategoryId
            };
            _context.Competitors.Add(competitor);
            _context.SaveChanges();
            return Ok("Başarılı bir şekilde yarışmacı kaydedildi.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompetitor(int id, UpdateCompetitorData updateCompetitorData)
        {
            var competitor = _context.Competitors.Find(id);

            competitor.FirstName = updateCompetitorData.FirstName;
            competitor.LastName = updateCompetitorData.LastName;
            competitor.CategoryId = updateCompetitorData.CategoryId;

            _context.Competitors.Update(competitor);
            _context.SaveChanges();
            return Ok("Güncelleme yapıldı");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCompetitor(int id)
        {
            var competitor = _context.Competitors.Find(id);
            _context.Remove(competitor);
            _context.SaveChanges();
            return Ok("Başarılı bir şekilde yarışmacı silindi.");
        }

    }
}
