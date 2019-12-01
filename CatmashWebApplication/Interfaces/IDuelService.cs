using CatmashWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatmashWebApplication.Interfaces
{
    public interface IDuelService
    {
        Cat[] ResultOfDuel(Cat winner, Cat loser);
        void GetCompetitors();
    }
}
