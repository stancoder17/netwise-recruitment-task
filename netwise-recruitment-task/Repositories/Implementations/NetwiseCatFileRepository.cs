using netwise_recruitment_task.Repositories.Interfaces;

namespace netwise_recruitment_task.Repositories.Implementations;

public class NetwiseCatFileRepository(IConfiguration configuration) : ICatRepository
{
    private readonly string _filePath = configuration["CatApiSettings:FilePath"] ?? throw new InvalidOperationException("File path is not set.");

    public async Task AppendAsync(string content)
    {
        await File.AppendAllTextAsync(_filePath, content + Environment.NewLine);
    }
}