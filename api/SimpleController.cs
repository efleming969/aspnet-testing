using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace api
{
    [ApiController]
    [Route("simple")]
    public class SimpleController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] RequestData requestData)
        {
            Console.WriteLine(requestData);
            return Ok();
        }
    }

    public class RequestData
    {
        [StringLength(5, ErrorMessage = "much too long")]
        public string Name { get; set; }
    }
}