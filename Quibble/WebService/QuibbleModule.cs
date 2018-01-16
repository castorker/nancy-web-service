using Data;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class QuibbleModule : NancyModule
    {
        public QuibbleModule()
        {
            Get["/quibbles"] = arguments => GetQuibbles();
            Get["/quibbles/{id}"] = arguments => GetQuibbleById(arguments.id);
        }

        private Quibble[] GetQuibbles()
        {
            var service = new QuibbleDataService();
            return service.GetAll();
        }

        private Quibble GetQuibbleById(int id)
        {
            var service = new QuibbleDataService();
            return service.GetById(id);
        }
    }
}