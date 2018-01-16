using ConsoleApplication.Transports;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.DataServices
{
    class QuibbleDataService
    {
        private RestClient _client;

        public QuibbleDataService()
        {
            _client = new RestClient("http://localhost:49161/");
        }

        public Quibble[] GetAll()
        {
            var request = new RestRequest("/quibbles", Method.GET);
            var response = _client.Execute<List<Quibble>>(request);
            return response.Data.ToArray();
        }

        public Quibble GetById(int Id)
        {
            var request = new RestRequest("/quibbles/{id}", Method.GET);
            request.AddUrlSegment("id", Id.ToString());
            var response = _client.Execute<Quibble>(request);
            return response.Data;
        }

        public void Create(Quibble quibble)
        {
            var request = new RestRequest("/quibbles", Method.POST);
            request.AddObject(quibble);
            var response = _client.Execute<Quibble>(request);
            Console.WriteLine("New quibble Id: " + response.Data.Id);
        }

        public void Update(Quibble quibble)
        {
            var request = new RestRequest("/quibbles/{id}", Method.PUT);
            request.AddUrlSegment("id", quibble.Id.ToString());
            request.AddObject(quibble);
            var response = _client.Execute(request);
        }

        public void Delete(int Id)
        {
            var request = new RestRequest("/quibbles/{id}", Method.DELETE);
            request.AddUrlSegment("id", Id.ToString());
            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                Console.WriteLine($"Quibble {Id} has been deleted successfully");
            }
        }
    }
}
