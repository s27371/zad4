using Microsoft.AspNetCore.Mvc;
using zad4.Models;

namespace zad4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    [HttpGet("{animalId}")]
    public ActionResult<IEnumerable<Visit>> GetVisits(int animalId)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
            return NotFound("Zwierzę nie istnieje.");

        var result = Database.Visits.Where(v => v.AnimalId == animalId);
        return Ok(result);
    }

    [HttpPost("{animalId}")]
    public ActionResult AddVisit(int animalId, Visit visit)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
            return NotFound("Zwierzę nie istnieje.");

        visit.AnimalId = animalId;
        Database.Visits.Add(visit);
        return Created($"/api/animals/{animalId}/visits", visit);
    }
}