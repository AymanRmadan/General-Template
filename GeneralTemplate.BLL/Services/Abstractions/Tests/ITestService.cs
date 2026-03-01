using GeneralTemplate.BLL.Commons.ErrorsHandling;

namespace GeneralTemplate.BLL.Services.Abstractions.Tests
{
    public interface ITestService
    {
        Task<Result<IEnumerable<Test>>> GetAllAsync();
    }
}