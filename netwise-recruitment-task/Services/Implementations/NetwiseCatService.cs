using netwise_recruitment_task.Clients.Interfaces;
using netwise_recruitment_task.Exceptions;
using netwise_recruitment_task.Repositories.Interfaces;
using netwise_recruitment_task.Services.Interfaces;

namespace netwise_recruitment_task.Services.Implementations;

public class NetwiseCatService(ICatClient client, ICatRepository repository) : ICatService
{
    public async Task FetchAndSaveAsync()
    {
        var fact = await client.GetCatFactAsync();
        
        if (fact == null)
        {
            throw new NotFoundException("Cat fact not found.");
        }
        
        await repository.AppendAsync(fact.Fact);
    }
}