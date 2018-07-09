using System.Collections.Generic;
using react_slingshot_project.Entities;

namespace react_slingshot_project.Services
{
    public interface IMemberInfoRepository
    {
        IEnumerable<Member> GetMembers();

        Member GetMember(int id);
        void AddMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
        bool Save();
    }
}