using netwise_recruitment_task.DTOs;

namespace netwise_recruitment_task.Clients.Interfaces;

public interface ICatClient
{
    Task<GetCatFactDto?> GetCatFactAsync();
}