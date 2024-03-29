﻿using CustomCRUDOps.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomCRUDOps.Data
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options) { }

        public DbSet<Employee> Employee { get; set; }
    }
}
