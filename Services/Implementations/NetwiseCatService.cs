using netwise_task.Clients.Interfaces;
using netwise_task.Exceptions;
using netwise_task.Repositories.Interfaces;
using netwise_task.Services.Interfaces;

namespace netwise_task.Services.Implementations;

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