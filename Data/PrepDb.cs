﻿using PlatformService.Models;

namespace PaltformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(servicesScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any()) 
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name= "dot net",
                        Publisher="Microsoft",
                        Cost="Free"
                    },
                    new Platform()
                    {
                        Name = "SQL Server Express",
                        Publisher = "Microsoft",
                        Cost = "Free"
                    },
                    new Platform()
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation",
                        Cost = "Free"
                    }
                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we have data...");
            }
        }
    }
}
