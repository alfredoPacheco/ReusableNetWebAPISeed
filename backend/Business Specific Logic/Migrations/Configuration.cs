namespace BusinessSpecificLogic.Migrations
{
    using EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BusinessSpecificLogic.EF.AssetsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusinessSpecificLogic.EF.AssetsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.cat_Area.AddOrUpdate(
                new cat_Area
                {
                    AreaKey = 1,
                    Area = "ERP"
                },
                new cat_Area
                {
                    AreaKey = 2,
                    Area = "CMS"
                }, 
                new cat_Area
                {
                    AreaKey = 3,
                    Area = "Custom Software"
                },
                new cat_Area
                {
                    AreaKey = 4,
                    Area = "Propietary Software"
                }, 
                new cat_Area
                {
                    AreaKey = 5,
                    Area = "Networking"
                }, 
                new cat_Area
                {
                    AreaKey = 6,
                    Area = "Servers"
                },
                new cat_Area
                {
                    AreaKey = 7,
                    Area = "Technical Support"
                }
            );

            context.cat_DutyLevel.AddOrUpdate(
                new cat_DutyLevel
                {
                    DutyLevelKey = 1,
                    DutyLevel = "Expertise"
                },
                new cat_DutyLevel
                {
                    DutyLevelKey = 2,
                    DutyLevel = "High Level Support"
                },
                new cat_DutyLevel
                {
                    DutyLevelKey = 3,
                    DutyLevel = "Just a Contact"
                }
            );            
        }
    }
}
