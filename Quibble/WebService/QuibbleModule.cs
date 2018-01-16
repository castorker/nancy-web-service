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
            Put["/{id}"] = arguments => UpdateQuibble(arguments.id);
            Delete["/{id}"] = arguments => DeleteQuibble(arguments.id);
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

        private Quibble UpdateQuibble(int id)
        {
            var quibble = this.Bind<Quibble>();
            var service = new QuibbleDataService();
            service.Update(quibble);
            return quibble;
        }

        private HttpStatusCode DeleteQuibble(int id)
        {
            var service = new QuibbleDataService();
            service.Delete(id);
            return HttpStatusCode.NoContent;
        }
    }
}