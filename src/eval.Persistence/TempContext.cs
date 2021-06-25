using Microsoft.EntityFrameworkCore;
using System;

namespace eval.Persistence
{
    public class TempContext: DbContext
    {
        public TempContext(DbContextOptions<TempContext> options): base(options)
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
