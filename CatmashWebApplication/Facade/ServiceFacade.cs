using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatmashWebApplication.Interfaces;
using CatmashWebApplication.Service;

namespace CatmashWebApplication.Facade
{
    public class ServiceFacade : IServiceFacade
    {
        private CatService _catService { get; set; }

        public ServiceFacade()
        {
            _catService = new CatService();
        }

        public ICatService GetCat()
        {
            return _catService;
        }
    }
}
