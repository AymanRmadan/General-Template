using GeneralTemplate.BLL.Commons.ResponseResults;

namespace GeneralTemplate.BLL.Services.Abstractions.Tests
{
    public interface ITestService
    {
        Task<Result<IEnumerable<Test>>> GetAllAsync();
    }
}