using Data;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class QuibbleModule : NancyModule
    {
        public QuibbleModule() : base("/quibbles")
        {
            Get["/"] = arguments => GetQuibbles();
            Get["/{id}"] = arguments => GetQuibbleById(arguments.id);
            Post["/"] = arguments => CreateQuibble();
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

        private Quibble CreateQuibble()
        {
            var quibble = this.Bind<Quibble>();
            var service = new QuibbleDataService();
            service.Add(quibble);
            return quibble;
        }
    }
}