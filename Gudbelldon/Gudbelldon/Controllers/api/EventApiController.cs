using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Gudbelldon.Data;

namespace Gudbelldon.Controllers.api
{
    [RoutePrefix("api")]
    public class EventApiController : ApiController
    {

        [EnableCors(origins:"*", headers:"*", methods:"*")]
        [Route("events")]
        public async Task<IEnumerable<dynamic>> GetAllEvents()
        {
            using (var context = new GudbelldonContext())
            {
                return await context.Events.Select(e => new
                {
                    EventId = e.EventId,
                    Date = e.Date,
                    Start = e.Start,
                    End = e.End,
                    Title = e.Title,
                    Subtitle = e.Subtitle,
                    Description = e.Description
                }).ToListAsync();
            }
        }
    }
}