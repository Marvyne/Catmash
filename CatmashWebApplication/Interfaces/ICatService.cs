using CatmashWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatmashWebApplication.Interfaces
{
    public interface ICatService
    {
        List<Cat> GetAll();
        List<Cat> GetTwoCatsRandomly();
        Cat Get(string id);
        Cat Create(Cat cat);
        Cat Updated(Cat cat);
        HttpStatusCode Delete(string id);
    }
}
