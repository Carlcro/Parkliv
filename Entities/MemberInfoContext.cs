using Microsoft.EntityFrameworkCore;

namespace react_slingshot_project.Entities
{
    public class MemberInfoContext:DbContext
    {
        public MemberInfoContext(DbContextOptions<MemberInfoContext> options)
        :base(options)
        {
            Database.Migrate();
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subgroup> Subgroups { get; set; }
    }
}