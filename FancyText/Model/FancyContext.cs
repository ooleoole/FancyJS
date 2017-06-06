using Microsoft.EntityFrameworkCore;

namespace FancyText
{
    public class FancyContext : DbContext
    {
        public FancyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<FancyText> FancyTexts { get; set; }
        public DbSet<FancyTextComposition> FancyTextCompositions { get; set; }
    }
}
