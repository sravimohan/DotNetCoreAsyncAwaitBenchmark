using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadFileController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return System.IO.File.ReadAllText(@"sample.txt");
        }
    }
}
