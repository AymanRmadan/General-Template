namespace GeneralTemplate.BLL.Services.Implementations.Tests
{
    public class TestService : ITestService
    {
        private readonly IGenericRepository<Test> _repo;

        public TestService(IGenericRepository<Test> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
            => await _repo.GetAllAsync();
    }
}