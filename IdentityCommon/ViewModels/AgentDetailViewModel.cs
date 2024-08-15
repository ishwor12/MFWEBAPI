using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityCommon.ViewModels
{
    public class AgentDetailViewModel
    {
        public string AgentCompanyName { get; set; }
        public int AgentId{ get; set; }
        public List<AgentBranchViewModel> AgentBranchViewModel { get; set; }
    }

    public class AgentBranchViewModel
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
    }
}
