using netwise_recruitment_task.Clients.Interfaces;
using netwise_recruitment_task.DTOs;

namespace netwise_recruitment_task.Clients.Implementations;

public class NetwiseCatClient(HttpClient httpClient) : ICatClient
{
    public async Task<GetCatFactDto?> GetCatFactAsync()
    {
        return await httpClient.GetFromJsonAsync<GetCatFactDto>("fact");
    }
}