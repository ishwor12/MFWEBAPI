using Domain.Entities.User;
using IdentityCommon.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthRepo.Abstraction.User
{
    public interface IPasswordChangeRepo : IAuthGenericRepo<UserPasswordChangedHistory>
    {
        Task<IEnumerable<UserPasswordChangedHistory>> GetPasswordHist(ApplicationUser applicationUser);
        Task<UserPasswordChangedHistory> GetLatestPasswordChangeHist(ApplicationUser applicationUser);
        Task<DataResult> ResetPasswordByLink(ApplicationUser applicationUser, string code, string newPassword, UserPasswordChangedHistory newUserPasswordChangedHistory);
    }
}
