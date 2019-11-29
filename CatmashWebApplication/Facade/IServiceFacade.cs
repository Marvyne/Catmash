using CatmashWebApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatmashWebApplication.Facade
{
    interface IServiceFacade
    {
        ICatService GetCat();
    }
}
