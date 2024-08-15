using AuthRepo.Abstraction;
using AuthRepo.Abstraction.User;
using AuthRepository.User;
using Domain;
using Domain.Entities.Global;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthRepository
{
    public class AuthRepositoryManager : IAuthRepositoryManager
    {
        private readonly UserDbContext _userContext;
        protected readonly UserManager<ApplicationUser> _userManager;
        private IDbContextTransaction _objTran;

        public AuthRepositoryManager(UserDbContext userDbContext, UserManager<ApplicationUser> userManager)
        {
            _userContext = userDbContext;
            _userManager = userManager;
        }

        public async Task SaveUserAsync()
        {
            await _userContext.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> CreateTransactionAsync()
        {
            _objTran = await _userContext.Database.BeginTransactionAsync();
            return _objTran;
        }
        public async Task RollbackAsync()
        {
            await _objTran.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            await _objTran.CommitAsync();
        }

        private readonly IPasswordChangeRepo _passwordChange;

        public IPasswordChangeRepo PasswordChange
        {
            get
            {
                return _passwordChange ?? new PasswordChangeRepo(_userContext, _userManager);
            }
        }
    }
}