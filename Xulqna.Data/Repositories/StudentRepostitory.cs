
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
