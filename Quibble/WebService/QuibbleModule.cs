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
        private QuibbleDataService _service;

        public QuibbleModule() : base("/quibbles")
        {
            _service = new QuibbleDataService();

            Get["/"] = arguments => GetQuibbles();
            Get["/{id}"] = arguments => GetQuibbleById(arguments.id);
            Post["/"] = arguments => CreateQuibble();
            Put["/{id}"] = arguments => UpdateQuibble(arguments.id);
            Delete["/{id}"] = arguments => DeleteQuibble(arguments.id);
        }

        private Quibble[] GetQuibbles()
        {
            return _service.GetAll();
        }

        private Quibble GetQuibbleById(int id)
        {
            return _service.GetById(id);
        }

        private Quibble CreateQuibble()
        {
            var quibble = this.Bind<Quibble>();
            _service.Add(quibble);
            return quibble;
        }

        private Quibble UpdateQuibble(int id)
        {
            var quibble = this.Bind<Quibble>();
            _service.Update(quibble);
            return quibble;
        }

        private HttpStatusCode DeleteQuibble(int id)
        {
            _service.Delete(id);
            return HttpStatusCode.NoContent;
        }
    }
}