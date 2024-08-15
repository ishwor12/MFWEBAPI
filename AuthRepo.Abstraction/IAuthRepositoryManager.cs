using AuthRepo.Abstraction.User;
using Domain;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthRepo.Abstraction
{
    public interface IAuthRepositoryManager
    {
        Task SaveUserAsync();
        Task<IDbContextTransaction> CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        IPasswordChangeRepo PasswordChange { get; }
    }
}