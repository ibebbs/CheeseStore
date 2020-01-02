using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseStore.Inventory
{
    [Route("api/inventory")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(uint), (int)HttpStatusCode.OK)]
        public Task<IActionResult> Get(Guid id)
        {
            return Task.FromResult<IActionResult>(Ok(0));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        public Task<IActionResult> Post([FromBody] Request request)
        {
            var response = new Response 
            { 
                Available = request.Ids.Select(id => new Available { Id = id, Quantity = 0 }) 
            };
            
            return Task.FromResult<IActionResult>(Ok(response));
        }
    }
}
