﻿using Microsoft.EntityFrameworkCore;
using RealState.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealState.Services
{
    public class RealStateDbContext: DbContext
    {
        public RealStateDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PropertyItem> PropertyItems { get; set; }
    }
}
