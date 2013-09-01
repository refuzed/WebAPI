using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    public class DummyController : ApiController
    {
        private static readonly IDummyRepository repository = new DummyRepository();

        public IEnumerable<Dummy> Get()
        {
            return repository.GetAll();
        }

        public Dummy Get(Guid id)
        {
            return repository.Get(id);
        }

        public HttpResponseMessage Post([FromBody]Dummy value)
        {
            value = repository.Add(value);
            var response = Request.CreateResponse<Dummy>(HttpStatusCode.Created, value);

            string uri = Url.Link("DefaultApi", new { id = value.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(Guid id, [FromBody]Dummy value)
        {
            value.Id = id;
            if(!repository.Update(value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }

        public void Delete(Guid id)
        {
            if (!repository.Delete(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}