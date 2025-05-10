using zad4.Models;

namespace zad4;

public class Database
{
    public static List<Animal> Animals { get; set; } = new()
    {
        new Animal { Id = 1, Name = "Reksio", Category = "pies", Weight = 12.5, FurColor = "brązowy" },
        new Animal { Id = 2, Name = "Mruczek", Category = "kot", Weight = 4.2, FurColor = "czarny" }
    };

    public static List<Visit> Visits { get; set; } = new()
    {
        new Visit { Date = DateTime.Now.AddDays(-10), AnimalId = 1, Description = "Szczepienie", Price = 120 },
        new Visit { Date = DateTime.Now.AddDays(-5), AnimalId = 2, Description = "Kontrola zdrowia", Price = 80 }
    };
}