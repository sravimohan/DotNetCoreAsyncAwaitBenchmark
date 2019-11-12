using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadFileAsyncController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            return await System.IO.File.ReadAllTextAsync(@"sample.txt").ConfigureAwait(true);
        }
    }
}
