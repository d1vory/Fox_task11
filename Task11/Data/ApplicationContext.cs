using Microsoft.EntityFrameworkCore;

namespace Task11.Data;

public class ApplicationContext: BaseApplicationContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"data source=o-dubchak-pc2\SQLEXPRESS;initial catalog=finance;trusted_connection=true;TrustServerCertificate=True;");
    }
}