using Xulqna.Data.Contexts;
using Xulqna.Data.IRepositories;
using Xulqna.Domain.Entities.Groups;

namespace Xulqna.Data.Repositories
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(XulqnaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
