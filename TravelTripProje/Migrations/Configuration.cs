

namespace TravelTripProje.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    internal sealed class Configuration :
        DbMigrationsConfiguration<TravelTripProje.Models.Siniflar.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(TravelTripProje.Models.Siniflar.Context
            context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method
            // to avoid creating duplicate seed data.
        }
    }
}