using Kaizen.CaseStudy.WebAPI.Bill;
using Microsoft.AspNetCore.Mvc;

namespace Kaizen.CaseStudy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;

        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetDetails")]
        public string GetDetails()
        {
            return BillParser.ParseResponseFile();
        }
    }
}