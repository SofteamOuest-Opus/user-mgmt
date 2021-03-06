﻿using Microsoft.EntityFrameworkCore;
using UserMgmtContext.Model;

namespace UserMgmtContext
{
    public class UserMgmtContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public UserMgmtContext(DbContextOptions<UserMgmtContext> options) : base(options)
        { }
    }
}
