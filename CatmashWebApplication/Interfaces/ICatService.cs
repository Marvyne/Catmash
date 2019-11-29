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
        Cat Get(int id);
        Cat Create(Cat cat);
        Cat Updated(Cat cat);
        HttpStatusCode Delete(int id);
    }
}
