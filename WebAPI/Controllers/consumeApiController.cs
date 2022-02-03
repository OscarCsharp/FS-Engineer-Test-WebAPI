using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.Extensions;
using WebAPI.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class consumeApiController : ControllerBase
    {
        private readonly IApiConsume _apiConsume;
        public consumeApiController(IApiConsume apiConsume)
        {
            _apiConsume = apiConsume;
        }

        [HttpGet]
        [Route("/chuck")]
        public async Task<ActionResult> categories()
        {
 
            try
            {
                return Ok(await _apiConsume.Jokes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [HttpGet("/{search}")]
        public async Task<ActionResult> categoryDetails([FromQuery] string query)
        {

            try
            {
                List<string> Categories = await _apiConsume.Jokes();
                bool isExist = Categories.find(query);

                if (Categories.Contains(query))
                {
                    return Ok(query + "exist in the categories");
                }
                else
                {
                    var person = await _apiConsume.Person(query);
                    var personResults = person.results;
                    if (personResults.Count == 0)
                    {
                        return Ok("Value Not Found");
                    }
                    else { return Ok(person.results); }
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("/swapi")]
        public async Task<ActionResult> people()
        {

            try
            {
                return Ok(await _apiConsume.getPeople());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


    }
   
}
