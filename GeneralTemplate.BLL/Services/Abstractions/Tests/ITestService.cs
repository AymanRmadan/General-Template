namespace GeneralTemplate.BLL.Services.Abstractions.Tests
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetAllAsync();
    }
}