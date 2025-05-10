using Microsoft.AspNetCore.Mvc;
using zad4.Models;

namespace zad4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAll() => Ok(Database.Animals);

    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        return animal is null ? NotFound() : Ok(animal);
    }

    [HttpPost]
    public ActionResult Add(Animal animal)
    {
        if (Database.Animals.Any(a => a.Id == animal.Id))
            return BadRequest("Zwierzę o tym ID już istnieje.");

        Database.Animals.Add(animal);
        return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Animal updated)
    {
        var index = Database.Animals.FindIndex(a => a.Id == id);
        if (index == -1) return NotFound();

        updated.Id = id;
        Database.Animals[index] = updated;
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal is null) return NotFound();

        Database.Animals.Remove(animal);
        Database.Visits.RemoveAll(v => v.AnimalId == id);
        return NoContent();
    }

    [HttpGet("search/{name}")]
    public ActionResult Search(string name)
    {
        var results = Database.Animals
            .Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Ok(results);
    }
}