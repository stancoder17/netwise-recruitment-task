using netwise_task.Clients.Interfaces;
using netwise_task.DTOs;

namespace netwise_task.Clients.Implementations;

public class NetwiseCatClient(HttpClient httpClient) : ICatClient
{
    public async Task<GetCatFactDto?> GetCatFactAsync()
    {
        return await httpClient.GetFromJsonAsync<GetCatFactDto>("fact");
    }
}