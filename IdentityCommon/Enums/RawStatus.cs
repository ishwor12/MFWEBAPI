using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCommon.Enums
{
    public enum RawStatus
    {
        Draft = -1,
        New = 0,
        Approved = 1,
        Modified = 2,
        Deleted = 3,
        ApprovedModified = 4,
        NonApproval = 5,
        Rejected = 6,
        RejectedModified = 7,
        ApprovedDeleted = 8
    }

    public enum DisplayStatus
    {
        All = 0,
        ApprovedOnly = 1,
        UnapprovedOnly = 2,
        DeletedOnly = 3,
        MergedOnly = 4,
        RejectedOnly = 5
    }
}
