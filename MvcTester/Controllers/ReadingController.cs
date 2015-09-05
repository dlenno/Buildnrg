using SensorApi.DAL;
using SensorApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SensorApi.Controllers
{
    public class ReadingController : ApiController
    {
        IRepository repo = new Repository();
        // GET api/temp
        public IEnumerable<Reading> Get()
        {
            var readings = repo.GetReadings();
            return readings;
        }

        // GET api/temp/5
        public string Get(int id)
        {
            return "value";
        }

        
        public HttpResponseMessage PostReading(Reading rd)
        {
            if (ModelState.IsValid)
            {
                repo.InsertReading(rd);
                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, rd);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = rd.ReadingId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/temp/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/temp/5
        public void Delete(int id)
        {
        }
    }
}
