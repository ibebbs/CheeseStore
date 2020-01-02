using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseStore.Store
{
    [Route("api/store")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Cheese>), (int)HttpStatusCode.OK)]
        public Task<IActionResult> Get()
        {
            var result = new[]
            {
                new Cheese
                {
                    Name = "API Cheese"
                }
            };

            return Task.FromResult<IActionResult>(Ok(result));
        }
    }
}
