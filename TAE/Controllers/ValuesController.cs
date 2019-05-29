using System.Xml.Xsl;
using Microsoft.AspNetCore.Mvc;

namespace TAE.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            // Load the style sheet.
            var xslt = new XslCompiledTransform();
            xslt.Load("JSON\\Resources\\customers.xsl");

            // Execute the transform and output the results to a file.
            xslt.Transform("JSON\\Resources\\customers.xml", $"JSON\\Resources\\customers.json");

            // Load books.html in a string variable
            var res = System.IO.File.ReadAllText("JSON\\Resources\\customers.json");

            return Json(res);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
