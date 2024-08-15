using AuthRepo.Abstraction.User;
using Domain;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IdentityCommon.Results;

namespace AuthRepository.User
{
    public class PasswordChangeRepo : AuthGenericRepo<UserPasswordChangedHistory>, IPasswordChangeRepo
    {
        public PasswordChangeRepo(UserDbContext context, UserManager<ApplicationUser> userManager) : base(context, userManager)
        {
        }

        public async Task<IEnumerable<UserPasswordChangedHistory>> GetPasswordHist(ApplicationUser applicationUser)
        {
            return await _userContext.UserPasswordChangedHistory.Where(x => x.UserId == applicationUser.Id).OrderByDescending(x => x.StatusChangeDate).ToListAsync();
        }

        public async Task<UserPasswordChangedHistory> GetLatestPasswordChangeHist(ApplicationUser applicationUser)
        {
            return await _userContext.UserPasswordChangedHistory.Where(x => x.UserId == applicationUser.Id).OrderByDescending(x => x.StatusChangeDate).FirstOrDefaultAsync();
        }

        public async Task<DataResult> ResetPasswordByLink(ApplicationUser applicationUser, string code, string newPassword, UserPasswordChangedHistory newUserPasswordHist)
        {
            DataResult result;
            using (IDbContextTransaction dbContextTransaction = _userContext.Database.BeginTransaction())
            {
                try
                {
                    IdentityResult identityResult = await _userManager.ResetPasswordAsync(applicationUser, code, newPassword);
                    if (identityResult.Succeeded is true)
                    {
                        newUserPasswordHist.LastChangedPassword = applicationUser.PasswordHash;
                        _userContext.UserPasswordChangedHistory.Add(newUserPasswordHist);
                        await _userContext.SaveChangesAsync();
                        dbContextTransaction.Commit();
                        result = new DataResult { Success = true, Message = "Successfully Updated." };
                    }
                    else
                    {
                        result = new DataResult
                        {
                            Success = false,
                            Message = string.Join(",", identityResult.Errors.Select(x => x.Description))
                        };
                    }
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    result = new DataResult { Success = false, Message = ex.Message };
                }
            }
            return result;
        }
    }
}
