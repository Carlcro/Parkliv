using System.Collections.Generic;
using System.Linq;
using react_slingshot_project.Entities;

namespace react_slingshot_project.Services
{
    public class MemberInfoRepository : IMemberInfoRepository
    {
        private MemberInfoContext _context;
        public MemberInfoRepository(MemberInfoContext context)
        {
            _context = context;

        }

        public void AddMember(Member member)
        {
            _context.Add(member);
        }

        public void UpdateMember(Member member)
        {
            _context.Update(member);
        }

        public void DeleteMember(Member member)
        {
            _context.Members.Remove(member);
        }

        public Member GetMember(int id)
        {
            return _context.Members.SingleOrDefault(c => c.id == id);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _context.Members.OrderBy(c => c.fname).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


    }
}