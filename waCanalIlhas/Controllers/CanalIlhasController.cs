using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace waCanalIlhas.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CanalIlhasController : ControllerBase
    {
        // GET v1/api/CanalIlhas
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "t1", "t2" };
        }
    }
}