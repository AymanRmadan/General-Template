
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
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

    }
}
