namespace netwise_task.Repositories.Interfaces;

public interface ICatRepository
{
    Task AppendAsync(string content);
}