using GeneralTemplate.BLL.Commons.ResponseResults;

namespace GeneralTemplate.BLL.Services.Implementations.Tests
{
    public class TestService : ITestService
    {
        private readonly IGenericRepository<Test, int> _repo;

        public TestService(IGenericRepository<Test, int> repo)
        {
            _repo = repo;
        }

        public async Task<Result<IEnumerable<Test>>> GetAllAsync()
        {
            var result = await _repo.GetAsync();
            if (result == null)
                return Result.Failure<IEnumerable<Test>>(TestErrors.InvalidCredentials);

            return Result.Success<IEnumerable<Test>>(result);

        }

    }
}