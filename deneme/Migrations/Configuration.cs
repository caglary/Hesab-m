namespace deneme.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<deneme.context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "deneme.context";
        }

        protected override void Seed(deneme.context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
