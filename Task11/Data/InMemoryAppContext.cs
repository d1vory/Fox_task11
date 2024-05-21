using Microsoft.EntityFrameworkCore;

namespace Task11.Data;

public class InMemoryAppContext: BaseApplicationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");
    }
}