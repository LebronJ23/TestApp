using DataModel.Contexts;
using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel.DataSeed
{
    public static class SeedEaters
    {
        public static void SeedData(DataContext context)
        {
            context.Database.Migrate();
            if (context.People.Count() == 0)
            {
                AppleEater a1 = new AppleEater { Name = "SeedMan1", Email = "seedman1@example.com" };
                AppleEater a2 = new AppleEater { Name = "SeedMan2", Email = "seedman2@example.com" };
                AppleEater a3 = new AppleEater { Name = "SeedMan3", Email = "seedman3@example.com" };
                AppleEater a4 = new AppleEater { Name = "SeedMan4", Email = "seedman4@example.com" };
                AppleEater a5 = new AppleEater { Name = "SeedMan5", Email = "seedman5@example.com" };
                AppleEater a6 = new AppleEater { Name = "SeedMan6", Email = "seedman6@example.com" };

                context.People.AddRange(a1, a2, a3, a4, a5, a6);
                context.SaveChanges();
            }
        }
    }
}
