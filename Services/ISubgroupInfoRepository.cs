using System.Collections.Generic;
using react_slingshot_project.Entities;

namespace react_slingshot_project.Services
{
    public interface ISubgroupInfoRepository
    {
        IEnumerable<Subgroup> GetSubgroups();
        IEnumerable<Member> GetMembers(int id);

        Subgroup GetSubgroup(int id);
        void AddSubgroup(Subgroup subgroup);
        void UpdateSubgroup(Subgroup subgroup);
        void DeleteSubgroup(Subgroup subgroup);
        bool Save();
    }
}