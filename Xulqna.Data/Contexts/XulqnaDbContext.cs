﻿using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Xulqna.Domain.Entities.Courses;
using Xulqna.Domain.Entities.Students;
using Xulqna.Domain.Entities.Teachers;

namespace Xulqna.Data.Contexts
{
    public class XulqnaDbContext : DbContext
    {
        public XulqnaDbContext(DbContextOptions<XulqnaDbContext> options)
            : base(options)
        {

        }

        // dbset
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

    }
}
