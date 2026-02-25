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
        {
            var result = await _testService.GetAllAsync();
            //return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
            return result.IsSuccess ? Ok(result.Value)
                : Problem(statusCode: StatusCodes.Status400BadRequest, title: result.Error.Code, detail: result.Error.Description);
        }

    }
}
