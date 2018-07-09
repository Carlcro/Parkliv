using System.Collections.Generic;
using System.Linq;
using react_slingshot_project.Entities;

namespace react_slingshot_project.Services
{
    public class SubgroupInfoRepository : ISubgroupInfoRepository
    {
        private MemberInfoContext _context;
        public SubgroupInfoRepository(MemberInfoContext context)
        {
            _context = context;

        }

        public void AddSubgroup(Subgroup subgroup)
        {
            _context.Add(subgroup);
        }

        public void UpdateSubgroup(Subgroup subgroup)
        {
            _context.Update(subgroup);
        }

        public void DeleteSubgroup(Subgroup subgroup)
        {
            _context.Subgroups.Remove(subgroup);
        }

        public Subgroup GetSubgroup(int id)
        {
            return _context.Subgroups.SingleOrDefault(x => x.id == id);
        }

        public IEnumerable<Subgroup> GetSubgroups()
        {
            return _context.Subgroups.OrderBy(c => c.groupName).ToList();
        }

        public IEnumerable<Member> GetMembers(int id)
        {
            return _context.Subgroups
                    .SingleOrDefault(x => x.id == id)
                    .Members.OrderBy(x => x.fname).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}