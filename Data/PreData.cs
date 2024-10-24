using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatFormService.Models;

namespace PlatFormService.Data
{
    public static class PreData
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using(var ServiceScpoe = app.ApplicationServices.CreateScope())
            {
                SeedData(ServiceScpoe.ServiceProvider.GetService<AppDbContext>());
            }


        }

        private static void SeedData (AppDbContext context)
        {
            if(!context.platforms.Any())
            {
                Console.WriteLine("--> Seed Data");
                context.platforms.AddRange(
                    new Platform() { Name="Dot Net" , Publisher="Microsoft" , Cost="free" },
                    new Platform() { Name="Sql Server Express" , Publisher="Microsoft" , Cost="free" },
                    new Platform() { Name="Kubernetes" , Publisher="Cloud Native Computing foundation" , Cost="free" }
                );
                context.SaveChanges();

            }
            else{
                Console.WriteLine("--> We Already Have Data");
            }
        }
        
    }
}