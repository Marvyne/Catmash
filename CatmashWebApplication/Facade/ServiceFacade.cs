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
        private DuelService _duelService { get; set; }

        public ServiceFacade()
        {
            _catService = new CatService();
            _duelService = new DuelService();
        }

        public ICatService GetCat()
        {
            return _catService;
        }

        public IDuelService GetDuel()
        {
            return _duelService;
        }
    }
}
