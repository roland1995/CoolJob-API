using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoolJobAPI.Models;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace CoolJobAPI.Controllers
{
    [EnableCors("Access-Control-Allow-Origin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly JobContext _context;

        public FilterController(JobContext context)
        {
            _context = context;
        }

        // GET: api/filter/Type/Contract/1
        [Route("{filterBy}/{filterValue}/{page}")]
        [HttpGet("{filterBy}/{filterValue}/{page}")]
        public ActionResult<IEnumerable<Job>> GetFilteredJobs(string filterBy, string filterValue, int page)
        {
            return _context.GetFilteredJobs(filterBy, filterValue, page);
        }

        // GET: api/filter/Type
        [Route("{filterBy}")]
        [HttpGet("{filterBy}")]
        public ActionResult<IEnumerable<string>> GetFilterValuesByFilterType(string filterBy)
        {
            return _context.GetSpecificFilterValuesByFilterType(filterBy);
        }
    }
}
