using DataModel.Contexts;
using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Interfaces.Repositories;

namespace TestApp.Repositories
{
    public class AppleEatersRepository : IAppleEatersRepository
    {
        private DataContext context;

        public AppleEatersRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IQueryable<AppleEater> People => context.People;

        public void CreateEater(AppleEater ae)
        {
            var user = context.People.FirstOrDefault(p => p.Email == ae.Email);
            if (user == null)
            {
                context.Add(ae);
            }
            else
            {
                user.AppleAmount++;
                user.Time= DateTime.Now;
                context.Update(user);
            }
            context.SaveChanges();
        }

        public void DeleteEater(AppleEater ae)
        {
            context.Remove(ae);
            context.SaveChanges();
        }

        public async Task<AppleEater> GetEater(long id)
        {
            var result = await context.People.FirstOrDefaultAsync<AppleEater>(p => p.Id == id);
            return result;
        }

        public async Task<AppleEater> GetEater(string email)
        {
            var result = await context.People.FirstOrDefaultAsync<AppleEater>(p => p.Email == email);
            return result;
        }

        public void SaveEater(AppleEater ae)
        {
            context.SaveChanges();
        }
    }
}
