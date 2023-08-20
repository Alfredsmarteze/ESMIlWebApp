using DataStructure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IGeneralMemberRepository
    {
        Task<bool> AddOrUpdateGeneralMember(GeneralMemberData generalMemberData);
        IQueryable<GeneralMemberDTO> ListAllGeneralMember();
    }
}
