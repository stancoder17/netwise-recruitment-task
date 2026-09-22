namespace netwise_recruitment_task.Repositories.Interfaces;

public interface ICatRepository
{
    Task AppendAsync(string content);
}