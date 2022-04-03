using Xulqna.Data.Contexts;
using Xulqna.Data.IRepositories;
using Xulqna.Domain.Entities.Students;

namespace Xulqna.Data.Repositories
{
    public class StudentRepostitory : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepostitory(XulqnaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
