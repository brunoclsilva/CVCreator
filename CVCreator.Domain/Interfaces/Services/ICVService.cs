using CVCreator.Domain.Entities.Models;

namespace CVCreator.Domain.Interfaces.Services
{
    public interface ICVService
    {
        byte[] GenerateCV(CVPayload payload);
    }
}
