using GeneralTemplate.BLL.Services.Abstractions.Tests;
using Microsoft.AspNetCore.Mvc;

namespace GeneralTemplate.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _testService.GetAllAsync());
    }
}
