using DataModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Interfaces.Repositories
{
    public interface IAppleEatersRepository
    {
        IQueryable<AppleEater> People { get; }
        Task<AppleEater> GetEater(long id);
        void CreateEater(AppleEater ae);
        void SaveEater(AppleEater ae);
        void DeleteEater(AppleEater ae);
    }
}
