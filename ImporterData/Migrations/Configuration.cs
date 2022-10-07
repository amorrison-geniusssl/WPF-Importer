using System.Data.Entity.Migrations;

namespace ImporterData.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ImporterData.ImporterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ImporterData.ImporterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
