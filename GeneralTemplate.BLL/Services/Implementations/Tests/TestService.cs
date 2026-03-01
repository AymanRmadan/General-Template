using GeneralTemplate.BLL.Commons.ErrorsHandling;

namespace GeneralTemplate.BLL.Services.Implementations.Tests
{
    public class TestService : ITestService
    {
        private readonly IGenericRepository<Test> _repo;

        public TestService(IGenericRepository<Test> repo)
        {
            _repo = repo;
        }

        public async Task<Result<IEnumerable<Test>>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            if (result == null)
                return Result.Failure<IEnumerable<Test>>(TestErrors.InvalidCredentials);

            return Result.Success(result);

        }

    }
}