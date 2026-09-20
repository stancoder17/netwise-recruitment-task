using netwise_task.DTOs;

namespace netwise_task.Clients.Interfaces;

public interface ICatClient
{
    Task<GetCatFactDto?> GetCatFactAsync();
}