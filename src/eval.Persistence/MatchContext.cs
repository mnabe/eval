﻿using Microsoft.EntityFrameworkCore;

namespace eval.Persistence
{
    public class MatchContext: DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options): base(options)
        {
        }

        public virtual DbSet<MatchEntity> MatchEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MatchEntity>()
                .HasKey(c => c.Id);
        }
    }
}
